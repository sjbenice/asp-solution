using BusinessLayer;
using BusinessLayer.Pages;
using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LaboratoryLayer.Pages
{
    public partial class SmapleReceiveAndAttachmentView : System.Web.UI.Page
    {
        public int TransactionTypeID
        {
            get
            {
                return int.Parse(this.lblTransTypeID.Text);
            }
            set
            {
                this.lblTransTypeID.Text = value.ToString();
            }
        }

        // Token: 0x17000034 RID: 52
        // (get) Token: 0x060000A7 RID: 167 RVA: 0x000073E0 File Offset: 0x000055E0
        // (set) Token: 0x060000A8 RID: 168 RVA: 0x0000279C File Offset: 0x0000099C
        public long TransactionID
        {
            get
            {
               
                return long.Parse(this.lblTransID.Text);
            }
            set
            {
                this.lblTransID.Text = value.ToString();
            }
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
                    string fileUrl = attachedFiles.FileUrl;
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
            else if (e.CommandArgs.CommandName == "delete")
            {
                AttachedFiles attachedFiles = new AttachedFiles();
                int num = Convert.ToInt32(e.CommandArgs.CommandArgument.ToString());
                object commandSource = e.CommandSource;
                AttachedFilesDB attachedFilesDB = new AttachedFilesDB();
                attachedFiles = attachedFilesDB.GetByID((long)num);
                if (attachedFiles != null)
                {

                    bool result = attachedFilesDB.Delete(attachedFiles);
                    if (attachedFiles.FKTransTypeID == 111222)
                    {
                        var byID = new TestReportingDB().GetByID(attachedFiles.FKTransID);

                        if (this.GetAttachmentList().Count - 1 <= 0)
                        {
                            byID.TestEndingDate = null;
                            new TestReportingDB().Update(byID);
                        }
                    }
                    this.ClearSessions();
                    this.gdvfiles.DataBind();

                }
            }
        }
        public void ClearSessions()
        {
            this.Session[this._fileListSessionString] = null;
         
        }

        // Token: 0x04000083 RID: 131
        private string _fileListSessionString = "_appattachfiles";
        public List<AttachedFiles> GetAttachmentList()
        {
            List<AttachedFiles> result = new List<AttachedFiles>();
            if (this.Session[this._fileListSessionString] != null)
            {
                result = (List<AttachedFiles>)this.Session[this._fileListSessionString];
            }
            return result;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              

             

                long id = Convert.ToInt64(base.Request["TransID"]);
                if (id > 0L)
                {
                    this.lblTransTypeID.Text = base.Request["TransTypeID"];
                    this.TransactionID = id;
                    this.gdvfiles.DataBind();

                    ASPxGridViewPopup.DataBind();
                }
            }
        }

        protected void FilContents_DataBinding(object sender, EventArgs e)
        {
           
        }

        protected void gdvfiles_DataBinding(object sender, EventArgs e)
        {
            long id = Convert.ToInt64(base.Request["TransID"]);
            if (id > 0L)
            {
                TestReporting testReporting = new TestReportingDB().GetByID(id);

                SampleReceiveTestListDB sampleReceiveTestListDB = new SampleReceiveTestListDB();
                SampleReceiveTestList receiveTestList = sampleReceiveTestListDB.GetByID(testReporting.FKSampleReceiveTestID);
                this.lblTransTypeID.Text = base.Request["TransTypeID"];
                this.TransactionID = id;
                id = Convert.ToInt64(receiveTestList.FKSampleID);
                var result = from c in new AttachedFilesDB().GetAttachmentListListByTransID(id)
                             select c;
                gdvfiles.DataSource = result;
            }
        }

        protected void ASPxGridViewPopup_DataBinding(object sender, EventArgs e)
        {
            long id = 0L;
            if (Int64.TryParse(base.Request["TransID"].ToString(), out id))
            {
                if (id > 0L)
                {

                    TestReporting testReporting = new TestReportingDB().GetByID(id);

                    SampleReceiveTestListDB sampleReceiveTestListDB = new SampleReceiveTestListDB();
                    SampleReceiveTestList receiveTestList = sampleReceiveTestListDB.GetByID(testReporting.FKSampleReceiveTestID);
                if (receiveTestList != null)
                    {
                        var SampleNo = new SampleReceiveListDB().GetByID(receiveTestList.FKSampleID.Value).SampleNo;

                        DataTable dataTable = new DataTable();
                        dataTable.Columns.Add("ReportName", typeof(string));
                        dataTable.Columns.Add("HyperlinkColumnName", typeof(string));

                        string directoryPath = Server.MapPath("~/Uploaded/SampleReceive");
                        string[] pdfFiles = Directory.GetFiles(directoryPath, SampleNo + "-R*.pdf")
                                                    .Select(Path.GetFileName)
                                                    .ToArray();

                        foreach (string row in pdfFiles)
                        {
                            dataTable.Rows.Add(row, "~/Uploaded/SampleReceive/" + row);
                        }

                        ASPxGridViewPopup.DataSource = dataTable;
                    }
                }
            }
        }

        protected void gdvfiles_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            string[] args = e.Parameters.Split('|');
            string command = args[0];
            string commandArgument = args[1];
            if (command == "btnPrintDetailClicked")
            {
             var   AttachedFiles  = new AttachedFilesDB().GetByID(Convert.ToInt64(commandArgument));
if(AttachedFiles != null)
                {

              

                TestReporting testReporting = new TestReportingDB().GetByID(this.TransactionID);
                string excelPath = ConvertFile.GetFilePath(testReporting);
                    string AttachmentFilesPath = string.Format(@"{0}{1}\{2}", ConfigurationManager.AppSettings["SampleFileReadPath"],
                             Path.GetFileName(Path.GetDirectoryName(excelPath)).Replace("\\", ""), "AttachmentFiles");

                    string AttachmentFilesPathNetwork = string.Format(@"{0}{1}\{2}", ConfigurationManager.AppSettings["SampleFileReadPath1"],
                            Path.GetFileName(Path.GetDirectoryName(excelPath)).Replace("\\", ""), "AttachmentFiles");
                    if (!Directory.Exists(AttachmentFilesPathNetwork))
                    {
                        Directory.CreateDirectory(AttachmentFilesPathNetwork);
                    }
         string copiedFile = string.Format(@"{0}\{1}", AttachmentFilesPathNetwork,
                                     AttachedFiles.FileName);
                    string copiedFileNetwork = string.Format(@"{0}\{1}", AttachmentFilesPath,
                            AttachedFiles.FileName);
                    if (File.Exists(copiedFile))
                {
                    File.Delete(copiedFile);
                }
                    File.WriteAllBytes(copiedFile, AttachedFiles.FileContent);
                gdvfiles.JSProperties["cpRowCommandCompleted"] = string.Format(@"localexplorer:{0}", copiedFileNetwork);
                }
            }
        }
    }
}