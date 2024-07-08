using System;
using LaboratoryLayer.Reports;
namespace LaboratoryLayer.Pages
{
    public partial class RSSSummaryHistoricalReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (IsPostBack)
            ViewReport();
        }
        public void btnSearch_Click(object sender, EventArgs e)
        {

            ViewReport();
            // this.CrystalReportViewer1.RefreshReport();
        }
        public void ViewReport()
        {
            //RequestSampleSummaryReport inc = new RequestSampleSummaryReport();
            //inc.Parameters["RequestNo"].Value = txtRSSNo.Text;
            //inc.CreateDocument();
            //this.ReportViewer1.Report = inc;
        }
    }
}