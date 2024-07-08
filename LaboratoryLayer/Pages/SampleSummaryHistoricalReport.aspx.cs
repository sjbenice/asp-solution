using System;
using System.Web.UI.HtmlControls;
using DevExpress.Web;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Web;
namespace LaboratoryLayer.Pages
{
    public partial class SampleSummaryHistoricalReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Tuple<bool, string> valid = Validate();
                if (valid.Item1)
                    this.ReportViewer1.Report = this.GetReport();
                else
                {
                    this.ReportViewer1.Visible = false;
                    this.lblError.Text = valid.Item2;
                }
                this.ReportViewer1.Report = this.GetReport();
                this.ReportViewer1.Visible = true;
            }
        }

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            this.ReportViewer1.Report = this.GetReport();
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

        protected Tuple<bool, string> Validate()
        {
            bool valid = false;
            string error = "";
            if (dtDateFrom.Text != "")
            {
                var diffMonths = (dtDateTo.Date.Month + dtDateTo.Date.Year * 12) - (dtDateFrom.Date.Month + dtDateFrom.Date.Year * 12);
                if (diffMonths <= 6)
                {
                    valid = true;
                    error = "From and To Date should not more than 6 month difference.";
                }
            }
            else
            {
                if (cmbContractorName.Value != null)
                    valid = true;
                else if (cmbproject.Value != null)
                    valid = true;
                else if (!string.IsNullOrWhiteSpace(tbSampleNoF.Text))
                    valid = true;
                else if (!string.IsNullOrWhiteSpace(tbSampleNoT.Text))
                    valid = true;
                if (!valid)
                    error = "Select at least one filter and then try again!";
            }

            return new Tuple<bool, string>(valid, error);
        }

        protected XtraReport GetReport()
        {
            LaboratoryLayer.Reports.Historical.SampleSummaryReport sampleSummary = new LaboratoryLayer.Reports.Historical.SampleSummaryReport();
            if (dtDateFrom.Text != "")
                sampleSummary.Parameters["samFromDate"].Value = dtDateFrom.Date.ToString("dd-MMM-yyyy");

            if (dtDateTo.Text != "")
                sampleSummary.Parameters["samDateTo"].Value = dtDateTo.Date.ToString("dd-MMM-yyyy");

            if (dtDateFrom0.Text != "")
                sampleSummary.Parameters["entFromDate"].Value = dtDateFrom0.Date.ToString("dd-MMM-yyyy");

            if (dtTo0.Text != "")
                sampleSummary.Parameters["entDateTo"].Value = dtTo0.Date.ToString("dd-MMM-yyyy");

            sampleSummary.Parameters["Contractor"].Value = cmbContractorName.Value;
            sampleSummary.Parameters["Project"].Value = cmbproject.Value;
            sampleSummary.Parameters["SampleNo1"].Value = tbSampleNoF.Text;
            sampleSummary.Parameters["SampleNo2"].Value = tbSampleNoT.Value;


            sampleSummary.CreateDocument();
            return sampleSummary;
        }

        //protected HtmlGenericControl ultitle;

        //protected HtmlGenericControl divParms;

        //protected HtmlGenericControl divValidityDetails;

        protected ASPxLabel ASPxLabel2;

        //protected ASPxDateEdit dtDateFrom;

        //protected ASPxLabel ASPxLabel1;

        //protected ASPxDateEdit dtDateTo;

        //protected ASPxButton btnGenerate;

        //protected ASPxLabel lblError;

        //protected ASPxDocumentViewer ReportViewer1;

        //protected ASPxComboBox cmbJobOrderNo;

        //protected ASPxTextBox tbSampleNo;

        //protected ASPxComboBox cmbServiceName;
        //protected ASPxComboBox cmbContractorName;

    }
}