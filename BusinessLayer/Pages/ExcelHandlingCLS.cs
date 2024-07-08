using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using DevExpress.Compression;
using DevExpress.Spreadsheet;

namespace BusinessLayer.Pages
{
	public class ExcelHandlingCLS
	{
        //public const string SampleNumber = "Sample Number";
        //public const string ReceiveDate = "Receive Date";
        //public const string RSSNumber = "RSS Number";
        //public const string JobOrderNumber = "Job Order Number";
        //public const string Customer = "Customer";
        //public const string Project = "Project";
        //public const string ProjectNumber = "Project Number";
        //public const string ProjectOwner = "Project Owner";
        //public const string ProjectContractor = "Project Contractor";
        //public const string ProjectType = "Project Type";
        //public const string ProjectLocation = "Project Location";
        //public const string ProjectConsultant = "Project Consultant";
        //public const string ConsultantName = "Consultant Name";
        //public const string ConsultantMobileNo = "Consultant Mobile No";
        //public const string ContactPersonatSite = "Contact Person at Site";
        //public const string ContactPersonMobileNo = "Contact Person Mobile No";
        //public const string DelivererName = "Deliverer Name";
        //public const string DelivererMobileNo = "Deliverer Mobile No";
        //public const string Supplier = "Supplier";
        //public const string Source = "Source";
        //public const string SamplingDate = "Sampling Date";
        //public const string SampleDescription = "Sample Description";
        //public const string SampleLocation = "Sample Location";
        //public const string Sampledby = "Sampled by";
        //public const string SampleByName = "Sample By Name";
        //public const string SiteRefNo = "Site Ref No";
        //public const string Samplebroughtinby = "Sample brought in by";
        //public const string BroughtinbyName = "Brought in by Name";
        //public const string BroughtinDate = "Brought in Date";
        //public const string LayerNo = "Layer No";
        //public const string ServiceSection = "Service Section";
        //public const string MaterialDetails = "Material Details";
        //public const string MaterialClass = "Material Class";
        //public const string ReceivedQty = "Received Qty";
        //public const string Unit = "Unit";
        //public const string Retentionperiod = "Retention period";
        //public const string SampleCondition = "Sample Condition";
        //public const string ConditionDetails = "Condition Details";
        //public const string SampleTemperature = "Sample Temperature";

