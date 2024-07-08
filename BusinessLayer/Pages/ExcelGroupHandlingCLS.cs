using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using DevExpress.Compression;
using DevExpress.Spreadsheet;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using System.Security.Cryptography;

namespace BusinessLayer.Pages
{
    public class ExcelGroupHandlingCLS
    {
        public Tuple<bool, string> GenerateXlsBySampleID(long SampleID)
        {
            try
            {
                SampleReceiveListDB sampleReceiveListDB = new SampleReceiveListDB();
                SampleReceiveList sampleReceive = sampleReceiveListDB.GetByID(SampleID);

                SampleReceiveTestListDB sampleReceiveTestListDB = new SampleReceiveTestListDB();
                List<SampleReceiveTestList> byMasterID = sampleReceiveTestListDB.GetByMasterID(SampleID);
                DataTable sampleFieldsBySampleID = sampleReceiveTestListDB.GetSampleFieldsBySampleID(SampleID);
                string destinationPath = System.Configuration.ConfigurationManager.AppSettings["SampleFilePath"];

                List<MaterialsDetailsTests> materialsDetailsTests = new List<MaterialsDetailsTests>();
                foreach (SampleReceiveTestList item in byMasterID)
                {
                    TestsList testsList = item.TestsList;
                    if (testsList == null)
                        continue;

                    List<MaterialsDetailsTests> materialsDetails = testsList.MaterialsDetailsTests.Where(m => m.FKMaterialDetailsID == sampleReceive.FKMaterialDetailsID).ToList();
                    List<int?> groups = materialsDetails.Where(md => md.FKGroupID != null).Select(m => m.FKGroupID).ToList();
                    if (groups.Count > 0)
                        item.FKGroupID = groups.FirstOrDefault();
                }

                foreach (SampleReceiveTestList item in byMasterID)
                {
                    TestsList testsList = item.TestsList;
                    if (testsList == null)
                        continue;

                    int matchedCount = 0;
                    if (item.FKGroupID != null)
                        matchedCount = byMasterID.Where(s => s.FKGroupID == item.FKGroupID).Count();

                    if (matchedCount > 1)
                    {
                        List<MaterialsDetailsTests> materialsDetails = testsList.MaterialsDetailsTests.Where(m => m.FKMaterialDetailsID == sampleReceive.FKMaterialDetailsID).ToList();
                        List<int?> groups = materialsDetails.Where(md => md.FKGroupID != null).Select(m => m.FKGroupID).ToList();
                        materialsDetailsTests.AddRange(materialsDetails);
                    }
                    else
                        CreateTestExcel(sampleReceive, sampleFieldsBySampleID, item, destinationPath);
                }

                foreach (ReportGroup reportGroup in materialsDetailsTests.Where(md => md.FKGroupID != null).Select(m => m.ReportGroup).Distinct())
                {
                    if (reportGroup.ReportGroupExcelMappings == null)
                        continue;

                    List<ReportGroupExcelMapping> source = reportGroup.ReportGroupExcelMappings.ToList();
                    if (source.Count == 0)
                        continue;

                    SampleReceiveTestList item = byMasterID.Where(s => s.FKTestID == s.TestsList.MaterialsDetailsTests.Where(m => m.FKMaterialDetailsID == sampleReceive.FKMaterialDetailsID && m.FKGroupID == reportGroup.GroupID).Select(m => m.FKTestID).FirstOrDefault()).FirstOrDefault();

                    string sourceFile = "";
                    string destinationFileName = "";

                    if (!string.IsNullOrWhiteSpace(reportGroup.WorkFormFileName) && !string.IsNullOrWhiteSpace(reportGroup.WorkFormWorksheet))
                    {
                        sourceFile = HttpContext.Current.Server.MapPath("~/Uploaded/ReportGroupInfo/" + reportGroup.WorkFormFileName);
                        if (File.Exists(sourceFile))
                        {
                            destinationFileName = string.Format(@"{0}\{1}\{2}-{3}{4}", destinationPath, sampleReceive.SampleNo, item.ReportNumber, "WR", Path.GetExtension(reportGroup.WorkFormFileName));
                            FileInfo dest = new FileInfo(destinationFileName);
                            Workbook workFile = new Workbook();
                            if (Path.GetExtension(sourceFile).ToLower().Equals(".xlsm"))
                                workFile.LoadDocument(sourceFile, DocumentFormat.Xlsm);
                            else
                                workFile.LoadDocument(sourceFile, DocumentFormat.Xlsx);

                            Worksheet newWorkFileSheet = workFile.Worksheets[reportGroup.WorkFormWorksheet];
                            foreach (ReportGroupExcelMapping item2 in source.Where((ReportGroupExcelMapping x) => !x.IsForReport).ToList())
                            {
                                try
                                {
                                    if (string.IsNullOrWhiteSpace(item2.ExcelCell))
                                        continue;

                                    if (item2.FieldName.ToLower() == "report number")
                                        newWorkFileSheet.Cells[item2.ExcelCell].SetValue(item.ReportNumber);
                                    else if (item2.FieldName.ToLower() == "witness name")
                                        newWorkFileSheet.Cells[item2.ExcelCell].SetValue(item.WitnessName);
                                    else if (item2.FieldName.ToLower() == "remarks")
                                        newWorkFileSheet.Cells[item2.ExcelCell].SetValue(item.Remarks);
                                    else if (item2.FieldName.ToLower() == "receive date" || item2.FieldName.ToLower() == "sampling date"
                                         || item2.FieldName.ToLower() == "sample brought in date")
                                    {
                                        if (sampleFieldsBySampleID.Rows[0][item2.FieldName] != null)
                                        {
                                            string date = sampleFieldsBySampleID.Rows[0][item2.FieldName].ToString();
                                            if (!string.IsNullOrWhiteSpace(date))
                                            {
                                                DateTime dt;
                                                if (DateTime.TryParse(date, out dt))
                                                {
                                                    string val = dt.ToString("dd/MMM/yyyy").Replace("-", "/");
                                                    newWorkFileSheet.Cells[item2.ExcelCell].SetValue(val);
                                                }
                                            }
                                        }
                                    }
                                    else
                                        newWorkFileSheet.Cells[item2.ExcelCell].SetValue(sampleFieldsBySampleID.Rows[0][item2.FieldName].ToString());
                                }
                                catch (Exception ex)
                                {
                                    System.Diagnostics.Debug.Assert(false);
                                }
                            }

                            if (!dest.Directory.Exists)
                                dest.Directory.Create();

                            if (Path.GetExtension(sourceFile).ToLower().Equals(".xlsm"))
                                workFile.SaveDocument(dest.FullName, DocumentFormat.Xlsm);
                            else
                                workFile.SaveDocument(dest.FullName, DocumentFormat.Xlsx);
                        }
                    }

                    if (!string.IsNullOrWhiteSpace(reportGroup.ReportFileName) && !string.IsNullOrWhiteSpace(reportGroup.ReportWorksheet))
                    {
                        sourceFile = HttpContext.Current.Server.MapPath("~/Uploaded/ReportGroupInfo/" + reportGroup.ReportFileName);
                        if (File.Exists(sourceFile))
                        {
                            destinationFileName = string.Format(@"{0}\{1}\{2}{3}", destinationPath, sampleReceive.SampleNo, item.ReportNumber, Path.GetExtension(reportGroup.ReportFileName));

                            FileInfo dest = new FileInfo(destinationFileName);
                            using (Workbook reportFile = new Workbook())
                            {

                                if (Path.GetExtension(sourceFile).ToLower().Equals(".xlsm"))
                                    reportFile.LoadDocument(sourceFile, DocumentFormat.Xlsm);
                                else
                                    reportFile.LoadDocument(sourceFile, DocumentFormat.Xlsx);

                                Worksheet newReportFileSheet = reportFile.Worksheets[reportGroup.ReportWorksheet];
                                foreach (ReportGroupExcelMapping item3 in source.Where((ReportGroupExcelMapping x) => x.IsForReport).ToList())
                                {
                                    try
                                    {
                                        if (string.IsNullOrWhiteSpace(item3.ExcelCell))
                                            continue;

                                        if (item3.FieldName.ToLower() == "report number")
                                            newReportFileSheet.Cells[item3.ExcelCell].SetValue(item.ReportNumber);
                                        else if (item3.FieldName.ToLower() == "witness name")
                                            newReportFileSheet.Cells[item3.ExcelCell].SetValue(item.WitnessName);
                                        else if (item3.FieldName.ToLower() == "remarks")
                                            newReportFileSheet.Cells[item3.ExcelCell].SetValue(item.Remarks);
                                        else if (item3.FieldName.ToLower() == "receive date" || item3.FieldName.ToLower() == "sampling date"
                                             || item3.FieldName.ToLower() == "sample brought in date")
                                        {
                                            if (sampleFieldsBySampleID.Rows[0][item3.FieldName] != null)
                                            {
                                                string date = sampleFieldsBySampleID.Rows[0][item3.FieldName].ToString();
                                                if (!string.IsNullOrWhiteSpace(date))
                                                {
                                                    DateTime dt;
                                                    if (DateTime.TryParse(date, out dt))
                                                    {
                                                        string val = dt.ToString("dd/MMM/yyyy").Replace("-", "/");
                                                        newReportFileSheet.Cells[item3.ExcelCell].SetValue(val);
                                                    }
                                                }
                                            }
                                        }
                                        else
                                            newReportFileSheet.Cells[item3.ExcelCell].SetValue(sampleFieldsBySampleID.Rows[0][item3.FieldName].ToString());

                                    }
                                    catch (Exception ex)
                                    {
                                        System.Diagnostics.Debug.Assert(false);
                                    }
                                }

                                if (!dest.Directory.Exists)
                                    dest.Directory.Create();

                                if (dest.Exists)
                                {
                                    using (Workbook saveReportFile = new Workbook())
                                    {
                                        saveReportFile.LoadDocument(dest.FullName);
                                        if (saveReportFile.Worksheets.Contains(reportGroup.ReportWorksheet))
                                        {
                                            Worksheet existingSheet = saveReportFile.Worksheets[reportGroup.ReportWorksheet];
                                            existingSheet = newReportFileSheet;
                                        }
                                        else
                                        {
                                            saveReportFile.Worksheets.Add(reportGroup.ReportWorksheet);
                                        }

                                        if (Path.GetExtension(dest.FullName).ToLower().Equals(".xlsm"))
                                        {
                                            saveReportFile.SaveDocument(dest.FullName, DocumentFormat.Xlsm);
                                        }
                                        else
                                        {

                                            saveReportFile.SaveDocument(dest.FullName, DocumentFormat.Xlsx);

                                        }
                                    }
                                    GenerateWSBySampleID(dest.FullName);

                                }
                                else
                                {
                                    if (Path.GetExtension(dest.FullName).ToLower().Equals(".xlsm"))
                                    {
                                        reportFile.SaveDocument(dest.FullName, DocumentFormat.Xlsm);
                                    }
                                    else
                                    {
                                        reportFile.SaveDocument(dest.FullName, DocumentFormat.Xlsx);
                                    }
                                }
                            }
                            GenerateWSBySampleID(dest.FullName);

                        }
                    }
                }

                return new Tuple<bool, string>(true, "");
            }
            catch (Exception ex)
            {
                return new Tuple<bool, string>(false, ex.Message);
            }
        }
        public void GenerateWSBySampleID(string sourceFileName)
        {


            FileInfo sourcefile = new FileInfo(sourceFileName);
            string destinationPath = System.Configuration.ConfigurationManager.AppSettings["SampleFilePath"];
            string destinationFileName = string.Format(@"{0}\{1}\{2}", Path.GetDirectoryName(sourceFileName), "WorkSheet", "WS-" + Path.GetFileNameWithoutExtension(sourceFileName) + ".pdf");


            FileInfo file = new FileInfo(destinationFileName);
            if (!file.Directory.Exists)
                file.Directory.Create();

            string copiedExcelPath = Path.Combine(Path.GetDirectoryName(sourceFileName), Guid.NewGuid().ToString().Replace("-", "") + Path.GetFileName(sourceFileName));
            File.Copy(sourceFileName, copiedExcelPath, true);


            ExportUsingSpire(copiedExcelPath, destinationFileName);




        }



