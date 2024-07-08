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
	public class LateSampleReportPage : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

            if (IsPostBack)
            {
                Tuple<bool, string> valid = ValidateInput();
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

        protected Tuple<bool, string> ValidateInput()
        {
            bool valid = false;
            string error = "";
            if (dtDateFrom.Text != "" || dtDateTo.Text != "")
                valid = true;



            if (cmbFKProjectID.Value != null)
                valid = true;


            if (ASPxDropDownEdit1.Value != null)
                valid = true;



            if (cmbCustomer.Value != null)
                valid = true;


            // Barkat : filter value of Service Section
            if (txtFromReportNo.Text != "" || txtToReportNumber.Text!="")
                               valid = true;




            if (cmblabsection.Value != null)
                valid = true;

            if (cmbTestStatus.SelectedIndex != 0)
                valid = true;
            if (cmbReportStatus.SelectedIndex != 0)
                valid = true;
            if (cmbTotalStatus.SelectedIndex != 0)
                valid = true;
            if (!valid)
                error = "Select at least one filter and then try again!";


            return new Tuple<bool, string>(valid, error);
        }
        protected XtraReport GetReport()
		{
            try
            {
                LaboratoryLayer.Reports.Menu.LateSmapleReportNew rptLateSampleReport = new LaboratoryLayer.Reports.Menu.LateSmapleReportNew();
                // LaboratoryLayer.Reports.LateSampleReport rptLateSampleReport = new LaboratoryLayer.Reports.LateSampleReport();
                if (dtDateFrom.Text != "")
                    rptLateSampleReport.Parameters["FromRecievedDate"].Value = dtDateFrom.Date.ToString("MM/dd/yyyy");
                else
                    rptLateSampleReport.Parameters["FromRecievedDate"].Value = "";

                if (dtDateTo.Text != "")
                    rptLateSampleReport.Parameters["ToRecievedDate"].Value = dtDateTo.Date.ToString("MM/dd/yyyy");
                else
                    rptLateSampleReport.Parameters["ToRecievedDate"].Value = "";


                if (cmbFKProjectID.Value != null)
                    rptLateSampleReport.Parameters["ProjectID"].Value = cmbFKProjectID.Value;
                else
                    rptLateSampleReport.Parameters["ProjectID"].Value = 0;

                //if (cmbServiceName.Value != null)
                //    rptLateSampleReport.Parameters["TestID"].Value = cmbServiceName.Value;
                //else
                //    rptLateSampleReport.Parameters["TestID"].Value = 0;

                if (ASPxDropDownEdit1.Value != null)
                    rptLateSampleReport.Parameters["TestID"].Value = ASPxDropDownEdit1.Value;
                else
                    rptLateSampleReport.Parameters["TestID"].Value = "";


                if (cmbCustomer.Value != null)
                    rptLateSampleReport.Parameters["CustomerID"].Value = cmbCustomer.Value;
                else
                    rptLateSampleReport.Parameters["CustomerID"].Value = 0;

                // Barkat : filter value of Service Section
                if (txtFromReportNo.Text != "")
                    rptLateSampleReport.Parameters["FromReportNo"].Value = txtFromReportNo.Text;
                else
                    rptLateSampleReport.Parameters["FromReportNo"].Value = 0;

                if (txtToReportNumber.Text != "")
                    rptLateSampleReport.Parameters["ToReportNo"].Value = txtToReportNumber.Text;
                else
                    rptLateSampleReport.Parameters["ToReportNo"].Value = 0;



                if (cmblabsection.Value != null)
                    rptLateSampleReport.Parameters["LabSection"].Value = cmblabsection.Value;
                else
                    rptLateSampleReport.Parameters["LabSection"].Value = 0;
                // System.Collections.IEnumerable data = (System.Collections.IEnumerable)ReportDS.Select();
                // rptLateSampleReport.DataSource = data;

                if (cmbTestStatus.SelectedIndex != 0)
                    rptLateSampleReport.Parameters["TestDurationStatus"].Value = cmbTestStatus.Value;
                else
                    rptLateSampleReport.Parameters["TestDurationStatus"].Value = "";

                if (cmbReportStatus.SelectedIndex != 0)
                    rptLateSampleReport.Parameters["ReportDurationStatus"].Value = cmbReportStatus.Value;
                else
                    rptLateSampleReport.Parameters["ReportDurationStatus"].Value = "";
                if (cmbTotalStatus.SelectedIndex != 0)
                    rptLateSampleReport.Parameters["TotalDurationStatus"].Value = cmbTotalStatus.Value;
                else
                    rptLateSampleReport.Parameters["TotalDurationStatus"].Value = "";
                        rptLateSampleReport.CreateDocument();
                return rptLateSampleReport;
            }
            catch (Exception ex)
            {
                return new XtraReport();
            }
		}

        protected ObjectDataSource ReportDS;

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

        protected ASPxComboBox cmbCustomer;
        protected ASPxComboBox cmbTestStatus;
        protected ASPxComboBox cmbReportStatus;
        protected ASPxComboBox cmbTotalStatus;


        protected ASPxComboBox cmbFKProjectID;

        protected ASPxComboBox cmbServiceName;

        protected ASPxComboBox cmblabsection;
        protected ASPxTextBox txtFromReportNo;
        protected ASPxTextBox txtToReportNumber;
        protected ASPxDropDownEdit ASPxDropDownEdit1;


    }
}
