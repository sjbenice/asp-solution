using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BusinessLayer;
using BusinessLayer.Admin;
using BusinessLayer.Pages;
using DevExpress.Web;
using DevExpress.Web.Data;

namespace LaboratoryLayer.Pages
{

    public class LastTestInfoAttachment : Page
    {

        private string _attachTransIDSessionString = "_appattachTransID";
		private string _fileListSessionString = "_appattachfiles";
		private string _unSavedFileListSessionString = "_appattachUnsavedfiles";
       
        protected ASPxLabel lblMasterId;
        protected ASPxLabel lblUploadDirectory;


        public const int TransactionTypeID = 55555;
        public long TransactionID
        {
            get
            {
                if (this.Session[this._attachTransIDSessionString] != null)
                {
                    return long.Parse(this.Session[this._attachTransIDSessionString].ToString());
                }
                return long.Parse(this.lblMasterId.Text);
            }
            set
            {
                this.Session[this._attachTransIDSessionString] = value.ToString();
                this.lblTransID.Text = value.ToString();
            }
        }
        public string UploadDirectory
        {
            get
            {
                return this.lblUploadDirectory.Text;
            }
            set
            {
                this.lblUploadDirectory.Text = value;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            List<UserLinkOptionsView> allOptionsForLink = new UserRolesDB().GetAllOptionsForLink("../Pages/LabTestInfoManage.aspx", long.Parse(this.Session["UserId"].ToString()));
            foreach (UserLinkOptionsView userLinkOptionsView in allOptionsForLink)
            {
                if (userLinkOptionsView.OptionEName == "Add")
                {
                    this.lblAdd.Text = "True";
                }
                if (userLinkOptionsView.OptionEName == "Edit")
                {
                    this.lblEdite.Text = "True";
                }
                if (userLinkOptionsView.OptionEName == "Delete")
                {
                    this.lblDelete.Text = "True";
                }
                if (userLinkOptionsView.OptionEName == "View")
                {
                    this.lblView.Text = "True";
                }
            }
            base.Response.Clear();
            if (!base.IsPostBack)
            {
                this.Session[this._fileListSessionString] = null;
                this.Session[this._unSavedFileListSessionString] = null;

                long id = Convert.ToInt64(base.Request["id"]);
                this.lblMasterId.Text = id.ToString();
                this.Session["lblMasterId"] = this.lblMasterId.Text;

                this.lblTransTypeID.Text = TransactionTypeID.ToString();
                this.TransactionID = long.Parse(lblMasterId.Text);

                this.gdvfiles.DataBind();



            }
        }

        protected void gdvfiles_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            (sender as ASPxGridView).DataBind();
        }
        protected void gdvfiles_RowCommand(object sender, ASPxGridViewRowCommandEventArgs e)
        {
            if (e.CommandArgs.CommandName == "download")
            {
                AttachedFiles attachedFiles = new AttachedFiles();
                int num = Convert.ToInt32(e.CommandArgs.CommandArgument.ToString());
                object commandSource = e.CommandSource;
                AttachedFilesDB attachedFilesDB = new AttachedFilesDB();
                attachedFiles = attachedFilesDB.GetByID((long)num);
                if (attachedFiles != null)
                {
                    string str = attachedFiles.FileName.Replace(" ", "_");
                    byte[] fileContent = attachedFiles.FileContent;
                    base.Response.Clear();
                    base.Response.ClearHeaders();
                    base.Response.AddHeader("Content-Type", "Application/octet-stream");
                    base.Response.AddHeader("Content-Length", fileContent.Length.ToString());
                    base.Response.AddHeader("Content-Disposition", "attachment;   filename=" + str);
                    base.Response.BinaryWrite(fileContent);
                    base.Response.Flush();
                    base.Response.End();
                }
            }
            
        }

        public void ClearSessions()
        {
            this.Session[this._fileListSessionString] = null;
            this.Session[this._attachTransIDSessionString] = null;
            this.Session[this._unSavedFileListSessionString] = null;
        }


        protected ASPxLabel lblView;
        
        protected ASPxLabel lblEdite;
        
        protected ASPxLabel lblDelete;

        protected ASPxLabel lblAdd;

        protected ASPxGridView ASPxGridViewPopup;

        protected ASPxGridView gdvfiles;

        protected ASPxLabel lblTransID;

        protected ASPxLabel lblTransTypeID;

    }
}
