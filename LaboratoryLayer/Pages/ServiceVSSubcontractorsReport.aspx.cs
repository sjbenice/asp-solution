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
	public class ServiceVSSubcontractorsReport : Page
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
            LaboratoryLayer.Reports.Menu.ServiceVSSubcontractorsReport serviceVSSubcontractors = new LaboratoryLayer.Reports.Menu.ServiceVSSubcontractorsReport();
            if (dtDateFrom.Text != "")
                serviceVSSubcontractors.Parameters["FromDate"].Value = dtDateFrom.Date.ToString("MM/dd/yyyy");

            if (dtDateTo.Text != "")
                serviceVSSubcontractors.Parameters["ToDate"].Value = dtDateTo.Date.ToString("MM/dd/yyyy");

            serviceVSSubcontractors.Parameters["JoNo"].Value = cmbJobOrderNo.Value;
            serviceVSSubcontractors.Parameters["AccreditationStatusID"].Value = cmbAccreditationStatus.Value;
            serviceVSSubcontractors.CreateDocument();
            return serviceVSSubcontractors;
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

        protected ASPxComboBox cmbAccreditationStatus;
    }
}
