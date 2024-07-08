using System;
using System.Web.UI;
using DevExpress.Web;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Web;
using LaboratoryLayer.Reports;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Collections.Generic;

namespace LaboratoryLayer.Pages
{
    // Token: 0x02000029 RID: 41
    public class ReportViwerNew : Page
	{
		// Token: 0x06000169 RID: 361 RVA: 0x0000C734 File Offset: 0x0000A934
		protected void Page_Load(object sender, EventArgs e)
		{
            if (Page.IsPostBack)
            {
                CreateObjectDataSource();

            }
        }

		// Token: 0x0600016A RID: 362 RVA: 0x00002071 File Offset: 0x00000271
		private void SetControls()
		{
		}

		// Token: 0x0600016B RID: 363 RVA: 0x0000C7A8 File Offset: 0x0000A9A8
		

        protected void CreateObjectDataSource()
        {
            string reportName = Request.QueryString["reportName"];
            string typeName = Request.QueryString["typeName"];
            string dataObjectTypeName = Request.QueryString["dataObjectTypeName"];
            string selectMethod = Request.QueryString["selectMethod"];
            string filterExpress = Request.QueryString["filterExpress"];
            ObjectDataSource AllPendingTestReportingDS = new ObjectDataSource();

            AllPendingTestReportingDS.TypeName = "BusinessLayer.Pages."+typeName;
            AllPendingTestReportingDS.DataObjectTypeName = "BusinessLayer."+ dataObjectTypeName;
            AllPendingTestReportingDS.SelectMethod = selectMethod;
            System.Collections.IEnumerable data = (System.Collections.IEnumerable)AllPendingTestReportingDS.Select();
            var report = new TestReportingAllPening();
            report.Parameters["ReportName"].Value = reportName;
            report.DataSource = data;
            if (filterExpress != "undefined")
            {
                report.FilterString = filterExpress;
              
            }
            report.CreateDocument();
            ReportViewer1.Report = report;
       
        }
        protected System.Data.DataTable CreateDataTableFromList(List<TestReporting> data)
        {
            System.Data.DataTable dataTable = new System.Data.DataTable();


            dataTable.Columns.Add("ReportNumber", typeof(int));
            dataTable.Columns.Add("SampleNumber", typeof(string));
            dataTable.Columns.Add("ReportingDate", typeof(DateTime));
            dataTable.Columns.Add("CustomerName", typeof(string));
            dataTable.Columns.Add("TestName", typeof(string));
            dataTable.Columns.Add("StandardNumber", typeof(string));
            dataTable.Columns.Add("TestRequiredTime", typeof(int));
            dataTable.Columns.Add("TestReportingID", typeof(long));
            dataTable.Columns.Add("SampleReceivedDate", typeof(DateTime));

            foreach (var item in data)
            {
                System.Data.DataRow row = dataTable.NewRow();
                row["ReportNumber"] = item.ReportNumber;
                row["SampleNumber"] = item.SampleNumber;
                row["ReportingDate"] = (item.ReportingDate.HasValue==true ? (object)item.ReportingDate.Value : DBNull.Value);
                row["CustomerName"] = item.CustomerName;
                row["TestName"] = item.TestName;
                row["StandardNumber"] = item.StandardNumber;
                row["TestRequiredTime"] = item.TestRequiredTime;
                row["TestReportingID"] = item.TestReportingID;
                row["SampleReceivedDate"] = item.SampleReceivedDate;

                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

		// Token: 0x040001FC RID: 508
		protected ASPxLabel LblError;

		// Token: 0x040001FD RID: 509
		protected ASPxDocumentViewer ReportViewer1;
        protected ObjectDataSource ReportingDSObjectDataSource;

    }
}
