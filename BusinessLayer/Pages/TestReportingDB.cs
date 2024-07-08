using DevExpress.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Aspose.Cells;
using System.Globalization;

namespace BusinessLayer.Pages
{
	public class TestReportingDB : DBBase<TestReporting, List<TestReporting>, long>
	{
        string pathread = ConfigurationManager.AppSettings["SampleFilePath"];
        string path = ConfigurationManager.AppSettings["SampleFileReadPath"];

       

		public override TestReporting GetByID(long id)
		{
            var result = ((IQueryable<TestReporting>)dbContext.TestReportings).FirstOrDefault((TestReporting t) => t.TestReportingID == id);
            return result;
		}

        public TestReporting GetByReportNumber(long sampleReceiveTestID)
        {
            var result = ((IQueryable<TestReporting>)dbContext.TestReportings).FirstOrDefault((TestReporting t) => t.FKSampleReceiveTestID == sampleReceiveTestID);
            return result;
        }

        public override bool Insert(TestReporting entity, out string message)
		{
			message = "";
            bool result = false;
            try
            {
                dbContext.TestReportings.Add(entity);
                if (((DbContext)dbContext).SaveChanges() > 0)
                {
                    HttpContext context = HttpContext.Current;
                    context.Session["TestReportingID"] = entity.TestReportingID;
                    return true;
                }

                message = "InsertError";
                return false;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                result = false;
            }
            return result;
        }

