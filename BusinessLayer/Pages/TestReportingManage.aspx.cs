using BusinessLayer;
using BusinessLayer.Admin;
using BusinessLayer.Pages;
using DevExpress.Spreadsheet;
using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Web.UI;
using System.Linq;
using System.Data;
using System.Web.UI.HtmlControls;
using DevExpress.Web;
namespace LaboratoryLayer.Pages
{
    // Token: 0x02000019 RID: 25
    public class TestReportingManage : Page
    {
        // Token: 0x060000D6 RID: 214 RVA: 0x00002071 File Offset: 0x00000271
        int ScannedLabWSSTransactionTypeID = 111222;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!base.IsPostBack)
            {
                if (base.Session["CurrentUser"] == null)
                {
                    string str = "?redUri=" + base.Request.Url.ToString();
                    base.Response.Redirect("~/Login.aspx" + str);
                    return;
                }
                ADMUsers admusers = base.Session["CurrentUser"] as ADMUsers;
                //this.UserName.InnerText = admusers.EName;
                RolesDB rolesDB = new RolesDB();
                new UserRolesDB();
                List<ADMRoles> list = (from i in rolesDB.GetAll()
                                       where i.UserType == Convert.ToInt32(base.Session["UserType"])
                                       select i).ToList<ADMRoles>();
                List<ADMCategoryMaster> list2 = new List<ADMCategoryMaster>();
                if (Convert.ToInt32(base.Session["UserType"]) == 1)
                {
                    UsersDB usersDB = new UsersDB();
                    ADMUsers admusers2 = base.Session["CurrentUser"] as ADMUsers;
                    int userID = admusers2.UserID;
                    ADMUsers byID = usersDB.GetByID(userID);
                    List<ADMUserRoles> list3 = byID.ADMUserRoles.ToList<ADMUserRoles>();
                    ModuleDB moduleDB = new ModuleDB();
                    List<ADMModules> modules = moduleDB.GetAllByRoles(list3);
                    foreach (ADMModules module in modules)
                    {
                        CategoryMasterDB categoryMasterDB = new CategoryMasterDB();
                        List<ADMCategoryMaster> masters = categoryMasterDB.GetByModuleId(module.ModuleID);
                        foreach (ADMCategoryMaster master in masters)
                        {
                            list2.Add(master);
                        }
                    }
                    //this.FillSideMenu(list2, list3);
                    this.reportvisibilty();
                    return;
                }
            }
            }
        protected void GdvPendingToReport_HtmlRowCreated(object sender, ASPxGridViewTableRowEventArgs e)
        {
            if (e.RowType == GridViewRowType.Data)
            {
                ASPxGridView aspxGridView = (ASPxGridView)sender;
                HtmlGenericControl htmlGenericControl = (HtmlGenericControl)aspxGridView.FindRowCellTemplateControlByKey(e.KeyValue,
                    (GridViewDataColumn)aspxGridView.Columns["Attachment"], "attchCount");
                AttachedFilesDB attachedFilesDB = new AttachedFilesDB();

                htmlGenericControl.InnerText = attachedFilesDB.GetAttachmentsCount(Convert.ToInt64(e.KeyValue), ScannedLabWSSTransactionTypeID).ToString();

                           HtmlGenericControl GetScannedLabWshtmlGenericControl = (HtmlGenericControl)aspxGridView.FindRowCellTemplateControlByKey(e.KeyValue,
                    (GridViewDataColumn)aspxGridView.Columns["ScannedLabWS"], "ScannedLabWS");
                if (GetScannedLabWshtmlGenericControl != null)
                {
                    GetScannedLabWshtmlGenericControl.InnerHtml = attachedFilesDB.GetScannedLabWs(Convert.ToInt64(e.KeyValue), ScannedLabWSSTransactionTypeID).ToString();
                }
            }
        }
        private void reportvisibilty()
        {
            var roleLinks = new UserRolesDB().GetAllOptionsForUser(int.Parse(this.Session["UserId"].ToString()));
            if (!roleLinks.Any(c => c.LinksEName == "Test Reporting Pending To Report"))
            {
                PendingToReport.Attributes["class"] = "hidden";
            }
            if (!roleLinks.Any(c => c.LinksEName == "Test Reporting Pending To Check"))
            {
                this.PendingToCheck.Attributes["class"] = "hidden";
            }
            if (!roleLinks.Any(c => c.LinksEName == "Test Reporting Pending To Approve"))
            {
                this.PendingToApprove.Attributes["class"] = "hidden";
            }
            if (!roleLinks.Any(c => c.LinksEName == "Test Reporting Completed Report"))
            {
                this.CompleteReport.Attributes["class"] = "hidden";
            }


                //Waiting for Approval of Payment
            
            //new StringBuilder();
            Convert.ToDecimal(base.Session["StaffId"]);
            Convert.ToDecimal(base.Session["DepId"]);
            //List<ViewBendingEnquiryMaster> allPending = new EnquiryMasterDB().GetAllPending();
            //List<ViewNewQuotationMaster> allNew = new QuotationMasterDB().GetAllNew();
            //List<JobOrderMaster> allPending2 = new JobOrderMasterDB().GetAllPending();
            //int countUnapprovedPayments = new PaymentMasterDB().CountAllNonApprovedAvancedPayment();
        
                }
        protected void BtnSendForCheck_Init(object sender, EventArgs e)
        {
            ASPxButton btnSendForCheck = (ASPxButton)sender;
            GridViewDataItemTemplateContainer container = (GridViewDataItemTemplateContainer)btnSendForCheck.NamingContainer;

            object testEndingDateValue = container.Grid.GetRowValues(container.VisibleIndex, "TestEndingDate");

            if (testEndingDateValue == null || Convert.IsDBNull(testEndingDateValue) || string.IsNullOrEmpty(testEndingDateValue.ToString()))
            {
                btnSendForCheck.Visible = false;
            }
        }
        protected void GdvPendingToReport_RowCommand(object sender, ASPxGridViewRowCommandEventArgs e)
        {
            LblError.Text = "";
            int testReportingId = Convert.ToInt32(e.CommandArgs.CommandArgument.ToString());
            if (testReportingId != 0)
            {
                if (e.CommandArgs.CommandName == "sendforcheck")
                {

                    //var roleLinks = new UserRolesDB().GetAllOptionsForUser(int.Parse(this.Session["UserId"].ToString()));
                    //if (!roleLinks.Any(c => c.LinksEName == "Test Reporting Pending To Report" && c.OptionEName=="Add" ))
                    //{
                    //    LblError.Text = string.Format("You have not permision!");
                    //    return;
                    //}

                    TestReporting testReporting = new TestReportingDB().GetByID(testReportingId);
                    //if (testReporting.TestEndingDate == null)
                    //{
                    //    LblError.Text = string.Format("Please provide test ending date");
                    //    return;
                    //}
                    SampleReceiveTestListDB sampleReceiveTestListDB = new SampleReceiveTestListDB();
                    SampleReceiveTestList receiveTestList = sampleReceiveTestListDB.GetByID(testReporting.FKSampleReceiveTestID);

                    SampleReceiveListDB sampleReceiveListDB = new SampleReceiveListDB();
                    SampleReceiveList receiveList = sampleReceiveListDB.GetByID(receiveTestList.FKSampleID.GetValueOrDefault(0));
                    JobOrderMaster jobOrderMaster = new JobOrderMasterDB().GetByID((long)receiveList.FKJobOrderMasterID);
                    if (jobOrderMaster == null || !jobOrderMaster.IsReporting)
                    {
                        LblError.Text = string.Format("Reporting not allowed for '{0}' job order", receiveTestList.ReportNumber);
                        return;
                    }

                    //if (string.IsNullOrWhiteSpace(receiveTestList.TestsList.ReportWorksheet))
                    //    LblError.Text = string.Format("Blank report worksheet for '{0}' job order", receiveTestList.ReportNumber);

                    bool attached = false;                 
                    try
                    {
                        LblError.Text += string.Format("Creating file");
                        attached = CreateReportGroupPDF(receiveList, receiveTestList, testReporting);
                    }
                    catch (Exception ex)
                    {
                        LblError.Text += string.Format("Error New: {0}", ex.Message);
                        attached = false;
                    }

                    if (attached)
                    {
                        LblError.Text = "";
                        testReporting.StatusID = 1;
                        testReporting.EnteredDate = DateTime.Now;
                        new TestReportingDB().Update(testReporting);

                        UpdateStatusdate(receiveTestList, testReporting.StatusID, testReporting.TestEndingDate, "sendforcheck");
                        //var db = new TestReportingDB();
                        //db.dbContext.Database.ExecuteSqlCommand("Update TestReporting set TestEndingDate={0} FROM TestReporting INNER JOIN SampleReceiveTestList ON TestReporting.FKSampleReceiveTestID = SampleReceiveTestList.SampleReceiveTestID where SampleReceiveTestList.ReportNumber={1}", DateTime.Now, testReporting.ReportNumber);
                        ////FROM TestReporting INNER JOIN SampleReceiveTestList ON TestReporting.FKSampleReceiveTestID = SampleReceiveTestList.SampleReceiveTestID
                        //  WHERE(SampleReceiveTestList.ReportNumber = @ReportNumber)
                        //GdvPendingToReport.JSProperties["cpMessage"] =
                              GdvPendingToReport.SettingsText.Title="Report No: "+testReportingId.ToString()+" Sent for Check Successfully!!!"; 
                        GdvPendingToReport.DataBind();
                        GdvPendingToCheckReport.DataBind();
                        //Response.Redirect("TestReportingManage.aspx");
                    }
                    GdvPendingToCheckReport.SettingsText.Title = "";
                    GdvPendingToApproveReport.SettingsText.Title = "";
                }
            }

        }

        protected void GdvPendingToCheckReport_RowCommand(object sender, ASPxGridViewRowCommandEventArgs e)
        {
           
            int testReportingId = Convert.ToInt32(e.CommandArgs.CommandArgument.ToString());
            if (testReportingId != 0)
            {
                //var roleLinks = new UserRolesDB().GetAllOptionsForUser(int.Parse(this.Session["UserId"].ToString()));
                //if (!roleLinks.Any(c => c.LinksEName == "Test Reporting Pending To Check" && c.OptionEName == "Add"))
                //{
                //    LblError.Text = string.Format("You have not permision!");
                //    return;
                //}

                TestReporting testReporting = new TestReportingDB().GetByID(testReportingId);
                SampleReceiveTestListDB sampleReceiveTestListDB = new SampleReceiveTestListDB();
                SampleReceiveTestList receiveTestList = sampleReceiveTestListDB.GetByID(testReporting.FKSampleReceiveTestID);

                //if (e.CommandArgs.CommandName == "download")
                //    DownloadPDF(testReportingId);
                //else 
                if (e.CommandArgs.CommandName == "check")
                {
                    //bool attached = CreatePDF(testReporting, receiveTestList.TestsList, true); 
                    //bool attached = CreateReportGroupPDF(receiveTestList.SampleReceiveList, receiveTestList, testReporting);
                    //if (attached)
                    //{
                        testReporting.CheckedDate = DateTime.Now;
                        testReporting.StatusID = 2;
                        new TestReportingDB().Update(testReporting);
                        UpdateStatus(receiveTestList, testReporting.StatusID);
                        GdvPendingToCheckReport.DataBind();
                        GdvPendingToApproveReport.DataBind();
                    
                    if (!AttachSignature(testReporting,true))
                       // GdvPendingToCheckReport.JSProperties["cpMessage"] =
                              GdvPendingToCheckReport.SettingsText.Title="Report Number: " + testReportingId.ToString() + " Checked Successfully without Attaching Signature!!!";
                      
                    else
                      //  GdvPendingToCheckReport.JSProperties["cpMessage"]
                              GdvPendingToCheckReport.SettingsText.Title = "Report Number: " + testReportingId.ToString() + " Checked Successfully!!!";


                    LblError.Text="";
                    //}
                }
                else if (e.CommandArgs.CommandName == "reject")
                {
                    testReporting.StatusID = 0;
                    new TestReportingDB().Update(testReporting);
                    UpdateStatus(receiveTestList, testReporting.StatusID);
                    GdvPendingToCheckReport.DataBind();
                    GdvPendingToReport.DataBind();
                   // GdvPendingToCheckReport.JSProperties["cpMessage"]
                        GdvPendingToCheckReport.SettingsText.Title = "Report Number: " + testReportingId.ToString() + " Reject Successfully!!!";
                    LblError.Text = "";

                    // Response.Redirect("TestReportingManage.aspx");
                }
                GdvPendingToReport.SettingsText.Title = "";
                GdvPendingToApproveReport.SettingsText.Title = "";

            }

        }
        // Load the Excel file
        //protected void LoadExcelData(string filePath)
        //{
        //    // Create a workbook object
        //    using (Workbook workbook = new Workbook())
        //    {
        //        // Load the Excel file
        //        workbook.LoadDocument(filePath);

        //        // Assuming you want to read data from the first worksheet (index 0)
        //        Worksheet worksheet = workbook.Worksheets[0];

        //        // Get the used range of cells
        //        CellRange usedRange = worksheet.GetUsedRange();

        //        // Convert the used range to a DataTable
        //        DataTable dataTable = worksheet.CreateDataTable(usedRange, true);

        //        // Now you have the Excel data in a DataTable
        //        // You can use it as needed
        //        // For example, bind it to a GridView:
        //        //gridView.DataSource = dataTable;
        //        //gridView.DataBind();
        //    }
        //}
        protected void GdvPendingToApproveReport_RowCommand(object sender, ASPxGridViewRowCommandEventArgs e)
        {
            int testReportingId = Convert.ToInt32(e.CommandArgs.CommandArgument.ToString());
            if (testReportingId != 0)
            {
                var roleLinks = new UserRolesDB().GetAllOptionsForUser(int.Parse(this.Session["UserId"].ToString()));
                if (!roleLinks.Any(c => c.LinksEName == "Test Reporting Pending To Approve" && c.OptionEName == "Add"))
                {
                    LblError.Text = string.Format("You have not permision!");
                    return;
                }

                SampleReceiveTestListDB sampleReceiveTestListDB = new SampleReceiveTestListDB();
                TestReporting testReporting = new TestReportingDB().GetByID(testReportingId);
                SampleReceiveTestList receiveTestList = sampleReceiveTestListDB.GetByID(testReporting.FKSampleReceiveTestID);

                //if (e.CommandArgs.CommandName == "download")
                //{
                //    SampleReceiveTestList receiveTestList = sampleReceiveTestListDB.GetByID(testReporting.FKSampleReceiveTestID);
                //    DownloadPDF(testReportingId, receiveTestList.TestsList);
                //}
                //else 
                if (e.CommandArgs.CommandName == "approve")
                {
                    //bool attached = CreatePDF(testReporting, receiveTestList.TestsList, false);
                    //bool attached = CreateReportGroupPDF(receiveTestList.SampleReceiveList, receiveTestList, testReporting);
                    //if (attached)
                    //{
                    //testReporting.StatusID = 3;
                    //new TestReportingDB().Update(testReporting);
                    //UpdateStatus(receiveTestList, testReporting.StatusID);
                    ///===============================================================
                    
                        testReporting.StatusID = 3;
                       testReporting.ReportingDate = DateTime.Now;
                        new TestReportingDB().Update(testReporting);

                       UpdateStatusdate(receiveTestList, testReporting.StatusID, DateTime.Now, "approve");
                        ///////
                        GdvPendingToApproveReport.DataBind();
                        GdvCompletedReport.DataBind();
                    if (!AttachSignature(testReporting, false))
                        //GdvPendingToApproveReport.JSProperties["cpMessage"]
                            GdvPendingToApproveReport.SettingsText.Title = "Report Number: " + testReportingId.ToString() + " Approved Successfully without Attaching Signature!!!";
                    else
                        GdvPendingToApproveReport.SettingsText.Title = "Report Number: " + testReportingId.ToString() + " Approved Successfully!!!";
                    LblError.Text = "";

                    // Response.Redirect("TestReportingManage.aspx");
                    //}
                }
                else if (e.CommandArgs.CommandName == "reject")
                {
                    //TestReporting testReporting = new TestReportingDB().GetByID(testReportingId);
                    testReporting.StatusID = 0;
                    testReporting.ReportingDate = DateTime.Now;
                    new TestReportingDB().Update(testReporting);
                    GdvPendingToApproveReport.SettingsText.Title = "Report Number: " + testReportingId.ToString() + " Rejected Successfully!!!";
                    //UpdateStatusdate(receiveTestList, testReporting.StatusID, DateTime.Now);
                    //new TestReportingDB().Update(testReporting);
                    //UpdateStatus(receiveTestList, testReporting.StatusID);
                    GdvPendingToApproveReport.DataBind();
                    GdvPendingToCheckReport.DataBind();
                    GdvPendingToReport.DataBind();
                    LblError.Text = "";

                    //  Response.Redirect("TestReportingManage.aspx");
                }
                GdvPendingToCheckReport.SettingsText.Title = "";
                GdvPendingToReport.SettingsText.Title = "";
            }
        }

        protected void GdvCompletedReport_RowCommand(object sender, ASPxGridViewRowCommandEventArgs e)
        {

            int testReportingId = Convert.ToInt32(e.CommandArgs.CommandArgument.ToString());
            if (testReportingId != 0)
            {
                var roleLinks = new UserRolesDB().GetAllOptionsForUser(int.Parse(this.Session["UserId"].ToString()));
                if (!roleLinks.Any(c => c.LinksEName == "Test Reporting Completed Report" && c.OptionEName == "Add"))
                {
                    LblError.Text = string.Format("You have not permision!");
                    return;
                }

                TestReporting testReporting = new TestReportingDB().GetByID(testReportingId);
                if (e.CommandArgs.CommandName == "Revise")
                {
                    testReporting.IsRevised = true;
                    new TestReportingDB().Update(testReporting);

                    TestReporting newTestReporting = new TestReporting();
                    newTestReporting.FKSampleReceiveTestID = testReporting.FKSampleReceiveTestID;
                    newTestReporting.RevisionNo = testReporting.RevisionNo + 1;
                    newTestReporting.StatusID = 0;
                    newTestReporting.IsRevised = false;
                    new TestReportingDB().Insert(newTestReporting);
                    newTestReporting = new TestReportingDB().GetByID(Convert.ToInt64(Session["TestReportingID"].ToString()));

                    string excelPath = GetFilePath(testReporting);//GetFilePath(testReporting, ".xlsx");
                    string newExcelPath = GetFilePath(newTestReporting);// GetFilePath(newTestReporting, ".xlsx");
                    if (File.Exists(excelPath))
                    {
                        File.Copy(excelPath, newExcelPath);

                        SampleReceiveTestListDB sampleReceiveTestListDB = new SampleReceiveTestListDB();
                        SampleReceiveTestList sampleReceiveTest = sampleReceiveTestListDB.GetByID(testReporting.FKSampleReceiveTestID);
                        List<TestExcelMapping> source = sampleReceiveTest.TestsList.TestExcelMappings.ToList();

                        string reportNo = string.Format("{0}-A0{1}", sampleReceiveTest.ReportNumber, newTestReporting.RevisionNo);

                        Workbook reportFile = new Workbook();
                        reportFile.LoadDocument(newExcelPath, DocumentFormat.Xlsx);
                        Worksheet newReportFileSheet = reportFile.Worksheets[sampleReceiveTest.TestsList.ReportWorksheet];
                        foreach (TestExcelMapping item3 in source.Where((TestExcelMapping x) => x.IsForReport).ToList())
                        {
                            try
                            {
                                if (string.IsNullOrWhiteSpace(item3.ExcelCell))
                                    continue;

                                if (item3.FieldName.ToLower() == "report number")
                                {
                                    newReportFileSheet.Cells[item3.ExcelCell].SetValue(reportNo);
                                    break;
                                }
                            }
                            catch (Exception ex)
                            {
                                System.Diagnostics.Debug.Assert(false);
                            }
                        }
                        reportFile.SaveDocument(newExcelPath, DocumentFormat.Xlsx);
                    }

                    Response.Redirect("TestReportingManage.aspx");
                }
                else if (e.CommandArgs.CommandName == "Print")
                {
                    SampleReceiveTestListDB sampleReceiveTestListDB = new SampleReceiveTestListDB();
                    SampleReceiveTestList receiveTestList = sampleReceiveTestListDB.GetByID(testReporting.FKSampleReceiveTestID);
                    DownloadPDF(testReportingId, receiveTestList.TestsList);
                }
                else if (e.CommandArgs.CommandName == "PrintWithDetails")
                {
                    SampleReceiveTestListDB sampleReceiveTestListDB = new SampleReceiveTestListDB();
                    SampleReceiveTestList receiveTestList = sampleReceiveTestListDB.GetByID(testReporting.FKSampleReceiveTestID);
                    DownloadPDF(testReportingId, receiveTestList.TestsList, true);
                }
                //else if (e.CommandArgs.CommandName == "download")
                //{
                //    SampleReceiveTestListDB sampleReceiveTestListDB = new SampleReceiveTestListDB();
                //    SampleReceiveTestList receiveTestList = sampleReceiveTestListDB.GetByID(testReporting.FKSampleReceiveTestID);
                //    DownloadPDF(testReportingId, receiveTestList.TestsList);
                //}
            }
        }

        protected void GdvPendingToReport_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            (sender as ASPxGridView).DataBind();
        }

        protected void GdvPendingToCheckReport_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            (sender as ASPxGridView).DataBind();
        }

        protected void GdvPendingToApproveReport_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            (sender as ASPxGridView).DataBind();
        }

        protected void GdvCompletedReport_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            (sender as ASPxGridView).DataBind();
        }

        private void DownloadPDF(int testReportingId, TestsList TestsList, bool withHeaderFooter = false)
        {
            TestReporting testReporting = new TestReportingDB().GetByID(testReportingId);
            string excelPath = GetFilePath(testReporting);//GetFilePath(testReporting, ".xlsx");
            string fileNameWithoutExt = withHeaderFooter == false?Path.GetFileNameWithoutExtension(excelPath):"Singed"+ Path.GetFileNameWithoutExtension(excelPath);

            string downloadPath = Path.GetDirectoryName(excelPath);
            string downloadFileName = string.Format("{0}.pdf", fileNameWithoutExt);



            string generatedFileName = string.Format(@"{0}\{1}\{2}", downloadPath, "PDFReport", downloadFileName);

            bool isConverted = false;
            if (File.Exists(generatedFileName))
            {
                if (!withHeaderFooter)
                {
                    ResponseRedirect(downloadFileName, generatedFileName);
                }
                else
                {
                    string copiedExcelPath = Path.Combine(Path.GetDirectoryName(generatedFileName), Guid.NewGuid().ToString().Replace("-", "") + Path.GetFileName(generatedFileName));
                    File.Copy(generatedFileName, copiedExcelPath, true);
                    isConverted = ConvertFile.AttachHeaderAndFooter(copiedExcelPath, Server.MapPath("~/images/Footer.jpeg"), Server.MapPath("~/images/header.jpeg"), Server.MapPath("~/images/stamp.jpeg"));
                    if (isConverted)
                    {
                        ResponseRedirect(downloadFileName, copiedExcelPath);
                    }
                 
                }
            }
            
        }
        private void ResponseRedirect(string downloadFileName, string generatedFileName)
        {
            base.Response.Clear();
            base.Response.ClearHeaders();
            base.Response.AddHeader("Content-Type", "application /pdf");
            base.Response.AddHeader("Content-Disposition", "attachment;   filename=" + downloadFileName);
            base.Response.TransmitFile(generatedFileName);
            base.Response.Flush();
            base.Response.End();
        }

        private bool AttachSignature(TestReporting testReporting,bool isLeft)
        {
            string excelPath = GetFilePath(testReporting);//GetFilePath(testReporting, ".xlsx");
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(excelPath);
            string downloadPath = Path.GetDirectoryName(excelPath);
            string downloadFileName = string.Format("{0}.pdf", fileNameWithoutExt);
            string generatedFileName = string.Format(@"{0}\{1}\{2}", downloadPath, "PDFReport", downloadFileName);

            string copiedExcelPath = "";
            if (File.Exists(generatedFileName))
            {
                copiedExcelPath=  Path.Combine(Path.GetDirectoryName(generatedFileName), "Singed" + Path.GetFileName(generatedFileName));
                if (File.Exists(copiedExcelPath) && isLeft)
                {
                    File.Delete(copiedExcelPath);
                    File.Copy(generatedFileName, copiedExcelPath, true);
                }
                else if (!File.Exists(copiedExcelPath))
                {
                    File.Copy(generatedFileName, copiedExcelPath, true);
                }


                ADMUsers admusers = base.Session["CurrentUser"] as ADMUsers;
                AttachedFilesDB attachedFilesDB = new AttachedFilesDB();
                int userTransactionTypeID = 33333;
                AttachedFiles existingAttachedFiles = attachedFilesDB.GetAttachment(admusers.UserID, userTransactionTypeID);
                if (existingAttachedFiles != null)
                    return ConvertFile.AttachSignature(copiedExcelPath, existingAttachedFiles, isLeft, admusers.EName);
                else
                    return false;
            }
            else
                return false;
        }
        //private bool CreatePDF(TestReporting testReporting, TestsList TestsList, bool leftSignature, bool attachSignature = true, bool forceDelete = false)
        //{
        //    ADMUsers admusers = base.Session["CurrentUser"] as ADMUsers;
        //    AttachedFilesDB attachedFilesDB = new AttachedFilesDB();
        //    int userTransactionTypeID = 33333;
        //    AttachedFiles existingAttachedFiles = attachedFilesDB.GetAttachment(admusers.UserID, userTransactionTypeID);
        //    //if (existingAttachedFiles == null)
        //    //    return false;

        //    //TestReporting testReporting = new TestReportingDB().GetByID(testReportingId);
        //    string excelPath = GetFilePath(testReporting, ".xlsx");
        //    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(excelPath);

        //    //string downloadFolder = "~/Downloads/";
        //    string downloadPath = Path.GetDirectoryName(excelPath); //Server.MapPath(downloadFolder);
        //    string downloadFileName = string.Format("{0}.pdf", fileNameWithoutExt);
        //    string generatedFileName = string.Format(@"{0}\{1}", downloadPath, downloadFileName);

        //    //if (forceDelete && File.Exists(generatedFileName))
        //    //    File.Delete(generatedFileName);

        //    LblError.Text = LblError.Text + "  Checking..";
        //    bool isConverted = false;
        //    if (forceDelete || !File.Exists(generatedFileName))
        //    {
        //        LblError.Text = LblError.Text + "  Force Delete: True";
        //        isConverted = new ConvertFile().ConvertExcelToPdf(generatedFileName, TestsList, excelPath);
        //    }

        //    if (File.Exists(generatedFileName))
        //        isConverted = true;

        //    if (attachSignature && isConverted && existingAttachedFiles != null)
        //        isConverted = ConvertFile.AttachSignatureFooter(generatedFileName, existingAttachedFiles, leftSignature);

        //    return isConverted;
        //}

        private bool CreatePDF(TestReporting testReporting, BusinessLayer.ReportGroup reportGroup, bool leftSignature, bool attachSignature = true, bool forceDelete = false)
        {
            ADMUsers admusers = base.Session["CurrentUser"] as ADMUsers;
            AttachedFilesDB attachedFilesDB = new AttachedFilesDB();
            int userTransactionTypeID = 33333;
            AttachedFiles existingAttachedFiles = attachedFilesDB.GetAttachment(admusers.UserID, userTransactionTypeID);
            //if (existingAttachedFiles == null)
            //    return false;

            //TestReporting testReporting = new TestReportingDB().GetByID(testReportingId);
            string excelPath = GetFilePath(testReporting);
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(excelPath);

            //string downloadFolder = "~/Downloads/";
            string downloadPath = Path.GetDirectoryName(excelPath); //Server.MapPath(downloadFolder);
            string downloadFileName = string.Format("{0}.pdf", fileNameWithoutExt);
            string generatedFileName = string.Format(@"{0}\{1}\{2}", downloadPath, "PDFReport", downloadFileName);

            //if (forceDelete && File.Exists(generatedFileName))
            //    File.Delete(generatedFileName);

            LblError.Text = LblError.Text + "  Checking..";
            bool isConverted = false;
            if (forceDelete || !File.Exists(generatedFileName))
            {
                LblError.Text = LblError.Text + "  Force Delete: True";
                isConverted = new ConvertFile().ConvertExcelToPdf(generatedFileName, reportGroup, excelPath, "2");
            }

            if (File.Exists(generatedFileName))
                isConverted = true;

            if (attachSignature && isConverted && existingAttachedFiles != null)
                isConverted = ConvertFile.AttachSignatureFooter(generatedFileName, existingAttachedFiles, leftSignature);

            return isConverted;
        }

        private bool CreateReportGroupPDF(SampleReceiveList receiveList, SampleReceiveTestList receiveTestList, TestReporting testReporting)
        {
            bool attached = false;
            MaterialsDetailsTests materialsDetailsTests = receiveTestList.TestsList.MaterialsDetailsTests.Where(md => md.FKMaterialDetailsID == receiveList.FKMaterialDetailsID).FirstOrDefault();
            if (materialsDetailsTests != null)
            {
                BusinessLayer.ReportGroup reportGroup = materialsDetailsTests.ReportGroup;
                //if (reportGroup != null)
                //{
                    attached = CreatePDF(testReporting, reportGroup, false, false, true);
                    LblError.Text += string.Format("Created file");
                //}
                //else
                //    LblError.Text = string.Format("Report group not found for '{0}' job order", receiveTestList.ReportNumber);
            }
            else
                LblError.Text = string.Format("Material Detail not found for '{0}' job order", receiveTestList.ReportNumber);

            return attached;
        }

        //private string GetFilePath(TestReporting testReporting, string fileExtension)
        //{
        //    string excelPath = string.Empty;
        //    if (testReporting.TestReportingID != 0)
        //    {
        //        SampleReceiveTestList sampleReceiveTestList = testReporting.SampleReceiveTestList;
        //        SampleReceiveList sampleReceiveList = new SampleReceiveListDB().GetByID(sampleReceiveTestList.FKSampleID.Value);
        //        string path = ConfigurationManager.AppSettings["SampleFilePath"];

        //        string fileName = string.Format("{0}{1}", sampleReceiveTestList.ReportNumber, fileExtension);
        //        if (testReporting.RevisionNo > 0 )
        //            fileName = string.Format("{0}-A0{1}{2}", sampleReceiveTestList.ReportNumber, testReporting.RevisionNo, fileExtension);

        //        excelPath = string.Format(@"{0}{1}\{2}", path, sampleReceiveList.SampleNo, fileName);
        //        if (!File.Exists(excelPath))
        //        {
        //            fileName = string.Format("{0}{1}", sampleReceiveTestList.ReportNumber, ".xlsm");
        //            if (testReporting.RevisionNo > 0)
        //                fileName = string.Format("{0}-A0{1}{2}", sampleReceiveTestList.ReportNumber, testReporting.RevisionNo, ".xlsm");
        //        }
        //        LblError.Text = LblError.Text + "  Sample #: " + sampleReceiveList.SampleNo + " FileName: " + fileName;
        //        excelPath = string.Format(@"{0}{1}\{2}", path, sampleReceiveList.SampleNo, fileName);
        //        LblError.Text = LblError.Text + "  Excel Path:" + excelPath;
        //    }

        //    return excelPath;
        //}
        private string GetFilePath(TestReporting testReporting)
        {
            string excelPath = string.Empty;
            if (testReporting.TestReportingID != 0)
            {
                SampleReceiveTestList sampleReceiveTestList = testReporting.SampleReceiveTestList;
                SampleReceiveList sampleReceiveList = new SampleReceiveListDB().GetByID(sampleReceiveTestList.FKSampleID.Value);
                string path = ConfigurationManager.AppSettings["SampleFilePath"];
                string reportNumber = sampleReceiveTestList.ReportNumber.ToString();
                int revisionNo = testReporting.RevisionNo;

                string searchPattern = string.Format("{0}*{1}", reportNumber, "*");
                string[] matchingFiles = Directory.GetFiles(Path.Combine(path, sampleReceiveList.SampleNo), searchPattern);

                if (matchingFiles.Length > 0)
                {
                    excelPath = matchingFiles[0];
                }
                else
                {
                    searchPattern = string.Format("{0}*", reportNumber);
                    matchingFiles = Directory.GetFiles(Path.Combine(path, sampleReceiveList.SampleNo), searchPattern);

                    if (matchingFiles.Length > 0)
                    {
                        excelPath = matchingFiles[0];
                    }
                }

                LblError.Text = LblError.Text + "  Sample #: " + sampleReceiveList.SampleNo + " FileName: " + Path.GetFileName(excelPath);
                LblError.Text = LblError.Text + "  Excel Path:" + excelPath;
            }

            return excelPath;
        }
        protected ASPxGridView GdvPendingToReport;

        protected ASPxGridView GdvPendingToCheckReport;

        protected ASPxGridView GdvPendingToApproveReport;
        
                    protected ASPxRadioButtonList radioButtonList;

        protected ASPxGridView GdvCompletedReport;

        protected ASPxLabel LblError;
        protected ASPxLoadingPanel PLMSAspxLoadingPanel;

        protected HtmlGenericControl PendingToReport;

        protected HtmlGenericControl PendingToCheck;
        protected HtmlGenericControl PendingToApprove;
        protected HtmlGenericControl CompleteReport;
        protected void GdvPendingToReport_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            if(e.Column!=null && e.Column.FieldName!=null && e.Column.FieldName!= "TestEndingDate")
            {
                e.Editor.ClientEnabled = false;
            }
        }

        protected void GdvPendingToReport_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            if (e.Keys.Count <= 0)
                return;
            object testenddate = e.NewValues["TestEndingDate"];
            if(testenddate!=null)
            {
                var db=new TestReportingDB();
                db.dbContext.Database.ExecuteSqlCommand("Update TestReporting set TestEndingDate={0} where TestReportingID={1}", Convert.ToDateTime(testenddate), e.Keys[0]);                
            }
            else
            {
                var db = new TestReportingDB();
                db.dbContext.Database.ExecuteSqlCommand("Update TestReporting set TestEndingDate={0} where TestReportingID={1}", DBNull.Value, e.Keys[0]);
            }            
        }

        protected void UpdateStatus(SampleReceiveTestList receiveTestList, int statusID)
        {
            SampleReceiveTestListDB sampleReceiveTestListDB = new SampleReceiveTestListDB();
            List<SampleReceiveTestList> receiveTestLists = sampleReceiveTestListDB.GetByReportNumber(receiveTestList.ReportNumber.GetValueOrDefault(0));

            foreach(SampleReceiveTestList testList in receiveTestLists)
            {
                if (testList.SampleReceiveTestID == receiveTestList.SampleReceiveTestID)
                    continue;

                TestReporting testReporting = new TestReportingDB().GetByReportNumber(testList.SampleReceiveTestID);
                testReporting.StatusID = statusID;
                new TestReportingDB().Update(testReporting);
            }
        }
        protected void UpdateStatusdate(SampleReceiveTestList receiveTestList, int statusID, DateTime? TestEndDate1, string statecode)
        {
            SampleReceiveTestListDB sampleReceiveTestListDB = new SampleReceiveTestListDB();
            List<SampleReceiveTestList> receiveTestLists = sampleReceiveTestListDB.GetByReportNumber(receiveTestList.ReportNumber.GetValueOrDefault(0));

            foreach (SampleReceiveTestList testList in receiveTestLists)
            {
                if (testList.SampleReceiveTestID == receiveTestList.SampleReceiveTestID)
                    continue;

                TestReporting testReporting = new TestReportingDB().GetByReportNumber(testList.SampleReceiveTestID);
                testReporting.StatusID = statusID;
                if (statecode== "approve")
                {
                    testReporting.ReportingDate = TestEndDate1;
                }
                else
                {
                    testReporting.TestEndingDate = TestEndDate1;
                }
                
                new TestReportingDB().Update(testReporting);
            }
        }
    }
}
