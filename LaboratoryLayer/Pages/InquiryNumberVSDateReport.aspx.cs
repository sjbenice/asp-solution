﻿using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using DevExpress.Web;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Web;
using LaboratoryLayer.Reports;
using LaboratoryLayer.Reports.Menu;

namespace LaboratoryLayer.Pages.Reports
{
	public class InquiryNumberVSDateReport : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if (IsPostBack)
                this.ReportViewer1.Report = this.GetReport();
        }

		protected void btnGenerate_Click(object sender, EventArgs e)
		{
            //this.ReportViewer1.Report = this.GetReport();
            if (this.ReportViewer1.Report.RowCount == 0)
            {
                this.ReportViewer1.Visible = false;
                this.lblError.Text = "No Data";
            }
            else
            {
                this.lblError.Text = "";
                this.ReportViewer1.Visible = true;
            }
        }

		protected XtraReport GetReport()
		{
            LaboratoryLayer.Reports.Menu.InquiryNumberVSDateReport inquiryNumberVSDate = new LaboratoryLayer.Reports.Menu.InquiryNumberVSDateReport();
            if (dtInquiryDateFrom.Text != "")
                inquiryNumberVSDate.Parameters["FromDate"].Value = dtInquiryDateFrom.Date.ToString("MM/dd/yyyy");

            if (dtInquiryDateTo.Text != "")
                inquiryNumberVSDate.Parameters["ToDate"].Value = dtInquiryDateTo.Date.ToString("MM/dd/yyyy");

            inquiryNumberVSDate.CreateDocument();
            return inquiryNumberVSDate;
		}

		protected HtmlGenericControl ultitle;

		protected HtmlGenericControl divParms;

		protected HtmlGenericControl divValidityDetails;

		protected ASPxLabel ASPxLabel2;

		protected ASPxDateEdit dtInquiryDateFrom;

		protected ASPxLabel ASPxLabel1;

        protected ASPxDateEdit dtInquiryDateTo;

        protected ASPxButton btnGenerate;

		protected ASPxLabel lblError;

		protected ASPxDocumentViewer ReportViewer1;
	}
}