        [MethodImpl(MethodImplOptions.NoOptimization)]
        [DebuggerStepThrough]
        private void ExportUsingSpire(string copiedExcelPath, string newFilePath)
        {                     
            string ext = Path.GetExtension(copiedExcelPath);
            if (ext == ".xlsm")
            {
                ExportUsingSpireXlsm(copiedExcelPath, newFilePath);
            }
            else
            {

                if (ext.Contains("xls"))
                {
                    Spire.Xls.Workbook workbook = new Spire.Xls.Workbook();
                    workbook.LoadFromFile(copiedExcelPath);
                    Spire.Xls.Workbook newWorkbook = new Spire.Xls.Workbook();

                    foreach (Spire.Xls.Worksheet ws in workbook.Worksheets)
                    {
                        if (ws.Name.Contains("Lab WS") || ws.Name.Contains("TW"))
                        {

                            Spire.Xls.Worksheet copiedSheet = newWorkbook.Worksheets.AddCopy(ws);
                            copiedSheet.Name = "WS" + ws.Index.ToString();
                            copiedSheet.PageSetup.FitToPagesWide = 1;
                        }
                    }
                    if (File.Exists(newFilePath))
                    {
                        File.Delete(newFilePath);
                    }
                    newWorkbook.SaveToFile(newFilePath, Spire.Xls.FileFormat.PDF);
                    workbook.Dispose();
                    newWorkbook.Dispose();
                    File.Delete(copiedExcelPath);
                }
              

            }




        }

