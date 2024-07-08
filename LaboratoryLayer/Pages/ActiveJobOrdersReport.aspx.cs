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
	public class ActiveJobOrdersReport : Page
	{
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //          this.ReportViewer1.Report = this.GetReport();
        //          if (this.ReportViewer1.Report.RowCount == 0)
        //          {
        //              this.ReportViewer1.Visible = false;
        //              this.lblError.Text = "No Data";
        //          }
        //          else
        //          {
        //              this.lblError.Text = "";
        //              this.ReportViewer1.Visible = true;
        //          }
        //      }
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
            LaboratoryLayer.Reports.Menu.ActiveJobOrdersReport activeJobOrders = new LaboratoryLayer.Reports.Menu.ActiveJobOrdersReport();
            if (dtTransactionDate.Text != "")
                activeJobOrders.Parameters["TransactionDate"].Value = dtTransactionDate.Date.ToString("MM/dd/yyyy");
            activeJobOrders.Parameters["JobOrderNumber"].Value = cmbJobOrderNo.Value;
            //if (dtReceiveDate.Text != "")
                activeJobOrders.Parameters["CustomerID"].Value = cmbCustomer.Value;
            if (dtReceiveDate.Text != "")
                activeJobOrders.Parameters["ReceiveDate"].Value = dtReceiveDate.Date.ToString("MM/dd/yyyy");
            if (dtPaymentDate.Text != "")
                activeJobOrders.Parameters["PaymentDate"].Value = dtPaymentDate.Date.ToString("MM/dd/yyyy");

            //if (tbPaymentAmount.Text != "")
                activeJobOrders.Parameters["PaymentAmount"].Value = tbPaymentAmount.Text;
            if (cmbCustomer.Text != "")
                ASPxLabel5.Text = cmbCustomer.Value.ToString();

            activeJobOrders.CreateDocument();
            return activeJobOrders;
		}
        protected HtmlGenericControl ultitle;

        protected HtmlGenericControl divParms;

        protected HtmlGenericControl divValidityDetails;

        protected ASPxLabel ASPxLabel2;

        protected ASPxDateEdit dtTransactionDate;

        protected ASPxLabel ASPxLabel1;

        protected ASPxDateEdit dtReceiveDate;
        protected ASPxDateEdit dtPaymentDate;

        protected ASPxButton btnGenerate;

        protected ASPxLabel lblError;
        protected ASPxLabel ASPxLabel5;

        protected ASPxDocumentViewer ReportViewer1;

        protected ASPxComboBox cmbJobOrderNo;

        protected ASPxTextBox tbPaymentAmount;

      

        protected ASPxComboBox cmbCustomer;
	}
}
