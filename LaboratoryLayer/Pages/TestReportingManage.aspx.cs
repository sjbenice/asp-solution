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
using System.Web.UI.WebControls;

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
                    this.reportvisibilty();
                   
                }
            }
            
            IntitlizeReportAutherization();
            NoofDisistinctRowCount();
          
        }

        private void NoofDisistinctRowCount()
        {

            int distinctCountAllPending = new TestReportingDB().GetAllPending().Select(item => item.ReportNumber)
                                                                 .Distinct()
                                                                 .Count();
            PendingToReporth5.InnerText = string.Format("{0} ({1} Reports) ", "Pending To Report ", distinctCountAllPending);
            
            int distinctCountPendingToCheck = new TestReportingDB().GetPendingToCheck().Select(item => item.ReportNumber)
                                                               .Distinct()
                                                               .Count();
            PendingToCheckh5.InnerText = string.Format("{0} ({1} Reports) ", "Pending To Check ", distinctCountPendingToCheck);

            
            int distinctCountPendingToApprove = new TestReportingDB().GetPendingToApprove().Select(item => item.ReportNumber)
                                                             .Distinct()
                                                             .Count();
            PendingToApproveh5.InnerText = string.Format("{0} ({1} Reports) ", "Pending To Approve ", distinctCountPendingToApprove);


            int distinctCountCompleted = new TestReportingDB().GetAllCompleted().Select(item => item.ReportNumber)
                                                       .Distinct()
                                                       .Count();
            CompleteReporth5.InnerText = string.Format("{0} ({1} Reports) ", "Completed Report", distinctCountCompleted);
        }

      
        protected DataTable CreateDataTableFromList(List<TestReporting> data)
        {
            DataTable dataTable = new DataTable();

         
            dataTable.Columns.Add("ReportNumber", typeof(string));
            dataTable.Columns.Add("SampleNumber", typeof(string));
            dataTable.Columns.Add("ReportingDate", typeof(string));
            dataTable.Columns.Add("CustomerName", typeof(string));


            foreach (var item in data)
            {
                DataRow row = dataTable.NewRow();
                row["ReportNumber"] = item.ReportNumber; 
                row["SampleNumber"] = item.SampleNumber;
                row["ReportingDate"] = item.ReportingDate;
                row["CustomerName"] = item.FKCustomerID;

                dataTable.Rows.Add(row);
            }

            return dataTable;
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


        private void IntitlizeReportAutherization()
        {
            try
            {
                GdvPendingToReport.JSProperties["cpIsView"] = "false";
                GdvPendingToReport.JSProperties["cpIsEdit"] = "false";
                GdvPendingToReport.JSProperties["cpIsDelete"] = "false";
                GdvPendingToReport.JSProperties["cpIsAdd"] = "false";


                GdvPendingToCheckReport.JSProperties["cpIsView"] = "false";
                GdvPendingToCheckReport.JSProperties["cpIsEdit"] = "false";
                GdvPendingToCheckReport.JSProperties["cpIsDelete"] = "false";
                GdvPendingToCheckReport.JSProperties["cpIsAdd"] = "false";


                GdvPendingToApproveReport.JSProperties["cpIsView"] = "false";
                GdvPendingToApproveReport.JSProperties["cpIsEdit"] = "false";
                GdvPendingToApproveReport.JSProperties["cpIsDelete"] = "false";
                GdvPendingToApproveReport.JSProperties["cpIsAdd"] = "false";


                GdvCompletedReport.JSProperties["cpIsView"] = "false";
                GdvCompletedReport.JSProperties["cpIsEdit"] = "false";
                GdvCompletedReport.JSProperties["cpIsDelete"] = "false";
                GdvCompletedReport.JSProperties["cpIsAdd"] = "false";


                List<UserLinkOptionsView> allOptionsForLink = new UserRolesDB().GetAllOptionsForUser(int.Parse(this.Session["UserId"].ToString()));
                var distinctOptions = allOptionsForLink
                    .Where(opt => opt.FKLinkCategoryID == 5)
                    .GroupBy(opt => new { opt.LinksEName, opt.OptionEName })
                    .Select(group => group.First())
                    .ToList();
                foreach (var userLinkOptionsView in distinctOptions)
                {
                    switch (userLinkOptionsView.LinksEName)
                    {
                        case "Test Reporting Pending To Report":
                            AssignGridAutherization(GdvPendingToReport, userLinkOptionsView.OptionEName);
                            break;
                        case "Test Reporting Pending To Check":
                            AssignGridAutherization(GdvPendingToCheckReport, userLinkOptionsView.OptionEName);
                            break;
                        case "Test Reporting Pending To Approve":
                            AssignGridAutherization(GdvPendingToApproveReport, userLinkOptionsView.OptionEName);
                            break;
                        case "Test Reporting Completed Report":
                            AssignGridAutherization(GdvCompletedReport, userLinkOptionsView.OptionEName);
                            break;

                    }


                }
            }
            catch (Exception ex)
            {
                LblError.Text += ex.Message;
            }
        }
        private void AssignGridAutherization(ASPxGridView gridView, string optionEName)
        {
            switch (optionEName)
            {
                case "All":
                    gridView.JSProperties["cpIsView"] = "true";
                    gridView.JSProperties["cpIsEdit"] = "true";
                    gridView.JSProperties["cpIsDelete"] = "true";
                    gridView.JSProperties["cpIsAdd"] = "true";
                    break;
                case "Add":
                    gridView.JSProperties["cpIsView"] = "true";
                    gridView.JSProperties["cpIsAdd"] = "true";
                    break;
                case "Edit":
                    gridView.JSProperties["cpIsView"] = "true";
                    gridView.JSProperties["cpIsEdit"] = "true";
                    break;
                case "Delete":
                    gridView.JSProperties["cpIsView"] = "true";
                    gridView.JSProperties["cpIsEdit"] = "true";
                    break;
                case "View":
                     gridView.JSProperties["cpIsView"] = "true";
                    break;
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


            Convert.ToDecimal(base.Session["StaffId"]);
            Convert.ToDecimal(base.Session["DepId"]);
           

        }
        protected void BtnSendForCheck_Init(object sender, EventArgs e)
        {
            ASPxButton btnSendForCheck = (ASPxButton)sender;
            GridViewDataItemTemplateContainer container = (GridViewDataItemTemplateContainer)btnSendForCheck.NamingContainer;

            object testEndingDateValue = container.Grid.GetRowValues(container.VisibleIndex, "TestEndingDate");

            if (testEndingDateValue == null || Convert.IsDBNull(testEndingDateValue) || string.IsNullOrEmpty(testEndingDateValue.ToString()))
            {
                btnSendForCheck.Visible = false;
                return;
            }


           
           
        }

        protected void GdvPendingToReport_BeforeGetCallbackResult(object sender, EventArgs e)
        {
            this.GdvPendingToReport.JSProperties["cpgridPendingToReportFilter"] = this.GdvPendingToReport.FilterExpression;
        }
        protected void GdvPendingToReport_RowCommand(object sender, ASPxGridViewRowCommandEventArgs e)
        {
            LblError.Text = "";
            int testReportingId = Convert.ToInt32(e.CommandArgs.CommandArgument.ToString());
            if (testReportingId != 0)
            {
                if (e.CommandArgs.CommandName == "sendforcheck")
                {
                    

                    TestReporting testReporting = new TestReportingDB().GetByID(testReportingId);

                    SampleReceiveTestListDB sampleReceiveTestListDB = new SampleReceiveTestListDB();
                    SampleReceiveTestList receiveTestList = sampleReceiveTestListDB.GetByID(testReporting.FKSampleReceiveTestID);

                    if (!CheckReportHasAttachment(receiveTestList.ReportNumber.Value))
                    {
                        LblError.Text = "Some tests in this group are missing worksheet attachments.";
                        return; 
                    }

                    SampleReceiveListDB sampleReceiveListDB = new SampleReceiveListDB();
                    SampleReceiveList receiveList = sampleReceiveListDB.GetByID(receiveTestList.FKSampleID.GetValueOrDefault(0));
                    JobOrderMaster jobOrderMaster = new JobOrderMasterDB().GetByID((long)receiveList.FKJobOrderMasterID);
                    if (jobOrderMaster == null || !jobOrderMaster.IsReporting)
                    {
                        LblError.Text = string.Format("Reporting not allowed for '{0}' job order", receiveTestList.ReportNumber);
                        return;
                    }


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
                        UpdateStatus(receiveTestList, testReporting.StatusID);

                        GdvPendingToReport.SettingsText.Title = "Report No: " + receiveTestList.ReportNumber.ToString() + " Sent for Check Successfully!!!";
                        GdvPendingToReport.DataBind();
                        GdvPendingToCheckReport.DataBind();
                    }
                    GdvPendingToCheckReport.SettingsText.Title = "";
                    GdvPendingToApproveReport.SettingsText.Title = "";
                }
            }

        }
        private bool CheckReportHasAttachment(int ReportNumber)
        {

      
            SampleReceiveTestListDB sampleReceiveTestListDB = new SampleReceiveTestListDB();

            foreach (var sampleRecive in sampleReceiveTestListDB.GetByReportNumber(ReportNumber))
            {
                TestReporting testReporting = new TestReportingDB().GetByReportNumber(sampleRecive.SampleReceiveTestID);

                if (!testReporting.TestEndingDate.HasValue)
                {
                    return false;
                }
            }
            return true;
        }
        protected void GdvPendingToCheckReport_RowCommand(object sender, ASPxGridViewRowCommandEventArgs e)
        {
           
            int testReportingId = Convert.ToInt32(e.CommandArgs.CommandArgument.ToString());
            if (testReportingId != 0)
            {
                

                TestReporting testReporting = new TestReportingDB().GetByID(testReportingId);
                SampleReceiveTestListDB sampleReceiveTestListDB = new SampleReceiveTestListDB();
                SampleReceiveTestList receiveTestList = sampleReceiveTestListDB.GetByID(testReporting.FKSampleReceiveTestID);

               
                if (e.CommandArgs.CommandName == "check")
                {
                    
                        testReporting.CheckedDate = DateTime.Now;
                        testReporting.StatusID = 2;
                        new TestReportingDB().Update(testReporting);
                        UpdateStatus(receiveTestList, testReporting.StatusID);
                        GdvPendingToCheckReport.DataBind();
                        GdvPendingToApproveReport.DataBind();
                    
                    if (!AttachSignature(testReporting,true))
                              GdvPendingToCheckReport.SettingsText.Title="Report Number: " + receiveTestList.ReportNumber.ToString() + " Checked Successfully without Attaching Signature!!!";
                      
                    else
                              GdvPendingToCheckReport.SettingsText.Title = "Report Number: " + receiveTestList.ReportNumber.ToString() + " Checked Successfully!!!";


                    LblError.Text="";
                }
                else if (e.CommandArgs.CommandName == "reject")
                {
                    testReporting.StatusID = 0;
                    new TestReportingDB().Update(testReporting);
                    UpdateStatus(receiveTestList, testReporting.StatusID);
                    DeleteAttachments(testReporting);
                    GdvPendingToCheckReport.DataBind();
                    GdvPendingToReport.DataBind();
                 
                        GdvPendingToCheckReport.SettingsText.Title = "Report Number: " + receiveTestList.ReportNumber.ToString() + " Reject Successfully!!!";
                    LblError.Text = "";

              
                }
                GdvPendingToReport.SettingsText.Title = "";
                GdvPendingToApproveReport.SettingsText.Title = "";

            }

        }
        protected void GdvPendingToCheckReport_BeforeGetCallbackResult(object sender, EventArgs e)
        {
            this.GdvPendingToCheckReport.JSProperties["cpgridPendingToCheckReportFilter"] = this.GdvPendingToCheckReport.FilterExpression;
        }
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

           
                if (e.CommandArgs.CommandName == "approve")
                {
                    string checkresult = checkReceivingCapability(testReporting);
                    if (checkresult == "")
                    {

                        testReporting.StatusID = 3;
                        testReporting.ReportingDate = DateTime.Now;
                        new TestReportingDB().Update(testReporting);
                        UpdateStatus(receiveTestList, testReporting.StatusID);

                        if (testReporting.RevisionNo > 0)
                        {
                            string pdfPath = GetPDfFilePath(testReporting);
                            if (!String.IsNullOrEmpty(pdfPath))
                            {
                                bool result = ConvertFile.CopyRevisedPDF(testReporting.RevisionNo.ToString(), pdfPath);
                                if (!result)
                                {
                                    LblError.Text = string.Format("Copying pdf to Revised PDg Failed!");
                                }
                            }
                        }

                        GdvPendingToApproveReport.DataBind();
                        GdvCompletedReport.DataBind();
                        if (!AttachSignature(testReporting, false))
                        {
                            DownloadPDFForCompleted(testReportingId, true);
                            GdvPendingToApproveReport.SettingsText.Title = "Report Number: " + receiveTestList.ReportNumber.ToString() + " Approved Successfully without Attaching Signature!!!";
                        }
                        else
                        {

                            DownloadPDFForCompleted(testReportingId, true);
                            GdvPendingToApproveReport.SettingsText.Title = "Report Number: " + receiveTestList.ReportNumber.ToString() + " Approved Successfully!!!";
                        }
                        LblError.Text = "";
                    }
                    else
                    {
                        GdvPendingToApproveReport.SettingsText.Title = checkresult;
                        LblError.Text = checkresult;
                    }
                   
                }
                else if (e.CommandArgs.CommandName == "reject")
                {
                    testReporting.StatusID = 0;
                    testReporting.ReportingDate = DateTime.Now;
                    new TestReportingDB().Update(testReporting);
                    GdvPendingToApproveReport.SettingsText.Title = "Report Number: " + receiveTestList.ReportNumber.ToString() + " Rejected Successfully!!!";
               
                    UpdateStatus(receiveTestList, testReporting.StatusID);
                    DeleteAttachments(testReporting);
                    GdvPendingToApproveReport.DataBind();
                    GdvPendingToCheckReport.DataBind();
                    GdvPendingToReport.DataBind();
                    LblError.Text = "";

                }
                GdvPendingToCheckReport.SettingsText.Title = "";
                GdvPendingToReport.SettingsText.Title = "";
            }
        }

        protected bool checkReportCapability(TestReporting testReporting)
        {

            SampleReceiveTestListDB sampleReceiveTestListDB = new SampleReceiveTestListDB();
            SampleReceiveTestList receiveTestList = sampleReceiveTestListDB.GetByID(testReporting.FKSampleReceiveTestID);


            SampleReceiveListDB sampleReceiveListDB = new SampleReceiveListDB();
            SampleReceiveList receiveList = sampleReceiveListDB.GetByID(receiveTestList.FKSampleID.GetValueOrDefault(0));
            JobOrderMaster jobOrderMaster = new JobOrderMasterDB().GetByID((long)receiveList.FKJobOrderMasterID);








            decimal? reportCreditLimit = new JobOrderMasterDB().GetByID((long)receiveList.FKJobOrderMasterID).ReportCreditLimit;
            decimal? totalPendingAmount = new SampleReceiveListDB().GetNOfUnpaidBills((long)receiveList.FKJobOrderMasterID).TotalPendingAmount;
            if (totalPendingAmount == null)
            {
                totalPendingAmount = new decimal?(0m);
            }
            decimal? num = new decimal?(new SampleReceiveTestListDB().GetNotSampleReceiveTestsByJobOrderID((long)receiveList.FKJobOrderMasterID, receiveTestList.FKSampleID.Value));
            decimal? num2 = new decimal?(new WorkOrderListDB().GetAllWorkOrderbyDueAmountJobOrderMasterID((long)receiveList.FKJobOrderMasterID));
            decimal? num3 = new decimal?(new WorkOrderListDB().GetAllPendingEntryAmount((long)receiveList.FKJobOrderMasterID));
            return !(totalPendingAmount + num + num2 + num3 > reportCreditLimit);
        }

        protected string checkReceivingCapability(TestReporting testReporting)
        {

            SampleReceiveTestListDB sampleReceiveTestListDB = new SampleReceiveTestListDB();
            SampleReceiveTestList receiveTestList = sampleReceiveTestListDB.GetByID(testReporting.FKSampleReceiveTestID);

            SampleReceiveListDB sampleReceiveListDB = new SampleReceiveListDB();
            SampleReceiveList receiveList = sampleReceiveListDB.GetByID(receiveTestList.FKSampleID.GetValueOrDefault(0));
            //JobOrderMaster jobOrderMaster = new JobOrderMasterDB().GetByID((long)receiveList.FKJobOrderMasterID);

            //decimal? reportCreditLimit = jobOrderMaster.ReportCreditLimit;
            //decimal? totalPendingAmount = sampleReceiveTestListDB.GetNotSampleReceiveTestsByFKSampleID((long)receiveTestList.FKSampleID.GetValueOrDefault(0));
            //if (reportCreditLimit != null)
            //{
            //    reportCreditLimit.GetValueOrDefault();
            //}

            //if (totalPendingAmount >= reportCreditLimit)
            //{
            //    return string.Concat(new string[]
            //    {
            //        "Cant Approve , Unpaid Bills (",
            //        string.Format(" {0:F3}", totalPendingAmount),
            //        ") Exceeds the Report CreaditLimit (",
            //        string.Format(" {0:F3}", reportCreditLimit),
            //        ")"
            //    });
            //}
            //return "";
            int num = new SampleReceiveListDB().GetNOfUnpaidBills((long)receiveList.FKJobOrderMasterID).No_of_PendingPayment ?? 0;
            int num2 = new JobOrderMasterDB().GetByID((long)receiveList.FKJobOrderMasterID).UnpaidReceiveLimit ?? 0;
            decimal? reportCreditLimit = new JobOrderMasterDB().GetByID((long)receiveList.FKJobOrderMasterID).ReportCreditLimit;
            if (reportCreditLimit != null)
            {
                reportCreditLimit.GetValueOrDefault();
            }
            decimal d = reportCreditLimit.Value;//'new JobOrderMasterDB().GetByID((long)this.cmbFKJobOrderMasterID.Value).ReceiveCreditLimit ?? 0m;
            decimal d2 = new SampleReceiveListDB().GetNOfUnpaidBills((long)receiveList.FKJobOrderMasterID).TotalPendingAmount ?? 0m;
            decimal notSampleReceiveTestsByJobOrderID =
            new SampleReceiveTestListDB().GetNotSampleReceiveTestsByFKSampleIDAndJobOrderID((long)receiveList.FKJobOrderMasterID,(long)receiveTestList.FKSampleID.GetValueOrDefault(0));
            decimal allWorkOrderbyDueAmountJobOrderMasterID =
            new WorkOrderListDB().GetAllWorkOrderbyDueAmountJobOrderMasterID((long)receiveList.FKJobOrderMasterID);
            decimal allPendingEntryAmount = new WorkOrderListDB().GetAllPendingEntryAmount((long)receiveList.FKJobOrderMasterID);
            decimal num3 = d2 + notSampleReceiveTestsByJobOrderID + allWorkOrderbyDueAmountJobOrderMasterID + allPendingEntryAmount;
            decimal d3 = new PaymentMasterDB().GetAllPendingAvancedPaymentAmountForJobOrder((long)(long)receiveList.FKJobOrderMasterID) ?? 0m;
            decimal num4 = 0m;
           // num4 +=  new SampleReceiveTestListDB().GetNotSampleReceiveTestsByFKSampleID((long)receiveTestList.FKSampleID.GetValueOrDefault(0));
           // num3 += num4;
            decimal num5 = d + d3;
            if (d - num3 + d3 <= 0m)
            {
                return string.Concat(new string[]
                {
                    "Cant Approve!!! Receive Amount",
                    string.Format(" {0:F3}", num3),
                    ") Exceeds the Receive Report Limit (",
                    string.Format(" {0:F3}", num5),
                    ")"
                });
            }
            //if (num >= num2)
            //{
            //    return string.Concat(new string[]
            //    {
            //        "Cant Receiving , Unpaid Bills (",
            //        string.Format(" {0:F3}", num),
            //        ") Exceeds the Unpaid Receive Limit (",
            //        string.Format(" {0:F3}", num2),
            //        ")"
            //    });
            //}
            return "";
        }

        protected void GdvPendingToApproveReport_BeforeGetCallbackResult(object sender, EventArgs e)
        {
            this.GdvPendingToApproveReport.JSProperties["cpgridPendingToApproveReportFilter"] = this.GdvPendingToApproveReport.FilterExpression;
        }
        protected void GdvCompletedReport_RowCommand(object sender, ASPxGridViewRowCommandEventArgs e)
        {
          

           
              
              
            
        }

        protected void GdvCompletedReport_BeforeGetCallbackResult(object sender, EventArgs e)
        {
            this.GdvCompletedReport.JSProperties["cpgridCompletedReportFilter"] = this.GdvCompletedReport.FilterExpression;
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
            string[] args = e.Parameters.Split('|');
            string command = args[0];
            string commandArgument = args[1];
            if (command == "btnPrintDetailClicked")
            {
                int testReportingId = Convert.ToInt32(commandArgument);
                TestReporting testReporting = new TestReportingDB().GetByID(testReportingId);

                SampleReceiveTestListDB sampleReceiveTestListDB = new SampleReceiveTestListDB();
                SampleReceiveTestList receiveTestList = sampleReceiveTestListDB.GetByID(testReporting.FKSampleReceiveTestID);
                string path = DownloadPDFForCompleted(testReportingId,  true);
                GdvCompletedReport.JSProperties["cpRowCommandCompleted"] = string.Format(@"localexplorer:{0}", path);
            }
            if (command == "BtnReviseCheck")
            {
                int testReportingId = Convert.ToInt32(commandArgument);
                TestReporting testReporting = new TestReportingDB().GetByID(testReportingId);
                testReporting.IsRevised = true;
                new TestReportingDB().Update(testReporting);

                TestReporting newTestReporting = new TestReporting();
                newTestReporting.FKSampleReceiveTestID = testReporting.FKSampleReceiveTestID;
                newTestReporting.RevisionNo = testReporting.RevisionNo + 1;
                newTestReporting.StatusID = 0;
                newTestReporting.IsRevised = false;
                new TestReportingDB().Insert(newTestReporting);
                newTestReporting = new TestReportingDB().GetByID(Convert.ToInt64(Session["TestReportingID"].ToString()));
                string errormessage = "";
                string excelPath = GetFilePath(testReporting);//GetFilePath(testReporting, ".xlsx");
                string newExcelPath = GetFilePath(newTestReporting);// GetFilePath(newTestReporting, ".xlsx");
                if (File.Exists(excelPath))
                {
                    //if (!File.Exists(newExcelPath))
                    //{
                    //   File.Copy(excelPath, newExcelPath);


                    //}

                  

                    if (testReporting.IsRevised && testReporting.RevisionNo == 0)
                    {
                        string pdfPath = GetPDfFilePath(testReporting);
                        if (!String.IsNullOrEmpty(pdfPath))
                        {
                            bool result = ConvertFile.CopyRevisedPDF((newTestReporting.RevisionNo - 1).ToString(), pdfPath);
                            if (!result)
                            {
                                //LblError.Text = string.Format("Copying pdf to Revised PDg Failed!");
                            }
                           
                        }
                    }
                    if (!ConvertFile.WriteRevisonNumber(testReporting, newTestReporting, excelPath))
                    {

                    }
                    GdvCompletedReport.JSProperties["cpRowCommandCompleted"] = "ReviseCompleted";

                    GdvCompletedReport.SettingsText.Title = "Report Number: " + Path.GetFileNameWithoutExtension(excelPath) + " Revised Successfully!!!";
                }
                GdvCompletedReport.DataBind();
            }
        }

        private void DownloadPDF(int testReportingId, TestsList TestsList, bool withHeaderFooter = false)
        {
            TestReporting testReporting = new TestReportingDB().GetByID(testReportingId);
            string excelPath = GetFilePath(testReporting);
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
                    string copiedExcelPath = Path.Combine(Path.GetDirectoryName(generatedFileName), "PrintDetail"+ Path.GetFileName(generatedFileName));
                    if (File.Exists(copiedExcelPath))
                    {
                        File.Delete(copiedExcelPath);
                    }
                    File.Copy(generatedFileName, copiedExcelPath, true);
                    isConverted = ConvertFile.AttachHeaderAndFooter(copiedExcelPath, Server.MapPath("~/images/Footer.jpeg"), Server.MapPath("~/images/header.jpeg"), Server.MapPath("~/images/stamp.jpeg"));
                    if (isConverted)
                    {
                        ResponseRedirect(downloadFileName, copiedExcelPath);
                    }
                 
                }
            }
            
        }

        private string DownloadPDFForCompleted(int testReportingId,  bool withHeaderFooter = false)
        {
            try
            {
                TestReporting testReporting = new TestReportingDB().GetByID(testReportingId);
                string excelPath = GetFilePath(testReporting);
                string fileNameWithoutExt = withHeaderFooter == false ? Path.GetFileNameWithoutExtension(excelPath) : "Singed" + Path.GetFileNameWithoutExtension(excelPath);

                string downloadPath = Path.GetDirectoryName(excelPath);
                string downloadFileName = string.Format("{0}.pdf", fileNameWithoutExt);




                string generatedFileName = string.Format(@"{0}\{1}\{2}", downloadPath, "PDFReport", downloadFileName);
                string copiedExcelPathtemp = string.Format(@"{0}\{1}\{2}", downloadPath, "PDFReport", 
                    ConvertFile.GetRevisedPDF(testReporting.RevisionNo.ToString(), generatedFileName));
                string copiedExcelPath = string.Format(@"{0}{1}\{2}\{3}", ConfigurationManager.AppSettings["SampleFileReadPath"],
                                        Path.GetFileName(Path.GetDirectoryName(excelPath)).Replace("\\", ""), "PDFReport",
                                         ConvertFile.GetRevisedPDF(testReporting.RevisionNo.ToString(), generatedFileName));
                bool isConverted = false;
                if (File.Exists(generatedFileName))
                {

                    if (File.Exists(copiedExcelPathtemp))
                    {
                        return copiedExcelPath;
                    }
                    File.Copy(generatedFileName, copiedExcelPathtemp, true);
                    isConverted = ConvertFile.AttachHeaderAndFooter(copiedExcelPathtemp, Server.MapPath("~/images/Footer.jpeg"), Server.MapPath("~/images/header.jpeg"), Server.MapPath("~/images/stamp.jpeg"));
                    if (isConverted)
                    {
                        //File.Delete(generatedFileName);
                        return copiedExcelPath;
                    }
                    else
                        return "Not able to convert";
                }
                else
                    return "File is not existed";
                //}
            }
            catch (Exception ex)
            {
                return ex.Message;
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


        private void DeleteAttachments(TestReporting testReporting)
        {
            string excelPath = GetFilePath(testReporting);
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(excelPath);
            string downloadPath = Path.GetDirectoryName(excelPath);
            string downloadFileName = string.Format("{0}.pdf", fileNameWithoutExt);
            string generatedFileName = string.Format(@"{0}\{1}\{2}", downloadPath, "PDFReport", downloadFileName);

            string copiedExcelPath = "";
            if (File.Exists(generatedFileName))
            {
                File.Delete(generatedFileName);
            }
        }
        private bool AttachSignature(TestReporting testReporting,bool isLeft)
        {
            string excelPath = GetFilePath(testReporting);
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
                    return ConvertFile.AttachSignature(copiedExcelPath, existingAttachedFiles, isLeft, admusers.EName,admusers.AName);
                else
                    return false;
            }
            else
                return false;
        }
       

        private bool CreatePDF(TestReporting testReporting, BusinessLayer.ReportGroup reportGroup, bool leftSignature, bool attachSignature = true, bool forceDelete = false)
        {
            ADMUsers admusers = base.Session["CurrentUser"] as ADMUsers;
            AttachedFilesDB attachedFilesDB = new AttachedFilesDB();
            int userTransactionTypeID = 33333;
            AttachedFiles existingAttachedFiles = attachedFilesDB.GetAttachment(admusers.UserID, userTransactionTypeID);
             string excelPath = GetFilePath(testReporting);
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(excelPath);

         
            string downloadPath = Path.GetDirectoryName(excelPath); 
            string pdfReportFileName = string.Format("{0}.pdf", fileNameWithoutExt);
            string generatedPDFReportFileName = string.Format(@"{0}\{1}\{2}", downloadPath, "PDFReport", pdfReportFileName);

            string pdfEntryFileName = string.Format("ED-{0}.pdf", fileNameWithoutExt);
            string generatedPDFEntryFileName = string.Format(@"{0}\{1}\{2}", downloadPath, "EntryData", pdfEntryFileName);


            LblError.Text = LblError.Text + "  Checking..";
            bool isConverted = false;
            if (forceDelete || !File.Exists(generatedPDFReportFileName))
            {
                LblError.Text = LblError.Text + "  Force Delete: True";
                isConverted = new ConvertFile().ConvertReportSheetToPdf(generatedPDFReportFileName, reportGroup, excelPath, "2");
                if (isConverted)
                {
                    LblError.Text = LblError.Text + "  Report Generated. Generating Entry Data Begain";

                    isConverted = new ConvertFile().ConvertEntrySheetToPdf(generatedPDFEntryFileName, reportGroup, excelPath, "2");

                }
            }

            if (File.Exists(generatedPDFReportFileName))
                isConverted = true;

            if (attachSignature && isConverted && existingAttachedFiles != null)
                isConverted = ConvertFile.AttachSignatureFooter(generatedPDFReportFileName, existingAttachedFiles, leftSignature);

            return isConverted;
        }

        private bool CreateReportGroupPDF(SampleReceiveList receiveList, SampleReceiveTestList receiveTestList, TestReporting testReporting)
        {
            bool attached = false;
            MaterialsDetailsTests materialsDetailsTests = receiveTestList.TestsList.MaterialsDetailsTests.Where(md => md.FKMaterialDetailsID == receiveList.FKMaterialDetailsID).FirstOrDefault();
            if (materialsDetailsTests != null)
            {
                BusinessLayer.ReportGroup reportGroup = materialsDetailsTests.ReportGroup;
               
                    attached = CreatePDF(testReporting, reportGroup, false, false, true);
                    LblError.Text += string.Format("Created file");
          
            }
            else
                LblError.Text = string.Format("Material Detail not found for '{0}' job order", receiveTestList.ReportNumber);

            return attached;
        }

      
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
                    searchPattern = string.Format("{0}.*", reportNumber);
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

        private string GetPDfFilePath(TestReporting testReporting)
        {
            string pdfPath = string.Empty;
            if (testReporting.TestReportingID != 0)
            {
                SampleReceiveTestList sampleReceiveTestList = testReporting.SampleReceiveTestList;
                SampleReceiveList sampleReceiveList = new SampleReceiveListDB().GetByID(sampleReceiveTestList.FKSampleID.Value);
                string path = ConfigurationManager.AppSettings["SampleFilePath"];
                string reportNumber = sampleReceiveTestList.ReportNumber.ToString();
                int revisionNo = testReporting.RevisionNo;

                string searchPattern = string.Format("{0}{1}", reportNumber, ".pdf");
                string[] matchingFiles = Directory.GetFiles(Path.Combine(path, sampleReceiveList.SampleNo+ "\\PDFReport"), searchPattern);

                if (matchingFiles.Length > 0)
                {
                    pdfPath = matchingFiles[0];
                }
                
               
            }

            return pdfPath;
        }

        protected ASPxGridView GdvPendingToReport;

        protected ASPxGridView GdvPendingToCheckReport;

        protected ASPxGridView GdvPendingToApproveReport;
        
        protected ASPxRadioButtonList radioButtonList;

        protected ASPxGridView GdvCompletedReport;

        protected ASPxLabel LblError;
        protected ASPxLoadingPanel PLMSAspxLoadingPanel;

        protected HtmlGenericControl PendingToReport;
        protected HtmlGenericControl PendingToReporth5;

        protected HtmlGenericControl PendingToCheck;
        protected HtmlGenericControl PendingToCheckh5;

        protected HtmlGenericControl PendingToApprove;
        protected HtmlGenericControl PendingToApproveh5;

        protected HtmlGenericControl CompleteReport;
        protected HtmlGenericControl CompleteReporth5;
        protected ObjectDataSource AllPendingTestReportingDS;
        protected void GdvPendingToReport_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            if(e.Column!=null && e.Column.FieldName!=null && e.Column.FieldName!= "SuggestedTestingDate")
            {
                e.Editor.ClientEnabled = false;
            }
        }

        protected void GdvPendingToReport_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            if (e.Keys.Count <= 0)
                return;
            object testenddate = e.NewValues["SuggestedTestingDate"];
            if(testenddate!=null)
            {
                TestReporting testReporting = new TestReportingDB().GetByID((long)e.Keys[0]);

               

                    testReporting.SuggestedTestingDate = (DateTime)testenddate;
                    new TestReportingDB().Update(testReporting);

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
               
                
                new TestReportingDB().Update(testReporting);
            }
        }
    }
}
