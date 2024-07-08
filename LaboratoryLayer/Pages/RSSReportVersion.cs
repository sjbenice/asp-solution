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

    public class RSSReportVersion : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            ////List<UserLinkOptionsView> allOptionsForLink = new UserRolesDB().GetAllOptionsForLink("../Pages/RSSReportVersion.aspx", long.Parse(this.Session["UserId"].ToString()));
            ////foreach (UserLinkOptionsView userLinkOptionsView in allOptionsForLink)
            ////{
            ////    if (userLinkOptionsView.OptionEName == "Add")
            ////    {
            ////        this.lblAdd.Text = "True";
            ////    }
            ////    if (userLinkOptionsView.OptionEName == "Edit")
            ////    {
            ////        this.lblEdite.Text = "True";
            ////    }
            ////    if (userLinkOptionsView.OptionEName == "Delete")
            ////    {
            ////        this.lblDelete.Text = "True";
            ////    }
            ////    if (userLinkOptionsView.OptionEName == "View")
            ////    {
            ////        this.lblView.Text = "True";
            ////    }
            ////}
            base.Response.Clear();
            if (!base.IsPostBack)
            {
                long id = Convert.ToInt64(base.Request["id"]);
                if (id > 0L)
                {
                    var RSSNumber = new RSSMasterDB().GetByID(id).RSSNumber;

                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("RSSNumber", typeof(string));
                    dataTable.Columns.Add("HyperlinkColumnName", typeof(string));

                    string directoryPath = Server.MapPath("~/Uploaded/RSSReceive");
                    string[] pdfFiles = Directory.GetFiles(directoryPath, RSSNumber + "-R*.pdf")
                                                .Select(Path.GetFileName)
                                                .ToArray();

                    foreach (string row in pdfFiles)
                    {
                        dataTable.Rows.Add(row, "~/Uploaded/RSSReceive/" + row);
                    }

                    ASPxGridViewPopup.DataSource = dataTable;
                    ASPxGridViewPopup.DataBind();
                }

                ASPxGridViewPopup.SettingsBehavior.AllowSort = false;
            }
        }


        protected ASPxLabel lblView;
        
        protected ASPxLabel lblEdite;
        
        protected ASPxLabel lblDelete;

        protected ASPxLabel lblAdd;

        protected ASPxGridView ASPxGridViewPopup;
    }
}