        public override bool Update(TestReporting entity, out string message)
        {
            message = "";
            bool result = false;
            try
            {
                TestReporting testReporting = this.GetByID(entity.TestReportingID);
                DbEntityEntry dbEntityEntry = this.dbContext.Entry<TestReporting>(testReporting);
                dbEntityEntry.State = EntityState.Modified;
                dbEntityEntry.CurrentValues.SetValues(entity);
                if (this.dbContext.SaveChanges() > 0)
                {
                    result = true;
                }
                else
                {
                    message = "UpdateError";
                    result = false;
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                result = false;
            }
            return result;
        }

		// Token: 0x060007C0 RID: 1984 RVA: 0x0001B170 File Offset: 0x00019370
		public override bool Delete(TestReporting entity, out string message)
		{
			message = "";
			bool result;
			try
			{
				this.dbContext.Entry<TestReporting>(entity).State = EntityState.Deleted;
				if (this.dbContext.SaveChanges() > 0)
				{
					result = true;
				}
				else
				{
					message = "DeleteError";
					result = false;
				}
			}
			catch (Exception)
			{
				message = "DeleteError";
				result = false;
			}
			return result;
		}

        public bool Insert(TestReporting entity)
        {
            string message = "";
            
            if (Insert(entity, out message))
            {
                return true;
            }
            throw new Exception(message);
        }

        public bool Update(TestReporting entity)
        {
            string message = "";
            if (Update(entity, out message))
            {
                return true;
            }
            throw new Exception(message);
        }

        public bool UpdatePendingTestEndingDate(TestReporting entity)
        {
            return true;
        }
        public override List<TestReporting> GetAll()
        {
            List<TestReporting> testReportings = new List<TestReporting>();
            var pendingList = dbContext.Database.SqlQuery<SqlQueryModels.TestReporting>(@"select 
TestReportingID = t.TestReportingID,
FKSampleReceiveTestID = t.FKSampleReceiveTestID,
StatusID = t.StatusID,
RevisionNo = t.RevisionNo,
IsRevised = t.IsRevised,
SampleNumber = sr.SampleNo,
FKProjectID = sr.FKProjectID,
FKTestID = s.FKTestID,
FKCustomerID = sr.FKCustomerID,
ReportNumber = Isnull(s.ReportNumber,0),
SampleReceivedDate = sr.ReceiveDate,
WorkFormFileName = tl.WorkFormFileName,
TestEndingDate = t.TestEndingDate,
StandardNumber =tl.StandardNumber

from TestReporting t
inner join SampleReceiveTestList s on t.FKSampleReceiveTestID=s.SampleReceiveTestID
left join TestsList tl on s.FKTestID= tl.TestID
inner join SampleReceiveList sr on  s.FKSampleID=sr.SampleID").ToList();
            if (pendingList.Count > 0)
            {
                foreach (SqlQueryModels.TestReporting testReporting in pendingList)
                {
                    var obj = new TestReporting()
                    {
                        TestReportingID = testReporting.TestReportingID,
                        FKSampleReceiveTestID = testReporting.FKSampleReceiveTestID,
                        StatusID = testReporting.StatusID,
                        RevisionNo = testReporting.RevisionNo,
                        IsRevised = testReporting.IsRevised,
                        SampleNumber = testReporting.SampleNumber,
                        FKProjectID = testReporting.FKProjectID,
                        FKTestID = testReporting.FKTestID,
                        FKCustomerID = testReporting.FKCustomerID,
                        ReportNumber = testReporting.ReportNumber,
                        SampleReceivedDate = testReporting.SampleReceivedDate,
                        TestEndingDate = testReporting.TestEndingDate,
                        StandardNumber = testReporting.StandardNumber

                    };
                    testReportings.Add(obj);
                }

                return testReportings.OrderByDescending(t => t.ReportNumber).ToList();
            }
            
                    return new List<TestReporting>();
        }
        public List<TestReporting> GetAllPendingForTheLast10Days()
        {
            List<TestReporting> testReportings = new List<TestReporting>();

            var pendingList = dbContext.Database.SqlQuery<SqlQueryModels.TestReporting>(@"select 
TestReportingID = t.TestReportingID,
FKSampleReceiveTestID = t.FKSampleReceiveTestID,
StatusID = t.StatusID,
RevisionNo = t.RevisionNo,
IsRevised = t.IsRevised,
SampleNumber = sr.SampleNo,
FKProjectID = sr.FKProjectID,
FKTestID = s.FKTestID,
FKCustomerID = sr.FKCustomerID,
ReportNumber = Isnull(s.ReportNumber,0),
SampleReceivedDate = sr.ReceiveDate,
WorkFormFileName = tl.WorkFormFileName,
TestEndingDate = t.TestEndingDate,
StandardNumber =tl.StandardNumber

from TestReporting t
inner join SampleReceiveTestList s on t.FKSampleReceiveTestID=s.SampleReceiveTestID
left join TestsList tl on s.FKTestID= tl.TestID
inner join SampleReceiveList sr on  s.FKSampleID=sr.SampleID
where s.ReportNumber is not null and StatusID=0 AND sr.ReceiveDate >= DATEADD(day, -10, GETDATE()) ").ToList();

            if (pendingList.Count > 0)
            {
                foreach (SqlQueryModels.TestReporting testReporting in pendingList)
                {
                    var obj = new TestReporting()
                    {
                        TestReportingID = testReporting.TestReportingID,
                        FKSampleReceiveTestID = testReporting.FKSampleReceiveTestID,
                        StatusID = testReporting.StatusID,
                        RevisionNo = testReporting.RevisionNo,
                        IsRevised = testReporting.IsRevised,
                        SampleNumber = testReporting.SampleNumber,
                        FKProjectID = testReporting.FKProjectID,
                        FKTestID = testReporting.FKTestID,
                        FKCustomerID = testReporting.FKCustomerID,
                        ReportNumber = testReporting.ReportNumber,
                        SampleReceivedDate = testReporting.SampleReceivedDate,
                        TestEndingDate = testReporting.TestEndingDate,
                        LabName = testReporting.LabName
                    };

                    string ext = ".xlsx";
                    if (!string.IsNullOrWhiteSpace(testReporting.WorkFormFileName))
                        ext = Path.GetExtension(testReporting.WorkFormFileName);
                   

                  
                    string filePath = string.Format(@"{0}\{1}\{2}{3}", pathread, testReporting.SampleNumber, testReporting.ReportNumber, ext);
                    filePath = RemoveExtraBackslashes(filePath);
                    if (File.Exists(filePath))
                    {
                        ext = ".xlsx";
                        //filePath = string.Format(@"{0}\{1}\{2}{3}", path, testReporting.SampleNumber, testReporting.ReportNumber, ext);
                        filePath = string.Format(@"{0}\{1}\{2}{3}", path, testReporting.SampleNumber, testReporting.ReportNumber, ext);
                        filePath = RemoveExtraBackslashes(filePath);
                    }
                    else if (!File.Exists(filePath))
                    {
                        ext = ".xlsm";
                        filePath = string.Format(@"{0}\{1}\{2}{3}", path, testReporting.SampleNumber, testReporting.ReportNumber, ext);
                        filePath = RemoveExtraBackslashes(filePath);
                    }

                    //if (testReporting.RevisionNo > 0)
                    //{
                    //    string fileName = string.Format("{0}-A0{1}{2}", testReporting.ReportNumber, testReporting.RevisionNo, ext);
                    //    filePath = string.Format(@"{0}\{1}\{2}", path, testReporting.SampleNumber, fileName);
                    //}
                  
                                  

                    filePath = string.Format(@"localexplorer:{0}", filePath);

                    obj.FileUrl = filePath;

                    //updatetestendingdate(testReporting.FKSampleReceiveTestID, obj.ReportingDate);
                    testReportings.Add(obj);
                }

                return testReportings.OrderByDescending(t => t.ReportNumber).ToList();
            }

            return testReportings;
        }
        public List<TestReporting> GetAllPending()
        {
            List<TestReporting> testReportings = new List<TestReporting>();

            var pendingList = dbContext.Database.SqlQuery<SqlQueryModels.TestReporting>(@"select 
TestReportingID = t.TestReportingID,
LabName = ll.LabName,
FKSampleReceiveTestID = t.FKSampleReceiveTestID,
StatusID = t.StatusID,
RevisionNo = t.RevisionNo,
IsRevised = t.IsRevised,
SampleNumber = sr.SampleNo,
FKProjectID = sr.FKProjectID,
FKTestID = s.FKTestID,
FKCustomerID = sr.FKCustomerID,
ReportNumber = Isnull(s.ReportNumber,0),
SampleReceivedDate = sr.ReceiveDate,
WorkFormFileName = tl.WorkFormFileName,
TestEndingDate = t.TestEndingDate,
StandardNumber =tl.StandardNumber,
CustomerName = cl.CustomerName,
TestRequiredTime = isnull(tl.TestRequiredTime,0),
TestName = tl.TestName,
SuggestedTestingDate = t.SuggestedTestingDate
from TestReporting t
inner join SampleReceiveTestList s on t.FKSampleReceiveTestID=s.SampleReceiveTestID
left join TestsList tl on s.FKTestID= tl.TestID
inner join LabsList ll on tl.FKLabID = ll.LabID
inner join SampleReceiveList sr on  s.FKSampleID=sr.SampleID 
inner join CustomersList cl on sr.FKCustomerID = cl.CustomerID 

where  s.ReportNumber is not null and  StatusID=0 and (sr.IsDeleted is null or sr.IsDeleted=0)").ToList();

            if (pendingList.Count > 0)
            {
                foreach (SqlQueryModels.TestReporting testReporting in pendingList)
                {
                    var obj = new TestReporting()
                    {
                        TestReportingID = testReporting.TestReportingID,
                        FKSampleReceiveTestID = testReporting.FKSampleReceiveTestID,
                        StatusID = testReporting.StatusID,
                        RevisionNo = testReporting.RevisionNo,
                        IsRevised = testReporting.IsRevised,
                        SampleNumber = testReporting.SampleNumber,
                        FKProjectID = testReporting.FKProjectID,
                        FKTestID = testReporting.FKTestID,
                        FKCustomerID = testReporting.FKCustomerID,
                        ReportNumber = testReporting.ReportNumber,
                        SampleReceivedDate = testReporting.SampleReceivedDate,
                        TestEndingDate = testReporting.TestEndingDate,
                        LabName = testReporting.LabName,
                        StandardNumber = testReporting.StandardNumber,
                        CustomerName = testReporting.CustomerName,
                        TestName = testReporting.TestName,
                        TestRequiredTime = testReporting.TestRequiredTime,                        
                        SuggestedTestingDate = testReporting.SuggestedTestingDate

                    };

                    string ext = ".xlsx";
                    if (!string.IsNullOrWhiteSpace(testReporting.WorkFormFileName))
                        ext = Path.GetExtension(testReporting.WorkFormFileName);
                    ////============================================================================
                   
                    string filePath = string.Format(@"{0}\{1}\{2}{3}", pathread, testReporting.SampleNumber, testReporting.ReportNumber, ext);
                    filePath = RemoveExtraBackslashes(filePath);
                    if (File.Exists(filePath))
                    {
                        ext = ".xlsx";
                        //filePath = string.Format(@"{0}\{1}\{2}{3}", path, testReporting.SampleNumber, testReporting.ReportNumber, ext);
                         filePath = string.Format(@"{0}\{1}\{2}{3}", path, testReporting.SampleNumber, testReporting.ReportNumber, ext);
                        filePath = RemoveExtraBackslashes(filePath);
                    }
                    else if (!File.Exists(filePath))
                    {
                        ext = ".xlsm";
                        filePath = string.Format(@"{0}\{1}\{2}{3}", path, testReporting.SampleNumber, testReporting.ReportNumber, ext);
                        filePath = RemoveExtraBackslashes(filePath);
                    }

                    //if (testReporting.RevisionNo > 0)
                    //{
                    //    string fileName = string.Format("{0}-A0{1}{2}", testReporting.ReportNumber, testReporting.RevisionNo, ext);
                    //    filePath = string.Format(@"{0}\{1}\{2}", path, testReporting.SampleNumber, fileName);
                    //}
                    //  if (File.Exists(filePath))
                    //    {
                    //    LoadOptions loadOptions = new LoadOptions();
                    //    loadOptions.Password = testReporting.SampleNumber;
                    //    //Instantiate the License class

                    //    Aspose.Cells.License license = new Aspose.Cells.License();

                    //    //Pass only the name of the license file embedded in the assembly

                    //    license.SetLicense("D:/PLSM_Site_code/LaboratoryLayer_PLSM/packages/Aspose New/License.lic");

                    //    using (Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook(filePath, loadOptions))
                    //        {                          
                    //        Aspose.Cells.Worksheet worksheet = workbook.Worksheets[0];                           
                    //        int rowIndex = 41; // Replace with the actual row index
                    //        int columnIndex = 2; // Replace with the actual column index (Column B is 1)
                           
                    //        try
                    //        {
                    //            string cellValue = worksheet.Cells[rowIndex, columnIndex].Value.ToString();
                              
                    //            DateTime parsedDate;
                    //            if (DateTime.TryParseExact(cellValue, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate))
                    //            {
                    //                // Date parsing was successful, you can use 'parsedDate' here.
                    //            }
                    //            obj.TestEndingDate = parsedDate;
                    //        }
                    //        catch (NullReferenceException ex)
                    //        {
                    //            // Handle the exception
                    //            Console.WriteLine("A NullReferenceException occurred: " + ex.Message);
                    //            // You can log the exception or take appropriate action here
                    //        }

                    //    }


                    //}                  

                    filePath = string.Format(@"localexplorer:{0}", filePath);

                    obj.FileUrl = filePath;
                   
                    //updatetestendingdate(testReporting.FKSampleReceiveTestID, obj.ReportingDate);
                    testReportings.Add(obj);
                }

                return testReportings.OrderByDescending(t => t.ReportNumber).ToList();
            }

            return testReportings;
        }

        public List<TestReporting> GetPendingToCheck()
        {
            List<TestReporting> testReportings = new List<TestReporting>();
            var pendingList = dbContext.Database.SqlQuery<SqlQueryModels.TestReporting>(@"select 
TestReportingID = t.TestReportingID,
FKSampleReceiveTestID = t.FKSampleReceiveTestID,
LabName = ll.LabName,
StatusID = t.StatusID,
RevisionNo = t.RevisionNo,
IsRevised = t.IsRevised,
SampleNumber = sr.SampleNo,
FKProjectID = sr.FKProjectID,
FKTestID = s.FKTestID,
FKCustomerID = sr.FKCustomerID,
ReportNumber = Isnull(s.ReportNumber,0),
SampleReceivedDate = sr.ReceiveDate,
WorkFormFileName = tl.WorkFormFileName,
TestEndingDate = t.TestEndingDate,
EnteredDate = t.EnteredDate,
StandardNumber =tl.StandardNumber,
CustomerName = cl.CustomerName, 
TestName = tl.TestName,
TestRequiredTime = isnull(tl.TestRequiredTime,0),
SuggestedTestingDate = t.SuggestedTestingDate


from TestReporting t
inner join SampleReceiveTestList s on t.FKSampleReceiveTestID=s.SampleReceiveTestID
left join TestsList tl on s.FKTestID= tl.TestID
inner join LabsList ll on tl.FKLabID = ll.LabID
inner join SampleReceiveList sr on  s.FKSampleID=sr.SampleID 
inner join CustomersList cl on sr.FKCustomerID = cl.CustomerID
where StatusID=1 and (sr.IsDeleted is null or sr.IsDeleted=0)
order by t.TestReportingID desc").ToList();
            if (pendingList.Count > 0)
            {
                foreach (SqlQueryModels.TestReporting testReporting in pendingList)
                {
                    var obj = new TestReporting()
                    {
                        TestReportingID = testReporting.TestReportingID,
                        FKSampleReceiveTestID = testReporting.FKSampleReceiveTestID,
                        StatusID = testReporting.StatusID,
                        RevisionNo = testReporting.RevisionNo,
                        IsRevised = testReporting.IsRevised,
                        SampleNumber = testReporting.SampleNumber,
                        FKProjectID = testReporting.FKProjectID,
                        FKTestID = testReporting.FKTestID,
                        FKCustomerID = testReporting.FKCustomerID,
                        ReportNumber = testReporting.ReportNumber,
                        SampleReceivedDate = testReporting.SampleReceivedDate,
                        TestEndingDate = testReporting.TestEndingDate,
                        EnteredDate = testReporting.EnteredDate,
                        LabName = testReporting.LabName,
                        StandardNumber = testReporting.StandardNumber,
                           CustomerName = testReporting.CustomerName,
                        TestName = testReporting.TestName,
                        TestRequiredTime = testReporting.TestRequiredTime,
                        SuggestedTestingDate = testReporting.SuggestedTestingDate

                    };
                    string ext = ".pdf";
                    string filePath = string.Format(@"{0}{1}\{2}\{3}{4}", path, testReporting.SampleNumber, "PDFReport", testReporting.ReportNumber, ext);
                    //if (testReporting.RevisionNo > 0)
                    //{
                    //    string fileName = string.Format("{0}-A0{1}{2}", testReporting.ReportNumber, testReporting.RevisionNo, ext);
                    //    filePath = string.Format(@"{0}\{1}\{2}", path, testReporting.SampleNumber, fileName);
                    //}
                    //string mypath = string.Format(@"{0}\{1}\{2}{3}", path, testReporting.SampleNumber, testReporting.ReportNumber, ".xlsx");
                    //mypath = RemoveExtraBackslashes(mypath);
                    //if (File.Exists(mypath))
                    //{
                    //    using (Workbook workbook = new Workbook())
                    //    {
                    //        // Load the Excel file
                    //        workbook.LoadDocument(string.Format(@"{0}\{1}\{2}{3}", path, testReporting.SampleNumber, testReporting.ReportNumber, ".xlsx"));

                    //        // Assuming you want to read from the first worksheet (index 0)
                    //        Worksheet worksheet = workbook.Worksheets[0];

                    //        // Specify the row and column indices (0-based) of the cell you want to read
                    //        int rowIndex = 55; // Replace with the actual row index
                    //        int columnIndex = 2; // Replace with the actual column index (Column B is 1)
                    //        DateTime dateTime;
                    //        // Get the cell value
                    //        string cellValue = worksheet.Cells[rowIndex, columnIndex].Value.ToString();
                    //        if (DateTime.TryParse(cellValue, out dateTime))
                    //        {
                    //            // Parsing succeeded, and "dateTime" contains the parsed date and time
                    //        }
                    //        else
                    //        {
                    //            // Parsing failed; handle the error
                    //        }
                    //        obj.TestEndingDate = dateTime;
                    //        //testReportings.Add(obj);
                    //        // Now, "cellValue" contains the value of the specified cell
                    //        //Console.WriteLine("Cell Value: " + cellValue);
                    //    }

                    //    //===============================================================================
                    //}
                    ////if (!File.Exists(filePath))
                    //    filePath = string.Empty;
                    //else
                    filePath = string.Format(@"localexplorer:{0}", filePath);

                    obj.FileUrl = filePath;
                    testReportings.Add(obj);
                }
            }

            return testReportings;
        }

        public List<TestReporting> GetPendingToApprove()
        {
            List<TestReporting> testReportings = new List<TestReporting>();
            var pendingList = dbContext.Database.SqlQuery<SqlQueryModels.TestReporting>(@"select 
TestReportingID = t.TestReportingID,
LabName = ll.LabName,

FKSampleReceiveTestID = t.FKSampleReceiveTestID,
StatusID = t.StatusID,
RevisionNo = t.RevisionNo,
IsRevised = t.IsRevised,
SampleNumber = sr.SampleNo,
FKProjectID = sr.FKProjectID,
FKTestID = s.FKTestID,
FKCustomerID = sr.FKCustomerID,
ReportNumber = Isnull(s.ReportNumber,0),
SampleReceivedDate = sr.ReceiveDate,
WorkFormFileName = tl.WorkFormFileName,
TestEndingDate = t.TestEndingDate,
CheckedDate = t.CheckedDate,
StandardNumber =tl.StandardNumber,
CustomerName = cl.CustomerName, 
TestName = tl.TestName,
TestRequiredTime = isnull(tl.TestRequiredTime,0)


from TestReporting t
inner join SampleReceiveTestList s on t.FKSampleReceiveTestID=s.SampleReceiveTestID
left join TestsList tl on s.FKTestID= tl.TestID
inner join LabsList ll on tl.FKLabID = ll.LabID
inner join SampleReceiveList sr on  s.FKSampleID=sr.SampleID 
inner join CustomersList cl on sr.FKCustomerID = cl.CustomerID

where StatusID=2 and (sr.IsDeleted is null or sr.IsDeleted=0)
order by t.TestReportingID desc").ToList();

            if (pendingList.Count > 0)
            {
                foreach (SqlQueryModels.TestReporting testReporting in pendingList)
                {
                    var obj = new TestReporting()
                    {
                        TestReportingID = testReporting.TestReportingID,
                        FKSampleReceiveTestID = testReporting.FKSampleReceiveTestID,
                        StatusID = testReporting.StatusID,
                        RevisionNo = testReporting.RevisionNo,
                        IsRevised = testReporting.IsRevised,
                        SampleNumber = testReporting.SampleNumber,
                        FKProjectID = testReporting.FKProjectID,
                        FKTestID = testReporting.FKTestID,
                        FKCustomerID = testReporting.FKCustomerID,
                        ReportNumber = testReporting.ReportNumber,
                        SampleReceivedDate = testReporting.SampleReceivedDate,
                        TestEndingDate = testReporting.TestEndingDate,
                        CheckedDate = testReporting.CheckedDate,
                        LabName = testReporting.LabName,
                        StandardNumber = testReporting.StandardNumber,
                        CustomerName = testReporting.CustomerName,
                        TestName = testReporting.TestName,
                        TestRequiredTime = testReporting.TestRequiredTime

                    };
                    string ext = ".pdf";
                    string filePath = string.Format(@"{0}{1}\{2}\{3}{4}", path, testReporting.SampleNumber, "PDFReport", testReporting.ReportNumber, ext);
                    //if (testReporting.RevisionNo > 0)
                    //{
                    //    string fileName = string.Format("{0}-A0{1}{2}", testReporting.ReportNumber, testReporting.RevisionNo, ext);
                    //    filePath = string.Format(@"{0}\{1}\{2}", path, testReporting.SampleNumber, fileName);
                    //}

                    //if (!File.Exists(filePath))
                    //    filePath = string.Empty;
                    //else
                    filePath = string.Format(@"localexplorer:{0}", filePath);

                    obj.FileUrl = filePath;
                    testReportings.Add(obj);
                }
            }

            return testReportings;
        }

        public List<TestReporting> GetAllCompleted()
        {
            List<TestReporting> testReportings = new List<TestReporting>();
            var pendingList = dbContext.Database.SqlQuery<SqlQueryModels.TestReporting>(@"select 
TestReportingID = t.TestReportingID,
LabName = ll.LabName,

FKSampleReceiveTestID = t.FKSampleReceiveTestID,
StatusID = t.StatusID,
RevisionNo = t.RevisionNo,
IsRevised = t.IsRevised,
SampleNumber = sr.SampleNo,
FKProjectID = sr.FKProjectID,
FKTestID = s.FKTestID,
FKCustomerID = sr.FKCustomerID,
ReportNumber = Isnull(s.ReportNumber,0),
SampleReceivedDate = sr.ReceiveDate,
WorkFormFileName = tl.WorkFormFileName,
TestEndingDate = t.TestEndingDate,
ReportingDate = t.ReportingDate,
StandardNumber =tl.StandardNumber,
CustomerName = cl.CustomerName, 
TestName = tl.TestName,
TestRequiredTime = isnull(tl.TestRequiredTime,0)


from TestReporting t
inner join SampleReceiveTestList s on t.FKSampleReceiveTestID=s.SampleReceiveTestID
left join TestsList tl on s.FKTestID= tl.TestID
inner join LabsList ll on tl.FKLabID = ll.LabID

inner join SampleReceiveList sr on  s.FKSampleID=sr.SampleID 
inner join CustomersList cl on sr.FKCustomerID = cl.CustomerID

where StatusID=3 and (sr.IsDeleted is null or sr.IsDeleted=0)
order by t.TestReportingID desc").ToList();
            if (pendingList.Count > 0)
            {
                foreach (SqlQueryModels.TestReporting testReporting in pendingList)
                {
                    var obj = new TestReporting()
                    {
                        TestReportingID = testReporting.TestReportingID,
                        FKSampleReceiveTestID = testReporting.FKSampleReceiveTestID,
                        StatusID = testReporting.StatusID,
                        RevisionNo = testReporting.RevisionNo,
                        IsRevised = testReporting.IsRevised,
                        SampleNumber = testReporting.SampleNumber,
                        FKProjectID = testReporting.FKProjectID,
                        FKTestID = testReporting.FKTestID,
                        FKCustomerID = testReporting.FKCustomerID,
                        ReportNumber = testReporting.ReportNumber,
                        SampleReceivedDate = testReporting.SampleReceivedDate,
                        TestEndingDate = testReporting.TestEndingDate,
                        ReportingDate = testReporting.ReportingDate,
                        LabName = testReporting.LabName,
                         StandardNumber = testReporting.StandardNumber,
                        CustomerName = testReporting.CustomerName,
                        TestName= testReporting.TestName,
                        TestRequiredTime = testReporting.TestRequiredTime


                    };
                    string ext = ".pdf";
                    string filePath = string.Format(@"{0}{1}\{2}\{3}{4}", path, testReporting.SampleNumber, "PDFReport", testReporting.ReportNumber, ext);

                    if (testReporting.RevisionNo > 0)
                    {
                        string fileName = string.Format("{0}-A0{1}{2}", testReporting.ReportNumber, testReporting.RevisionNo, ext);
                        filePath = string.Format(@"{0}{1}\{2}\{3}", path, testReporting.SampleNumber, "PDFReport",fileName);
                    }
                    if (testReporting.RevisionNo == 0 && testReporting.IsRevised==true)
                    {
                        string fileName = string.Format("{0}-A0{1}{2}", testReporting.ReportNumber, "0", ext);
                        filePath = string.Format(@"{0}{1}\{2}\{3}", path, testReporting.SampleNumber, "PDFReport", fileName);
                    }
                    //if (!File.Exists(filePath))
                    //    filePath = string.Empty;
                    //else
                    filePath = string.Format(@"localexplorer:{0}", filePath);

                    obj.FileUrl = filePath;
                    testReportings.Add(obj);
                }
            }

            return testReportings;
        }


        static string RemoveExtraBackslashes(string input)
        {
            char prevChar = '\0';
            string result = "";

            foreach (char c in input)
            {
                if (c == '\\' && prevChar == '\\')
                {
                    // Skip the extra backslash
                }
                else
                {
                    result += c;
                }

                prevChar = c;
            }

            return result;
            //// Use regular expression to match 3 or more consecutive backslashes
            //string pattern = @"\\{3,}";
            //string replacement = "\\"; // Replace with a single backslash
            //string result = Regex.Replace(input, pattern, replacement);

            //return result;
        }
        /*
        public List<TestReporting> GetAllPending()
        {
            List<TestReporting> testReportings = new List<TestReporting>();
            var pendingList = (from x in (IQueryable<TestReporting>)dbContext.TestReportings
                               where x.StatusID == 0
                               //orderby x.TestReportingID descending
                               select x).ToList();
            if (pendingList.Count > 0)
            {
                foreach (TestReporting testReporting in pendingList)
                {
                    SampleReceiveTestList sampleReceiveTestList = testReporting.SampleReceiveTestList;
                    SampleReceiveList sampleReceiveList = new SampleReceiveListDB().GetByID(sampleReceiveTestList.FKSampleID.Value);
                    TestsList testsList = sampleReceiveTestList.TestsList;
                    testReporting.FKTestID = sampleReceiveTestList.FKTestID.Value;
                    testReporting.ReportNumber = sampleReceiveTestList.ReportNumber.GetValueOrDefault(0);
                    testReporting.SampleNumber = sampleReceiveList.SampleNo;
                    testReporting.FKCustomerID = sampleReceiveList.FKCustomerID.Value;
                    testReporting.FKProjectID = sampleReceiveList.FKProjectID.Value;
                    testReporting.SampleReceivedDate = sampleReceiveList.ReceiveDate.Value;

                    string ext = ".xlsx";
                    if (testsList != null && !string.IsNullOrWhiteSpace(testsList.WorkFormFileName))
                        ext = Path.GetExtension(testsList.WorkFormFileName);

                    string filePath = string.Format(@"{0}\{1}\{2}{3}", path, sampleReceiveList.SampleNo, sampleReceiveTestList.ReportNumber, ext);

                    if (testReporting.RevisionNo > 0)
                    {
                        string fileName = string.Format("{0}-A0{1}{2}", sampleReceiveTestList.ReportNumber, testReporting.RevisionNo, ext);
                        filePath = string.Format(@"{0}\{1}\{2}", path, sampleReceiveList.SampleNo, fileName);
                    }

                    //if (!File.Exists(filePath))
                    //    filePath = string.Empty;
                    //else
                        filePath = string.Format(@"localexplorer:{0}", filePath);

                    testReporting.FileUrl = filePath;
                    testReportings.Add(testReporting);
                }

                return testReportings.OrderByDescending(t => t.ReportNumber).ToList();
            }

            return testReportings;
        }

        public List<TestReporting> GetPendingToCheck()
        {
            List<TestReporting> testReportings = new List<TestReporting>();
            var pendingList = (from x in (IQueryable<TestReporting>)dbContext.TestReportings
                               where x.StatusID == 1
                               orderby x.TestReportingID descending
                               select x).ToList();
            if (pendingList.Count > 0)
            {
                foreach (TestReporting testReporting in pendingList)
                {
                    SampleReceiveTestList sampleReceiveTestList = testReporting.SampleReceiveTestList;
                    SampleReceiveList sampleReceiveList = new SampleReceiveListDB().GetByID(sampleReceiveTestList.FKSampleID.Value);
                    testReporting.FKTestID = sampleReceiveTestList.FKTestID.Value;
                    testReporting.ReportNumber = sampleReceiveTestList.ReportNumber.Value;
                    testReporting.SampleNumber = sampleReceiveList.SampleNo;
                    testReporting.FKCustomerID = sampleReceiveList.FKCustomerID.Value;
                    testReporting.FKProjectID = sampleReceiveList.FKProjectID.Value;
                    testReporting.SampleReceivedDate = sampleReceiveList.ReceiveDate.Value;

                    TestsList testsList = sampleReceiveTestList.TestsList;
                    string ext = ".pdf";
                    string filePath = string.Format(@"{0}\{1}\{2}{3}", path, sampleReceiveList.SampleNo, sampleReceiveTestList.ReportNumber, ext);
                    if (testReporting.RevisionNo > 0)
                    {
                        string fileName = string.Format("{0}-A0{1}{2}", sampleReceiveTestList.ReportNumber, testReporting.RevisionNo, ext);
                        filePath = string.Format(@"{0}\{1}\{2}", path, sampleReceiveList.SampleNo, fileName);
                    }

                    //if (!File.Exists(filePath))
                    //    filePath = string.Empty;
                    //else
                        filePath = string.Format(@"localexplorer:{0}", filePath);

                    testReporting.FileUrl = filePath;
                    testReportings.Add(testReporting);
                }
            }

            return testReportings;
        }

        public List<TestReporting> GetPendingToApprove()
        {
            List<TestReporting> testReportings = new List<TestReporting>();
            var pendingList = (from x in (IQueryable<TestReporting>)dbContext.TestReportings
                               where x.StatusID == 2
                               orderby x.TestReportingID descending
                               select x).ToList();

            if (pendingList.Count > 0)
            {
                foreach (TestReporting testReporting in pendingList)
                {
                    SampleReceiveTestList sampleReceiveTestList = testReporting.SampleReceiveTestList;
                    SampleReceiveList sampleReceiveList = new SampleReceiveListDB().GetByID(sampleReceiveTestList.FKSampleID.Value);
                    testReporting.FKTestID = sampleReceiveTestList.FKTestID.Value;
                    testReporting.ReportNumber = sampleReceiveTestList.ReportNumber.Value;
                    testReporting.SampleNumber = sampleReceiveList.SampleNo;
                    testReporting.FKCustomerID = sampleReceiveList.FKCustomerID.Value;
                    testReporting.FKProjectID = sampleReceiveList.FKProjectID.Value;
                    testReporting.SampleReceivedDate = sampleReceiveList.ReceiveDate.Value;

                    TestsList testsList = sampleReceiveTestList.TestsList;
                    string ext = ".pdf";
                    string filePath = string.Format(@"{0}\{1}\{2}{3}", path, sampleReceiveList.SampleNo, sampleReceiveTestList.ReportNumber, ext);
                    if (testReporting.RevisionNo > 0)
                    {
                        string fileName = string.Format("{0}-A0{1}{2}", sampleReceiveTestList.ReportNumber, testReporting.RevisionNo, ext);
                        filePath = string.Format(@"{0}\{1}\{2}", path, sampleReceiveList.SampleNo, fileName);
                    }

                    //if (!File.Exists(filePath))
                    //    filePath = string.Empty;
                    //else
                        filePath = string.Format(@"localexplorer:{0}", filePath);

                    testReporting.FileUrl = filePath;
                    testReportings.Add(testReporting);
                }
            }

            return testReportings;
        }

        public List<TestReporting> GetAllCompleted()
        {
            List<TestReporting> testReportings = new List<TestReporting>();
            var pendingList = (from x in (IQueryable<TestReporting>)dbContext.TestReportings
                               where x.StatusID == 3
                               orderby x.TestReportingID descending
                               select x).ToList();
            if (pendingList.Count > 0)
            {
                foreach (TestReporting testReporting in pendingList)
                {
                    SampleReceiveTestList sampleReceiveTestList = testReporting.SampleReceiveTestList;
                    SampleReceiveList sampleReceiveList = new SampleReceiveListDB().GetByID(sampleReceiveTestList.FKSampleID.Value);
                    testReporting.FKTestID = sampleReceiveTestList.FKTestID.Value;
                    testReporting.ReportNumber = sampleReceiveTestList.ReportNumber.Value;
                    testReporting.SampleNumber = sampleReceiveList.SampleNo;
                    testReporting.FKCustomerID = sampleReceiveList.FKCustomerID.Value;
                    testReporting.FKProjectID = sampleReceiveList.FKProjectID.Value;
                    testReporting.SampleReceivedDate = sampleReceiveList.ReceiveDate.Value;

                    TestsList testsList = sampleReceiveTestList.TestsList;
                    string ext = ".pdf";
                    string filePath = string.Format(@"{0}\{1}\{2}{3}", path, sampleReceiveList.SampleNo, sampleReceiveTestList.ReportNumber, ext);

                    if (testReporting.RevisionNo > 0)
                    {
                        string fileName = string.Format("{0}-A0{1}{2}", sampleReceiveTestList.ReportNumber, testReporting.RevisionNo, ext);
                        filePath = string.Format(@"{0}\{1}\{2}", path, sampleReceiveList.SampleNo, fileName);
                    }

                    //if (!File.Exists(filePath))
                    //    filePath = string.Empty;
                    //else
                        filePath = string.Format(@"localexplorer:{0}", filePath);

                    testReporting.FileUrl = filePath;
                    testReportings.Add(testReporting);
                }
            }

            return testReportings;
        }

        */
        protected void updatetestendingdate(long SampleReceiveTestID, DateTime TestEndDate)
        {
            //SampleReceiveTestListDB sampleReceiveTestListDB = new SampleReceiveTestListDB();
            //List<SampleReceiveTestList> receiveTestLists = sampleReceiveTestListDB.GetByReportNumber(receiveTestList.ReportNumber.GetValueOrDefault(0));

            //foreach (SampleReceiveTestList testList in receiveTestLists)
            //{
            //    if (testList.SampleReceiveTestID == receiveTestList.SampleReceiveTestID)
            //        continue;
            TestReporting testReporting = new TestReportingDB().GetByReportNumber(SampleReceiveTestID);
            if (TestEndDate != null && TestEndDate != DateTime.MinValue)
            {
                
                    testReporting.TestEndingDate = TestEndDate;
                    new TestReportingDB().Update(testReporting);
                
                
            }
           
        }
    }
}
