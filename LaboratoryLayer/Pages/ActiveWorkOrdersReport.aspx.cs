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
	public class ActiveWorkOrdersReport : Page
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
            LaboratoryLayer.Reports.Menu.ActiveWorkOrdersReport activeWorkOrders = new LaboratoryLayer.Reports.Menu.ActiveWorkOrdersReport();

          
            activeWorkOrders.Parameters["WorkOrderNo"].Value = cmbWorkOrderNo.Value;
            //if (dtReceiveDate.Text != "")
            activeWorkOrders.Parameters["CustomerID"].Value = cmbCustomer.Value;
            if (dtTransDate.Text != "")
                activeWorkOrders.Parameters["TransDate"].Value = dtTransDate.Date.ToString("MM/dd/yyyy");
            if (dtLastInvoicePaidDate.Text != "")
                activeWorkOrders.Parameters["LastInvoicePaidDate"].Value = dtLastInvoicePaidDate.Date.ToString("MM/dd/yyyy");

            //if (tbPaymentAmount.Text != "")
            activeWorkOrders.Parameters["LastInvoicePaidAmount"].Value = dtLastInvoicePaidAmount.Text;

            activeWorkOrders.CreateDocument();
            return activeWorkOrders;
		}

        protected HtmlGenericControl ultitle;

        protected HtmlGenericControl divParms;

        protected HtmlGenericControl divValidityDetails;

        protected ASPxLabel ASPxLabel2;

        protected ASPxDateEdit dtLastInvoicePaidDate;

        protected ASPxLabel ASPxLabel1;

        protected ASPxDateEdit dtTransDate;      

        protected ASPxButton btnGenerate;

        protected ASPxLabel lblError;
        protected ASPxLabel ASPxLabel5;

        protected ASPxDocumentViewer ReportViewer1;

        protected ASPxComboBox cmbWorkOrderNo;

        protected ASPxTextBox dtLastInvoicePaidAmount;



        protected ASPxComboBox cmbCustomer;
    }
}