        private bool ExportUsingSpireXlsm(string copiedExcelPath, string newFilePath)
        {
            try
            {

                Spire.Xls.Workbook workbook = new Spire.Xls.Workbook();
                workbook.LoadFromFile(copiedExcelPath);

                Spire.Xls.Workbook loginWorkbook = new Spire.Xls.Workbook();

                foreach (Spire.Xls.Worksheet ws in workbook.Worksheets)
                {
                    if (ws.Name.Contains("Log in"))
                    {
                        Spire.Xls.Worksheet copiedSheet = loginWorkbook.Worksheets.AddCopy(ws);
                        copiedSheet.Name = "LogIn";

                    }
                }

                string loginShtName = "LogIn"; 

                Spire.Xls.Worksheet loginSht = loginWorkbook.Worksheets[loginShtName];
                int noofShtRPT = 0;
                bool isSingle = true;
                if (int.TryParse(loginSht.Range["H11"].Value, out noofShtRPT))
                {
                    isSingle = false;
                }
                string[] sheetNames = new string[noofShtRPT];

                for (int i = 0; i < noofShtRPT; i++)
                {
                    sheetNames[i] = "LWS" + (i + 1);
                }

                Spire.Xls.Workbook newWorkbook = new Spire.Xls.Workbook();

                foreach (Spire.Xls.Worksheet ws in workbook.Worksheets)
                {
                    if (Array.Exists(sheetNames, sheet => sheet == ws.CodeName) && isSingle == false)
                    {
                        Spire.Xls.Worksheet copiedSheet = newWorkbook.Worksheets.AddCopy(ws);
                        copiedSheet.Name = "WS" + ws.Index.ToString();
                        copiedSheet.PageSetup.FitToPagesWide = 1;
                    }
                    else
                    {
                        if (ws.Name.Contains("Lab WS") && isSingle == true)
                        {
                            Spire.Xls.Worksheet copiedSheet = newWorkbook.Worksheets.AddCopy(ws);
                            copiedSheet.Name = "Lab WS" + ws.Index.ToString();
                            copiedSheet.PageSetup.FitToPagesWide = 1;
                        }
                    }
                }
                if (File.Exists(newFilePath))
                {
                    File.Delete(newFilePath);
                }

                newWorkbook.SaveToFile(newFilePath, Spire.Xls.FileFormat.PDF);
                loginWorkbook.Dispose();
                workbook.Dispose();
                newWorkbook.Dispose();
                File.Delete(copiedExcelPath);



            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }

            // Delete the copied Excel file
            File.Delete(copiedExcelPath);

            return true;
        }


