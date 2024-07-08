using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using DevExpress.DataAccess.Sql;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;

namespace LaboratoryLayer.Reports
{
	// Token: 0x02000070 RID: 112
	public class InvoiceTimeSheetReport : XtraReport
	{
		// Token: 0x0600038F RID: 911 RVA: 0x00004734 File Offset: 0x00002934
		public InvoiceTimeSheetReport()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000390 RID: 912 RVA: 0x00004742 File Offset: 0x00002942
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000391 RID: 913 RVA: 0x0006520C File Offset: 0x0006340C
		private void InitializeComponent()
		{
			this.components = new Container();
			CustomSqlQuery customSqlQuery = new CustomSqlQuery();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvoiceTimeSheetReport));
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(InvoiceTimeSheetReport));
			CustomSqlQuery customSqlQuery2 = new CustomSqlQuery();
			SelectQuery selectQuery = new SelectQuery();
			Column column = new Column();
			ColumnExpression columnExpression = new ColumnExpression();
			Table table = new Table();
			Column column2 = new Column();
			ColumnExpression columnExpression2 = new ColumnExpression();
			Table table2 = new Table();
			Column column3 = new Column();
			ColumnExpression columnExpression3 = new ColumnExpression();
			Column column4 = new Column();
			ColumnExpression columnExpression4 = new ColumnExpression();
			Column column5 = new Column();
			ColumnExpression columnExpression5 = new ColumnExpression();
			Join join = new Join();
			RelationColumnInfo relationColumnInfo = new RelationColumnInfo();
			MasterDetailInfo masterDetailInfo = new MasterDetailInfo();
			RelationColumnInfo relationColumnInfo2 = new RelationColumnInfo();
			RelationColumnInfo relationColumnInfo3 = new RelationColumnInfo();
			DynamicListLookUpSettings dynamicListLookUpSettings = new DynamicListLookUpSettings();
			this.sqlDataSource1 = new SqlDataSource(this.components);
			this.Detail = new DetailBand();
			this.xrTable1 = new XRTable();
			this.xrTableRow1 = new XRTableRow();
			this.xrTableCell1 = new XRTableCell();
			this.xrTableCell2 = new XRTableCell();
			this.xrTableCell3 = new XRTableCell();
			this.xrTableCell4 = new XRTableCell();
			this.xrTableCell5 = new XRTableCell();
			this.xrTableCell6 = new XRTableCell();
			this.xrTableRow2 = new XRTableRow();
			this.xrTableCell7 = new XRTableCell();
			this.xrTableCell8 = new XRTableCell();
			this.xrTableCell9 = new XRTableCell();
			this.xrTableCell10 = new XRTableCell();
			this.xrTableCell11 = new XRTableCell();
			this.xrTableCell12 = new XRTableCell();
			this.xrTableRow3 = new XRTableRow();
			this.xrTableCell13 = new XRTableCell();
			this.xrTableCell14 = new XRTableCell();
			this.xrTableCell15 = new XRTableCell();
			this.xrTableCell16 = new XRTableCell();
			this.xrTableCell17 = new XRTableCell();
			this.xrTableCell18 = new XRTableCell();
			this.xrTableRow4 = new XRTableRow();
			this.xrTableCell19 = new XRTableCell();
			this.xrTableCell20 = new XRTableCell();
			this.xrTableCell21 = new XRTableCell();
			this.xrTableCell22 = new XRTableCell();
			this.xrTableCell23 = new XRTableCell();
			this.xrTableCell24 = new XRTableCell();
			this.xrTableRow5 = new XRTableRow();
			this.xrTableCell25 = new XRTableCell();
			this.xrTableCell26 = new XRTableCell();
			this.xrTableCell27 = new XRTableCell();
			this.xrTableCell28 = new XRTableCell();
			this.xrTableCell29 = new XRTableCell();
			this.xrTableCell30 = new XRTableCell();
			this.xrTableRow6 = new XRTableRow();
			this.xrTableCell31 = new XRTableCell();
			this.xrTableCell36 = new XRTableCell();
			this.TopMargin = new TopMarginBand();
			this.BottomMargin = new BottomMarginBand();
			this.pageFooterBand1 = new PageFooterBand();
			this.xrPageInfo2 = new XRPageInfo();
			this.reportHeaderBand1 = new ReportHeaderBand();
			this.Title = new XRControlStyle();
			this.FieldCaption = new XRControlStyle();
			this.PageInfo = new XRControlStyle();
			this.DataField = new XRControlStyle();
			this.DetailReport = new DetailReportBand();
			this.Detail1 = new DetailBand();
			this.xrTable5 = new XRTable();
			this.xrTableRow11 = new XRTableRow();
			this.xrTableCell65 = new XRTableCell();
			this.xrTableCell66 = new XRTableCell();
			this.xrTableCell67 = new XRTableCell();
			this.xrTableCell68 = new XRTableCell();
			this.xrTableCell69 = new XRTableCell();
			this.xrTableCell70 = new XRTableCell();
			this.xrTableCell71 = new XRTableCell();
			this.xrTableCell72 = new XRTableCell();
			this.xrTableCell73 = new XRTableCell();
			this.xrTableCell74 = new XRTableCell();
			this.xrTableCell75 = new XRTableCell();
			this.xrTableCell76 = new XRTableCell();
			this.xrTableCell77 = new XRTableCell();
			this.xrTableCell78 = new XRTableCell();
			this.xrTableCell79 = new XRTableCell();
			this.xrTableCell80 = new XRTableCell();
			this.GroupHeader1 = new GroupHeaderBand();
			this.xrTable6 = new XRTable();
			this.xrTableRow12 = new XRTableRow();
			this.xrTableCell81 = new XRTableCell();
			this.xrTableCell82 = new XRTableCell();
			this.xrTableCell83 = new XRTableCell();
			this.xrTableCell84 = new XRTableCell();
			this.xrTableCell85 = new XRTableCell();
			this.xrTableCell86 = new XRTableCell();
			this.xrTableCell87 = new XRTableCell();
			this.xrTableCell88 = new XRTableCell();
			this.xrTableCell89 = new XRTableCell();
			this.xrTableCell90 = new XRTableCell();
			this.xrTableCell91 = new XRTableCell();
			this.xrTableCell92 = new XRTableCell();
			this.xrTableCell93 = new XRTableCell();
			this.xrTableCell94 = new XRTableCell();
			this.xrTableCell95 = new XRTableCell();
			this.xrTableCell96 = new XRTableCell();
			this.xrRichText1 = new XRRichText();
			this.xrTable4 = new XRTable();
			this.xrTableRow9 = new XRTableRow();
			this.xrTableCell63 = new XRTableCell();
			this.xrTableRow10 = new XRTableRow();
			this.xrTableCell64 = new XRTableCell();
			this.PageHeader = new PageHeaderBand();
			this.InvoiceId = new Parameter();
			this.DetailReport1 = new DetailReportBand();
			this.Detail2 = new DetailBand();
			this.xrLabel15 = new XRLabel();
			this.xrLabel16 = new XRLabel();
			this.xrLabel17 = new XRLabel();
			this.xrLabel18 = new XRLabel();
			this.xrLabel13 = new XRLabel();
			this.xrLabel14 = new XRLabel();
			this.xrLabel9 = new XRLabel();
			this.xrLabel11 = new XRLabel();
			this.xrLabel12 = new XRLabel();
			this.xrLabel10 = new XRLabel();
			this.xrLabel8 = new XRLabel();
			this.xrLabel7 = new XRLabel();
			this.xrLabel3 = new XRLabel();
			this.xrLabel4 = new XRLabel();
			this.xrLabel5 = new XRLabel();
			this.xrLabel6 = new XRLabel();
			this.GrandTotal = new CalculatedField();
			this.Total = new CalculatedField();
			this.StartDateTime = new CalculatedField();
			this.EndDateTime = new CalculatedField();
			this.NigthDays = new CalculatedField();
			this.calculatedField2 = new CalculatedField();
			((ISupportInitialize)this.xrTable1).BeginInit();
			((ISupportInitialize)this.xrTable5).BeginInit();
			((ISupportInitialize)this.xrTable6).BeginInit();
			((ISupportInitialize)this.xrRichText1).BeginInit();
			((ISupportInitialize)this.xrTable4).BeginInit();
			((ISupportInitialize)this).BeginInit();
			this.sqlDataSource1.ConnectionName = "localhost_LabSys_Connection";
			this.sqlDataSource1.Name = "sqlDataSource1";
			customSqlQuery.Name = "Invoice";
			customSqlQuery.Sql = resources.GetString("customSqlQuery1.Sql");
			customSqlQuery2.Name = "WorkOrderTimeSheet";
			customSqlQuery2.Sql = resources.GetString("customSqlQuery2.Sql");
			columnExpression.ColumnName = "InvoiceId";
			table.MetaSerializable = "30|30|125|300";
			table.Name = "Invoice";
			columnExpression.Table = table;
			column.Expression = columnExpression;
			columnExpression2.ColumnName = "FkInvoiceId";
			table2.MetaSerializable = "185|30|125|140";
			table2.Name = "WorkOrderInvoice";
			columnExpression2.Table = table2;
			column2.Expression = columnExpression2;
			columnExpression3.ColumnName = "FkWorkOrderId";
			columnExpression3.Table = table2;
			column3.Expression = columnExpression3;
			columnExpression4.ColumnName = "StartDate";
			columnExpression4.Table = table2;
			column4.Expression = columnExpression4;
			columnExpression5.ColumnName = "EndDate";
			columnExpression5.Table = table2;
			column5.Expression = columnExpression5;
			selectQuery.Columns.Add(column);
			selectQuery.Columns.Add(column2);
			selectQuery.Columns.Add(column3);
			selectQuery.Columns.Add(column4);
			selectQuery.Columns.Add(column5);
			selectQuery.Name = "WorkOderInvoiced";
			relationColumnInfo.NestedKeyColumn = "FkInvoiceId";
			relationColumnInfo.ParentKeyColumn = "InvoiceId";
			join.KeyColumns.Add(relationColumnInfo);
			join.Nested = table2;
			join.Parent = table;
			selectQuery.Relations.Add(join);
			selectQuery.Tables.Add(table);
			selectQuery.Tables.Add(table2);
			this.sqlDataSource1.Queries.AddRange(new SqlQuery[]
			{
				customSqlQuery,
				customSqlQuery2,
				selectQuery
			});
			masterDetailInfo.DetailQueryName = "WorkOrderTimeSheet";
			relationColumnInfo2.NestedKeyColumn = "FkInvoiceId";
			relationColumnInfo2.ParentKeyColumn = "InvoiceId";
			relationColumnInfo3.NestedKeyColumn = "FkWorkOrderID";
			relationColumnInfo3.ParentKeyColumn = "FkWorkOrderId";
			masterDetailInfo.KeyColumns.Add(relationColumnInfo2);
			masterDetailInfo.KeyColumns.Add(relationColumnInfo3);
			masterDetailInfo.MasterQueryName = "Invoice";
			this.sqlDataSource1.Relations.AddRange(new MasterDetailInfo[]
			{
				masterDetailInfo
			});
			this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
			this.Detail.Controls.AddRange(new XRControl[]
			{
				this.xrTable1
			});
			this.Detail.Dpi = 100f;
			this.Detail.HeightF = 157.9167f;
			this.Detail.KeepTogether = true;
			this.Detail.KeepTogetherWithDetailReports = true;
			this.Detail.Name = "Detail";
			this.Detail.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
			this.Detail.PageBreak = PageBreak.BeforeBand;
			this.Detail.StylePriority.UseTextAlignment = false;
			this.Detail.TextAlignment = TextAlignment.TopLeft;
			this.xrTable1.Borders = BorderSide.All;
			this.xrTable1.Dpi = 100f;
			this.xrTable1.Font = new Font("Times New Roman", 9f);
			this.xrTable1.LocationFloat = new PointFloat(27.29921f, 0f);
			this.xrTable1.Name = "xrTable1";
			this.xrTable1.Padding = new PaddingInfo(3, 0, 0, 0, 100f);
			this.xrTable1.Rows.AddRange(new XRTableRow[]
			{
				this.xrTableRow1,
				this.xrTableRow2,
				this.xrTableRow3,
				this.xrTableRow4,
				this.xrTableRow5,
				this.xrTableRow6
			});
			this.xrTable1.SizeF = new SizeF(797.5259f, 150f);
			this.xrTable1.StylePriority.UseBorders = false;
			this.xrTable1.StylePriority.UseFont = false;
			this.xrTable1.StylePriority.UsePadding = false;
			this.xrTableRow1.Cells.AddRange(new XRTableCell[]
			{
				this.xrTableCell1,
				this.xrTableCell2,
				this.xrTableCell3,
				this.xrTableCell4,
				this.xrTableCell5,
				this.xrTableCell6
			});
			this.xrTableRow1.Dpi = 100f;
			this.xrTableRow1.Name = "xrTableRow1";
			this.xrTableRow1.Weight = 1.0;
			this.xrTableCell1.Borders = (BorderSide.Left | BorderSide.Top | BorderSide.Bottom);
			this.xrTableCell1.Dpi = 100f;
			this.xrTableCell1.Font = new Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTableCell1.Name = "xrTableCell1";
			this.xrTableCell1.StylePriority.UseBorders = false;
			this.xrTableCell1.StylePriority.UseFont = false;
			this.xrTableCell1.Text = "Job Order No";
			this.xrTableCell1.Weight = 1.0;
			this.xrTableCell2.Borders = (BorderSide.Left | BorderSide.Top | BorderSide.Bottom);
			this.xrTableCell2.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "Invoice.JobOrderNumber")
			});
			this.xrTableCell2.Dpi = 100f;
			this.xrTableCell2.Name = "xrTableCell2";
			this.xrTableCell2.StylePriority.UseBorders = false;
			this.xrTableCell2.Weight = 0.8097073637047818;
			this.xrTableCell3.Borders = (BorderSide.Left | BorderSide.Top | BorderSide.Bottom);
			this.xrTableCell3.Dpi = 100f;
			this.xrTableCell3.Font = new Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTableCell3.Name = "xrTableCell3";
			this.xrTableCell3.StylePriority.UseBorders = false;
			this.xrTableCell3.StylePriority.UseFont = false;
			this.xrTableCell3.Text = "Customer  Name";
			this.xrTableCell3.Weight = 1.4168303386350092;
			this.xrTableCell4.Borders = (BorderSide.Left | BorderSide.Top | BorderSide.Bottom);
			this.xrTableCell4.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "Invoice.CustomerName")
			});
			this.xrTableCell4.Dpi = 100f;
			this.xrTableCell4.Name = "xrTableCell4";
			this.xrTableCell4.StylePriority.UseBorders = false;
			this.xrTableCell4.Weight = 2.121604908703867;
			this.xrTableCell5.Borders = (BorderSide.Left | BorderSide.Top | BorderSide.Bottom);
			this.xrTableCell5.Dpi = 100f;
			this.xrTableCell5.Font = new Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTableCell5.Name = "xrTableCell5";
			this.xrTableCell5.StylePriority.UseBorders = false;
			this.xrTableCell5.StylePriority.UseFont = false;
			this.xrTableCell5.Text = "Work Order   No.";
			this.xrTableCell5.Weight = 1.1899479685554617;
			this.xrTableCell6.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "Invoice.WorkOrderNo", "{0:dd MMM yyyy}")
			});
			this.xrTableCell6.Dpi = 100f;
			this.xrTableCell6.Name = "xrTableCell6";
			this.xrTableCell6.StylePriority.UseBorders = false;
			this.xrTableCell6.Weight = 0.8039430219169557;
			this.xrTableRow2.Cells.AddRange(new XRTableCell[]
			{
				this.xrTableCell7,
				this.xrTableCell8,
				this.xrTableCell9,
				this.xrTableCell10,
				this.xrTableCell11,
				this.xrTableCell12
			});
			this.xrTableRow2.Dpi = 100f;
			this.xrTableRow2.Name = "xrTableRow2";
			this.xrTableRow2.Weight = 1.0;
			this.xrTableCell7.Borders = (BorderSide.Left | BorderSide.Top | BorderSide.Bottom);
			this.xrTableCell7.Dpi = 100f;
			this.xrTableCell7.Font = new Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTableCell7.Name = "xrTableCell7";
			this.xrTableCell7.StylePriority.UseBorders = false;
			this.xrTableCell7.StylePriority.UseFont = false;
			this.xrTableCell7.Text = "Agreement No";
			this.xrTableCell7.Weight = 1.0;
			this.xrTableCell8.Borders = (BorderSide.Left | BorderSide.Top | BorderSide.Bottom);
			this.xrTableCell8.Dpi = 100f;
			this.xrTableCell8.Name = "xrTableCell8";
			this.xrTableCell8.StylePriority.UseBorders = false;
			this.xrTableCell8.Weight = 0.8097078946552179;
			this.xrTableCell9.Borders = (BorderSide.Left | BorderSide.Top | BorderSide.Bottom);
			this.xrTableCell9.Dpi = 100f;
			this.xrTableCell9.Font = new Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTableCell9.Name = "xrTableCell9";
			this.xrTableCell9.StylePriority.UseBorders = false;
			this.xrTableCell9.StylePriority.UseFont = false;
			this.xrTableCell9.Text = "Project Name";
			this.xrTableCell9.Weight = 1.4168300731597911;
			this.xrTableCell10.Borders = (BorderSide.Left | BorderSide.Top | BorderSide.Bottom);
			this.xrTableCell10.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "Invoice.ProjectName")
			});
			this.xrTableCell10.Dpi = 100f;
			this.xrTableCell10.Name = "xrTableCell10";
			this.xrTableCell10.StylePriority.UseBorders = false;
			this.xrTableCell10.Weight = 2.1216046432286486;
			this.xrTableCell11.Borders = (BorderSide.Left | BorderSide.Top | BorderSide.Bottom);
			this.xrTableCell11.Dpi = 100f;
			this.xrTableCell11.Font = new Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTableCell11.Name = "xrTableCell11";
			this.xrTableCell11.StylePriority.UseBorders = false;
			this.xrTableCell11.StylePriority.UseFont = false;
			this.xrTableCell11.Text = "Agreement Start Date";
			this.xrTableCell11.Weight = 1.1899479685554617;
			this.xrTableCell12.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "Invoice.TransactionDate", "{0:dd MMM yyyy}")
			});
			this.xrTableCell12.Dpi = 100f;
			this.xrTableCell12.Name = "xrTableCell12";
			this.xrTableCell12.StylePriority.UseBorders = false;
			this.xrTableCell12.Weight = 0.8039430219169557;
			this.xrTableRow3.Cells.AddRange(new XRTableCell[]
			{
				this.xrTableCell13,
				this.xrTableCell14,
				this.xrTableCell15,
				this.xrTableCell16,
				this.xrTableCell17,
				this.xrTableCell18
			});
			this.xrTableRow3.Dpi = 100f;
			this.xrTableRow3.Name = "xrTableRow3";
			this.xrTableRow3.Weight = 1.0;
			this.xrTableCell13.Borders = (BorderSide.Left | BorderSide.Top | BorderSide.Bottom);
			this.xrTableCell13.Dpi = 100f;
			this.xrTableCell13.Font = new Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTableCell13.Name = "xrTableCell13";
			this.xrTableCell13.StylePriority.UseBorders = false;
			this.xrTableCell13.StylePriority.UseFont = false;
			this.xrTableCell13.Text = "Work Hours/Day";
			this.xrTableCell13.Weight = 1.0;
			this.xrTableCell14.Borders = (BorderSide.Left | BorderSide.Top | BorderSide.Bottom);
			this.xrTableCell14.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "Invoice.RegularWorkHrs")
			});
			this.xrTableCell14.Dpi = 100f;
			this.xrTableCell14.Name = "xrTableCell14";
			this.xrTableCell14.StylePriority.UseBorders = false;
			this.xrTableCell14.Weight = 0.8097081601304359;
			this.xrTableCell15.Borders = (BorderSide.Left | BorderSide.Top | BorderSide.Bottom);
			this.xrTableCell15.Dpi = 100f;
			this.xrTableCell15.Font = new Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTableCell15.Name = "xrTableCell15";
			this.xrTableCell15.StylePriority.UseBorders = false;
			this.xrTableCell15.StylePriority.UseFont = false;
			this.xrTableCell15.Text = "Test Name";
			this.xrTableCell15.Weight = 1.4168298076845731;
			this.xrTableCell16.Borders = (BorderSide.Left | BorderSide.Top | BorderSide.Bottom);
			this.xrTableCell16.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "Invoice.TestName")
			});
			this.xrTableCell16.Dpi = 100f;
			this.xrTableCell16.Name = "xrTableCell16";
			this.xrTableCell16.StylePriority.UseBorders = false;
			this.xrTableCell16.Weight = 2.1216046432286486;
			this.xrTableCell17.Borders = (BorderSide.Left | BorderSide.Top | BorderSide.Bottom);
			this.xrTableCell17.Dpi = 100f;
			this.xrTableCell17.Font = new Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTableCell17.Name = "xrTableCell17";
			this.xrTableCell17.StylePriority.UseBorders = false;
			this.xrTableCell17.StylePriority.UseFont = false;
			this.xrTableCell17.Text = "Invoice Start Date";
			this.xrTableCell17.Weight = 1.1899479685554617;
			this.xrTableCell18.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "Invoice.InvoiceStartDate", "{0:dd MMM yyyy}")
			});
			this.xrTableCell18.Dpi = 100f;
			this.xrTableCell18.Name = "xrTableCell18";
			this.xrTableCell18.StylePriority.UseBorders = false;
			this.xrTableCell18.Weight = 0.8039430219169557;
			this.xrTableRow4.Cells.AddRange(new XRTableCell[]
			{
				this.xrTableCell19,
				this.xrTableCell20,
				this.xrTableCell21,
				this.xrTableCell22,
				this.xrTableCell23,
				this.xrTableCell24
			});
			this.xrTableRow4.Dpi = 100f;
			this.xrTableRow4.Name = "xrTableRow4";
			this.xrTableRow4.Weight = 1.0;
			this.xrTableCell19.Borders = (BorderSide.Left | BorderSide.Top | BorderSide.Bottom);
			this.xrTableCell19.Dpi = 100f;
			this.xrTableCell19.Font = new Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTableCell19.Name = "xrTableCell19";
			this.xrTableCell19.StylePriority.UseBorders = false;
			this.xrTableCell19.StylePriority.UseFont = false;
			this.xrTableCell19.Text = "Agreed Unit";
			this.xrTableCell19.Weight = 1.0;
			this.xrTableCell20.Borders = (BorderSide.Left | BorderSide.Top | BorderSide.Bottom);
			this.xrTableCell20.Dpi = 100f;
			this.xrTableCell20.Name = "xrTableCell20";
			this.xrTableCell20.StylePriority.UseBorders = false;
			this.xrTableCell20.Weight = 0.809708425605654;
			this.xrTableCell21.Borders = (BorderSide.Left | BorderSide.Top | BorderSide.Bottom);
			this.xrTableCell21.Dpi = 100f;
			this.xrTableCell21.Font = new Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTableCell21.Name = "xrTableCell21";
			this.xrTableCell21.StylePriority.UseBorders = false;
			this.xrTableCell21.StylePriority.UseFont = false;
			this.xrTableCell21.Text = "Rate of the unit";
			this.xrTableCell21.Weight = 1.416829542209355;
			this.xrTableCell22.Borders = (BorderSide.Left | BorderSide.Top | BorderSide.Bottom);
			this.xrTableCell22.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "Invoice.MonthlyRate")
			});
			this.xrTableCell22.Dpi = 100f;
			this.xrTableCell22.Name = "xrTableCell22";
			this.xrTableCell22.StylePriority.UseBorders = false;
			this.xrTableCell22.Weight = 2.1216046432286486;
			this.xrTableCell23.Borders = (BorderSide.Left | BorderSide.Top | BorderSide.Bottom);
			this.xrTableCell23.Dpi = 100f;
			this.xrTableCell23.Font = new Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTableCell23.Name = "xrTableCell23";
			this.xrTableCell23.StylePriority.UseBorders = false;
			this.xrTableCell23.StylePriority.UseFont = false;
			this.xrTableCell23.Text = "Invoice End Date";
			this.xrTableCell23.Weight = 1.1899479685554617;
			this.xrTableCell24.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "Invoice.InvoiceEndDate", "{0:dd MMM yyyy}")
			});
			this.xrTableCell24.Dpi = 100f;
			this.xrTableCell24.Name = "xrTableCell24";
			this.xrTableCell24.StylePriority.UseBorders = false;
			this.xrTableCell24.Weight = 0.8039430219169557;
			this.xrTableRow5.Cells.AddRange(new XRTableCell[]
			{
				this.xrTableCell25,
				this.xrTableCell26,
				this.xrTableCell27,
				this.xrTableCell28,
				this.xrTableCell29,
				this.xrTableCell30
			});
			this.xrTableRow5.Dpi = 100f;
			this.xrTableRow5.Name = "xrTableRow5";
			this.xrTableRow5.Weight = 1.0;
			this.xrTableCell25.Borders = (BorderSide.Left | BorderSide.Top | BorderSide.Bottom);
			this.xrTableCell25.Dpi = 100f;
			this.xrTableCell25.Font = new Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTableCell25.Name = "xrTableCell25";
			this.xrTableCell25.StylePriority.UseBorders = false;
			this.xrTableCell25.StylePriority.UseFont = false;
			this.xrTableCell25.Text = "Unit of Addition";
			this.xrTableCell25.Weight = 1.0;
			this.xrTableCell26.Borders = (BorderSide.Left | BorderSide.Top | BorderSide.Bottom);
			this.xrTableCell26.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "Invoice.UnitOfAddition")
			});
			this.xrTableCell26.Dpi = 100f;
			this.xrTableCell26.Name = "xrTableCell26";
			this.xrTableCell26.StylePriority.UseBorders = false;
			this.xrTableCell26.Weight = 0.8097086910808721;
			this.xrTableCell27.Borders = (BorderSide.Left | BorderSide.Top | BorderSide.Bottom);
			this.xrTableCell27.Dpi = 100f;
			this.xrTableCell27.Font = new Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTableCell27.Name = "xrTableCell27";
			this.xrTableCell27.StylePriority.UseBorders = false;
			this.xrTableCell27.StylePriority.UseFont = false;
			this.xrTableCell27.Text = "Extra Working Hour Rate";
			this.xrTableCell27.Weight = 1.416829276734137;
			this.xrTableCell28.Borders = (BorderSide.Left | BorderSide.Top | BorderSide.Bottom);
			this.xrTableCell28.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "Invoice.ExtraWorkHourRate")
			});
			this.xrTableCell28.Dpi = 100f;
			this.xrTableCell28.Name = "xrTableCell28";
			this.xrTableCell28.StylePriority.UseBorders = false;
			this.xrTableCell28.Weight = 2.1216046432286486;
			this.xrTableCell29.Borders = (BorderSide.Left | BorderSide.Top | BorderSide.Bottom);
			this.xrTableCell29.Dpi = 100f;
			this.xrTableCell29.Font = new Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTableCell29.Name = "xrTableCell29";
			this.xrTableCell29.StylePriority.UseBorders = false;
			this.xrTableCell29.StylePriority.UseFont = false;
			this.xrTableCell29.Text = " Site Name";
			this.xrTableCell29.Weight = 1.1899479685554617;
			this.xrTableCell30.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "Invoice.SiteName")
			});
			this.xrTableCell30.Dpi = 100f;
			this.xrTableCell30.Name = "xrTableCell30";
			this.xrTableCell30.StylePriority.UseBorders = false;
			this.xrTableCell30.Weight = 0.8039430219169557;
			this.xrTableRow6.Cells.AddRange(new XRTableCell[]
			{
				this.xrTableCell31,
				this.xrTableCell36
			});
			this.xrTableRow6.Dpi = 100f;
			this.xrTableRow6.Name = "xrTableRow6";
			this.xrTableRow6.Weight = 1.0;
			this.xrTableCell31.Borders = (BorderSide.Left | BorderSide.Top | BorderSide.Bottom);
			this.xrTableCell31.Dpi = 100f;
			this.xrTableCell31.Font = new Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTableCell31.Name = "xrTableCell31";
			this.xrTableCell31.StylePriority.UseBorders = false;
			this.xrTableCell31.StylePriority.UseFont = false;
			this.xrTableCell31.Text = "Work Order Description";
			this.xrTableCell31.Weight = 1.0;
			this.xrTableCell36.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "Invoice.Description")
			});
			this.xrTableCell36.Dpi = 100f;
			this.xrTableCell36.Name = "xrTableCell36";
			this.xrTableCell36.Weight = 6.342033601516075;
			this.TopMargin.Dpi = 100f;
			this.TopMargin.HeightF = 89.54167f;
			this.TopMargin.Name = "TopMargin";
			this.TopMargin.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
			this.TopMargin.TextAlignment = TextAlignment.TopLeft;
			this.BottomMargin.Dpi = 100f;
			this.BottomMargin.HeightF = 3f;
			this.BottomMargin.Name = "BottomMargin";
			this.BottomMargin.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
			this.BottomMargin.TextAlignment = TextAlignment.TopLeft;
			this.pageFooterBand1.Controls.AddRange(new XRControl[]
			{
				this.xrPageInfo2
			});
			this.pageFooterBand1.Dpi = 100f;
			this.pageFooterBand1.HeightF = 32.99997f;
			this.pageFooterBand1.Name = "pageFooterBand1";
			this.pageFooterBand1.StylePriority.UseTextAlignment = false;
			this.xrPageInfo2.Dpi = 100f;
			this.xrPageInfo2.Format = "Page {0} of {1}";
			this.xrPageInfo2.LocationFloat = new PointFloat(314.3929f, 9.999974f);
			this.xrPageInfo2.Name = "xrPageInfo2";
			this.xrPageInfo2.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrPageInfo2.SizeF = new SizeF(313f, 23f);
			this.xrPageInfo2.StyleName = "PageInfo";
			this.xrPageInfo2.StylePriority.UseTextAlignment = false;
			this.xrPageInfo2.TextAlignment = TextAlignment.TopCenter;
			this.reportHeaderBand1.Dpi = 100f;
			this.reportHeaderBand1.Expanded = false;
			this.reportHeaderBand1.HeightF = 1.208369f;
			this.reportHeaderBand1.Name = "reportHeaderBand1";
			this.Title.BackColor = Color.Transparent;
			this.Title.BorderColor = Color.Black;
			this.Title.Borders = BorderSide.None;
			this.Title.BorderWidth = 1f;
			this.Title.Font = new Font("Times New Roman", 20f, FontStyle.Bold);
			this.Title.ForeColor = Color.Maroon;
			this.Title.Name = "Title";
			this.FieldCaption.BackColor = Color.Transparent;
			this.FieldCaption.BorderColor = Color.Black;
			this.FieldCaption.Borders = BorderSide.None;
			this.FieldCaption.BorderWidth = 1f;
			this.FieldCaption.Font = new Font("Arial", 10f, FontStyle.Bold);
			this.FieldCaption.ForeColor = Color.Maroon;
			this.FieldCaption.Name = "FieldCaption";
			this.PageInfo.BackColor = Color.Transparent;
			this.PageInfo.BorderColor = Color.Black;
			this.PageInfo.Borders = BorderSide.None;
			this.PageInfo.BorderWidth = 1f;
			this.PageInfo.Font = new Font("Times New Roman", 10f, FontStyle.Bold);
			this.PageInfo.ForeColor = Color.Black;
			this.PageInfo.Name = "PageInfo";
			this.DataField.BackColor = Color.Transparent;
			this.DataField.BorderColor = Color.Black;
			this.DataField.Borders = BorderSide.None;
			this.DataField.BorderWidth = 1f;
			this.DataField.Font = new Font("Times New Roman", 10f);
			this.DataField.ForeColor = Color.Black;
			this.DataField.Name = "DataField";
			this.DataField.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.DetailReport.Bands.AddRange(new Band[]
			{
				this.Detail1,
				this.GroupHeader1
			});
			this.DetailReport.DataMember = "Invoice.InvoiceWorkOrderTimeSheet";
			this.DetailReport.DataSource = this.sqlDataSource1;
			this.DetailReport.Dpi = 100f;
			this.DetailReport.Level = 0;
			this.DetailReport.Name = "DetailReport";
			this.Detail1.Controls.AddRange(new XRControl[]
			{
				this.xrTable5
			});
			this.Detail1.Dpi = 100f;
			this.Detail1.HeightF = 25f;
			this.Detail1.Name = "Detail1";
			this.xrTable5.Borders = (BorderSide.Left | BorderSide.Right | BorderSide.Bottom);
			this.xrTable5.Dpi = 100f;
			this.xrTable5.Font = new Font("Times New Roman", 8f);
			this.xrTable5.LocationFloat = new PointFloat(27.29928f, 0f);
			this.xrTable5.Name = "xrTable5";
			this.xrTable5.Padding = new PaddingInfo(3, 0, 0, 0, 100f);
			this.xrTable5.Rows.AddRange(new XRTableRow[]
			{
				this.xrTableRow11
			});
			this.xrTable5.SizeF = new SizeF(797.5259f, 25f);
			this.xrTable5.StylePriority.UseBorders = false;
			this.xrTable5.StylePriority.UseFont = false;
			this.xrTable5.StylePriority.UsePadding = false;
			this.xrTable5.StylePriority.UseTextAlignment = false;
			this.xrTable5.TextAlignment = TextAlignment.TopCenter;
			this.xrTableRow11.Cells.AddRange(new XRTableCell[]
			{
				this.xrTableCell65,
				this.xrTableCell66,
				this.xrTableCell67,
				this.xrTableCell68,
				this.xrTableCell69,
				this.xrTableCell70,
				this.xrTableCell71,
				this.xrTableCell72,
				this.xrTableCell73,
				this.xrTableCell74,
				this.xrTableCell75,
				this.xrTableCell76,
				this.xrTableCell77,
				this.xrTableCell78,
				this.xrTableCell79,
				this.xrTableCell80
			});
			this.xrTableRow11.Dpi = 100f;
			this.xrTableRow11.Name = "xrTableRow11";
			this.xrTableRow11.Weight = 11.5;
			this.xrTableCell65.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "Invoice.InvoiceWorkOrderTimeSheet.EmpName")
			});
			this.xrTableCell65.Dpi = 100f;
			this.xrTableCell65.Name = "xrTableCell65";
			this.xrTableCell65.Text = "xrTableCell65";
			this.xrTableCell65.Weight = 0.209948893245528;
			this.xrTableCell66.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "Invoice.InvoiceWorkOrderTimeSheet.StartDateTime", "{0:dd MMM yyyy H:mm}")
			});
			this.xrTableCell66.Dpi = 100f;
			this.xrTableCell66.Name = "xrTableCell66";
			this.xrTableCell66.Text = "xrTableCell66";
			this.xrTableCell66.Weight = 0.19703866304135867;
			this.xrTableCell67.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "Invoice.InvoiceWorkOrderTimeSheet.EndDateTime", "{0:dd MMM yyyy H:mm}")
			});
			this.xrTableCell67.Dpi = 100f;
			this.xrTableCell67.Name = "xrTableCell67";
			this.xrTableCell67.Text = "xrTableCell67";
			this.xrTableCell67.Weight = 0.20880730176046866;
			this.xrTableCell68.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "Invoice.InvoiceWorkOrderTimeSheet.Day")
			});
			this.xrTableCell68.Dpi = 100f;
			this.xrTableCell68.Font = new Font("Times New Roman", 7.5f);
			this.xrTableCell68.Name = "xrTableCell68";
			this.xrTableCell68.StylePriority.UseFont = false;
			this.xrTableCell68.Text = "xrTableCell68";
			this.xrTableCell68.Weight = 0.12229633935064382;
			this.xrTableCell69.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "Invoice.InvoiceWorkOrderTimeSheet.WorkStatus")
			});
			this.xrTableCell69.Dpi = 100f;
			this.xrTableCell69.Name = "xrTableCell69";
			this.xrTableCell69.Text = "xrTableCell69";
			this.xrTableCell69.Weight = 0.09318389521105513;
			this.xrTableCell70.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "Invoice.InvoiceWorkOrderTimeSheet.ShiftStatus")
			});
			this.xrTableCell70.Dpi = 100f;
			this.xrTableCell70.Name = "xrTableCell70";
			this.xrTableCell70.Text = "xrTableCell70";
			this.xrTableCell70.Weight = 0.06512692819257909;
			this.xrTableCell71.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "Invoice.InvoiceWorkOrderTimeSheet.Breake")
			});
			this.xrTableCell71.Dpi = 100f;
			this.xrTableCell71.Name = "xrTableCell71";
			this.xrTableCell71.Text = "xrTableCell71";
			this.xrTableCell71.Weight = 0.06876836399219807;
			this.xrTableCell72.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "Invoice.InvoiceWorkOrderTimeSheet.WorkHrs", "{0:#}")
			});
			this.xrTableCell72.Dpi = 100f;
			this.xrTableCell72.Name = "xrTableCell72";
			this.xrTableCell72.Text = "xrTableCell72";
			this.xrTableCell72.Weight = 0.09237515369636778;
			this.xrTableCell73.Dpi = 100f;
			this.xrTableCell73.Name = "xrTableCell73";
			this.xrTableCell73.Text = "Day";
			this.xrTableCell73.Weight = 0.10355715201070498;
			this.xrTableCell74.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "Invoice.InvoiceWorkOrderTimeSheet.Qty")
			});
			this.xrTableCell74.Dpi = 100f;
			this.xrTableCell74.Name = "xrTableCell74";
			this.xrTableCell74.Text = "xrTableCell74";
			this.xrTableCell74.Weight = 0.0660802390131657;
			this.xrTableCell75.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "Invoice.InvoiceWorkOrderTimeSheet.TotalWorkingPrice", "{0:n2}")
			});
			this.xrTableCell75.Dpi = 100f;
			this.xrTableCell75.Name = "xrTableCell75";
			this.xrTableCell75.Text = "xrTableCell75";
			this.xrTableCell75.Weight = 0.10716727935709106;
			this.xrTableCell76.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "Invoice.InvoiceWorkOrderTimeSheet.TotalWorkingPrice", "{0:n2}")
			});
			this.xrTableCell76.Dpi = 100f;
			this.xrTableCell76.Name = "xrTableCell76";
			this.xrTableCell76.Weight = 0.10894210349531556;
			this.xrTableCell77.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "Invoice.InvoiceWorkOrderTimeSheet.OT Unit")
			});
			this.xrTableCell77.Dpi = 100f;
			this.xrTableCell77.Name = "xrTableCell77";
			this.xrTableCell77.Text = "xrTableCell77";
			this.xrTableCell77.Weight = 0.07075048493501451;
			this.xrTableCell78.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "Invoice.InvoiceWorkOrderTimeSheet.OTWorkingHours", "{0:n2}")
			});
			this.xrTableCell78.Dpi = 100f;
			this.xrTableCell78.Name = "xrTableCell78";
			this.xrTableCell78.Text = "xrTableCell78";
			this.xrTableCell78.Weight = 0.07134279646221814;
			this.xrTableCell79.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "Invoice.InvoiceWorkOrderTimeSheet.OTRate", "{0:n2}")
			});
			this.xrTableCell79.Dpi = 100f;
			this.xrTableCell79.Name = "xrTableCell79";
			this.xrTableCell79.Text = "xrTableCell79";
			this.xrTableCell79.Weight = 0.09543264069014916;
			this.xrTableCell80.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "Invoice.InvoiceWorkOrderTimeSheet.TotalAdditionalPrice", "{0:n2}")
			});
			this.xrTableCell80.Dpi = 100f;
			this.xrTableCell80.Name = "xrTableCell80";
			this.xrTableCell80.Text = "xrTableCell80";
			this.xrTableCell80.Weight = 0.09253632700473433;
			this.GroupHeader1.Controls.AddRange(new XRControl[]
			{
				this.xrTable6
			});
			this.GroupHeader1.Dpi = 100f;
			this.GroupHeader1.HeightF = 42.82408f;
			this.GroupHeader1.Name = "GroupHeader1";
			this.GroupHeader1.RepeatEveryPage = true;
			this.xrTable6.Borders = BorderSide.All;
			this.xrTable6.Dpi = 100f;
			this.xrTable6.Font = new Font("Times New Roman", 8f, FontStyle.Bold);
			this.xrTable6.LocationFloat = new PointFloat(27.29917f, 0f);
			this.xrTable6.Name = "xrTable6";
			this.xrTable6.Rows.AddRange(new XRTableRow[]
			{
				this.xrTableRow12
			});
			this.xrTable6.SizeF = new SizeF(797.5259f, 42.82408f);
			this.xrTable6.StylePriority.UseBorders = false;
			this.xrTable6.StylePriority.UseFont = false;
			this.xrTable6.StylePriority.UseTextAlignment = false;
			this.xrTable6.TextAlignment = TextAlignment.TopCenter;
			this.xrTableRow12.Cells.AddRange(new XRTableCell[]
			{
				this.xrTableCell81,
				this.xrTableCell82,
				this.xrTableCell83,
				this.xrTableCell84,
				this.xrTableCell85,
				this.xrTableCell86,
				this.xrTableCell87,
				this.xrTableCell88,
				this.xrTableCell89,
				this.xrTableCell90,
				this.xrTableCell91,
				this.xrTableCell92,
				this.xrTableCell93,
				this.xrTableCell94,
				this.xrTableCell95,
				this.xrTableCell96
			});
			this.xrTableRow12.Dpi = 100f;
			this.xrTableRow12.Name = "xrTableRow12";
			this.xrTableRow12.Weight = 11.5;
			this.xrTableCell81.Dpi = 100f;
			this.xrTableCell81.Name = "xrTableCell81";
			this.xrTableCell81.Text = "Tech Name";
			this.xrTableCell81.Weight = 0.2089249460053793;
			this.xrTableCell82.Dpi = 100f;
			this.xrTableCell82.Name = "xrTableCell82";
			this.xrTableCell82.Text = "Date/Time From";
			this.xrTableCell82.Weight = 0.19732342425251026;
			this.xrTableCell83.Dpi = 100f;
			this.xrTableCell83.Name = "xrTableCell83";
			this.xrTableCell83.Text = "Date/Time To";
			this.xrTableCell83.Weight = 0.2065431734578254;
			this.xrTableCell84.Dpi = 100f;
			this.xrTableCell84.Name = "xrTableCell84";
			this.xrTableCell84.Text = "Day";
			this.xrTableCell84.Weight = 0.12169988131353836;
			this.xrTableCell85.Dpi = 100f;
			this.xrTableCell85.Name = "xrTableCell85";
			this.xrTableCell85.Text = "Holiday /Duty";
			this.xrTableCell85.Weight = 0.09272945276787058;
			this.xrTableCell86.Dpi = 100f;
			this.xrTableCell86.Multiline = true;
			this.xrTableCell86.Name = "xrTableCell86";
			this.xrTableCell86.Text = "Day/Night";
			this.xrTableCell86.Weight = 0.06480929276796711;
			this.xrTableCell87.Dpi = 100f;
			this.xrTableCell87.Name = "xrTableCell87";
			this.xrTableCell87.Text = "Break";
			this.xrTableCell87.Weight = 0.06843297136728806;
			this.xrTableCell88.Dpi = 100f;
			this.xrTableCell88.Name = "xrTableCell88";
			this.xrTableCell88.Text = "Total Work Hrs";
			this.xrTableCell88.Weight = 0.09192462638037269;
			this.xrTableCell89.Dpi = 100f;
			this.xrTableCell89.Name = "xrTableCell89";
			this.xrTableCell89.Text = "Working Unit";
			this.xrTableCell89.Weight = 0.10305202213644579;
			this.xrTableCell90.Dpi = 100f;
			this.xrTableCell90.Name = "xrTableCell90";
			this.xrTableCell90.Text = "Qty";
			this.xrTableCell90.Weight = 0.06575813355386294;
			this.xrTableCell91.Dpi = 100f;
			this.xrTableCell91.Name = "xrTableCell91";
			this.xrTableCell91.Text = "Rate of Workimg";
			this.xrTableCell91.Weight = 0.10664461272341853;
			this.xrTableCell92.Dpi = 100f;
			this.xrTableCell92.Name = "xrTableCell92";
			this.xrTableCell92.Text = "Price Of Working";
			this.xrTableCell92.Weight = 0.10841078851813156;
			this.xrTableCell93.Dpi = 100f;
			this.xrTableCell93.Name = "xrTableCell93";
			this.xrTableCell93.Text = "OT Unit";
			this.xrTableCell93.Weight = 0.07040542514090005;
			this.xrTableCell94.Dpi = 100f;
			this.xrTableCell94.Name = "xrTableCell94";
			this.xrTableCell94.Text = "Qty";
			this.xrTableCell94.Weight = 0.07099484481219978;
			this.xrTableCell95.Dpi = 100f;
			this.xrTableCell95.Name = "xrTableCell95";
			this.xrTableCell95.Text = "OT Rate";
			this.xrTableCell95.Weight = 0.09496720465529544;
			this.xrTableCell96.Dpi = 100f;
			this.xrTableCell96.Name = "xrTableCell96";
			this.xrTableCell96.Text = "OT price";
			this.xrTableCell96.Weight = 0.09208484879661032;
			this.xrRichText1.Dpi = 100f;
			this.xrRichText1.Font = new Font("Times New Roman", 16f, FontStyle.Bold);
			this.xrRichText1.LocationFloat = new PointFloat(177.4255f, 10.00001f);
			this.xrRichText1.Name = "xrRichText1";
			//this.xrRichText1.SerializableRtfString = resources.GetString("xrRichText1.SerializableRtfString");
			this.xrRichText1.SizeF = new SizeF(430.8138f, 25f);
			this.xrRichText1.StylePriority.UseFont = false;
			this.xrTable4.Borders = BorderSide.All;
			this.xrTable4.Dpi = 100f;
			this.xrTable4.LocationFloat = new PointFloat(649.0879f, 10.00001f);
			this.xrTable4.Name = "xrTable4";
			this.xrTable4.Rows.AddRange(new XRTableRow[]
			{
				this.xrTableRow9,
				this.xrTableRow10
			});
			this.xrTable4.SizeF = new SizeF(175.7372f, 50.00001f);
			this.xrTable4.StylePriority.UseBorders = false;
			this.xrTable4.StylePriority.UseTextAlignment = false;
			this.xrTable4.TextAlignment = TextAlignment.TopCenter;
			this.xrTableRow9.Cells.AddRange(new XRTableCell[]
			{
				this.xrTableCell63
			});
			this.xrTableRow9.Dpi = 100f;
			this.xrTableRow9.Name = "xrTableRow9";
			this.xrTableRow9.Weight = 1.0;
			this.xrTableCell63.Borders = (BorderSide.Left | BorderSide.Top | BorderSide.Right);
			this.xrTableCell63.Dpi = 100f;
			this.xrTableCell63.Font = new Font("Times New Roman", 11f, FontStyle.Bold);
			this.xrTableCell63.Name = "xrTableCell63";
			this.xrTableCell63.StylePriority.UseBorders = false;
			this.xrTableCell63.StylePriority.UseFont = false;
			this.xrTableCell63.Text = "Summary of";
			this.xrTableCell63.Weight = 3.0;
			this.xrTableRow10.Cells.AddRange(new XRTableCell[]
			{
				this.xrTableCell64
			});
			this.xrTableRow10.Dpi = 100f;
			this.xrTableRow10.Name = "xrTableRow10";
			this.xrTableRow10.Weight = 1.0;
			this.xrTableCell64.Borders = (BorderSide.Left | BorderSide.Right | BorderSide.Bottom);
			this.xrTableCell64.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "Invoice.InvoiceNumber")
			});
			this.xrTableCell64.Dpi = 100f;
			this.xrTableCell64.Font = new Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTableCell64.Name = "xrTableCell64";
			this.xrTableCell64.StylePriority.UseBorders = false;
			this.xrTableCell64.StylePriority.UseFont = false;
			this.xrTableCell64.Weight = 3.0;
			this.PageHeader.Controls.AddRange(new XRControl[]
			{
				this.xrRichText1,
				this.xrTable4
			});
			this.PageHeader.Dpi = 100f;
			this.PageHeader.HeightF = 65.625f;
			this.PageHeader.Name = "PageHeader";
			this.InvoiceId.Description = "Parameter1";
			dynamicListLookUpSettings.DataAdapter = null;
			dynamicListLookUpSettings.DataMember = "Invoice";
			dynamicListLookUpSettings.DataSource = this.sqlDataSource1;
			dynamicListLookUpSettings.DisplayMember = "InvoiceNumber";
			dynamicListLookUpSettings.FilterString = null;
			dynamicListLookUpSettings.ValueMember = "InvoiceId";
			this.InvoiceId.LookUpSettings = dynamicListLookUpSettings;
			this.InvoiceId.Name = "InvoiceId";
			this.InvoiceId.Type = typeof(int);
			this.InvoiceId.ValueInfo = "0";
			this.DetailReport1.Bands.AddRange(new Band[]
			{
				this.Detail2
			});
			this.DetailReport1.Dpi = 100f;
			this.DetailReport1.Level = 1;
			this.DetailReport1.Name = "DetailReport1";
			this.Detail2.Controls.AddRange(new XRControl[]
			{
				this.xrLabel15,
				this.xrLabel16,
				this.xrLabel17,
				this.xrLabel18,
				this.xrLabel13,
				this.xrLabel14,
				this.xrLabel9,
				this.xrLabel11,
				this.xrLabel12,
				this.xrLabel10,
				this.xrLabel8,
				this.xrLabel7,
				this.xrLabel3,
				this.xrLabel4,
				this.xrLabel5,
				this.xrLabel6
			});
			this.Detail2.Dpi = 100f;
			this.Detail2.HeightF = 128.7501f;
			this.Detail2.Name = "Detail2";
			this.xrLabel15.BackColor = Color.WhiteSmoke;
			this.xrLabel15.Borders = (BorderSide.Left | BorderSide.Top | BorderSide.Bottom);
			this.xrLabel15.Dpi = 100f;
			this.xrLabel15.Font = new Font("Times New Roman", 9f);
			this.xrLabel15.LocationFloat = new PointFloat(509.6795f, 64.05214f);
			this.xrLabel15.Multiline = true;
			this.xrLabel15.Name = "xrLabel15";
			this.xrLabel15.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel15.SizeF = new SizeF(204.4222f, 20.64582f);
			this.xrLabel15.StylePriority.UseBackColor = false;
			this.xrLabel15.StylePriority.UseBorders = false;
			this.xrLabel15.StylePriority.UseFont = false;
			this.xrLabel15.StylePriority.UsePadding = false;
			this.xrLabel15.StylePriority.UseTextAlignment = false;
			this.xrLabel15.Text = "Total Overtime Hrs(QAR):";
			this.xrLabel15.TextAlignment = TextAlignment.TopCenter;
			this.xrLabel16.BackColor = Color.WhiteSmoke;
			this.xrLabel16.Borders = BorderSide.All;
			this.xrLabel16.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "Invoice.Sum_TotalAdditionalPrice", "{0:n2}")
			});
			this.xrLabel16.Dpi = 100f;
			this.xrLabel16.Font = new Font("Times New Roman", 9f);
			this.xrLabel16.LocationFloat = new PointFloat(714.102f, 64.05214f);
			this.xrLabel16.Name = "xrLabel16";
			this.xrLabel16.Padding = new PaddingInfo(2, 5, 0, 0, 100f);
			this.xrLabel16.SizeF = new SizeF(84.42401f, 20.64583f);
			this.xrLabel16.StylePriority.UseBackColor = false;
			this.xrLabel16.StylePriority.UseBorders = false;
			this.xrLabel16.StylePriority.UseFont = false;
			this.xrLabel16.StylePriority.UsePadding = false;
			this.xrLabel16.StylePriority.UseTextAlignment = false;
			this.xrLabel16.TextAlignment = TextAlignment.TopRight;
			this.xrLabel17.BackColor = Color.WhiteSmoke;
			this.xrLabel17.Borders = BorderSide.All;
			this.xrLabel17.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "Invoice.Sum_TotalWorkingPrice", "{0:n2}")
			});
			this.xrLabel17.Dpi = 100f;
			this.xrLabel17.Font = new Font("Times New Roman", 9f);
			this.xrLabel17.LocationFloat = new PointFloat(714.1025f, 43.4063f);
			this.xrLabel17.Name = "xrLabel17";
			this.xrLabel17.Padding = new PaddingInfo(2, 5, 0, 0, 100f);
			this.xrLabel17.SizeF = new SizeF(83.42365f, 20.64583f);
			this.xrLabel17.StylePriority.UseBackColor = false;
			this.xrLabel17.StylePriority.UseBorders = false;
			this.xrLabel17.StylePriority.UseFont = false;
			this.xrLabel17.StylePriority.UsePadding = false;
			this.xrLabel17.StylePriority.UseTextAlignment = false;
			this.xrLabel17.TextAlignment = TextAlignment.TopRight;
			this.xrLabel18.BackColor = Color.WhiteSmoke;
			this.xrLabel18.Borders = (BorderSide.Left | BorderSide.Top | BorderSide.Bottom);
			this.xrLabel18.Dpi = 100f;
			this.xrLabel18.Font = new Font("Times New Roman", 9f);
			this.xrLabel18.LocationFloat = new PointFloat(509.6795f, 43.4063f);
			this.xrLabel18.Name = "xrLabel18";
			this.xrLabel18.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel18.SizeF = new SizeF(203.4224f, 20.64583f);
			this.xrLabel18.StylePriority.UseBackColor = false;
			this.xrLabel18.StylePriority.UseBorders = false;
			this.xrLabel18.StylePriority.UseFont = false;
			this.xrLabel18.StylePriority.UsePadding = false;
			this.xrLabel18.StylePriority.UseTextAlignment = false;
			this.xrLabel18.Text = "Total of working Hrs(QAR):";
			this.xrLabel18.TextAlignment = TextAlignment.TopCenter;
			this.xrLabel13.BackColor = Color.WhiteSmoke;
			this.xrLabel13.Borders = (BorderSide.Left | BorderSide.Top | BorderSide.Bottom);
			this.xrLabel13.Dpi = 100f;
			this.xrLabel13.Font = new Font("Times New Roman", 9.75f);
			this.xrLabel13.LocationFloat = new PointFloat(27.29928f, 43.4063f);
			this.xrLabel13.Name = "xrLabel13";
			this.xrLabel13.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel13.SizeF = new SizeF(173.0334f, 20.64583f);
			this.xrLabel13.StylePriority.UseBackColor = false;
			this.xrLabel13.StylePriority.UseBorders = false;
			this.xrLabel13.StylePriority.UseFont = false;
			this.xrLabel13.StylePriority.UsePadding = false;
			this.xrLabel13.StylePriority.UseTextAlignment = false;
			this.xrLabel13.Text = "Extra night shift %:";
			this.xrLabel13.TextAlignment = TextAlignment.TopCenter;
			this.xrLabel14.BackColor = Color.WhiteSmoke;
			this.xrLabel14.Borders = BorderSide.All;
			this.xrLabel14.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "Invoice.NightShiftPerc", "{0:#}")
			});
			this.xrLabel14.Dpi = 100f;
			this.xrLabel14.Font = new Font("Times New Roman", 9.75f);
			this.xrLabel14.LocationFloat = new PointFloat(200.3325f, 43.4063f);
			this.xrLabel14.Name = "xrLabel14";
			this.xrLabel14.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel14.SizeF = new SizeF(103.9066f, 20.64583f);
			this.xrLabel14.StylePriority.UseBackColor = false;
			this.xrLabel14.StylePriority.UseBorders = false;
			this.xrLabel14.StylePriority.UseFont = false;
			this.xrLabel14.StylePriority.UsePadding = false;
			this.xrLabel14.StylePriority.UseTextAlignment = false;
			this.xrLabel14.TextAlignment = TextAlignment.TopCenter;
			this.xrLabel9.BackColor = Color.WhiteSmoke;
			this.xrLabel9.Borders = (BorderSide.Left | BorderSide.Top | BorderSide.Bottom);
			this.xrLabel9.Dpi = 100f;
			this.xrLabel9.Font = new Font("Times New Roman", 9f);
			this.xrLabel9.LocationFloat = new PointFloat(509.6795f, 84.69798f);
			this.xrLabel9.Name = "xrLabel9";
			this.xrLabel9.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel9.SizeF = new SizeF(204.4228f, 20.64585f);
			this.xrLabel9.StylePriority.UseBackColor = false;
			this.xrLabel9.StylePriority.UseBorders = false;
			this.xrLabel9.StylePriority.UseFont = false;
			this.xrLabel9.StylePriority.UsePadding = false;
			this.xrLabel9.StylePriority.UseTextAlignment = false;
			this.xrLabel9.Text = "Extra night shift Amount(QAR):";
			this.xrLabel9.TextAlignment = TextAlignment.TopCenter;
			this.xrLabel11.BackColor = Color.WhiteSmoke;
			this.xrLabel11.Borders = BorderSide.All;
			this.xrLabel11.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "Invoice.NightShiftPercAmount", "{0:n2}")
			});
			this.xrLabel11.Dpi = 100f;
			this.xrLabel11.Font = new Font("Times New Roman", 9f);
			this.xrLabel11.LocationFloat = new PointFloat(714.102f, 84.69798f);
			this.xrLabel11.Name = "xrLabel11";
			this.xrLabel11.Padding = new PaddingInfo(2, 5, 0, 0, 100f);
			this.xrLabel11.SizeF = new SizeF(84.42401f, 20.64583f);
			this.xrLabel11.StylePriority.UseBackColor = false;
			this.xrLabel11.StylePriority.UseBorders = false;
			this.xrLabel11.StylePriority.UseFont = false;
			this.xrLabel11.StylePriority.UsePadding = false;
			this.xrLabel11.StylePriority.UseTextAlignment = false;
			this.xrLabel11.TextAlignment = TextAlignment.TopRight;
			this.xrLabel12.BackColor = Color.WhiteSmoke;
			this.xrLabel12.Borders = BorderSide.All;
			this.xrLabel12.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "Invoice.Sum_TotalAdditionalPrice", "{0:n2}")
			});
			this.xrLabel12.Dpi = 100f;
			this.xrLabel12.Font = new Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrLabel12.LocationFloat = new PointFloat(783.209f, 0f);
			this.xrLabel12.Name = "xrLabel12";
			this.xrLabel12.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel12.SizeF = new SizeF(41.61609f, 20.64583f);
			this.xrLabel12.StylePriority.UseBackColor = false;
			this.xrLabel12.StylePriority.UseBorders = false;
			this.xrLabel12.StylePriority.UseFont = false;
			this.xrLabel12.StylePriority.UsePadding = false;
			this.xrLabel12.StylePriority.UseTextAlignment = false;
			this.xrLabel12.TextAlignment = TextAlignment.TopCenter;
			this.xrLabel10.BackColor = Color.WhiteSmoke;
			this.xrLabel10.Borders = BorderSide.All;
			this.xrLabel10.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "Invoice.Sum_OTWorkingHours", "{0:n2}")
			});
			this.xrLabel10.Dpi = 100f;
			this.xrLabel10.Font = new Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrLabel10.LocationFloat = new PointFloat(708.2056f, 0f);
			this.xrLabel10.Name = "xrLabel10";
			this.xrLabel10.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel10.SizeF = new SizeF(32.08478f, 20.64583f);
			this.xrLabel10.StylePriority.UseBackColor = false;
			this.xrLabel10.StylePriority.UseBorders = false;
			this.xrLabel10.StylePriority.UseFont = false;
			this.xrLabel10.StylePriority.UsePadding = false;
			this.xrLabel10.StylePriority.UseTextAlignment = false;
			this.xrLabel10.TextAlignment = TextAlignment.TopCenter;
			this.xrLabel8.BackColor = Color.WhiteSmoke;
			this.xrLabel8.Borders = BorderSide.All;
			this.xrLabel8.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "Invoice.Sum_TotalWorkingPrice", "{0:#}")
			});
			this.xrLabel8.Dpi = 100f;
			this.xrLabel8.Font = new Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrLabel8.LocationFloat = new PointFloat(579.1968f, 0f);
			this.xrLabel8.Name = "xrLabel8";
			this.xrLabel8.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel8.SizeF = new SizeF(48.19604f, 20.64583f);
			this.xrLabel8.StylePriority.UseBackColor = false;
			this.xrLabel8.StylePriority.UseBorders = false;
			this.xrLabel8.StylePriority.UseFont = false;
			this.xrLabel8.StylePriority.UsePadding = false;
			this.xrLabel8.StylePriority.UseTextAlignment = false;
			this.xrLabel8.TextAlignment = TextAlignment.TopCenter;
			this.xrLabel7.BackColor = Color.WhiteSmoke;
			this.xrLabel7.Borders = BorderSide.All;
			this.xrLabel7.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "Invoice.Sum_WorkHrs", "{0:#}")
			});
			this.xrLabel7.Dpi = 100f;
			this.xrLabel7.Font = new Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrLabel7.LocationFloat = new PointFloat(461.3627f, 0f);
			this.xrLabel7.Name = "xrLabel7";
			this.xrLabel7.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel7.SizeF = new SizeF(41.54364f, 20.64583f);
			this.xrLabel7.StylePriority.UseBackColor = false;
			this.xrLabel7.StylePriority.UseBorders = false;
			this.xrLabel7.StylePriority.UseFont = false;
			this.xrLabel7.StylePriority.UsePadding = false;
			this.xrLabel7.StylePriority.UseTextAlignment = false;
			this.xrLabel7.TextAlignment = TextAlignment.TopCenter;
			this.xrLabel3.BackColor = Color.WhiteSmoke;
			this.xrLabel3.Borders = BorderSide.All;
			this.xrLabel3.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "Invoice.NigthDays")
			});
			this.xrLabel3.Dpi = 100f;
			this.xrLabel3.Font = new Font("Times New Roman", 9.75f);
			this.xrLabel3.LocationFloat = new PointFloat(200.3325f, 64.0522f);
			this.xrLabel3.Name = "xrLabel3";
			this.xrLabel3.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel3.SizeF = new SizeF(103.9066f, 20.64583f);
			this.xrLabel3.StylePriority.UseBackColor = false;
			this.xrLabel3.StylePriority.UseBorders = false;
			this.xrLabel3.StylePriority.UseFont = false;
			this.xrLabel3.StylePriority.UsePadding = false;
			this.xrLabel3.StylePriority.UseTextAlignment = false;
			this.xrLabel3.TextAlignment = TextAlignment.TopCenter;
			this.xrLabel4.BackColor = Color.WhiteSmoke;
			this.xrLabel4.Borders = (BorderSide.Left | BorderSide.Top | BorderSide.Bottom);
			this.xrLabel4.Dpi = 100f;
			this.xrLabel4.Font = new Font("Times New Roman", 9.75f);
			this.xrLabel4.LocationFloat = new PointFloat(27.29928f, 64.0522f);
			this.xrLabel4.Name = "xrLabel4";
			this.xrLabel4.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel4.SizeF = new SizeF(173.0334f, 20.64583f);
			this.xrLabel4.StylePriority.UseBackColor = false;
			this.xrLabel4.StylePriority.UseBorders = false;
			this.xrLabel4.StylePriority.UseFont = false;
			this.xrLabel4.StylePriority.UsePadding = false;
			this.xrLabel4.StylePriority.UseTextAlignment = false;
			this.xrLabel4.Text = "Extra night shift days:";
			this.xrLabel4.TextAlignment = TextAlignment.TopCenter;
			this.xrLabel5.BackColor = Color.WhiteSmoke;
			this.xrLabel5.Borders = BorderSide.All;
			this.xrLabel5.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "Invoice.GrandTotal", "{0:n2}")
			});
			this.xrLabel5.Dpi = 100f;
			this.xrLabel5.Font = new Font("Times New Roman", 9f);
			this.xrLabel5.LocationFloat = new PointFloat(714.1025f, 105.3438f);
			this.xrLabel5.Name = "xrLabel5";
			this.xrLabel5.Padding = new PaddingInfo(2, 5, 0, 0, 100f);
			this.xrLabel5.SizeF = new SizeF(84.42401f, 20.64583f);
			this.xrLabel5.StylePriority.UseBackColor = false;
			this.xrLabel5.StylePriority.UseBorders = false;
			this.xrLabel5.StylePriority.UseFont = false;
			this.xrLabel5.StylePriority.UsePadding = false;
			this.xrLabel5.StylePriority.UseTextAlignment = false;
			this.xrLabel5.TextAlignment = TextAlignment.TopRight;
			this.xrLabel6.BackColor = Color.WhiteSmoke;
			this.xrLabel6.Borders = (BorderSide.Left | BorderSide.Top | BorderSide.Bottom);
			this.xrLabel6.Dpi = 100f;
			this.xrLabel6.Font = new Font("Times New Roman", 9f);
			this.xrLabel6.LocationFloat = new PointFloat(509.6795f, 105.3438f);
			this.xrLabel6.Name = "xrLabel6";
			this.xrLabel6.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel6.SizeF = new SizeF(204.4228f, 20.64583f);
			this.xrLabel6.StylePriority.UseBackColor = false;
			this.xrLabel6.StylePriority.UseBorders = false;
			this.xrLabel6.StylePriority.UseFont = false;
			this.xrLabel6.StylePriority.UsePadding = false;
			this.xrLabel6.StylePriority.UseTextAlignment = false;
			this.xrLabel6.Text = "GRAND TOTAL(QAR):";
			this.xrLabel6.TextAlignment = TextAlignment.TopCenter;
			this.GrandTotal.DataMember = "Invoice";
			this.GrandTotal.Expression = "[Sum_TotalAdditionalPrice] + [Sum_TotalWorkingPrice] + [NightShiftPercAmount]";
			this.GrandTotal.Name = "GrandTotal";
			this.Total.DataMember = "Invoice";
			this.Total.Expression = "[Sum_TotalAdditionalPrice] + [Sum_TotalWorkingPrice]";
			this.Total.Name = "Total";
			this.StartDateTime.DataMember = "Invoice.InvoiceWorkOrderTimeSheet";
			this.StartDateTime.Expression = "Iif(IsNullOrEmpty([StartTime]) ,[StartDate],[StartTime] )";
			this.StartDateTime.Name = "StartDateTime";
			this.EndDateTime.DataMember = "Invoice.InvoiceWorkOrderTimeSheet";
			this.EndDateTime.Expression = "Iif(IsNullOrEmpty([EndTime]) ,[EndDate],[EndTime] )";
			this.EndDateTime.Name = "EndDateTime";
			this.NigthDays.DataMember = "Invoice.InvoiceWorkOrderTimeSheet";
			this.NigthDays.Expression = "Iif([ShiftStatus]==2,[ShiftStatus].Count()  ,0 )";
			this.NigthDays.Name = "NigthDays";
			this.calculatedField2.DataMember = "Invoice.InvoiceWorkOrderTimeSheet";
			this.calculatedField2.Expression = "[NigthAmount]";
			this.calculatedField2.Name = "calculatedField2";
			base.Bands.AddRange(new Band[]
			{
				this.Detail,
				this.TopMargin,
				this.BottomMargin,
				this.pageFooterBand1,
				this.reportHeaderBand1,
				this.DetailReport,
				this.PageHeader,
				this.DetailReport1
			});
			base.CalculatedFields.AddRange(new CalculatedField[]
			{
				this.GrandTotal,
				this.Total,
				this.StartDateTime,
				this.EndDateTime,
				this.NigthDays,
				this.calculatedField2
			});
			base.ComponentStorage.AddRange(new IComponent[]
			{
				this.sqlDataSource1
			});
			base.DataMember = "Invoice";
			base.DataSource = this.sqlDataSource1;
			base.DefaultPrinterSettingsUsing.UseLandscape = true;
			this.FilterString = "[InvoiceId] = ?InvoiceId";
			base.Margins = new Margins(0, 0, 90, 3);
			base.Parameters.AddRange(new Parameter[]
			{
				this.InvoiceId
			});
			base.StyleSheet.AddRange(new XRControlStyle[]
			{
				this.Title,
				this.FieldCaption,
				this.PageInfo,
				this.DataField
			});
			base.Version = "16.1";
			((ISupportInitialize)this.xrTable1).EndInit();
			((ISupportInitialize)this.xrTable5).EndInit();
			((ISupportInitialize)this.xrTable6).EndInit();
			((ISupportInitialize)this.xrRichText1).EndInit();
			((ISupportInitialize)this.xrTable4).EndInit();
			((ISupportInitialize)this).EndInit();
		}

		// Token: 0x04000BDE RID: 3038
		private IContainer components;

		// Token: 0x04000BDF RID: 3039
		private DetailBand Detail;

		// Token: 0x04000BE0 RID: 3040
		private TopMarginBand TopMargin;

		// Token: 0x04000BE1 RID: 3041
		private BottomMarginBand BottomMargin;

		// Token: 0x04000BE2 RID: 3042
		private SqlDataSource sqlDataSource1;

		// Token: 0x04000BE3 RID: 3043
		private PageFooterBand pageFooterBand1;

		// Token: 0x04000BE4 RID: 3044
		private XRPageInfo xrPageInfo2;

		// Token: 0x04000BE5 RID: 3045
		private ReportHeaderBand reportHeaderBand1;

		// Token: 0x04000BE6 RID: 3046
		private XRControlStyle Title;

		// Token: 0x04000BE7 RID: 3047
		private XRControlStyle FieldCaption;

		// Token: 0x04000BE8 RID: 3048
		private XRControlStyle PageInfo;

		// Token: 0x04000BE9 RID: 3049
		private XRControlStyle DataField;

		// Token: 0x04000BEA RID: 3050
		private DetailReportBand DetailReport;

		// Token: 0x04000BEB RID: 3051
		private DetailBand Detail1;

		// Token: 0x04000BEC RID: 3052
		private GroupHeaderBand GroupHeader1;

		// Token: 0x04000BED RID: 3053
		private XRTable xrTable1;

		// Token: 0x04000BEE RID: 3054
		private XRTableRow xrTableRow1;

		// Token: 0x04000BEF RID: 3055
		private XRTableCell xrTableCell1;

		// Token: 0x04000BF0 RID: 3056
		private XRTableCell xrTableCell2;

		// Token: 0x04000BF1 RID: 3057
		private XRTableCell xrTableCell3;

		// Token: 0x04000BF2 RID: 3058
		private XRTableCell xrTableCell4;

		// Token: 0x04000BF3 RID: 3059
		private XRTableCell xrTableCell5;

		// Token: 0x04000BF4 RID: 3060
		private XRTableCell xrTableCell6;

		// Token: 0x04000BF5 RID: 3061
		private XRTableRow xrTableRow2;

		// Token: 0x04000BF6 RID: 3062
		private XRTableCell xrTableCell7;

		// Token: 0x04000BF7 RID: 3063
		private XRTableCell xrTableCell8;

		// Token: 0x04000BF8 RID: 3064
		private XRTableCell xrTableCell9;

		// Token: 0x04000BF9 RID: 3065
		private XRTableCell xrTableCell10;

		// Token: 0x04000BFA RID: 3066
		private XRTableCell xrTableCell11;

		// Token: 0x04000BFB RID: 3067
		private XRTableCell xrTableCell12;

		// Token: 0x04000BFC RID: 3068
		private XRTableRow xrTableRow3;

		// Token: 0x04000BFD RID: 3069
		private XRTableCell xrTableCell13;

		// Token: 0x04000BFE RID: 3070
		private XRTableCell xrTableCell14;

		// Token: 0x04000BFF RID: 3071
		private XRTableCell xrTableCell15;

		// Token: 0x04000C00 RID: 3072
		private XRTableCell xrTableCell16;

		// Token: 0x04000C01 RID: 3073
		private XRTableCell xrTableCell17;

		// Token: 0x04000C02 RID: 3074
		private XRTableCell xrTableCell18;

		// Token: 0x04000C03 RID: 3075
		private XRTableRow xrTableRow4;

		// Token: 0x04000C04 RID: 3076
		private XRTableCell xrTableCell19;

		// Token: 0x04000C05 RID: 3077
		private XRTableCell xrTableCell20;

		// Token: 0x04000C06 RID: 3078
		private XRTableCell xrTableCell21;

		// Token: 0x04000C07 RID: 3079
		private XRTableCell xrTableCell22;

		// Token: 0x04000C08 RID: 3080
		private XRTableCell xrTableCell23;

		// Token: 0x04000C09 RID: 3081
		private XRTableCell xrTableCell24;

		// Token: 0x04000C0A RID: 3082
		private XRTableRow xrTableRow5;

		// Token: 0x04000C0B RID: 3083
		private XRTableCell xrTableCell25;

		// Token: 0x04000C0C RID: 3084
		private XRTableCell xrTableCell26;

		// Token: 0x04000C0D RID: 3085
		private XRTableCell xrTableCell27;

		// Token: 0x04000C0E RID: 3086
		private XRTableCell xrTableCell28;

		// Token: 0x04000C0F RID: 3087
		private XRTableCell xrTableCell29;

		// Token: 0x04000C10 RID: 3088
		private XRTableCell xrTableCell30;

		// Token: 0x04000C11 RID: 3089
		private XRTableRow xrTableRow6;

		// Token: 0x04000C12 RID: 3090
		private XRTableCell xrTableCell31;

		// Token: 0x04000C13 RID: 3091
		private XRTableCell xrTableCell36;

		// Token: 0x04000C14 RID: 3092
		private XRTable xrTable4;

		// Token: 0x04000C15 RID: 3093
		private XRTableRow xrTableRow9;

		// Token: 0x04000C16 RID: 3094
		private XRTableCell xrTableCell63;

		// Token: 0x04000C17 RID: 3095
		private XRTableRow xrTableRow10;

		// Token: 0x04000C18 RID: 3096
		private XRTableCell xrTableCell64;

		// Token: 0x04000C19 RID: 3097
		private XRRichText xrRichText1;

		// Token: 0x04000C1A RID: 3098
		private PageHeaderBand PageHeader;

		// Token: 0x04000C1B RID: 3099
		private Parameter InvoiceId;

		// Token: 0x04000C1C RID: 3100
		private DetailReportBand DetailReport1;

		// Token: 0x04000C1D RID: 3101
		private DetailBand Detail2;

		// Token: 0x04000C1E RID: 3102
		private XRLabel xrLabel3;

		// Token: 0x04000C1F RID: 3103
		private XRLabel xrLabel4;

		// Token: 0x04000C20 RID: 3104
		private XRLabel xrLabel5;

		// Token: 0x04000C21 RID: 3105
		private XRLabel xrLabel6;

		// Token: 0x04000C22 RID: 3106
		private XRLabel xrLabel12;

		// Token: 0x04000C23 RID: 3107
		private XRLabel xrLabel10;

		// Token: 0x04000C24 RID: 3108
		private XRLabel xrLabel8;

		// Token: 0x04000C25 RID: 3109
		private XRLabel xrLabel7;

		// Token: 0x04000C26 RID: 3110
		private CalculatedField GrandTotal;

		// Token: 0x04000C27 RID: 3111
		private CalculatedField Total;

		// Token: 0x04000C28 RID: 3112
		private CalculatedField StartDateTime;

		// Token: 0x04000C29 RID: 3113
		private CalculatedField EndDateTime;

		// Token: 0x04000C2A RID: 3114
		private XRTable xrTable5;

		// Token: 0x04000C2B RID: 3115
		private XRTableRow xrTableRow11;

		// Token: 0x04000C2C RID: 3116
		private XRTableCell xrTableCell65;

		// Token: 0x04000C2D RID: 3117
		private XRTableCell xrTableCell66;

		// Token: 0x04000C2E RID: 3118
		private XRTableCell xrTableCell67;

		// Token: 0x04000C2F RID: 3119
		private XRTableCell xrTableCell68;

		// Token: 0x04000C30 RID: 3120
		private XRTableCell xrTableCell69;

		// Token: 0x04000C31 RID: 3121
		private XRTableCell xrTableCell70;

		// Token: 0x04000C32 RID: 3122
		private XRTableCell xrTableCell71;

		// Token: 0x04000C33 RID: 3123
		private XRTableCell xrTableCell72;

		// Token: 0x04000C34 RID: 3124
		private XRTableCell xrTableCell73;

		// Token: 0x04000C35 RID: 3125
		private XRTableCell xrTableCell74;

		// Token: 0x04000C36 RID: 3126
		private XRTableCell xrTableCell75;

		// Token: 0x04000C37 RID: 3127
		private XRTableCell xrTableCell76;

		// Token: 0x04000C38 RID: 3128
		private XRTableCell xrTableCell77;

		// Token: 0x04000C39 RID: 3129
		private XRTableCell xrTableCell78;

		// Token: 0x04000C3A RID: 3130
		private XRTableCell xrTableCell79;

		// Token: 0x04000C3B RID: 3131
		private XRTableCell xrTableCell80;

		// Token: 0x04000C3C RID: 3132
		private XRTable xrTable6;

		// Token: 0x04000C3D RID: 3133
		private XRTableRow xrTableRow12;

		// Token: 0x04000C3E RID: 3134
		private XRTableCell xrTableCell81;

		// Token: 0x04000C3F RID: 3135
		private XRTableCell xrTableCell82;

		// Token: 0x04000C40 RID: 3136
		private XRTableCell xrTableCell83;

		// Token: 0x04000C41 RID: 3137
		private XRTableCell xrTableCell84;

		// Token: 0x04000C42 RID: 3138
		private XRTableCell xrTableCell85;

		// Token: 0x04000C43 RID: 3139
		private XRTableCell xrTableCell86;

		// Token: 0x04000C44 RID: 3140
		private XRTableCell xrTableCell87;

		// Token: 0x04000C45 RID: 3141
		private XRTableCell xrTableCell88;

		// Token: 0x04000C46 RID: 3142
		private XRTableCell xrTableCell89;

		// Token: 0x04000C47 RID: 3143
		private XRTableCell xrTableCell90;

		// Token: 0x04000C48 RID: 3144
		private XRTableCell xrTableCell91;

		// Token: 0x04000C49 RID: 3145
		private XRTableCell xrTableCell92;

		// Token: 0x04000C4A RID: 3146
		private XRTableCell xrTableCell93;

		// Token: 0x04000C4B RID: 3147
		private XRTableCell xrTableCell94;

		// Token: 0x04000C4C RID: 3148
		private XRTableCell xrTableCell95;

		// Token: 0x04000C4D RID: 3149
		private XRTableCell xrTableCell96;

		// Token: 0x04000C4E RID: 3150
		private XRLabel xrLabel13;

		// Token: 0x04000C4F RID: 3151
		private XRLabel xrLabel14;

		// Token: 0x04000C50 RID: 3152
		private XRLabel xrLabel9;

		// Token: 0x04000C51 RID: 3153
		private XRLabel xrLabel11;

		// Token: 0x04000C52 RID: 3154
		private CalculatedField NigthDays;

		// Token: 0x04000C53 RID: 3155
		private CalculatedField calculatedField2;

		// Token: 0x04000C54 RID: 3156
		private XRLabel xrLabel15;

		// Token: 0x04000C55 RID: 3157
		private XRLabel xrLabel16;

		// Token: 0x04000C56 RID: 3158
		private XRLabel xrLabel17;

		// Token: 0x04000C57 RID: 3159
		private XRLabel xrLabel18;
	}
}
