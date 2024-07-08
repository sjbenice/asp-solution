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
	public class ServicesReceivedVsQARReport : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if (IsPostBack)
                this.ReportViewer1.Report = this.GetReport();
        }

		protected void btnGenerate_Click(object sender, EventArgs e)
		{
            //this.ReportViewer1.Report = this.GetReport();
            if (this.ReportViewer1.Report.Pages.Count == 0)
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
            LaboratoryLayer.Reports.Menu.ServicesReceivedVsQARReport servicesReceivedVsQAR = new LaboratoryLayer.Reports.Menu.ServicesReceivedVsQARReport();
            if (dtDateFrom.Text != "")
                servicesReceivedVsQAR.Parameters["FromDate"].Value = dtDateFrom.Date.ToString("MM/dd/yyyy");

            if (dtDateTo.Text != "")
                servicesReceivedVsQAR.Parameters["ToDate"].Value = dtDateTo.Date.ToString("MM/dd/yyyy");

            if (cmbJobOrderNo.Value != null)
                servicesReceivedVsQAR.Parameters["JoNo"].Value = cmbJobOrderNo.Value;
            else
                servicesReceivedVsQAR.Parameters["JoNo"].Value = 0;

            if (cmbServiceName.Value != null)
                servicesReceivedVsQAR.Parameters["ServiceID"].Value = cmbServiceName.Value;
            else
                servicesReceivedVsQAR.Parameters["ServiceID"].Value = 0;

            if (cmbAccreditationStatus.Value != null)
                servicesReceivedVsQAR.Parameters["AccreditationStatusID"].Value = cmbAccreditationStatus.Value;
            else
                servicesReceivedVsQAR.Parameters["AccreditationStatusID"].Value = 0;

            // Barkat : filter value of Service Section
            if (cmbFKMaterialTypeID.Value != null)
                servicesReceivedVsQAR.Parameters["MaterialTypeID"].Value = cmbFKMaterialTypeID.Value;
            else
                servicesReceivedVsQAR.Parameters["MaterialTypeID"].Value = 0;

            if (cmblabsection.Value != null)
                servicesReceivedVsQAR.Parameters["LabNameID"].Value = cmblabsection.Value;
            else
                servicesReceivedVsQAR.Parameters["LabNameID"].Value = 0;

            servicesReceivedVsQAR.CreateDocument();
            return servicesReceivedVsQAR;
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

        protected ASPxComboBox cmbServiceName;

        protected ASPxComboBox cmblabsection;
        protected ASPxComboBox cmbFKMaterialTypeID;

    }
}
