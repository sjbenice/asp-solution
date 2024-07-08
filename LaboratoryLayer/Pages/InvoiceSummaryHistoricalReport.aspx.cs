using System;
using LaboratoryLayer.Reports;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Web;
using DevExpress.Web;

namespace LaboratoryLayer.Pages
{
    public  partial class InvoiceSummaryHistoricalReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (IsPostBack)
              ViewReport();
        }

        public void btnGenerate_Click(object sender, EventArgs e)
        {
             ViewReport();
        }
        public void ViewReport()
        {
            //InvoiceSummaryReport inc = new InvoiceSummaryReport();
            //if (string.IsNullOrEmpty(txtInvoiceNo.Text))
            //    inc.Parameters["InvoiceNo"].Value = DBNull.Value;
            //else
            //inc.Parameters["InvoiceNo"].Value = txtInvoiceNo.Text;
            //inc.CreateDocument();
            //this.ReportViewer1.Report = inc;
        }

        //public void ViewReport()
        //{

        //    string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["localhost_LabSys_Connection"].ConnectionString;
        //    SqlConnection con = new SqlConnection(connectionstring);
        //    SqlDataAdapter sqa = new SqlDataAdapter();
        //    DataTable InvoiceSummary = new DataTable();
        //    SqlCommand cmd = new SqlCommand();
        //    ReportDataSet.SummaryReport ds = new ReportDataSet.SummaryReport();
        //    cmd.Connection = con;
        //    cmd.CommandText = "GetInvoiceSummary";
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    if (string.IsNullOrEmpty(txtInvoiceNo.Text))
        //        cmd.Parameters.AddWithValue("@InvoiceNo", DBNull.Value);
        //    else
        //        cmd.Parameters.AddWithValue("@InvoiceNo", txtInvoiceNo.Text);
        //    sqa.SelectCommand = cmd;
        //    con.Open();
        //    sqa.Fill(ds, "InvoiceSummary");
        //    ReportDocument rpt = new ReportDocument();
        //    rpt.Load(Server.MapPath("~//HistoricalReports//SummaryReports//Invoice.rpt"));
        //    rpt.SetDataSource(ds.Tables["InvoiceSummary"]);
        //    CrystalReportViewer1.ReportSource = rpt;
        //}

        protected ASPxTextBox txtInvoiceNo;

        protected ASPxDocumentViewer ReportViewer1;
    }
}