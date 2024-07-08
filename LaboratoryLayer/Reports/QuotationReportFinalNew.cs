using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using BusinessLayer.Pages;
using BusinessLayer;
using System.IO;
using System.Web;
using BusinessLayer.Admin;

namespace LaboratoryLayer.Reports
{
    public partial class QuotationReportFinalNew : DevExpress.XtraReports.UI.XtraReport
    {
        public QuotationReportFinalNew(int quoteID)
        {
            InitializeComponent();

            ADMUsers admusers = null;
            //int? quoteID = this.Parameters["QID"].Value as int?;
            //if (quoteID.HasValue)
            //{
                QuotationMasterDB quotationMasterDB = new QuotationMasterDB();
                QuotationMaster master = quotationMasterDB.GetByID(quoteID);
                if (master != null)
                {
                    UsersDB usersDB = new UsersDB();
                    admusers = usersDB.GetByEName(master.ApprovedBy);
                }
            //}

            //ADMUsers admusers = (ADMUsers) HttpContext.Current.Session["CurrentUser"];
            if (admusers != null)
            {
                AttachedFilesDB attachedFilesDB = new AttachedFilesDB();
                AttachedFiles attachedFiles = new AttachedFiles();
                int transTypeID = 33333;   //For User Signature

                long transID = admusers.UserID;       //Current User's Id
                attachedFiles = attachedFilesDB.GetAttachment(transID, transTypeID);

                if (attachedFiles != null && attachedFiles.FileContent.Length > 0)
                {
                    MemoryStream ms = new MemoryStream(attachedFiles.FileContent);
                    xrpbSignature.Image = Image.FromStream(ms);
                }
            }
        }
    }
}
