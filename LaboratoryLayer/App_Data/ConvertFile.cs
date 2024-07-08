
using BusinessLayer;
using BusinessLayer.Pages;
using DevExpress.Charts.Model;
using DevExpress.DashboardCommon.Native.DashboardRestfulService;
using DevExpress.Pdf;
using DevExpress.Spreadsheet;
using DevExpress.Web.ASPxHtmlEditor.Internal;
using DevExpress.Web.Internal;
using DevExpress.XtraPrinting;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LaboratoryLayer.Pages
{
    public class ConvertFile
    {
        Workbook workbook;

        public bool ConvertExcelToPdf(string newFilePath, TestsList TestsList, string excelPath)
        {

            if (string.IsNullOrWhiteSpace(excelPath) || !File.Exists(excelPath))
                return false;
            workbook = new Workbook();
            bool isExists = false;
            string ext = Path.GetExtension(excelPath);
            if (ext == ".xlsm")
            {
                string copiedExcelPath = Path.Combine(Path.GetDirectoryName(excelPath), Guid.NewGuid().ToString().Replace("-", "") + Path.GetFileName(excelPath));
                File.Copy(excelPath, copiedExcelPath, true);


                return ExportReportUsingSpire(copiedExcelPath, newFilePath);



            }

            else
            {


                if (ext.Contains("xls"))
                {
                    string copiedExcelPath = Path.Combine(Path.GetDirectoryName(excelPath), Guid.NewGuid().ToString().Replace("-", "") + Path.GetFileName(excelPath));
                    File.Copy(excelPath, copiedExcelPath, true);
                    Spire.Xls.Workbook workbook = new Spire.Xls.Workbook();
                    workbook.LoadFromFile(copiedExcelPath);
                    Spire.Xls.Workbook newWorkbook = new Spire.Xls.Workbook();

                    foreach (Spire.Xls.Worksheet ws in workbook.Worksheets)
                    {
                        // if (ws.Name.Contains("Report"))
                        if (ws.Name.Contains("Report") || ws.Name.Contains("TR"))
                        {

                            Spire.Xls.Worksheet copiedSheet = newWorkbook.Worksheets.AddCopy(ws);
                            copiedSheet.Name = "Report" + ws.Index.ToString();
                            copiedSheet.PageSetup.FitToPagesWide = 1;
                        }
                    }
                    newWorkbook.SaveToFile(newFilePath, Spire.Xls.FileFormat.PDF);
                    workbook.Dispose();
                    newWorkbook.Dispose();
                    File.Delete(copiedExcelPath);
                    return true;
                }
                else
                    return false;
            }
        }
        public bool ConvertEntrySheetToPdf(string newFilePath, BusinessLayer.ReportGroup reportGroup, string excelPath, string methodsSelected)
        {
            if (string.IsNullOrWhiteSpace(excelPath) || !File.Exists(excelPath))
                return false;
            workbook = new Workbook();
            bool isExists = false;
            string ext = Path.GetExtension(excelPath);
            if (ext == ".xlsm")
            {
                string copiedExcelPath = Path.Combine(Path.GetDirectoryName(excelPath), Guid.NewGuid().ToString().Replace("-", "") + Path.GetFileName(excelPath));
                File.Copy(excelPath, copiedExcelPath, true);


                return ExportEntryUsingSpire(copiedExcelPath, newFilePath);


            }

            else
            {


                if (ext.Contains("xls"))
                {
                    string copiedExcelPath = Path.Combine(Path.GetDirectoryName(excelPath), Guid.NewGuid().ToString().Replace("-", "") + Path.GetFileName(excelPath));
                    File.Copy(excelPath, copiedExcelPath, true);
                    Spire.Xls.Workbook workbook = new Spire.Xls.Workbook();
                    workbook.LoadFromFile(copiedExcelPath);
                    Spire.Xls.Workbook newWorkbook = new Spire.Xls.Workbook();

                    foreach (Spire.Xls.Worksheet ws in workbook.Worksheets)
                    {
                        // if (ws.Name.Contains("Report"))
                        if (ws.Name.Contains("Data Entry") || ws.Name.Contains("DR"))
                        {

                            Spire.Xls.Worksheet copiedSheet = newWorkbook.Worksheets.AddCopy(ws);
                            copiedSheet.Name = "DR" + ws.Index.ToString();
                            copiedSheet.PageSetup.FitToPagesWide = 1;
                        }
                    }
                    newWorkbook.SaveToFile(newFilePath, Spire.Xls.FileFormat.PDF);
                    workbook.Dispose();
                    newWorkbook.Dispose();
                    File.Delete(copiedExcelPath);
                    return true;
                }
                else
                    return false;
            }

        }
        public bool ConvertReportSheetToPdf(string newFilePath, BusinessLayer.ReportGroup reportGroup, string excelPath, string methodsSelected)
        {
            if (string.IsNullOrWhiteSpace(excelPath) || !File.Exists(excelPath))
                return false;
            workbook = new Workbook();
            bool isExists = false;
            string ext = Path.GetExtension(excelPath);
            if (ext == ".xlsm")
            {
                string copiedExcelPath = Path.Combine(Path.GetDirectoryName(excelPath), Guid.NewGuid().ToString().Replace("-", "") + Path.GetFileName(excelPath));
                File.Copy(excelPath, copiedExcelPath, true);


                return ExportReportUsingSpire(copiedExcelPath, newFilePath);


            }

            else
            {


                if (ext.Contains("xls"))
                {
                    string copiedExcelPath = Path.Combine(Path.GetDirectoryName(excelPath), Guid.NewGuid().ToString().Replace("-", "") + Path.GetFileName(excelPath));
                    File.Copy(excelPath, copiedExcelPath, true);
                    Spire.Xls.Workbook workbook = new Spire.Xls.Workbook();
                    workbook.LoadFromFile(copiedExcelPath);
                    Spire.Xls.Workbook newWorkbook = new Spire.Xls.Workbook();

                    foreach (Spire.Xls.Worksheet ws in workbook.Worksheets)
                    {
                        // if (ws.Name.Contains("Report"))
                        if (ws.Name.Contains("Report") || ws.Name.Contains("TR"))
                        {

                            Spire.Xls.Worksheet copiedSheet = newWorkbook.Worksheets.AddCopy(ws);
                            copiedSheet.Name = "Report" + ws.Index.ToString();
                            copiedSheet.PageSetup.FitToPagesWide = 1;
                        }
                    }
                    newWorkbook.SaveToFile(newFilePath, Spire.Xls.FileFormat.PDF);
                    workbook.Dispose();
                    newWorkbook.Dispose();
                    File.Delete(copiedExcelPath);
                    return true;
                }
                else
                    return false;
            }

        }

        private bool ExportUsingAspose(string copiedExcelPath, string newFilePath)
        {
            try
            {
                UpdateTitle(copiedExcelPath, true);

                Aspose.Cells.License cellslic = new Aspose.Cells.License();
                cellslic.SetLicense("License.lic");

                Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook(copiedExcelPath);
                workbook.RemoveMacro();
                List<int> sheetsToRemove = new List<int>();



                for (int i = workbook.Worksheets.Count - 1; i >= 0; i--)
                {
                    Aspose.Cells.Worksheet ws = workbook.Worksheets[i];

                    if (ws.Name.Contains("Report") || ws.Name.Contains("TR"))
                    {
                        // Modify the worksheet that contains "Report"
                        ws.PageSetup.FitToPagesWide = 1;
                    }
                    else
                    {
                        sheetsToRemove.Add(i);
                    }
                }

                if (File.Exists(newFilePath))
                {
                    File.Delete(newFilePath);
                }
                foreach (int index in sheetsToRemove)
                {
                    workbook.Worksheets.RemoveAt(index);
                }
                workbook.Save(copiedExcelPath, Aspose.Cells.SaveFormat.Xlsm);
                workbook.Dispose();
                ConvertToPdfUsingInterop(newFilePath, copiedExcelPath);
                File.Delete(copiedExcelPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }

            return true;
        }
        
        public bool ConvertToPdfUsingInterop(string newFilePath, string intermediateExcelPath)
        {
            //foreach (var process in System.Diagnostics.Process.GetProcessesByName("EXCEL"))
            //{
            //    process.Kill();
            //}
            //Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            //var workbook = excelApp.Workbooks.Open(intermediateExcelPath);
            //workbook.ExportAsFixedFormat(Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF, newFilePath);
            //Task.Delay(20000);

            //// Close and release resources
            //workbook.Close();
            //excelApp.Quit();
            //System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
            //System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

            return true;
        }

       // NoOptimization is used to help us debug and look into each worksheet
        [MethodImpl(MethodImplOptions.NoOptimization)]
        [DebuggerStepThrough]
        private bool ExportReportUsingSpire(string copiedExcelPath, string newFilePath)
        {
            try
            {
              

                Spire.Xls.Workbook workbook = new Spire.Xls.Workbook();
                workbook.LoadFromFile(copiedExcelPath);

                Spire.Xls.Workbook loginWorkbook = new Spire.Xls.Workbook();
                //get the login sheet to get the number of reports to print
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
                if (int.TryParse(loginSht.Range["H10"].Value, out noofShtRPT))
                {
                    isSingle = false;
                }
                string[] sheetNames = new string[noofShtRPT];
                // if noofshtprt has a value  store codename of the sheet in string array 
                for (int i = 0; i < noofShtRPT; i++)
                {
                    sheetNames[i] = "RPT" + (i + 1);
                }

                Spire.Xls.Workbook newWorkbook = new Spire.Xls.Workbook();

                // Copy the worksheet to the new workbook if worksheet has codname found into sheetNames
                foreach (Spire.Xls.Worksheet ws in workbook.Worksheets)
                {
                    
                    if (Array.Exists(sheetNames, sheet => sheet == ws.CodeName) && isSingle == false)
                    {
                       


                        Spire.Xls.Worksheet copiedSheet = newWorkbook.Worksheets.AddCopy(ws);
                        copiedSheet.Name = "Report" + ws.Index.ToString();
                        
                        copiedSheet.PageSetup.FitToPagesWide = 1;
                    }
                    else
                    {
                        if (ws.Name.Contains("Report") && isSingle == true)
                        {
                            Spire.Xls.Worksheet copiedSheet = newWorkbook.Worksheets.AddCopy(ws);
                            copiedSheet.Name = "Report" + ws.Index.ToString();
                            copiedSheet.PageSetup.FitToPagesWide = 1;
                        }
                    }
                }
                // Check for existence before deleting
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

        [MethodImpl(MethodImplOptions.NoOptimization)]
        [DebuggerStepThrough]
        private bool ExportEntryUsingSpire(string copiedExcelPath, string newFilePath)
        {
            try
            {


                Spire.Xls.Workbook workbook = new Spire.Xls.Workbook();
                workbook.LoadFromFile(copiedExcelPath);

                Spire.Xls.Workbook loginWorkbook = new Spire.Xls.Workbook();
                //get the login sheet to get the number of reports to print
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
                if (int.TryParse(loginSht.Range["H9"].Value, out noofShtRPT))
                {
                    isSingle = false;
                }
                string[] sheetNames = new string[noofShtRPT];
                // if noofshtprt has a value  store codename of the sheet in string array 
                for (int i = 0; i < noofShtRPT; i++)
                {
                    sheetNames[i] = "DE" + (i + 1);
                }

                Spire.Xls.Workbook newWorkbook = new Spire.Xls.Workbook();

                // Copy the worksheet to the new workbook if worksheet has codname found into sheetNames
                foreach (Spire.Xls.Worksheet ws in workbook.Worksheets)
                {

                    if (Array.Exists(sheetNames, sheet => sheet == ws.CodeName) && isSingle == false)
                    {



                        Spire.Xls.Worksheet copiedSheet = newWorkbook.Worksheets.AddCopy(ws);
                        copiedSheet.Name = "Entry" + ws.Index.ToString();

                        copiedSheet.PageSetup.FitToPagesWide = 1;
                    }
                    else
                    {
                        if (ws.Name.Contains("Data Entry") && isSingle == true)
                        {
                            Spire.Xls.Worksheet copiedSheet = newWorkbook.Worksheets.AddCopy(ws);
                            copiedSheet.Name = "Entry" + ws.Index.ToString();
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

        [MethodImpl(MethodImplOptions.NoOptimization)]
        [DebuggerStepThrough]
        public static bool WriteRevisonNumber(TestReporting testReporting, TestReporting newTestReporting, string excelPath)
        {



           

                SampleReceiveTestListDB sampleReceiveTestListDB = new SampleReceiveTestListDB();
                SampleReceiveTestList sampleReceiveTest = sampleReceiveTestListDB.GetByID(testReporting.FKSampleReceiveTestID);
                List<TestExcelMapping> source = sampleReceiveTest.TestsList.TestExcelMappings.Where(P=>P.FieldName== "Revision Number").ToList();

                string reportNo = string.Format("A0{0}",  newTestReporting.RevisionNo);
            Spire.Xls.Workbook reportFile = new Spire.Xls.Workbook();
                
                    reportFile.LoadFromFile(excelPath);
            if (!String.IsNullOrEmpty(sampleReceiveTest.TestsList.ReportWorksheet))
            {

                foreach (Spire.Xls.Worksheet newReportFileSheet in reportFile.Worksheets)
                {
                    if (newReportFileSheet.Name == sampleReceiveTest.TestsList.ReportWorksheet)
                    {
                        foreach (TestExcelMapping item3 in source)
                        {
                            try
                            {
                                if (string.IsNullOrWhiteSpace(item3.ExcelCell))
                                    continue;

                                if (item3.FieldName.ToLower() == "revision number")
                                {
                                    newReportFileSheet.Range[item3.ExcelCell.ToUpper()].Value = reportNo;
                                    break;
                                }
                            }
                            catch (Exception ex)
                            {
                                reportFile.Dispose();
                                return false;
                            }
                        }
                    }
                }


                reportFile.SaveToFile(excelPath);
                reportFile.Dispose();
                return true;

            }
            return true;

        }

        public static bool WriteRevisionNumberASPOSE(TestReporting testReporting, TestReporting newTestReporting, string excelPath)
        {
            try
            {
                SampleReceiveTestListDB sampleReceiveTestListDB = new SampleReceiveTestListDB();
                SampleReceiveTestList sampleReceiveTest = sampleReceiveTestListDB.GetByID(testReporting.FKSampleReceiveTestID);
                List<TestExcelMapping> source = sampleReceiveTest.TestsList.TestExcelMappings.Where(P => P.FieldName == "Revision Number").ToList();

                string reportNo = string.Format("{0}-A0{1}", sampleReceiveTest.ReportNumber, newTestReporting.RevisionNo);

                // Load the Excel file using Aspose.Cells.Workbook
                Aspose.Cells.Workbook reportFile = new Aspose.Cells.Workbook(excelPath);

                if (!string.IsNullOrEmpty(sampleReceiveTest.TestsList.ReportWorksheet))
                {
                    // Iterate through the worksheets
                    foreach (Aspose.Cells.Worksheet newReportFileSheet in reportFile.Worksheets)
                    {
                        if (newReportFileSheet.Name == sampleReceiveTest.TestsList.ReportWorksheet)
                        {
                            // Iterate through the TestExcelMapping objects
                            foreach (TestExcelMapping item3 in source)
                            {
                                try
                                {
                                    if (string.IsNullOrWhiteSpace(item3.ExcelCell))
                                        continue;

                                    if (item3.FieldName.ToLower() == "revision number")
                                    {
                                        // Update the Excel cell with the new revision number
                                        newReportFileSheet.Cells[item3.ExcelCell].PutValue(reportNo);
                                        break;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    // Handle exceptions more gracefully (e.g., log the details)
                                    return false;
                                }
                            }
                        }
                    }

                    // Save the updated Excel file
                    reportFile.Save(excelPath);
                    return true;
                }

                return true;
            }
            catch (Exception ex)
            {
                // Handle exceptions more gracefully (e.g., log the details)
                return false;
            }
        }

        private void UpdateTitle(string excelPath, bool unlock)
        {
            //ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            //using (ExcelPackage package = new ExcelPackage(new FileInfo(excelPath)))
            //{
            //    var properties = package.Workbook.Properties;

            //    // Update or set the title property based on the 'unlock' condition
            //    properties.Title = unlock ? "SLS" : "";

            //    // Save the changes
            //    package.Save();
            //}
            //foreach (var process in System.Diagnostics.Process.GetProcessesByName("EXCEL"))
            //{
            //    process.Kill();
            //}

        }
        public int ExtractNumberFromString(string input)
        {
            string pattern = @"\d+";

            Match match = Regex.Match(input, pattern);

            if (match.Success)
            {
                int result;
                if (int.TryParse(match.Value, out result))
                {
                    return result;
                }
            }

            // Return 0 if no number is found or parsing fails
            return 0;
        }

        private void Workbook_BeforePrintSheet(object sender, BeforePrintSheetEventArgs e)
        {
            if (workbook.Tag.ToString().ToLower() != e.Name.ToLower())
                e.Cancel = true;
        }

        public static bool AttachSignatureFooter(string filePath, AttachedFiles attachedFiles, bool leftSignature)
        {
            try
            {
                using (PdfDocumentProcessor processor = new PdfDocumentProcessor())
                {
                    processor.LoadDocument(filePath);
                    //PdfPage page = processor.Document.Pages.FirstOrDefault();

                    foreach (PdfPage page in processor.Document.Pages)
                    {
                        // Create graphics and draw a signature field.
                        using (DevExpress.Pdf.PdfGraphics graphics = processor.CreateGraphics())
                        {
                            byte[] fileContent = attachedFiles.FileContent;
                            if (leftSignature)
                                graphics.DrawImage(fileContent, new Rectangle(130, (int)PdfPaperSize.A3.Height - 450, 150, 60));
                            else
                                graphics.DrawImage(fileContent, new Rectangle((int)PdfPaperSize.A3.Width - 420, (int)PdfPaperSize.A3.Height - 450, 150, 60));

                            graphics.AddToPageForeground(page, 72, 72);
                        }
                    }

                    processor.SaveDocument(filePath);
                }
                return true;
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.Assert(false);
                return false;
            }
        }

        public static bool CopyRevisedPDF(string revsionNo, string pdfToCopy)
        {
           
            string fileName = string.Format("{0}-A0{1}{2}", Path.GetFileNameWithoutExtension(pdfToCopy), revsionNo, Path.GetExtension(pdfToCopy));
            string newFileLocation = string.Format(@"{0}\{1}", Path.GetDirectoryName(pdfToCopy), fileName);
            if (File.Exists(pdfToCopy))
            {
                if(File.Exists(newFileLocation))
                {
                    File.Delete(newFileLocation);
                }
                File.Copy(pdfToCopy, newFileLocation);
                return true;
            }
            return false;

        }
        public static string GetFilePath(TestReporting testReporting)
        {
            string excelPath = string.Empty;
            if (testReporting.TestReportingID != 0)
            {
                SampleReceiveTestList sampleReceiveTestList = testReporting.SampleReceiveTestList;
                SampleReceiveList sampleReceiveList = new SampleReceiveListDB().GetByID(sampleReceiveTestList.FKSampleID.Value);
                string path = ConfigurationManager.AppSettings["SampleFilePath"];
                string reportNumber = sampleReceiveTestList.ReportNumber.ToString();
                int revisionNo = testReporting.RevisionNo;

                string searchPattern = string.Format("{0}.{1}", reportNumber, "*");
                string[] matchingFiles = Directory.GetFiles(Path.Combine(path, sampleReceiveList.SampleNo), searchPattern);

                if (matchingFiles.Length > 0)
                {
                    excelPath = matchingFiles[0];
                }
                else
                {
                    searchPattern = string.Format("{0}.*", reportNumber);
                    matchingFiles = Directory.GetFiles(Path.Combine(path, sampleReceiveList.SampleNo), searchPattern);

                    if (matchingFiles.Length > 0)
                    {
                        excelPath = matchingFiles[0];
                    }
                }

               
            }

            return excelPath;
        }
        public static string GetRevisedPDF(string revsionNo, string pdfToCopy)
        {
            string fileName = string.Format("{0}-A0{1}{2}", Path.GetFileNameWithoutExtension(pdfToCopy), revsionNo, Path.GetExtension(pdfToCopy));
            return fileName;
        }

        //add only left and right approvers name and signature
        public static bool AttachSignature(string filePath, AttachedFiles attachedFiles, bool leftSignature, string signerName, string signerArabicName)
        {
            try
            {
                using (PdfDocumentProcessor processor = new PdfDocumentProcessor())
                {
                    processor.LoadDocument(filePath);

                    foreach (PdfPage page in processor.Document.Pages)
                    {
                        double pdfHeight = page.CropBox.Height;

                        double pdfWidth = page.CropBox.Width;
                        byte[] footerContent = attachedFiles.FileContent;

                        if (pdfWidth < pdfHeight)
                        {


                            using (DevExpress.Pdf.PdfGraphics footerGraphics = processor.CreateGraphics())
                            {
                                if (leftSignature)
                                {

                                    footerGraphics.DrawString(signerArabicName, new Font("Arial", 12), new SolidBrush(Color.Black), new PointF(80, Convert.ToInt16(pdfHeight) - 68));
                                    footerGraphics.DrawString(signerName, new Font("Arial", 12), new SolidBrush(Color.Black), new PointF(80, Convert.ToInt16(pdfHeight) - 80));
                                    footerGraphics.DrawImage(footerContent, new Rectangle(165, Convert.ToInt16(pdfHeight) - 127, 60, 60));
                                    footerGraphics.AddToPageForeground(page, 72, 72);
                                }
                                else
                                {
                                    footerGraphics.DrawString(signerArabicName, new Font("Arial", 12), new SolidBrush(Color.Black), new PointF((float)pdfWidth - 190, Convert.ToInt16(pdfHeight) - 68));
                                    footerGraphics.DrawString(signerName, new Font("Arial", 12), new SolidBrush(Color.Black), new PointF((float)pdfWidth - 190, Convert.ToInt16(pdfHeight) - 80));

                                    footerGraphics.DrawImage(footerContent, new Rectangle((int)pdfWidth - 100, Convert.ToInt16(pdfHeight) - 127, 60, 60));
                                    footerGraphics.AddToPageForeground(page, 72, 72);
                                }
                            }
                        }
                        if (page.CropBox.Width >= page.CropBox.Height)
                        {
                            using (DevExpress.Pdf.PdfGraphics footerGraphics = processor.CreateGraphics())
                            {
                                if (leftSignature)
                                {

                                    footerGraphics.DrawString(signerArabicName, new Font("Arial", 12), new SolidBrush(Color.Black), new PointF(140, Convert.ToInt16(pdfHeight) - 68));
                                    footerGraphics.DrawString(signerName, new Font("Arial", 12), new SolidBrush(Color.Black), new PointF(140, Convert.ToInt16(pdfHeight) - 80));
                                    footerGraphics.DrawImage(footerContent, new Rectangle(165, Convert.ToInt16(pdfHeight) - 127, 60, 60));
                                    footerGraphics.AddToPageForeground(page, 72, 72);
                                }
                                else
                                {
                                    footerGraphics.DrawString(signerArabicName, new Font("Arial", 12), new SolidBrush(Color.Black), new PointF((float)pdfWidth - 310, Convert.ToInt16(pdfHeight) - 68));
                                    footerGraphics.DrawString(signerName, new Font("Arial", 12), new SolidBrush(Color.Black), new PointF((float)pdfWidth - 310, Convert.ToInt16(pdfHeight) - 80));

                                    footerGraphics.DrawImage(footerContent, new Rectangle((int)pdfWidth - 225, Convert.ToInt16(pdfHeight) - 127, 60, 60));
                                    footerGraphics.AddToPageForeground(page, 72, 72);
                                }
                            }

                        }
                        }

                    processor.SaveDocument(filePath);
                }
                return true;
            }
            catch (System.Exception ex)
            {

                return false;
            }
        }
        public static bool ConvertExcelToPdfWithHeaderFooter(string newFilePath, string excelPath, TestsList TestsList, AttachedFiles attachedFiles)
        {
            if (string.IsNullOrWhiteSpace(excelPath) || !File.Exists(excelPath))
                return false;
            string copiedexcelpath = Path.Combine(Path.GetDirectoryName(excelPath), Guid.NewGuid().ToString() + Path.GetFileName(excelPath));
            Spire.Xls.Workbook workbook_modifed = new Spire.Xls.Workbook();
            workbook_modifed.LoadFromFile(excelPath);
            Spire.Xls.Workbook newworkbook = new Spire.Xls.Workbook();
            string sheetName = "";
            //if (!string.IsNullOrWhiteSpace(TestsList.WorkFormWorksheet))
            //    sheetName = TestsList.WorkFormWorksheet;
            //else 
            if (!string.IsNullOrWhiteSpace(TestsList.ReportWorksheet))
                sheetName = TestsList.ReportWorksheet;
            foreach (Spire.Xls.Worksheet ws in workbook_modifed.Worksheets)
            {
                if (ws.Name == sheetName)
                {
                    Spire.Xls.Worksheet copiedsheet = newworkbook.Worksheets.AddCopy(ws);
                    copiedsheet.PageSetup.FitToPagesWide = 1;
                }
            }


            using (Workbook workbook = new Workbook())
            {
                bool isExists = false;
                string ext = Path.GetExtension(copiedexcelpath);
                if (ext == ".xls")
                {
                    newworkbook.SaveToFile(copiedexcelpath, Spire.Xls.FileFormat.Version2007);
                    workbook_modifed.Dispose();
                    newworkbook.Dispose();
                    isExists = workbook.LoadDocument(copiedexcelpath, DocumentFormat.Xls);
                }
                else if (ext == ".xlsx")
                {
                    newworkbook.SaveToFile(copiedexcelpath, Spire.Xls.FileFormat.Version2013);
                    workbook_modifed.Dispose();
                    newworkbook.Dispose();
                    isExists = workbook.LoadDocument(copiedexcelpath, DocumentFormat.Xlsx);
                }
                else if (ext == ".xlsm")
                {
                    newworkbook.SaveToFile(copiedexcelpath, Spire.Xls.FileFormat.Xlsm);
                    workbook_modifed.Dispose();
                    newworkbook.Dispose();
                    isExists = workbook.LoadDocument(copiedexcelpath, DocumentFormat.Xlsm);
                }
                //workbook.Unit = DevExpress.Office.DocumentUnit.Inch;
                //WorksheetCollection worksheets = workbook.Worksheets;
                //WorksheetHeaderFooterOptions worksheetoptions = worksheets[0].HeaderFooterOptions;  //First Worksheet
                //worksheetoptions.DifferentFirst = true;

                ////options.FirstFooter.AddPicture("DxLogo.png", HeaderFooterSection.Center);
                ////HeaderFooterPicture picture = options.FirstHeader.AddPicture(SpreadsheetImageSource.FromFile("~\images\LoginImages\Lab Logo.jpeg"), HeaderFooterSection.Left);
                //byte[] fileContent = attachedFiles.FileContent;
                //MemoryStream stream = new MemoryStream();
                //stream.Write(fileContent, 0, fileContent.Length);

                //Image image = Image.FromStream(stream);
                //worksheetoptions.FirstFooter.AddPicture(image, HeaderFooterSection.Center);
                //HeaderFooterPicture picture = worksheetoptions.FirstHeader.AddPicture(image, HeaderFooterSection.Left);
                //worksheetoptions.FirstHeader.Left = string.Format("{0}&BDev{1}AV &G", HeaderFooterCode.FontColor(Color.FromArgb(0x05, 0x6f, 0xCE)),
                //    HeaderFooterCode.FontColor(Color.FromArgb(0x39, 0xA6, 0xF7)));
                //picture.Height = 0.3f;
                //picture.Width = 0.3f;

                if (isExists)
                {
                    FileInfo file = new FileInfo(newFilePath);
                    if (!file.Directory.Exists)
                        file.Directory.Create();

                    if (File.Exists(newFilePath))
                    {
                        File.Delete(newFilePath);
                    }

                    //if (!string.IsNullOrWhiteSpace(sheetName))
                    //{
                    //    List<Worksheet> worksheetList = workbook.Worksheets.Where(w => w.Name != sheetName).ToList();
                    //    foreach (Worksheet worksheet in worksheetList)
                    //        workbook.Worksheets.Remove(worksheet);
                    //}

                    PdfExportOptions options = new PdfExportOptions();
                    options.PdfACompatibility = PdfACompatibility.PdfA2b;
                    workbook.ExportToPdf(newFilePath, options);


                }
                else
                    return false;
            }
            return AttachSignatureFooter(newFilePath, attachedFiles, true);

        }


        //add only header and footer
        public static bool AttachHeaderAndFooter(string filePath, string footerImagePath, string headerImagePath, string stampImagePath)
        {
            try
            {
                using (PdfDocumentProcessor processor = new PdfDocumentProcessor())
                {
                    processor.LoadDocument(filePath);

                    foreach (PdfPage page in processor.Document.Pages)
                    {
                        double pdfWidth = page.CropBox.Width;
                        using (DevExpress.Pdf.PdfGraphics headerGraphics = processor.CreateGraphics())
                        {
                            byte[] headerContent = File.ReadAllBytes(headerImagePath);
                            // double pdfWidth = page.CropBox.Width;
                            double headerAspectRatio = (double)956 / 113;
                            int headerHeight = (int)(pdfWidth / headerAspectRatio);
                            int headerTopPosition = (int)PdfPaperSize.A3.Height - 5;


                            headerGraphics.DrawImage(headerContent, new Rectangle(1, 1, (int)pdfWidth, 60));
                            headerGraphics.AddToPageBackground(page, 72, 72);
                        }

                        using (DevExpress.Pdf.PdfGraphics footerGraphics = processor.CreateGraphics())
                        {
                            byte[] footerContent = File.ReadAllBytes(footerImagePath);
                            int footerTopPosition = 0;
                            int pdfHeight = (int)page.CropBox.Height;
                            footerGraphics.DrawImage(footerContent, new Rectangle(5, pdfHeight - 60, (int)pdfWidth, 60));
                            footerGraphics.AddToPageBackground(page, 72, 72);
                        }

                        using (DevExpress.Pdf.PdfGraphics stampGraphics = processor.CreateGraphics())
                        {
                            byte[] stampContent = File.ReadAllBytes(stampImagePath);
                            int pdfHeight = (int)page.CropBox.Height;
                            pdfWidth = page.CropBox.Width;

                            int targetWidth, targetHeight;
                            if (1066.0 / 747.0 > 1.0)
                            {
                                targetWidth = 150;
                                targetHeight = (int)(150.0 * 747.0 / 1066.0);
                            }
                            else
                            {
                                targetWidth = (int)(150 * 1066.0 / 747.0);
                                targetHeight = 150;
                            }
                            if (pdfHeight > pdfWidth)
                            {
                                stampGraphics.DrawImage(stampContent, new Rectangle((int)pdfWidth - 400, pdfHeight - 160, targetWidth, targetHeight));
                            }
                            else
                            {
                                stampGraphics.DrawImage(stampContent, new Rectangle((int)pdfWidth - 500, pdfHeight - 160, targetWidth, targetHeight));
                            }

                            stampGraphics.AddToPageForeground(page, 72, 72);
                        }

                    }

                    processor.SaveDocument(filePath);
                }
                return true;
            }
            catch (System.Exception ex)
            {

                return false;
            }
        }

        public static bool AttachDeletionReasonAndDeleteSampleReceive(string directoryPath, string SampleNo, string Reason)
        {
             Reason = InsertNewLines(Reason, 65);
            string[] pdfFiles = Directory.GetFiles(directoryPath, SampleNo + "-R*.pdf")
                                        .Select(Path.GetFileName)
                                        .ToArray();

            foreach (string row in pdfFiles)
            {
                using (PdfDocumentProcessor processor = new PdfDocumentProcessor())
                {
                    processor.LoadDocument(directoryPath + "\\" + row);

                    foreach (PdfPage page in processor.Document.Pages)
                    {
                        using (DevExpress.Pdf.PdfGraphics footerGraphics = processor.CreateGraphics())
                        {
                            int pdfHeight = (int)page.CropBox.Height;

                            footerGraphics.DrawString("Reason for Delete:"+Reason, new Font("Arial", 12), new SolidBrush(Color.Red), new PointF(60, pdfHeight - 50));

                            footerGraphics.AddToPageForeground(page, 72, 72);

                        }
                    }
                    processor.SaveDocument(directoryPath + "\\" + row);
                }
                // File.Delete(directoryPath + "\\" + row);

            }
            return true;
        }
        public static string InsertNewLines(string input, int interval)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            int index = 0;
            int count = 0;
            while (index < input.Length)
            {
                if (1==count)
                {
                    interval = interval + 16;
                }
                sb.Append(input.Substring(index, Math.Min(interval, input.Length - index)));
                index += interval;
                if (index < input.Length)
                {
                    sb.Append("\n");
                    count++;
                }
            }
            return sb.ToString();
        }
        [DllImport("shell32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SHEmptyRecycleBin(IntPtr hwnd, string pszRootPath, RecycleFlags dwFlags);

        [Flags]
        enum RecycleFlags : uint
        {
            SHERB_NOCONFIRMATION = 0x00000001,
            SHERB_NOPROGRESSUI = 0x00000001,
            SHERB_NOSOUND = 0x00000004
        }

        private static void MoveFileToRecycleBin(string filePath)
        {

            if (SHEmptyRecycleBin(IntPtr.Zero, filePath, RecycleFlags.SHERB_NOCONFIRMATION))
            {
                Console.WriteLine("File moved to Recycle Bin successfully.");
            }
        }
    }
}






