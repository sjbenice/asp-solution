using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using DevExpress.Web;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Web;
using LaboratoryLayer.Reports;
using LaboratoryLayer.Reports.Menu;

namespace LaboratoryLayer.Pages
{
    public partial class ServiceVSMaterialsReport : System.Web.UI.Page
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
            LaboratoryLayer.Reports.Menu.ServiceVSMaterialsReport ServiceVSMaterialsReport = new LaboratoryLayer.Reports.Menu.ServiceVSMaterialsReport();
            if (cmdServiceName.Value != null)
                ServiceVSMaterialsReport.Parameters["ServiceName"].Value = cmdServiceName.Value;
            else
                ServiceVSMaterialsReport.Parameters["ServiceName"].Value = "";

            if (cmbServiceSection.Value != null)
                ServiceVSMaterialsReport.Parameters["MaterialName"].Value = cmbServiceSection.Value;
            else
                ServiceVSMaterialsReport.Parameters["MaterialName"].Value = "";

            ServiceVSMaterialsReport.CreateDocument();
            return ServiceVSMaterialsReport;
        }

        protected HtmlGenericControl ultitle;

        protected HtmlGenericControl divParms;

        protected HtmlGenericControl divValidityDetails;

        protected ASPxLabel ASPxLabel2;

        protected ASPxComboBox cmbAccreditationStatus;

        protected ASPxLabel ASPxLabel1;

        protected DropDownList ddlTestAvailability;

        protected ASPxButton btnGenerate;

        protected ASPxLabel lblError;

        protected ASPxDocumentViewer ReportViewer1;

        protected ASPxDropDownEdit cmdServiceName;

        protected ASPxDropDownEdit cmbServiceSection;
    }
}