using System;
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
	public class DateVsPaymentReport : Page
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
            LaboratoryLayer.Reports.Menu.DateVsPaymentReport dateVsPayment = new LaboratoryLayer.Reports.Menu.DateVsPaymentReport();
            if (dtDateFrom.Text != "")
                dateVsPayment.Parameters["FromDate"].Value = dtDateFrom.Date.ToString("MM/dd/yyyy");

            if (dtDateTo.Text != "")
                dateVsPayment.Parameters["ToDate"].Value = dtDateTo.Date.ToString("MM/dd/yyyy");

            dateVsPayment.Parameters["JoNo"].Value = cmbJobOrderNo.Value;
            dateVsPayment.Parameters["InvNumber"].Value = tbInvNumber.Text;
            dateVsPayment.Parameters["ReceiptNo"].Value = tbReceiptNo.Text;
            dateVsPayment.Parameters["BookCrvNo"].Value = txtBookCrvNo.Text;
            dateVsPayment.Parameters["CustomerID"].Value = cmbCustomer.Value??0;
            dateVsPayment.CreateDocument();
            return dateVsPayment;
		}

		protected HtmlGenericControl ultitle;

		protected HtmlGenericControl divParms;

		protected HtmlGenericControl divValidityDetails;

		protected ASPxLabel ASPxLabel2;

        protected ASPxDateEdit dtDateFrom;

        protected ASPxLabel ASPxLabel1;

        protected ASPxDateEdit dtDateTo;

        protected ASPxButton btnGenerate;

		protected ASPxLabel lblError;

		protected ASPxDocumentViewer ReportViewer1;

        protected ASPxComboBox cmbJobOrderNo;

        protected ASPxTextBox tbInvNumber;

        protected ASPxTextBox tbReceiptNo;

        protected ASPxTextBox txtBookCrvNo;

        protected ASPxComboBox cmbCustomer;
    }
}
