using BusinessLayer;
using BusinessLayer.Admin;
using BusinessLayer.Pages;
using DevExpress.Spreadsheet;
using DevExpress.Web;
using DevExpress.Web.Data;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LaboratoryLayer.Pages
{
    public partial class ReportGroupInfo : Page
    {
        private int TransactionTypeID=88888;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.txtWorkform.Attributes.Add("onclick", "UploadButton_Click()");
            this.txtReport.Attributes.Add("onclick", "UploadReportButton_Click()");
            if (!base.IsPostBack)
            {
                this.Session["WorkformWorksheetList"] = null;
                this.Session["ReportWorksheetList"] = null;
                this.Session["ReportGroupExcelMappingList"] = null;
                Session["ProjectGroupFileAttached"] = null;
                Session["ProjectGroupID"] = null;
                int num = Convert.ToInt32(base.Request["id"]);
                this.lblMasterId.Text = num.ToString();
                if (num == 0)
                {
                    ReportGroupDB groupDB = new ReportGroupDB();
                    this.txtGroupNumber.Text = groupDB.GetNewSerial();
                }
                this.Session["lblMasterId"] = this.lblMasterId.Text;
                this.flReportGroupList.DataBind();
            }

            List<UserLinkOptionsView> allOptionsForLink = new UserRolesDB().GetAllOptionsForLink("../Pages/ReportGroup.aspx", long.Parse(this.Session["UserId"].ToString()));
            foreach (UserLinkOptionsView userLinkOptionsView in allOptionsForLink)
            {
                if (userLinkOptionsView.OptionEName == "Add")
                    this.lblAdd.Text = "True";
                if (userLinkOptionsView.OptionEName == "Edit")
                    this.lblEdite.Text = "True";
                if (userLinkOptionsView.OptionEName == "Delete")
                    this.lblDelete.Text = "True";
                if (userLinkOptionsView.OptionEName == "View")
                    this.lblView.Text = "True";
            }
        }

        protected void UploadControl_FileUploadComplete(object sender, FileUploadCompleteEventArgs e)
        {
            string paymentID = base.Request["id"] != null ? base.Request["id"].Split('_')[0] : "0";


            string fileSize = (e.UploadedFile.ContentLength / 1024L).ToString() + " KB";
            byte[] fileBytes = e.UploadedFile.FileBytes;


            string path = ConfigurationManager.AppSettings["SampleFileReadPath1"];
            string uploadDir = string.Format(@"{0}{1}", path, "ReportGroupAttachments");
            if (!Directory.Exists(uploadDir))
            {
                Directory.CreateDirectory(uploadDir);
            }
            string fileExtension = Path.GetExtension(e.UploadedFile.FileName);
            string fileName = $"Pro-{Guid.NewGuid().ToString()}{fileExtension}";
            string fullfilepath = Path.Combine(uploadDir, fileName);
            if (File.Exists(fullfilepath))
            {
                File.Delete(fullfilepath);
            }
            e.UploadedFile.SaveAs(fullfilepath);

            AttachedFiles attachedFiles = new AttachedFiles();
            attachedFiles.FileContent = fileBytes;
            attachedFiles.FileExtention = System.IO.Path.GetExtension(e.UploadedFile.FileName);
            attachedFiles.FileName = fileName;
            attachedFiles.FileSize = fileSize;
            attachedFiles.FileUrl = string.Format(@"localexplorer:{0}", Path.Combine(string.Format(@"{0}{1}", ConfigurationManager.AppSettings["SampleFileReadPath"], "ReportGroupAttachments"), fileName));
            attachedFiles.IsUrl = false;
            attachedFiles.CreatedDate = DateTime.Now;

            if (Convert.ToInt32(paymentID) == 0 && attachedFiles != null)
            {
                Session["ReportGroupFileAttached"] = attachedFiles;
                e.CallbackData = fileName + "|" + fileSize;


            }
            else
            {
                attachedFiles.FKTransID = Convert.ToInt32(paymentID);
                  attachedFiles.FKTransTypeID = TransactionTypeID;
                AttachedFilesDB attachedFilesDB = new AttachedFilesDB();
                attachedFilesDB.Insert(attachedFiles);
                Session["ReportGroupFileAttached"] = null;
            }
           
        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                long num = Convert.ToInt64(this.lblMasterId.Text);
                if (num > 0L)
                {
                    if (this.lblEdite.Text == "True")
                    {
                        this.ReportGroupDS.Update();
                    }
                    else
                    {
                        this.BtnSave.Enabled = false;
                        this.divmsg.Attributes["class"] = "alert alert-info";
                        this.LblError.ForeColor = Color.Red;
                        this.LblError.Text = "You dont have permission to Update";
                    }
                }
                else if (this.lblAdd.Text == "True")
                {
                    this.ReportGroupDS.Insert();

                    AttachedFilesDB attachedFilesDB = new AttachedFilesDB();
                    if (Session["ReportGroupFileAttached"] != null)
                    {
                        if (Session["ReportGroupID"] != null)
                        {
                            AttachedFiles attachedFiles = (AttachedFiles)Session["ReportGroupFileAttached"];
                            attachedFiles.FKTransID = Convert.ToInt32(Session["ReportGroupID"]);
                            attachedFiles.FKTransTypeID = TransactionTypeID;
                            AttachedFiles existingAttachedFiles = attachedFilesDB.GetAttachment(attachedFiles.FKTransID, TransactionTypeID);
                            if (existingAttachedFiles != null)
                            {
                                attachedFiles.FileID = existingAttachedFiles.FileID;
                                attachedFilesDB.Update(attachedFiles);
                            }
                            else
                                attachedFilesDB.Insert(attachedFiles);

                        }
                        Session["ReportGroupFileAttached"] = null;
                        Session["ReportGroupID"] = null;

                    }
                }
                else
                {
                    this.BtnSave.Enabled = false;
                    this.divmsg.Attributes["class"] = "alert alert-info";
                    this.LblError.ForeColor = Color.Red;
                    this.LblError.Text = "You dont have permission to Add";
                }
            }
            catch (Exception ex)
            {
                this.divmsg.Attributes["class"] = "alert alert-danger";
                this.LblError.ForeColor = Color.Red;
                this.LblError.Text = ex.Message;
            }
        }

        protected void ReportGroupDS_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
        {
            BusinessLayer.ReportGroup masterEntity = this.GetMasterEntity(0);
            e.InputParameters["entity"] = masterEntity;
        }

        protected void ReportGroupDS_Updating(object sender, ObjectDataSourceMethodEventArgs e)
        {
            int masterID = Convert.ToInt32(this.lblMasterId.Text);
            e.InputParameters["entity"] = this.GetMasterEntity(masterID);
        }

        private BusinessLayer.ReportGroup GetMasterEntity(int MasterID)
        {
            BusinessLayer.ReportGroup reportGroup;
            if (MasterID > 0)
                reportGroup = new ReportGroupDB().GetByID(MasterID);
            else
                reportGroup = new BusinessLayer.ReportGroup();
            
            reportGroup.GroupNumber = this.txtGroupNumber.Text;
            reportGroup.GroupName = this.txtGroupName.Text;
            reportGroup.FKMaterialTypeID = Convert.ToInt32(this.cmbFKMaterialTypeID.Value);
            reportGroup.GroupDescription = this.txtGroupDescription.Text;
            reportGroup.WorkFormFileName = this.txtWorkform.Text;
            reportGroup.WorkFormWorksheet = this.cmbWorkform.Text;
            reportGroup.ReportFileName = this.txtReport.Text;
            reportGroup.ReportWorksheet = this.cmbReport.Text;
            return reportGroup;
        }

        protected void ReportGroupDS_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
        {
            this.divmsg.Attributes["class"] = "alert alert-success";
            this.LblError.ForeColor = Color.Green;
            this.LblError.Text = "Data has been saved successfully!";
        }

        protected void ReportGroupDS_Updated(object sender, ObjectDataSourceStatusEventArgs e)
        {
            this.divmsg.Attributes["class"] = "alert alert-success";
            this.LblError.ForeColor = Color.Green;
            this.LblError.Text = "Data has been Updated successfully!";
        }

        protected void BtnBack_Click(object sender, EventArgs e)
		{
			base.Response.Redirect("ReportGroup.aspx");
		}

        protected void gdvColumnMapping_BatchUpdate(object sender, ASPxDataBatchUpdateEventArgs e)
        {
            foreach (ASPxDataUpdateValues aspxDataUpdateValues in e.UpdateValues)
            {
                this.UpdateItem(aspxDataUpdateValues.Keys, aspxDataUpdateValues.NewValues);
            }
        }

        protected ViewReportGroupExcelCellFieldMapping UpdateItem(OrderedDictionary keys, OrderedDictionary newValues)
        {
            List<ViewReportGroupExcelCellFieldMapping> source = new List<ViewReportGroupExcelCellFieldMapping>();
            new List<ViewExcelCellFieldMapping>();
            ViewReportGroupExcelCellFieldMapping viewReportGroupExcelCellFieldMapping = new ViewReportGroupExcelCellFieldMapping();
            source = new ReportGroupExcelMappingDB().GetFieldCellMappingListByGroupID(int.Parse(this.lblMasterId.Text.ToString()));
            int id = Convert.ToInt32(keys["ExcelMappingFieldId"]);
            viewReportGroupExcelCellFieldMapping = source.First((ViewReportGroupExcelCellFieldMapping j) => j.ExcelMappingFieldId == id);
            this.LoadNewValues(viewReportGroupExcelCellFieldMapping, newValues);

            if (!viewReportGroupExcelCellFieldMapping.IsForReport)
                new ReportGroupExcelMappingDB().UpdateMappingWithSession(viewReportGroupExcelCellFieldMapping);
            else
                new ReportGroupExcelMappingDB().UpdateMappingWithSession(viewReportGroupExcelCellFieldMapping);

            return viewReportGroupExcelCellFieldMapping;
        }

        private void LoadNewValues(ViewReportGroupExcelCellFieldMapping det, OrderedDictionary values)
        {
            det.ExcelCell = "";
            if (values.Contains("ExcelCell") && values["ExcelCell"] != null)
                det.ExcelCell = values["ExcelCell"].ToString();

            det.IsForReport = Convert.ToBoolean(this.isreport.Text);
        }

        protected void gdvColumnMapping_RowUpdating(object sender, ASPxDataUpdatingEventArgs e)
        {
            int num = Convert.ToInt32(this.lblMasterId.Text);
            bool flag = Convert.ToBoolean(this.isreport.Text);
            e.NewValues["FKGroupID"] = num;
            e.NewValues["IsForReport"] = flag;
        }

        protected void gdvColumnMapping_CustomErrorText(object sender, ASPxGridViewCustomErrorTextEventArgs e)
        {
            if (e.ErrorText == "SaveError")
            {
                e.ErrorText = "SaveError";
            }
            if (e.ErrorText != "SaveError")
            {
                e.ErrorText += ((e.Exception.InnerException == null) ? "" : (" ; IE:" + e.Exception.InnerException.Message));
            }
        }

        protected void uplWorkbookfile_FileUploadComplete(object sender, FileUploadCompleteEventArgs e)
		{
            try
            {
                string text = base.Server.MapPath("~/Uploaded/ReportGroupInfo/" + e.UploadedFile.FileName);
                this.txtWorkform.Text = e.UploadedFile.FileName;
                e.CallbackData = e.UploadedFile.FileName;
                e.UploadedFile.SaveAs(text);
                this.Session["WorkformWorksheetList"] = this.GetSheetListFromExcel(text);
            }
            catch (Exception ex)
            {
                this.LogError(ex);
                this.divmsg.Attributes["class"] = "alert alert-danger";
                this.LblError.ForeColor = Color.Red;
                this.LblError.Text = ex.Message + ((ex.InnerException == null) ? "" : ("IE: " + ex.InnerException.Message));
            }
        }

		protected void cmbWorkform_Callback(object sender, CallbackEventArgsBase e)
		{
			this.cmbWorkform.DataBind();
		}

		protected void uplReportfile_FileUploadComplete(object sender, FileUploadCompleteEventArgs e)
		{
            try
            {
                string text = base.Server.MapPath("~/Uploaded/ReportGroupInfo/" + e.UploadedFile.FileName);
                this.txtWorkform.Text = e.UploadedFile.FileName;
                e.CallbackData = e.UploadedFile.FileName;
                e.UploadedFile.SaveAs(text);
                this.Session["ReportWorksheetList"] = this.GetSheetListFromExcel(text);
            }
            catch (Exception ex)
            {
                this.LogError(ex);
                this.divmsg.Attributes["class"] = "alert alert-danger";
                this.LblError.ForeColor = Color.Red;
                this.LblError.Text = ex.Message + ((ex.InnerException == null) ? "" : ("IE: " + ex.InnerException.Message));
            }
        }

		protected void cmbReport_Callback(object sender, CallbackEventArgsBase e)
		{
			this.cmbReport.DataBind();
		}

        private List<string> GetSheetListFromExcel(string FilePath)
        {
            Workbook workbook = new Workbook();
            workbook.InvalidFormatException += this.book_InvalidFormatException;
            workbook.LoadDocument(FilePath);
            return (from x in workbook.Worksheets select x.Name).ToList<string>();
        }

        private void book_InvalidFormatException(object sender, SpreadsheetInvalidFormatExceptionEventArgs e)
        {
            this.divmsg.Attributes["class"] = "alert alert-danger";
            this.LblError.ForeColor = Color.Red;
            this.LblError.Text = e.Exception.Message;
        }

        private void LogError(Exception ex)
        {
            string text = string.Format("Time: {0}", DateTime.Now.ToString("dd MMM yyyy hh:mm:ss tt"));
            text += Environment.NewLine;
            text += "-----------------------------------------------------------";
            text += Environment.NewLine;
            text += string.Format("Message: {0}", ex.Message);
            text += Environment.NewLine;
            text += string.Format("StackTrace: {0}", ex.StackTrace);
            text += Environment.NewLine;
            text += string.Format("Source: {0}", ex.Source);
            text += Environment.NewLine;
            text += string.Format("TargetSite: {0}", ex.TargetSite.ToString());
            text += Environment.NewLine;
            if (ex.InnerException != null)
            {
                text += string.Format("InnerException: {0}", ex.InnerException.Message);
                text += Environment.NewLine;
            }
            text += "-----------------------------------------------------------";
            text += Environment.NewLine;
            string path = base.Server.MapPath("~/ErrorLogs/ErrorLog.txt");
            using (StreamWriter streamWriter = new StreamWriter(path, true))
            {
                streamWriter.WriteLine(text);
                streamWriter.Close();
            }
        }
    }
}