        public Tuple<bool, string> GenerateXlsBySampleID(long SampleID)
		{
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_0049: Expected O, but got Unknown
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0179: Unknown result type (might be due to invalid IL or missing references)
			//IL_0183: Unknown result type (might be due to invalid IL or missing references)
			//IL_0189: Expected O, but got Unknown
			//IL_0213: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b9: Unknown result type (might be due to invalid IL or missing references)
			try
			{
                SampleReceiveListDB sampleReceiveListDB = new SampleReceiveListDB();
                SampleReceiveList sampleReceive = sampleReceiveListDB.GetByID(SampleID);

                SampleReceiveTestListDB sampleReceiveTestListDB = new SampleReceiveTestListDB();
				List<SampleReceiveTestList> byMasterID = sampleReceiveTestListDB.GetByMasterID(SampleID);
				DataTable sampleFieldsBySampleID = sampleReceiveTestListDB.GetSampleFieldsBySampleID(SampleID);
                string destinationPath = System.Configuration.ConfigurationManager.AppSettings["SampleFilePath"];
                foreach (SampleReceiveTestList item in byMasterID)
				{
					TestsList testsList = item.TestsList;
                    if (testsList == null || testsList.TestExcelMappings == null)
                        continue;

					List<TestExcelMapping> source = testsList.TestExcelMappings.ToList();
                    if (source.Count == 0)
                        continue;

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
                            }
                            else
                            {
                                if (Path.GetExtension(dest.FullName).ToLower().Equals(".xlsm"))
                                    reportFile.SaveDocument(dest.FullName, DocumentFormat.Xlsm);
                                else
                                    reportFile.SaveDocument(dest.FullName, DocumentFormat.Xlsx);
                                //reportFile.SaveDocument(dest.FullName, DocumentFormat.Xlsx);
                            }
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

		public bool GenerateSingleXlsBySampleID(long SampleID)
		{
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_0049: Expected O, but got Unknown
			//IL_0049: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Expected O, but got Unknown
			//IL_00da: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01be: Expected O, but got Unknown
			//IL_0248: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_033c: Unknown result type (might be due to invalid IL or missing references)
			try
			{
				SampleReceiveTestListDB sampleReceiveTestListDB = new SampleReceiveTestListDB();
				List<SampleReceiveTestList> byMasterID = sampleReceiveTestListDB.GetByMasterID(SampleID);
				DataTable sampleFieldsBySampleID = sampleReceiveTestListDB.GetSampleFieldsBySampleID(SampleID);
				foreach (SampleReceiveTestList item in byMasterID)
				{
					TestsList testsList = item.TestsList;
					List<TestExcelMapping> source = testsList.TestExcelMappings.ToList();
					Workbook val = new Workbook();
					Workbook val2 = new Workbook();
					string text = HttpContext.Current.Server.MapPath("~/Uploaded/LabTestInfo/" + testsList.WorkFormFileName);
					string str = testsList.WorkFormFileName.Insert(testsList.WorkFormFileName.LastIndexOf('.'), "_" + item.SampleReceiveList.JobOrderMaster.LPONumber + "_" + item.SampleReceiveList.SampleNo);
					string text2 = HttpContext.Current.Server.MapPath("~/SavedDocuments/" + str);
					val.LoadDocument(text, DocumentFormat.Xlsx);
					Worksheet val3 = val.Worksheets[testsList.WorkFormWorksheet];
					foreach (TestExcelMapping item2 in source.Where((TestExcelMapping x) => !x.IsForReport).ToList())
					{
						val3.Cells[item2.ExcelCell].SetValue(sampleFieldsBySampleID.Rows[0][item2.FieldName].ToString());
					}
					val2.Worksheets.Add(testsList.WorkFormWorksheet);
					val2.Worksheets[testsList.WorkFormWorksheet].CopyFrom(val3);
					val.SaveDocument(text2, DocumentFormat.Xlsx);
					val = new Workbook();
					text = HttpContext.Current.Server.MapPath("~/Uploaded/LabTestInfo/" + testsList.ReportFileName);
					str = testsList.ReportFileName.Insert(testsList.ReportFileName.LastIndexOf('.'), "_" + item.SampleReceiveList.JobOrderMaster.LPONumber + "_" + item.SampleReceiveList.SampleNo);
					text2 = HttpContext.Current.Server.MapPath("~/SavedDocuments/" + str);
					val.LoadDocument(text, DocumentFormat.Xlsx);
					val3 = val.Worksheets[testsList.ReportWorksheet];
					foreach (TestExcelMapping item3 in source.Where((TestExcelMapping x) => x.IsForReport).ToList())
					{
						val3.Cells[item3.ExcelCell].SetValue(sampleFieldsBySampleID.Rows[0][item3.FieldName].ToString());
					}
					val.SaveDocument(text2, DocumentFormat.Xlsx);
					val2.Worksheets.Add(testsList.ReportWorksheet);
					val2.Worksheets[testsList.ReportWorksheet].CopyFrom(val3);
					val2.SaveDocument(HttpContext.Current.Server.MapPath("~/SavedDocuments/Output.xlsx"), DocumentFormat.Xlsx);
				}
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public string GetReportListPathBySampleID(long SampleID)
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0015: Expected O, but got Unknown
			SampleReceiveTestListDB sampleReceiveTestListDB = new SampleReceiveTestListDB();
			List<SampleReceiveTestList> byMasterID = sampleReceiveTestListDB.GetByMasterID(SampleID);
			ZipArchive val = new ZipArchive();
			try
			{
				foreach (SampleReceiveTestList item in byMasterID)
				{
					TestsList testsList = item.TestsList;
					string str = testsList.WorkFormFileName.Insert(testsList.WorkFormFileName.LastIndexOf('.'), "_" + item.SampleReceiveList.JobOrderMaster.LPONumber + "_" + item.SampleReceiveList.SampleNo);
					string text = HttpContext.Current.Server.MapPath("~/SavedDocuments/" + str);
					val.AddFile(text, "/");
					str = testsList.ReportFileName.Insert(testsList.ReportFileName.LastIndexOf('.'), "_" + item.SampleReceiveList.JobOrderMaster.LPONumber + "_" + item.SampleReceiveList.SampleNo);
					text = HttpContext.Current.Server.MapPath("~/SavedDocuments/" + str);
					val.AddFile(text, "/");
				}
				val.Save(HttpContext.Current.Server.MapPath("~/Temp/GeneratedFiles.zip"));
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
			return HttpContext.Current.Server.MapPath("~/Temp/GeneratedFiles.zip");
		}

		public MemoryStream GetReportListStreamBySampleID(long SampleID)
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Expected O, but got Unknown
			MemoryStream memoryStream = new MemoryStream();
			SampleReceiveTestListDB sampleReceiveTestListDB = new SampleReceiveTestListDB();
			List<SampleReceiveTestList> byMasterID = sampleReceiveTestListDB.GetByMasterID(SampleID);
			ZipArchive val = new ZipArchive();
			try
			{
				foreach (SampleReceiveTestList item in byMasterID)
				{
					TestsList testsList = item.TestsList;
					string str = testsList.WorkFormFileName.Insert(testsList.WorkFormFileName.LastIndexOf('.'), "_" + item.SampleReceiveList.JobOrderMaster.LPONumber + "_" + item.SampleReceiveList.SampleNo);
					string text = HttpContext.Current.Server.MapPath("~/SavedDocuments/" + str);
					val.AddFile(text, "/");
					str = testsList.ReportFileName.Insert(testsList.ReportFileName.LastIndexOf('.'), "_" + item.SampleReceiveList.JobOrderMaster.LPONumber + "_" + item.SampleReceiveList.SampleNo);
					text = HttpContext.Current.Server.MapPath("~/SavedDocuments/" + str);
					val.AddFile(text, "/");
				}
				val.Save((Stream)memoryStream);
				return memoryStream;
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
	}
}