        private void CreateTestExcel(SampleReceiveList sampleReceive, DataTable sampleFieldsBySampleID, SampleReceiveTestList item, string destinationPath)
        {
            TestsList testsList = item.TestsList;
            if (testsList == null || testsList.TestExcelMappings == null || testsList.IsReporting == null || testsList.IsReporting == false)
                return;

            List<TestExcelMapping> source = testsList.TestExcelMappings.ToList();
            if (source.Count == 0)
                return;

            string sourceFile = "";
            string destinationFileName = "";

            if (!string.IsNullOrWhiteSpace(testsList.WorkFormFileName) && !string.IsNullOrWhiteSpace(testsList.WorkFormWorksheet))
            {
                sourceFile = HttpContext.Current.Server.MapPath("~/Uploaded/LabTestInfo/" + testsList.WorkFormFileName);
                if (File.Exists(sourceFile))
                {
                    //if (Path.GetExtension(testsList.WorkFormFileName).ToLower().Equals(".xlsm"))
                    //    destinationFileName = string.Format(@"{0}\{1}\{2}-{3}{4}", destinationPath, sampleReceive.SampleNo, item.ReportNumber, "WR", ".xlsx");
                    //else
                    destinationFileName = string.Format(@"{0}\{1}\{2}-{3}{4}", destinationPath, sampleReceive.SampleNo, item.ReportNumber, "WR", Path.GetExtension(testsList.WorkFormFileName)); //testsList.WorkFormFileName.Insert(testsList.WorkFormFileName.LastIndexOf('.'), "_" + item.SampleReceiveList.JobOrderMaster.LPONumber + "_" + item.SampleReceiveList.SampleNo);
                    FileInfo dest = new FileInfo(destinationFileName);
                    Workbook workFile = new Workbook();
                    if (Path.GetExtension(sourceFile).ToLower().Equals(".xlsm"))
                        workFile.LoadDocument(sourceFile, DocumentFormat.Xlsm);
                    else
                        workFile.LoadDocument(sourceFile, DocumentFormat.Xlsx);
                    //workFile.Worksheets[testsList.WorkFormWorksheet].Unprotect("admin");
                    Worksheet newWorkFileSheet = workFile.Worksheets[testsList.WorkFormWorksheet];
                    foreach (TestExcelMapping item2 in source.Where((TestExcelMapping x) => !x.IsForReport).ToList())
                    {
                        try
                        {
                            if (string.IsNullOrWhiteSpace(item2.ExcelCell))
                                continue;

                            if (item2.FieldName.ToLower() == "report number")
                                newWorkFileSheet.Cells[item2.ExcelCell].SetValue(item.ReportNumber);
                            else if (item2.FieldName.ToLower() == "witness name")
                                newWorkFileSheet.Cells[item2.ExcelCell].SetValue(item.WitnessName);
                            else if (item2.FieldName.ToLower() == "remarks")
                                newWorkFileSheet.Cells[item2.ExcelCell].SetValue(item.Remarks);
                            else if (item2.FieldName.ToLower() == "receive date" || item2.FieldName.ToLower() == "sampling date"
                                 || item2.FieldName.ToLower() == "sample brought in date")
                            {
                                if (sampleFieldsBySampleID.Rows[0][item2.FieldName] != null)
                                {
                                    string date = sampleFieldsBySampleID.Rows[0][item2.FieldName].ToString();
                                    if (!string.IsNullOrWhiteSpace(date))
                                    {
                                        DateTime dt;
                                        if (DateTime.TryParse(date, out dt))
                                        {
                                            string val = dt.ToString("dd/MMM/yyyy").Replace("-", "/");
                                            newWorkFileSheet.Cells[item2.ExcelCell].SetValue(val);
                                        }
                                    }
                                }
                            }
                            else
                                newWorkFileSheet.Cells[item2.ExcelCell].SetValue(sampleFieldsBySampleID.Rows[0][item2.FieldName].ToString());
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.Assert(false);
                        }
                    }

                    if (!dest.Directory.Exists)
                        dest.Directory.Create();

                    if (Path.GetExtension(sourceFile).ToLower().Equals(".xlsm"))
                        workFile.SaveDocument(dest.FullName, DocumentFormat.Xlsm);
                    else
                        workFile.SaveDocument(dest.FullName, DocumentFormat.Xlsx);
                }
            }

            if (!string.IsNullOrWhiteSpace(testsList.ReportFileName) && !string.IsNullOrWhiteSpace(testsList.ReportWorksheet))
            {
                sourceFile = HttpContext.Current.Server.MapPath("~/Uploaded/LabTestInfo/" + testsList.ReportFileName);
                if (File.Exists(sourceFile))
                {
                    Workbook reportFile = new Workbook();
                    destinationFileName = string.Format(@"{0}\{1}\{2}{3}", destinationPath, sampleReceive.SampleNo, item.ReportNumber, Path.GetExtension(testsList.ReportFileName)); //testsList.ReportFileName.Insert(testsList.ReportFileName.LastIndexOf('.'), "_" + item.SampleReceiveList.JobOrderMaster.LPONumber + "_" + item.SampleReceiveList.SampleNo);
                                                                                                                                                                                     //destinationFullName = HttpContext.Current.Server.MapPath("~/SavedDocuments/" + destinationFileName);
                    FileInfo dest = new FileInfo(destinationFileName);
                    if (Path.GetExtension(sourceFile).ToLower().Equals(".xlsm"))
                        reportFile.LoadDocument(sourceFile, DocumentFormat.Xlsm);
                    else
                        reportFile.LoadDocument(sourceFile, DocumentFormat.Xlsx);
                    //reportFile.LoadDocument(sourceFile, DocumentFormat.Xlsx);
                    Worksheet newReportFileSheet = reportFile.Worksheets[testsList.ReportWorksheet];
                    foreach (TestExcelMapping item3 in source.Where((TestExcelMapping x) => x.IsForReport).ToList())
                    {
                        try
                        {
                            if (string.IsNullOrWhiteSpace(item3.ExcelCell))
                                continue;

                            if (item3.FieldName.ToLower() == "report number")
                                newReportFileSheet.Cells[item3.ExcelCell].SetValue(item.ReportNumber);
                            else if (item3.FieldName.ToLower() == "witness name")
                                newReportFileSheet.Cells[item3.ExcelCell].SetValue(item.WitnessName);
                            else if (item3.FieldName.ToLower() == "remarks")
                                newReportFileSheet.Cells[item3.ExcelCell].SetValue(item.Remarks);
                            else if (item3.FieldName.ToLower() == "receive date" || item3.FieldName.ToLower() == "sampling date"
                                 || item3.FieldName.ToLower() == "sample brought in date")
                            {
                                if (sampleFieldsBySampleID.Rows[0][item3.FieldName] != null)
                                {
                                    string date = sampleFieldsBySampleID.Rows[0][item3.FieldName].ToString();
                                    if (!string.IsNullOrWhiteSpace(date))
                                    {
                                        DateTime dt;
                                        if (DateTime.TryParse(date, out dt))
                                        {
                                            string val = dt.ToString("dd/MMM/yyyy").Replace("-", "/");
                                            newReportFileSheet.Cells[item3.ExcelCell].SetValue(val);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                try
                                {
                                    newReportFileSheet.Cells[item3.ExcelCell].SetValue(sampleFieldsBySampleID.Rows[0][item3.FieldName].ToString());
                                }
                                catch (Exception ex)
                                {

                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.Assert(false);
                        }
                    }

                    if (!dest.Directory.Exists)
                        dest.Directory.Create();

                    if (dest.Exists)
                    {
                        Workbook saveReportFile = new Workbook();
                        saveReportFile.LoadDocument(dest.FullName);
                        if (saveReportFile.Worksheets.Contains(testsList.ReportWorksheet))
                        {
                            Worksheet existingSheet = saveReportFile.Worksheets[testsList.ReportWorksheet];
                            existingSheet = newReportFileSheet;
                        }
                        else
                            saveReportFile.Worksheets.Add(testsList.ReportWorksheet);

                        if (Path.GetExtension(dest.FullName).ToLower().Equals(".xlsm"))
                            saveReportFile.SaveDocument(dest.FullName, DocumentFormat.Xlsm);
                        else
                            saveReportFile.SaveDocument(dest.FullName, DocumentFormat.Xlsx);
                        //saveReportFile.SaveDocument(dest.FullName, DocumentFormat.Xlsx);
                        GenerateWSBySampleID(dest.FullName);
                    }
                    else
                    {
                        if (Path.GetExtension(dest.FullName).ToLower().Equals(".xlsm"))
                            reportFile.SaveDocument(dest.FullName, DocumentFormat.Xlsm);
                        else
                            reportFile.SaveDocument(dest.FullName, DocumentFormat.Xlsx);
                        //reportFile.SaveDocument(dest.FullName, DocumentFormat.Xlsx);
                        GenerateWSBySampleID(dest.FullName);
                    }

                }
            }
        }

        //public bool GenerateSingleXlsBySampleID(long SampleID)
        //{
        //	//IL_0043: Unknown result type (might be due to invalid IL or missing references)
        //	//IL_0049: Expected O, but got Unknown
        //	//IL_0049: Unknown result type (might be due to invalid IL or missing references)
        //	//IL_0050: Expected O, but got Unknown
        //	//IL_00da: Unknown result type (might be due to invalid IL or missing references)
        //	//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
        //	//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
        //	//IL_01be: Expected O, but got Unknown
        //	//IL_0248: Unknown result type (might be due to invalid IL or missing references)
        //	//IL_02ee: Unknown result type (might be due to invalid IL or missing references)
        //	//IL_033c: Unknown result type (might be due to invalid IL or missing references)
        //	try
        //	{
        //		SampleReceiveTestListDB sampleReceiveTestListDB = new SampleReceiveTestListDB();
        //		List<SampleReceiveTestList> byMasterID = sampleReceiveTestListDB.GetByMasterID(SampleID);
        //		DataTable sampleFieldsBySampleID = sampleReceiveTestListDB.GetSampleFieldsBySampleID(SampleID);
        //		foreach (SampleReceiveTestList item in byMasterID)
        //		{
        //			TestsList testsList = item.TestsList;
        //			List<TestExcelMapping> source = testsList.TestExcelMapping.ToList();
        //			Workbook val = new Workbook();
        //			Workbook val2 = new Workbook();
        //			string text = HttpContext.Current.Server.MapPath("~/Uploaded/ReportGroupInfo/" + testsList.WorkFormFileName);
        //			string str = testsList.WorkFormFileName.Insert(testsList.WorkFormFileName.LastIndexOf('.'), "_" + item.SampleReceiveList.JobOrderMaster.LPONumber + "_" + item.SampleReceiveList.SampleNo);
        //			string text2 = HttpContext.Current.Server.MapPath("~/SavedDocuments/" + str);
        //			val.LoadDocument(text, DocumentFormat.Xlsx);
        //			Worksheet val3 = val.Worksheets[testsList.WorkFormWorksheet];
        //			foreach (TestExcelMapping item2 in source.Where((TestExcelMapping x) => !x.IsForReport).ToList())
        //			{
        //				val3.Cells[item2.ExcelCell].SetValue(sampleFieldsBySampleID.Rows[0][item2.FieldName].ToString());
        //			}
        //			val2.Worksheets.Add(testsList.WorkFormWorksheet);
        //			val2.Worksheets[testsList.WorkFormWorksheet].CopyFrom(val3);
        //			val.SaveDocument(text2, DocumentFormat.Xlsx);
        //			val = new Workbook();
        //			text = HttpContext.Current.Server.MapPath("~/Uploaded/ReportGroupInfo/" + testsList.ReportFileName);
        //			str = testsList.ReportFileName.Insert(testsList.ReportFileName.LastIndexOf('.'), "_" + item.SampleReceiveList.JobOrderMaster.LPONumber + "_" + item.SampleReceiveList.SampleNo);
        //			text2 = HttpContext.Current.Server.MapPath("~/SavedDocuments/" + str);
        //			val.LoadDocument(text, DocumentFormat.Xlsx);
        //			val3 = val.Worksheets[testsList.ReportWorksheet];
        //			foreach (TestExcelMapping item3 in source.Where((TestExcelMapping x) => x.IsForReport).ToList())
        //			{
        //				val3.Cells[item3.ExcelCell].SetValue(sampleFieldsBySampleID.Rows[0][item3.FieldName].ToString());
        //			}
        //			val.SaveDocument(text2, DocumentFormat.Xlsx);
        //			val2.Worksheets.Add(testsList.ReportWorksheet);
        //			val2.Worksheets[testsList.ReportWorksheet].CopyFrom(val3);
        //			val2.SaveDocument(HttpContext.Current.Server.MapPath("~/SavedDocuments/Output.xlsx"), DocumentFormat.Xlsx);
        //		}
        //		return true;
        //	}
        //	catch (Exception)
        //	{
        //		return false;
        //	}
        //}

        //public string GetReportListPathBySampleID(long SampleID)
        //{
        //	//IL_000e: Unknown result type (might be due to invalid IL or missing references)
        //	//IL_0015: Expected O, but got Unknown
        //	SampleReceiveTestListDB sampleReceiveTestListDB = new SampleReceiveTestListDB();
        //	List<SampleReceiveTestList> byMasterID = sampleReceiveTestListDB.GetByMasterID(SampleID);
        //	ZipArchive val = new ZipArchive();
        //	try
        //	{
        //		foreach (SampleReceiveTestList item in byMasterID)
        //		{
        //			TestsList testsList = item.TestsList;
        //			string str = testsList.WorkFormFileName.Insert(testsList.WorkFormFileName.LastIndexOf('.'), "_" + item.SampleReceiveList.JobOrderMaster.LPONumber + "_" + item.SampleReceiveList.SampleNo);
        //			string text = HttpContext.Current.Server.MapPath("~/SavedDocuments/" + str);
        //			val.AddFile(text, "/");
        //			str = testsList.ReportFileName.Insert(testsList.ReportFileName.LastIndexOf('.'), "_" + item.SampleReceiveList.JobOrderMaster.LPONumber + "_" + item.SampleReceiveList.SampleNo);
        //			text = HttpContext.Current.Server.MapPath("~/SavedDocuments/" + str);
        //			val.AddFile(text, "/");
        //		}
        //		val.Save(HttpContext.Current.Server.MapPath("~/Temp/GeneratedFiles.zip"));
        //	}
        //	finally
        //	{
        //		((IDisposable)val)?.Dispose();
        //	}
        //	return HttpContext.Current.Server.MapPath("~/Temp/GeneratedFiles.zip");
        //}

        //public MemoryStream GetReportListStreamBySampleID(long SampleID)
        //{
        //	//IL_0014: Unknown result type (might be due to invalid IL or missing references)
        //	//IL_001b: Expected O, but got Unknown
        //	MemoryStream memoryStream = new MemoryStream();
        //	SampleReceiveTestListDB sampleReceiveTestListDB = new SampleReceiveTestListDB();
        //	List<SampleReceiveTestList> byMasterID = sampleReceiveTestListDB.GetByMasterID(SampleID);
        //	ZipArchive val = new ZipArchive();
        //	try
        //	{
        //		foreach (SampleReceiveTestList item in byMasterID)
        //		{
        //			TestsList testsList = item.TestsList;
        //			string str = testsList.WorkFormFileName.Insert(testsList.WorkFormFileName.LastIndexOf('.'), "_" + item.SampleReceiveList.JobOrderMaster.LPONumber + "_" + item.SampleReceiveList.SampleNo);
        //			string text = HttpContext.Current.Server.MapPath("~/SavedDocuments/" + str);
        //			val.AddFile(text, "/");
        //			str = testsList.ReportFileName.Insert(testsList.ReportFileName.LastIndexOf('.'), "_" + item.SampleReceiveList.JobOrderMaster.LPONumber + "_" + item.SampleReceiveList.SampleNo);
        //			text = HttpContext.Current.Server.MapPath("~/SavedDocuments/" + str);
        //			val.AddFile(text, "/");
        //		}
        //		val.Save((Stream)memoryStream);
        //		return memoryStream;
        //	}
        //	finally
        //	{
        //		((IDisposable)val)?.Dispose();
        //	}
        //}
    }
}
