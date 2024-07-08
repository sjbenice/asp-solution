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
	public class SampleSummaryReport : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if (IsPostBack)
            {
                Tuple<bool, string> valid = Validate();
                if (valid.Item1)
                {
                    this.ReportViewer1.Report = this.GetReport();
                    this.ReportViewer1.Visible = true;
                    this.lblError.Visible = true;

                }
                else
                {
                    this.ReportViewer1.Visible = false;
                    this.lblError.Text = valid.Item2;
                    this.lblError.Visible = true;
                }
              
            }
        }

		protected void btnGenerate_Click(object sender, EventArgs e)
		{
            //this.ReportViewer1.Report = this.GetReport();
            //if (this.ReportViewer1.Report.RowCount == 0)
            //{
            //    this.ReportViewer1.Visible = false;
            //    this.lblError.Text = "No Data";
            //}
            //else
            //{
            //    this.lblError.Text = "";
            //    this.ReportViewer1.Visible = true;
            //}
        }

        protected Tuple<bool, string> Validate()
        {
            bool valid = false;
            string error = "";
            if (dtDateFrom.Text != "" && dtDateTo.Text !="")
            {
                valid = true;
            }
           
                if (cmbJobOrderNo.Value != null)
                    valid = true;
                 if (ASPxDropDownEdit1.Value != null)
                    valid = true;
                 if (!string.IsNullOrWhiteSpace(tbSampleNo.Text))
                    valid = true;
                 if(cmblabsection.Value!=null)
                valid = true;
                 if (cmbSubcontractors.Value!=null)
                valid = true;
            if (cmdSubContracted.Text != "")
                valid = true;
            
            if (cmblabsection.Value != null)
                valid = true;
                 if(txtFromReportNo.Text!="" || txtToReportNumber.Text !="")
                valid = true;
            if (txtFromRRSNo.Text != "" || txtFromRRSNo.Text != "")
                valid = true;

            if (cmbTechnician.Value != null)
                valid = true;
            if (dtSamplingDate.Text != "")
                valid = true;
            if(txtSiteRefNo.Text!="")
                valid = true;

            if (!valid)
                    error = "Select at least one filter and then try again!";
            

            return new Tuple<bool, string>(valid, error);
        }

		protected XtraReport GetReport()
		{
            try
            {

           
            LaboratoryLayer.Reports.Menu.SampleSummaryReport sampleSummary = new LaboratoryLayer.Reports.Menu.SampleSummaryReport();
                if (dtDateFrom.Text != "")
                    sampleSummary.Parameters["FromDate"].Value = dtDateFrom.Date.ToString("MM/dd/yyyy");
                else
                    sampleSummary.Parameters["FromDate"].Value = "";

            if (dtDateTo.Text != "")
                sampleSummary.Parameters["ToDate"].Value = dtDateTo.Date.ToString("MM/dd/yyyy");
            else
                    sampleSummary.Parameters["ToDate"].Value = "";


                if (txtFromReportNo.Value != null)
                    sampleSummary.Parameters["FromReportNo"].Value = txtFromReportNo.Value;
                else
                    sampleSummary.Parameters["FromReportNo"].Value = 0;

                if (txtToReportNumber.Value != null)
                    sampleSummary.Parameters["ToReportNumber"].Value = txtToReportNumber.Value;
                else
                    sampleSummary.Parameters["ToReportNumber"].Value = 0;


                if (txtFromRRSNo.Value != null)
                    sampleSummary.Parameters["FromRSSNo"].Value = txtFromRRSNo.Value;
                else
                    sampleSummary.Parameters["FromRSSNo"].Value = 0;

                if (txtToRRSNo.Value != null)
                    sampleSummary.Parameters["ToRSSNo"].Value = txtToRRSNo.Value;
                else
                    sampleSummary.Parameters["ToRSSNo"].Value = 0;

                sampleSummary.Parameters["SampleNo"].Value = tbSampleNo.Text;

                if (cmdSubContracted.Text == "Yes" || cmdSubContracted.Text == "No")
                    sampleSummary.Parameters["IsSubContracted"].Value = cmdSubContracted.Value;
                else
                    sampleSummary.Parameters["IsSubContracted"].Value = "";



                sampleSummary.Parameters["JoNo"].Value = cmbJobOrderNo.Value;
            sampleSummary.Parameters["ServiceNameID"].Value = ASPxDropDownEdit1.Value;
          
            sampleSummary.Parameters["LabSection"].Value = cmblabsection.Value;
            if (cmbSubcontractors.Value != null)
                sampleSummary.Parameters["SubContractorID"].Value = cmbSubcontractors.Value;
            else
                sampleSummary.Parameters["SubContractorID"].Value = 0;

                if (ASPxDropDownEdit1.Value != null)
                    sampleSummary.Parameters["TestID"].Value = ASPxDropDownEdit1.Value;
                else
                    sampleSummary.Parameters["TestID"].Value = "";


               

                if (cmbTechnician.Value != null)
                sampleSummary.Parameters["EmpID"].Value = cmbTechnician.Value;
            else
                sampleSummary.Parameters["EmpID"].Value = 0;





                if (dtSamplingDate.Text != "")
                sampleSummary.Parameters["SamplingDate"].Value = dtSamplingDate.Date.ToString("dd-MMM-yyyy");
            sampleSummary.Parameters["SiteRefNo"].Value = txtSiteRefNo.Text;

            sampleSummary.CreateDocument();
            return sampleSummary;
            }
            catch (Exception ex)
            {
                return new XtraReport();
            }
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

        protected ASPxTextBox tbSampleNo;
        protected ASPxTextBox txtFromReportNo;
        protected ASPxTextBox txtToReportNumber;

        protected ASPxTextBox txtFromRRSNo;
        protected ASPxTextBox txtToRRSNo;
        //protected ASPxComboBox cmbServiceName;

        protected ASPxComboBox cmdSubContracted;
        protected ASPxDropDownEdit ASPxDropDownEdit1;
        protected ASPxDropDownEdit cmbSubcontractors;

        protected ASPxComboBox cmbTechnician;
        protected ASPxComboBox cmblabsection;
        protected ASPxDateEdit dtSamplingDate;
        protected ASPxTextBox txtSiteRefNo;
    }
}
