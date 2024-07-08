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
	// Token: 0x02000066 RID: 102
	public class QuotationReportFinal : XtraReport
	{
		// Token: 0x0600036B RID: 875 RVA: 0x0000446A File Offset: 0x0000266A
		public QuotationReportFinal()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600036C RID: 876 RVA: 0x00004478 File Offset: 0x00002678
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600036D RID: 877 RVA: 0x000446B0 File Offset: 0x000428B0
		private void InitializeComponent()
		{
			this.components = new Container();
			CustomSqlQuery customSqlQuery = new CustomSqlQuery();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuotationReportFinal));
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(QuotationReportFinal));
			CustomSqlQuery customSqlQuery2 = new CustomSqlQuery();
			SelectQuery selectQuery = new SelectQuery();
			Column column = new Column();
			ColumnExpression columnExpression = new ColumnExpression();
			Table table = new Table();
			Column column2 = new Column();
			ColumnExpression columnExpression2 = new ColumnExpression();
			MasterDetailInfo masterDetailInfo = new MasterDetailInfo();
			RelationColumnInfo relationColumnInfo = new RelationColumnInfo();
			MasterDetailInfo masterDetailInfo2 = new MasterDetailInfo();
			RelationColumnInfo relationColumnInfo2 = new RelationColumnInfo();
			DynamicListLookUpSettings dynamicListLookUpSettings = new DynamicListLookUpSettings();
			this.sqlDataSource1 = new SqlDataSource(this.components);
			this.Detail = new DetailBand();
			this.xrTable1 = new XRTable();
			this.xrTableRow1 = new XRTableRow();
			this.xrTableCell28 = new XRTableCell();
			this.xrTableCell1 = new XRTableCell();
			this.xrTableRow2 = new XRTableRow();
			this.xrTableCell29 = new XRTableCell();
			this.xrTableCell2 = new XRTableCell();
			this.xrTableRow3 = new XRTableRow();
			this.xrTableCell30 = new XRTableCell();
			this.xrTableCell3 = new XRTableCell();
			this.xrTableRow4 = new XRTableRow();
			this.xrTableCell31 = new XRTableCell();
			this.xrTableCell4 = new XRTableCell();
			this.xrTableRow5 = new XRTableRow();
			this.xrTableCell32 = new XRTableCell();
			this.xrTableCell5 = new XRTableCell();
			this.xrTableRow6 = new XRTableRow();
			this.xrTableCell33 = new XRTableCell();
			this.xrTableCell6 = new XRTableCell();
			this.xrTableRow7 = new XRTableRow();
			this.xrTableCell34 = new XRTableCell();
			this.xrTableCell7 = new XRTableCell();
			this.xrTable2 = new XRTable();
			this.xrTableRow8 = new XRTableRow();
			this.xrTableCell8 = new XRTableCell();
			this.xrTableCell17 = new XRTableCell();
			this.xrLabel28 = new XRLabel();
			this.xrTableRow9 = new XRTableRow();
			this.xrTableCell9 = new XRTableCell();
			this.xrTableCell25 = new XRTableCell();
			this.xrLabel1 = new XRLabel();
			this.xrLabel2 = new XRLabel();
			this.xrLabel3 = new XRLabel();
			this.xrLabel35 = new XRLabel();
			this.TopMargin = new TopMarginBand();
			this.BottomMargin = new BottomMarginBand();
			this.xrPageInfo4 = new XRPageInfo();
			this.reportHeaderBand1 = new ReportHeaderBand();
			this.Title = new XRControlStyle();
			this.FieldCaption = new XRControlStyle();
			this.PageInfo = new XRControlStyle();
			this.DataField = new XRControlStyle();
			this.DetailReport = new DetailReportBand();
			this.Detail1 = new DetailBand();
			this.xrTable4 = new XRTable();
			this.xrTableRow11 = new XRTableRow();
			this.xrTableCell38 = new XRTableCell();
			this.xrTableCell18 = new XRTableCell();
			this.xrTableCell19 = new XRTableCell();
			this.xrTableCell20 = new XRTableCell();
			this.xrTableCell21 = new XRTableCell();
			this.xrTableCell22 = new XRTableCell();
			this.xrTableCell23 = new XRTableCell();
			this.xrTableCell24 = new XRTableCell();
			this.xrTableCell27 = new XRTableCell();
			this.GroupHeader1 = new GroupHeaderBand();
			this.xrTable3 = new XRTable();
			this.xrTableRow10 = new XRTableRow();
			this.xrTableCell40 = new XRTableCell();
			this.xrTableCell10 = new XRTableCell();
			this.xrTableCell11 = new XRTableCell();
			this.xrTableCell12 = new XRTableCell();
			this.xrTableCell13 = new XRTableCell();
			this.xrTableCell14 = new XRTableCell();
			this.xrTableCell15 = new XRTableCell();
			this.xrTableCell16 = new XRTableCell();
			this.xrTableCell26 = new XRTableCell();
			this.DetailReport1 = new DetailReportBand();
			this.Detail2 = new DetailBand();
			this.xrLabel4 = new XRLabel();
			this.xrTable7 = new XRTable();
			this.xrTableRow16 = new XRTableRow();
			this.xrTableCell49 = new XRTableCell();
			this.ReportFooter = new ReportFooterBand();
			this.DetailReport2 = new DetailReportBand();
			this.Detail3 = new DetailBand();
			this.calculatedField1 = new CalculatedField();
			this.ExpiresDay = new CalculatedField();
			this.QID = new Parameter();
			this.calculatedField2 = new CalculatedField();
			this.PageHeader = new PageHeaderBand();
			this.xrLabel5 = new XRLabel();
			this.DetailReport3 = new DetailReportBand();
			this.Detail4 = new DetailBand();
			this.xrTableCell39 = new XRTableCell();
			this.xrTableCell37 = new XRTableCell();
			this.xrTableCell36 = new XRTableCell();
			this.xrTableCell35 = new XRTableCell();
			this.xrTableRow12 = new XRTableRow();
			this.xrTable5 = new XRTable();
			this.xrLabel21 = new XRLabel();
			this.xrTableCell43 = new XRTableCell();
			this.xrTableRow15 = new XRTableRow();
			this.xrTable9 = new XRTable();
			this.xrLabel22 = new XRLabel();
			this.xrLabel26 = new XRLabel();
			((ISupportInitialize)this.xrTable1).BeginInit();
			((ISupportInitialize)this.xrTable2).BeginInit();
			((ISupportInitialize)this.xrTable4).BeginInit();
			((ISupportInitialize)this.xrTable3).BeginInit();
			((ISupportInitialize)this.xrTable7).BeginInit();
			((ISupportInitialize)this.xrTable5).BeginInit();
			((ISupportInitialize)this.xrTable9).BeginInit();
			((ISupportInitialize)this).BeginInit();
			this.sqlDataSource1.ConnectionName = "localhost_LabSys_Connection";
			this.sqlDataSource1.Name = "sqlDataSource1";
			customSqlQuery.Name = "QuotationMaster";
			customSqlQuery.Sql = resources.GetString("customSqlQuery1.Sql");
			customSqlQuery2.Name = "QuotationDetails";
			customSqlQuery2.Sql = resources.GetString("customSqlQuery2.Sql");
			columnExpression.ColumnName = "ContactPerson";
			table.MetaSerializable = "30|30|125|360";
			table.Name = "EnquiryMaster";
			columnExpression.Table = table;
			column.Expression = columnExpression;
			columnExpression2.ColumnName = "EnquiryMasterID";
			columnExpression2.Table = table;
			column2.Expression = columnExpression2;
			selectQuery.Columns.Add(column);
			selectQuery.Columns.Add(column2);
			selectQuery.Name = "EnquiryMaster";
			selectQuery.Tables.Add(table);
			this.sqlDataSource1.Queries.AddRange(new SqlQuery[]
			{
				customSqlQuery,
				customSqlQuery2,
				selectQuery
			});
			masterDetailInfo.DetailQueryName = "QuotationDetails";
			relationColumnInfo.NestedKeyColumn = "FKQuotationMasterID";
			relationColumnInfo.ParentKeyColumn = "QuotationMasterID";
			masterDetailInfo.KeyColumns.Add(relationColumnInfo);
			masterDetailInfo.MasterQueryName = "QuotationMaster";
			masterDetailInfo2.DetailQueryName = "EnquiryMaster";
			relationColumnInfo2.NestedKeyColumn = "EnquiryMasterID";
			relationColumnInfo2.ParentKeyColumn = "FKEnquiryMasterID";
			masterDetailInfo2.KeyColumns.Add(relationColumnInfo2);
			masterDetailInfo2.MasterQueryName = "QuotationMaster";
			this.sqlDataSource1.Relations.AddRange(new MasterDetailInfo[]
			{
				masterDetailInfo,
				masterDetailInfo2
			});
			this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
			this.Detail.Controls.AddRange(new XRControl[]
			{
				this.xrTable1,
				this.xrTable2,
				this.xrLabel1,
				this.xrLabel2,
				this.xrLabel3,
				this.xrLabel35
			});
			this.Detail.Dpi = 100f;
			this.Detail.Font = new Font("Times New Roman", 10.4f);
			this.Detail.HeightF = 268.75f;
			this.Detail.KeepTogether = true;
			this.Detail.KeepTogetherWithDetailReports = true;
			this.Detail.Name = "Detail";
			this.Detail.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
			this.Detail.PageBreak = PageBreak.BeforeBand;
			this.Detail.SnapLinePadding = new PaddingInfo(10, 10, 50, 10, 100f);
			this.Detail.StylePriority.UseFont = false;
			this.Detail.TextAlignment = TextAlignment.TopLeft;
			this.xrTable1.Borders = BorderSide.All;
			this.xrTable1.Dpi = 100f;
			this.xrTable1.Font = new Font("Arial", 9.75f);
			this.xrTable1.LocationFloat = new PointFloat(22.58333f, 10.00001f);
			this.xrTable1.Name = "xrTable1";
			this.xrTable1.Padding = new PaddingInfo(5, 0, 0, 0, 100f);
			this.xrTable1.Rows.AddRange(new XRTableRow[]
			{
				this.xrTableRow1,
				this.xrTableRow2,
				this.xrTableRow3,
				this.xrTableRow4,
				this.xrTableRow5,
				this.xrTableRow6,
				this.xrTableRow7
			});
			this.xrTable1.SizeF = new SizeF(347.5367f, 138.5417f);
			this.xrTable1.StylePriority.UseBorders = false;
			this.xrTable1.StylePriority.UseFont = false;
			this.xrTable1.StylePriority.UsePadding = false;
			this.xrTableRow1.Cells.AddRange(new XRTableCell[]
			{
				this.xrTableCell28,
				this.xrTableCell1
			});
			this.xrTableRow1.Dpi = 100f;
			this.xrTableRow1.Name = "xrTableRow1";
			this.xrTableRow1.Weight = 1.0;
			this.xrTableCell28.Borders = BorderSide.All;
			this.xrTableCell28.Dpi = 100f;
			this.xrTableCell28.Font = new Font("Arial", 9.75f, FontStyle.Bold);
			this.xrTableCell28.Name = "xrTableCell28";
			this.xrTableCell28.StylePriority.UseBorders = false;
			this.xrTableCell28.StylePriority.UseFont = false;
			this.xrTableCell28.Text = "To,";
			this.xrTableCell28.Weight = 0.6541925704159364;
			this.xrTableCell1.Borders = (BorderSide.Top | BorderSide.Right | BorderSide.Bottom);
			this.xrTableCell1.Dpi = 100f;
			this.xrTableCell1.Name = "xrTableCell1";
			this.xrTableCell1.StylePriority.UseBorders = false;
			this.xrTableCell1.Weight = 1.3458074295840634;
			this.xrTableRow2.Cells.AddRange(new XRTableCell[]
			{
				this.xrTableCell29,
				this.xrTableCell2
			});
			this.xrTableRow2.Dpi = 100f;
			this.xrTableRow2.Name = "xrTableRow2";
			this.xrTableRow2.Weight = 1.0;
			this.xrTableCell29.Borders = BorderSide.All;
			this.xrTableCell29.Dpi = 100f;
			this.xrTableCell29.Font = new Font("Arial", 9.75f, FontStyle.Bold);
			this.xrTableCell29.Name = "xrTableCell29";
			this.xrTableCell29.StylePriority.UseBorders = false;
			this.xrTableCell29.StylePriority.UseFont = false;
			this.xrTableCell29.Text = "Customer Name:";
			this.xrTableCell29.Weight = 0.6541925704159364;
			this.xrTableCell2.Borders = (BorderSide.Top | BorderSide.Right | BorderSide.Bottom);
			this.xrTableCell2.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "QuotationMaster.CustomerName")
			});
			this.xrTableCell2.Dpi = 100f;
			this.xrTableCell2.Font = new Font("Arial", 9.75f);
			this.xrTableCell2.Name = "xrTableCell2";
			this.xrTableCell2.StylePriority.UseBorders = false;
			this.xrTableCell2.StylePriority.UseFont = false;
			this.xrTableCell2.Weight = 1.3458074295840634;
			this.xrTableRow3.Cells.AddRange(new XRTableCell[]
			{
				this.xrTableCell30,
				this.xrTableCell3
			});
			this.xrTableRow3.Dpi = 100f;
			this.xrTableRow3.Name = "xrTableRow3";
			this.xrTableRow3.Weight = 1.0;
			this.xrTableCell30.Borders = BorderSide.All;
			this.xrTableCell30.Dpi = 100f;
			this.xrTableCell30.Font = new Font("Arial", 9.75f, FontStyle.Bold);
			this.xrTableCell30.Name = "xrTableCell30";
			this.xrTableCell30.StylePriority.UseBorders = false;
			this.xrTableCell30.StylePriority.UseFont = false;
			this.xrTableCell30.Text = "P.O.Box:";
			this.xrTableCell30.Weight = 0.6541925704159364;
			this.xrTableCell3.Borders = (BorderSide.Top | BorderSide.Right | BorderSide.Bottom);
			this.xrTableCell3.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "QuotationMaster.POBox")
			});
			this.xrTableCell3.Dpi = 100f;
			this.xrTableCell3.Name = "xrTableCell3";
			this.xrTableCell3.StylePriority.UseBorders = false;
			this.xrTableCell3.Weight = 1.3458074295840634;
			this.xrTableRow4.Cells.AddRange(new XRTableCell[]
			{
				this.xrTableCell31,
				this.xrTableCell4
			});
			this.xrTableRow4.Dpi = 100f;
			this.xrTableRow4.Name = "xrTableRow4";
			this.xrTableRow4.Weight = 1.0;
			this.xrTableCell31.Borders = BorderSide.All;
			this.xrTableCell31.Dpi = 100f;
			this.xrTableCell31.Font = new Font("Arial", 9.75f, FontStyle.Bold);
			this.xrTableCell31.Name = "xrTableCell31";
			this.xrTableCell31.StylePriority.UseBorders = false;
			this.xrTableCell31.StylePriority.UseFont = false;
			this.xrTableCell31.Text = "Address: ";
			this.xrTableCell31.Weight = 0.6541925704159364;
			this.xrTableCell4.Borders = (BorderSide.Top | BorderSide.Right | BorderSide.Bottom);
			this.xrTableCell4.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "QuotationMaster.Address")
			});
			this.xrTableCell4.Dpi = 100f;
			this.xrTableCell4.Name = "xrTableCell4";
			this.xrTableCell4.StylePriority.UseBorders = false;
			this.xrTableCell4.Weight = 1.3458074295840634;
			this.xrTableRow5.Cells.AddRange(new XRTableCell[]
			{
				this.xrTableCell32,
				this.xrTableCell5
			});
			this.xrTableRow5.Dpi = 100f;
			this.xrTableRow5.Name = "xrTableRow5";
			this.xrTableRow5.Weight = 1.0;
			this.xrTableCell32.Borders = BorderSide.All;
			this.xrTableCell32.Dpi = 100f;
			this.xrTableCell32.Font = new Font("Arial", 9.75f, FontStyle.Bold);
			this.xrTableCell32.Name = "xrTableCell32";
			this.xrTableCell32.StylePriority.UseBorders = false;
			this.xrTableCell32.StylePriority.UseFont = false;
			this.xrTableCell32.Text = "Telephone No: ";
			this.xrTableCell32.Weight = 0.6541925704159364;
			this.xrTableCell5.Borders = (BorderSide.Top | BorderSide.Right | BorderSide.Bottom);
			this.xrTableCell5.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "QuotationMaster.PhoneNumber")
			});
			this.xrTableCell5.Dpi = 100f;
			this.xrTableCell5.Font = new Font("Arial", 9.75f);
			this.xrTableCell5.Name = "xrTableCell5";
			this.xrTableCell5.StylePriority.UseBorders = false;
			this.xrTableCell5.StylePriority.UseFont = false;
			this.xrTableCell5.Weight = 1.3458074295840634;
			this.xrTableRow6.Cells.AddRange(new XRTableCell[]
			{
				this.xrTableCell33,
				this.xrTableCell6
			});
			this.xrTableRow6.Dpi = 100f;
			this.xrTableRow6.Name = "xrTableRow6";
			this.xrTableRow6.Weight = 1.0;
			this.xrTableCell33.Borders = BorderSide.All;
			this.xrTableCell33.Dpi = 100f;
			this.xrTableCell33.Font = new Font("Arial", 9.75f, FontStyle.Bold);
			this.xrTableCell33.Name = "xrTableCell33";
			this.xrTableCell33.StylePriority.UseBorders = false;
			this.xrTableCell33.StylePriority.UseFont = false;
			this.xrTableCell33.Text = "Fax No: ";
			this.xrTableCell33.Weight = 0.6541925704159364;
			this.xrTableCell6.Borders = (BorderSide.Top | BorderSide.Right | BorderSide.Bottom);
			this.xrTableCell6.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "QuotationMaster.FaxNumber")
			});
			this.xrTableCell6.Dpi = 100f;
			this.xrTableCell6.Font = new Font("Arial", 9.75f);
			this.xrTableCell6.Name = "xrTableCell6";
			this.xrTableCell6.StylePriority.UseBorders = false;
			this.xrTableCell6.StylePriority.UseFont = false;
			this.xrTableCell6.Weight = 1.3458074295840634;
			this.xrTableRow7.Cells.AddRange(new XRTableCell[]
			{
				this.xrTableCell34,
				this.xrTableCell7
			});
			this.xrTableRow7.Dpi = 100f;
			this.xrTableRow7.Name = "xrTableRow7";
			this.xrTableRow7.Weight = 1.0;
			this.xrTableCell34.Borders = BorderSide.All;
			this.xrTableCell34.Dpi = 100f;
			this.xrTableCell34.Font = new Font("Arial", 9.75f, FontStyle.Bold);
			this.xrTableCell34.Name = "xrTableCell34";
			this.xrTableCell34.StylePriority.UseBorders = false;
			this.xrTableCell34.StylePriority.UseFont = false;
			this.xrTableCell34.Text = "Email: ";
			this.xrTableCell34.Weight = 0.6541925704159364;
			this.xrTableCell7.Borders = (BorderSide.Top | BorderSide.Right | BorderSide.Bottom);
			this.xrTableCell7.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "QuotationMaster.Email")
			});
			this.xrTableCell7.Dpi = 100f;
			this.xrTableCell7.Font = new Font("Arial", 9.75f);
			this.xrTableCell7.Name = "xrTableCell7";
			this.xrTableCell7.StylePriority.UseBorders = false;
			this.xrTableCell7.StylePriority.UseFont = false;
			this.xrTableCell7.Weight = 1.3458074295840634;
			this.xrTable2.Borders = BorderSide.All;
			this.xrTable2.Dpi = 100f;
			this.xrTable2.Font = new Font("Arial", 9.75f);
			this.xrTable2.LocationFloat = new PointFloat(567.3432f, 10.00001f);
			this.xrTable2.Name = "xrTable2";
			this.xrTable2.Padding = new PaddingInfo(3, 0, 0, 0, 100f);
			this.xrTable2.Rows.AddRange(new XRTableRow[]
			{
				this.xrTableRow8,
				this.xrTableRow9
			});
			this.xrTable2.SizeF = new SizeF(259.0685f, 42f);
			this.xrTable2.StylePriority.UseBorders = false;
			this.xrTable2.StylePriority.UseFont = false;
			this.xrTable2.StylePriority.UsePadding = false;
			this.xrTableRow8.Cells.AddRange(new XRTableCell[]
			{
				this.xrTableCell8,
				this.xrTableCell17
			});
			this.xrTableRow8.Dpi = 100f;
			this.xrTableRow8.Name = "xrTableRow8";
			this.xrTableRow8.Weight = 1.0;
			this.xrTableCell8.Borders = (BorderSide.Left | BorderSide.Top | BorderSide.Bottom);
			this.xrTableCell8.Dpi = 100f;
			this.xrTableCell8.Font = new Font("Arial", 9.75f, FontStyle.Bold);
			this.xrTableCell8.Name = "xrTableCell8";
			this.xrTableCell8.StylePriority.UseBorders = false;
			this.xrTableCell8.StylePriority.UseFont = false;
			this.xrTableCell8.StylePriority.UseTextAlignment = false;
			this.xrTableCell8.Text = "Date :";
			this.xrTableCell8.TextAlignment = TextAlignment.TopLeft;
			this.xrTableCell8.Weight = 2.005370755142419;
			this.xrTableCell17.Borders = (BorderSide.Top | BorderSide.Right | BorderSide.Bottom);
			this.xrTableCell17.Controls.AddRange(new XRControl[]
			{
				this.xrLabel28
			});
			this.xrTableCell17.Dpi = 100f;
			this.xrTableCell17.Name = "xrTableCell17";
			this.xrTableCell17.StylePriority.UseBorders = false;
			this.xrTableCell17.Text = "xrTableCell17";
			this.xrTableCell17.Weight = 5.664616348695239;
			this.xrLabel28.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "QuotationMaster.EntryDate", "{0:dd MMMM yyyy}")
			});
			this.xrLabel28.Dpi = 100f;
			this.xrLabel28.Font = new Font("Arial", 10f);
			this.xrLabel28.LocationFloat = new PointFloat(9.999974f, 1.791668f);
			this.xrLabel28.Name = "xrLabel28";
			this.xrLabel28.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel28.SizeF = new SizeF(138.9853f, 18f);
			this.xrLabel28.StyleName = "DataField";
			this.xrLabel28.StylePriority.UseFont = false;
			this.xrLabel28.Text = "xrLabel37";
			this.xrTableRow9.Cells.AddRange(new XRTableCell[]
			{
				this.xrTableCell9,
				this.xrTableCell25
			});
			this.xrTableRow9.Dpi = 100f;
			this.xrTableRow9.Name = "xrTableRow9";
			this.xrTableRow9.Weight = 1.0;
			this.xrTableCell9.Borders = (BorderSide.Left | BorderSide.Top | BorderSide.Bottom);
			this.xrTableCell9.Dpi = 100f;
			this.xrTableCell9.Font = new Font("Arial", 9.75f, FontStyle.Bold);
			this.xrTableCell9.Name = "xrTableCell9";
			this.xrTableCell9.StylePriority.UseBorders = false;
			this.xrTableCell9.StylePriority.UseFont = false;
			this.xrTableCell9.StylePriority.UseTextAlignment = false;
			this.xrTableCell9.Text = "Ref: QTN_";
			this.xrTableCell9.TextAlignment = TextAlignment.TopRight;
			this.xrTableCell9.Weight = 2.102027527520697;
			this.xrTableCell25.Borders = (BorderSide.Top | BorderSide.Right | BorderSide.Bottom);
			this.xrTableCell25.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "QuotationMaster.QuotationNo")
			});
			this.xrTableCell25.Dpi = 100f;
			this.xrTableCell25.Font = new Font("Arial", 9.75f);
			this.xrTableCell25.Name = "xrTableCell25";
			this.xrTableCell25.StylePriority.UseBorders = false;
			this.xrTableCell25.StylePriority.UseFont = false;
			this.xrTableCell25.Weight = 5.56795957631696;
			this.xrLabel1.Dpi = 100f;
			this.xrLabel1.Font = new Font("Arial", 10f);
			this.xrLabel1.ForeColor = Color.FromArgb(0, 0, 0);
			this.xrLabel1.LocationFloat = new PointFloat(22.83334f, 164.0834f);
			this.xrLabel1.Multiline = true;
			this.xrLabel1.Name = "xrLabel1";
			this.xrLabel1.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel1.SizeF = new SizeF(104.7601f, 17.99998f);
			this.xrLabel1.StyleName = "FieldCaption";
			this.xrLabel1.StylePriority.UseFont = false;
			this.xrLabel1.StylePriority.UseForeColor = false;
			this.xrLabel1.Text = "Kind Attention:";
			this.xrLabel2.Dpi = 100f;
			this.xrLabel2.Font = new Font("Arial", 10f);
			this.xrLabel2.ForeColor = Color.FromArgb(0, 0, 0);
			this.xrLabel2.LocationFloat = new PointFloat(21.20844f, 194.3333f);
			this.xrLabel2.Name = "xrLabel2";
			this.xrLabel2.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel2.SizeF = new SizeF(148.9951f, 18f);
			this.xrLabel2.StyleName = "FieldCaption";
			this.xrLabel2.StylePriority.UseFont = false;
			this.xrLabel2.StylePriority.UseForeColor = false;
			this.xrLabel2.Text = "Dear Sir/Madam,";
			this.xrLabel3.Dpi = 100f;
			this.xrLabel3.Font = new Font("Arial", 11f);
			this.xrLabel3.ForeColor = Color.FromArgb(0, 0, 0);
			this.xrLabel3.LocationFloat = new PointFloat(24.79482f, 226.0417f);
			this.xrLabel3.Name = "xrLabel3";
			this.xrLabel3.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel3.SizeF = new SizeF(794.1586f, 32.58328f);
			this.xrLabel3.StyleName = "FieldCaption";
			this.xrLabel3.StylePriority.UseFont = false;
			this.xrLabel3.StylePriority.UseForeColor = false;
			this.xrLabel3.Text = "Thank you for providing us the opportunity to quote our competitive prices for your requirement of laboratory services.";
			this.xrLabel35.Borders = BorderSide.None;
			this.xrLabel35.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "QuotationMaster.QuotationMasterEnquiryMaster.ContactPerson")
			});
			this.xrLabel35.Dpi = 100f;
			this.xrLabel35.Font = new Font("Arial", 10f, FontStyle.Bold);
			this.xrLabel35.ForeColor = Color.FromArgb(0, 0, 0);
			this.xrLabel35.LocationFloat = new PointFloat(143.9734f, 164.0834f);
			this.xrLabel35.Name = "xrLabel35";
			this.xrLabel35.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel35.SizeF = new SizeF(386.1617f, 18f);
			this.xrLabel35.StyleName = "DataField";
			this.xrLabel35.StylePriority.UseBorders = false;
			this.xrLabel35.StylePriority.UseFont = false;
			this.xrLabel35.StylePriority.UseForeColor = false;
			this.TopMargin.Dpi = 100f;
			this.TopMargin.HeightF = 0f;
			this.TopMargin.Name = "TopMargin";
			this.TopMargin.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
			this.TopMargin.TextAlignment = TextAlignment.TopLeft;
			this.BottomMargin.Controls.AddRange(new XRControl[]
			{
				this.xrPageInfo4
			});
			this.BottomMargin.Dpi = 100f;
			this.BottomMargin.HeightF = 24f;
			this.BottomMargin.Name = "BottomMargin";
			this.BottomMargin.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
			this.BottomMargin.TextAlignment = TextAlignment.TopLeft;
			this.xrPageInfo4.Dpi = 100f;
			this.xrPageInfo4.Format = "Page {0} of {1}";
			this.xrPageInfo4.LocationFloat = new PointFloat(513.0784f, 0.9583156f);
			this.xrPageInfo4.Name = "xrPageInfo4";
			this.xrPageInfo4.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrPageInfo4.SizeF = new SizeF(313f, 23f);
			this.xrPageInfo4.StyleName = "PageInfo";
			this.xrPageInfo4.TextAlignment = TextAlignment.TopRight;
			this.reportHeaderBand1.Dpi = 100f;
			this.reportHeaderBand1.HeightF = 3.125f;
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
			this.DetailReport.DataMember = "QuotationMaster.QuotationMasterQuotationDetails";
			this.DetailReport.DataSource = this.sqlDataSource1;
			this.DetailReport.Dpi = 100f;
			this.DetailReport.Level = 0;
			this.DetailReport.Name = "DetailReport";
			this.Detail1.Controls.AddRange(new XRControl[]
			{
				this.xrTable4
			});
			this.Detail1.Dpi = 100f;
			this.Detail1.HeightF = 25f;
			this.Detail1.Name = "Detail1";
			this.xrTable4.Borders = (BorderSide.Left | BorderSide.Right | BorderSide.Bottom);
			this.xrTable4.Dpi = 100f;
			this.xrTable4.Font = new Font("Arial", 9.75f);
			this.xrTable4.LocationFloat = new PointFloat(22.58333f, 0f);
			this.xrTable4.Name = "xrTable4";
			this.xrTable4.Padding = new PaddingInfo(0, 0, 2, 0, 100f);
			this.xrTable4.Rows.AddRange(new XRTableRow[]
			{
				this.xrTableRow11
			});
			this.xrTable4.SizeF = new SizeF(796.2034f, 25f);
			this.xrTable4.StylePriority.UseBorders = false;
			this.xrTable4.StylePriority.UseFont = false;
			this.xrTable4.StylePriority.UsePadding = false;
			this.xrTable4.StylePriority.UseTextAlignment = false;
			this.xrTable4.TextAlignment = TextAlignment.TopCenter;
			this.xrTableRow11.Cells.AddRange(new XRTableCell[]
			{
				this.xrTableCell38,
				this.xrTableCell18,
				this.xrTableCell19,
				this.xrTableCell20,
				this.xrTableCell21,
				this.xrTableCell22,
				this.xrTableCell23,
				this.xrTableCell24,
				this.xrTableCell27
			});
			this.xrTableRow11.Dpi = 100f;
			this.xrTableRow11.Name = "xrTableRow11";
			this.xrTableRow11.Weight = 11.5;
			this.xrTableCell38.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "QuotationMaster.QuotationMasterQuotationDetails.No")
			});
			this.xrTableCell38.Dpi = 100f;
			this.xrTableCell38.Name = "xrTableCell38";
			this.xrTableCell38.Weight = 0.038765718551350296;
			this.xrTableCell18.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "QuotationMaster.QuotationMasterQuotationDetails.MaterialName")
			});
			this.xrTableCell18.Dpi = 100f;
			this.xrTableCell18.Name = "xrTableCell18";
			this.xrTableCell18.Weight = 0.12248637874113746;
			this.xrTableCell19.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "QuotationMaster.QuotationMasterQuotationDetails.MaterialName_MaterialName")
			});
			this.xrTableCell19.Dpi = 100f;
			this.xrTableCell19.Name = "xrTableCell19";
			this.xrTableCell19.Weight = 0.15217600587969818;
			this.xrTableCell20.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "QuotationMaster.QuotationMasterQuotationDetails.TestName")
			});
			this.xrTableCell20.Dpi = 100f;
			this.xrTableCell20.Name = "xrTableCell20";
			this.xrTableCell20.Weight = 0.3797707154940347;
			this.xrTableCell21.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "QuotationMaster.QuotationMasterQuotationDetails.StandardNumber")
			});
			this.xrTableCell21.Dpi = 100f;
			this.xrTableCell21.Name = "xrTableCell21";
			this.xrTableCell21.Weight = 0.1089152043104616;
			this.xrTableCell22.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "QuotationMaster.QuotationMasterQuotationDetails.UnitName")
			});
			this.xrTableCell22.Dpi = 100f;
			this.xrTableCell22.Name = "xrTableCell22";
			this.xrTableCell22.Weight = 0.06802917265149869;
			this.xrTableCell23.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "QuotationMaster.QuotationMasterQuotationDetails.Price", "{0:#.00}")
			});
			this.xrTableCell23.Dpi = 100f;
			this.xrTableCell23.Name = "xrTableCell23";
			this.xrTableCell23.Weight = 0.09798737410363567;
			this.xrTableCell24.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "QuotationMaster.QuotationMasterQuotationDetails.MinQty", "{0:#}")
			});
			this.xrTableCell24.Dpi = 100f;
			this.xrTableCell24.Name = "xrTableCell24";
			this.xrTableCell24.Weight = 0.0460661124181471;
			this.xrTableCell27.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "QuotationMaster.QuotationMasterQuotationDetails.calculatedField1", "{0:#.00}")
			});
			this.xrTableCell27.Dpi = 100f;
			this.xrTableCell27.Name = "xrTableCell27";
			this.xrTableCell27.Weight = 0.11123989390433016;
			this.GroupHeader1.Controls.AddRange(new XRControl[]
			{
				this.xrTable3
			});
			this.GroupHeader1.Dpi = 100f;
			this.GroupHeader1.HeightF = 39.58333f;
			this.GroupHeader1.Name = "GroupHeader1";
			this.GroupHeader1.RepeatEveryPage = true;
			this.xrTable3.Borders = BorderSide.All;
			this.xrTable3.Dpi = 100f;
			this.xrTable3.Font = new Font("Arial", 9f, FontStyle.Bold);
			this.xrTable3.LocationFloat = new PointFloat(22.58333f, 0f);
			this.xrTable3.Name = "xrTable3";
			this.xrTable3.Padding = new PaddingInfo(0, 0, 2, 0, 100f);
			this.xrTable3.Rows.AddRange(new XRTableRow[]
			{
				this.xrTableRow10
			});
			this.xrTable3.SizeF = new SizeF(796.1201f, 39.58333f);
			this.xrTable3.StylePriority.UseBorders = false;
			this.xrTable3.StylePriority.UseFont = false;
			this.xrTable3.StylePriority.UsePadding = false;
			this.xrTable3.StylePriority.UseTextAlignment = false;
			this.xrTable3.TextAlignment = TextAlignment.TopCenter;
			this.xrTableRow10.Cells.AddRange(new XRTableCell[]
			{
				this.xrTableCell40,
				this.xrTableCell10,
				this.xrTableCell11,
				this.xrTableCell12,
				this.xrTableCell13,
				this.xrTableCell14,
				this.xrTableCell15,
				this.xrTableCell16,
				this.xrTableCell26
			});
			this.xrTableRow10.Dpi = 100f;
			this.xrTableRow10.Name = "xrTableRow10";
			this.xrTableRow10.Weight = 11.5;
			this.xrTableCell40.Dpi = 100f;
			this.xrTableCell40.Name = "xrTableCell40";
			this.xrTableCell40.Text = "#";
			this.xrTableCell40.Weight = 0.03516230243368429;
			this.xrTableCell10.Dpi = 100f;
			this.xrTableCell10.Name = "xrTableCell10";
			this.xrTableCell10.Text = "Service Section";
			this.xrTableCell10.Weight = 0.11852859272607999;
			this.xrTableCell11.Dpi = 100f;
			this.xrTableCell11.Name = "xrTableCell11";
			this.xrTableCell11.Text = "Material Details";
			this.xrTableCell11.Weight = 0.1450403761286224;
			this.xrTableCell12.Dpi = 100f;
			this.xrTableCell12.Name = "xrTableCell12";
			this.xrTableCell12.Text = "Services Name";
			this.xrTableCell12.Weight = 0.3620322913862431;
			this.xrTableCell13.Dpi = 100f;
			this.xrTableCell13.Name = "xrTableCell13";
			this.xrTableCell13.Text = "Standard Number";
			this.xrTableCell13.Weight = 0.10393115439086731;
			this.xrTableCell14.Dpi = 100f;
			this.xrTableCell14.Name = "xrTableCell14";
			this.xrTableCell14.Text = "Unit ";
			this.xrTableCell14.Weight = 0.06484610116802719;
			this.xrTableCell15.Dpi = 100f;
			this.xrTableCell15.Name = "xrTableCell15";
			this.xrTableCell15.Text = "Rate";
			this.xrTableCell15.Weight = 0.09330172097886055;
			this.xrTableCell16.Dpi = 100f;
			this.xrTableCell16.Name = "xrTableCell16";
			this.xrTableCell16.Text = "Min Qty";
			this.xrTableCell16.Weight = 0.0439060401014066;
			this.xrTableCell26.Dpi = 100f;
			this.xrTableCell26.Multiline = true;
			this.xrTableCell26.Name = "xrTableCell26";
			this.xrTableCell26.Text = "Total Amount\r\nQAR";
			this.xrTableCell26.Weight = 0.1059156115923504;
			this.DetailReport1.Bands.AddRange(new Band[]
			{
				this.Detail2,
				this.ReportFooter,
				this.DetailReport2
			});
			this.DetailReport1.DataMember = "QuotationMaster";
			this.DetailReport1.DataSource = this.sqlDataSource1;
			this.DetailReport1.Dpi = 100f;
			this.DetailReport1.FilterString = "[QuotationMasterID] = ?QID";
			this.DetailReport1.Level = 1;
			this.DetailReport1.Name = "DetailReport1";
			this.Detail2.Controls.AddRange(new XRControl[]
			{
				this.xrLabel4,
				this.xrTable7
			});
			this.Detail2.Dpi = 100f;
			this.Detail2.HeightF = 91.79169f;
			this.Detail2.Name = "Detail2";
			this.xrLabel4.Dpi = 100f;
			this.xrLabel4.Font = new Font("Arial", 11f, FontStyle.Bold | FontStyle.Underline);
			this.xrLabel4.ForeColor = Color.FromArgb(0, 0, 0);
			this.xrLabel4.LocationFloat = new PointFloat(22.58333f, 9.999974f);
			this.xrLabel4.Name = "xrLabel4";
			this.xrLabel4.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel4.SizeF = new SizeF(149.5f, 18f);
			this.xrLabel4.StyleName = "FieldCaption";
			this.xrLabel4.StylePriority.UseFont = false;
			this.xrLabel4.StylePriority.UseForeColor = false;
			this.xrLabel4.Text = "Remarks:";
			this.xrTable7.Borders = BorderSide.All;
			this.xrTable7.Dpi = 100f;
			this.xrTable7.Font = new Font("Arial", 9.75f);
			this.xrTable7.LocationFloat = new PointFloat(22.58333f, 39.16664f);
			this.xrTable7.Name = "xrTable7";
			this.xrTable7.Padding = new PaddingInfo(5, 0, 0, 0, 100f);
			this.xrTable7.Rows.AddRange(new XRTableRow[]
			{
				this.xrTableRow16
			});
			this.xrTable7.SizeF = new SizeF(809.5833f, 48.41342f);
			this.xrTable7.StylePriority.UseBorders = false;
			this.xrTable7.StylePriority.UseFont = false;
			this.xrTable7.StylePriority.UsePadding = false;
			this.xrTableRow16.Cells.AddRange(new XRTableCell[]
			{
				this.xrTableCell49
			});
			this.xrTableRow16.Dpi = 100f;
			this.xrTableRow16.Name = "xrTableRow16";
			this.xrTableRow16.Weight = 1.0;
			this.xrTableCell49.Borders = BorderSide.None;
			this.xrTableCell49.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "QuotationMaster.Remarks")
			});
			this.xrTableCell49.Dpi = 100f;
			this.xrTableCell49.Font = new Font("Arial", 9f);
			this.xrTableCell49.Multiline = true;
			this.xrTableCell49.Name = "xrTableCell49";
			this.xrTableCell49.StylePriority.UseBorders = false;
			this.xrTableCell49.StylePriority.UseFont = false;
			this.xrTableCell49.Weight = 3.7268977454972294;
			this.ReportFooter.Dpi = 100f;
			this.ReportFooter.HeightF = 2.083333f;
			this.ReportFooter.Name = "ReportFooter";
			this.ReportFooter.Visible = false;
			this.DetailReport2.Bands.AddRange(new Band[]
			{
				this.Detail3
			});
			this.DetailReport2.DataMember = "QuotationMaster";
			this.DetailReport2.DataSource = this.sqlDataSource1;
			this.DetailReport2.Dpi = 100f;
			this.DetailReport2.FilterString = "[QuotationMasterID] = ?QID";
			this.DetailReport2.Level = 0;
			this.DetailReport2.Name = "DetailReport2";
			this.DetailReport2.Padding = new PaddingInfo(0, 0, 50, 0, 100f);
			this.Detail3.Controls.AddRange(new XRControl[]
			{
				this.xrTable5,
				this.xrLabel21,
				this.xrTable9,
				this.xrLabel22,
				this.xrLabel26
			});
			this.Detail3.Dpi = 100f;
			this.Detail3.HeightF = 204.4168f;
			this.Detail3.KeepTogether = true;
			this.Detail3.Name = "Detail3";
			this.calculatedField1.DataMember = "QuotationMaster.QuotationMasterQuotationDetails";
			this.calculatedField1.Expression = "[Price] * [MinQty]";
			this.calculatedField1.Name = "calculatedField1";
			this.ExpiresDay.DataMember = "QuotationMaster";
			this.ExpiresDay.Expression = "DateDiffDay( [EntryDate],[ExpiryDate])";
			this.ExpiresDay.Name = "ExpiresDay";
			this.QID.Description = "Parameter1";
			dynamicListLookUpSettings.DataAdapter = null;
			dynamicListLookUpSettings.DataMember = "QuotationMaster";
			dynamicListLookUpSettings.DataSource = this.sqlDataSource1;
			dynamicListLookUpSettings.DisplayMember = "QuotationNo";
			dynamicListLookUpSettings.FilterString = null;
			dynamicListLookUpSettings.ValueMember = "QuotationMasterID";
			this.QID.LookUpSettings = dynamicListLookUpSettings;
			this.QID.Name = "QID";
			this.QID.Type = typeof(int);
			this.QID.ValueInfo = "0";
			this.calculatedField2.DataMember = "QuotationMaster.QuotationMasterQuotationDetails";
			this.calculatedField2.Name = "calculatedField2";
			this.PageHeader.Controls.AddRange(new XRControl[]
			{
				this.xrLabel5
			});
			this.PageHeader.Dpi = 100f;
			this.PageHeader.HeightF = 75f;
			this.PageHeader.Name = "PageHeader";
			this.xrLabel5.BorderWidth = 0f;
			this.xrLabel5.Dpi = 100f;
			this.xrLabel5.LocationFloat = new PointFloat(312.0418f, 10.00001f);
			this.xrLabel5.Name = "xrLabel5";
			this.xrLabel5.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel5.SizeF = new SizeF(100f, 59.16665f);
			this.xrLabel5.StylePriority.UseBorderWidth = false;
			this.DetailReport3.Bands.AddRange(new Band[]
			{
				this.Detail4
			});
			this.DetailReport3.Dpi = 100f;
			this.DetailReport3.Expanded = false;
			this.DetailReport3.Level = 2;
			this.DetailReport3.Name = "DetailReport3";
			this.Detail4.Dpi = 100f;
			this.Detail4.HeightF = 100f;
			this.Detail4.Name = "Detail4";
			this.xrTableCell39.Borders = BorderSide.None;
			this.xrTableCell39.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "QuotationMaster.ExpiryDate", "{0:dd MMM yyyy}")
			});
			this.xrTableCell39.Dpi = 100f;
			this.xrTableCell39.Name = "xrTableCell39";
			this.xrTableCell39.StylePriority.UseBorders = false;
			this.xrTableCell39.StylePriority.UseTextAlignment = false;
			this.xrTableCell39.TextAlignment = TextAlignment.TopLeft;
			this.xrTableCell39.Weight = 1.4357116733488833;
			this.xrTableCell37.Borders = BorderSide.None;
			this.xrTableCell37.Dpi = 100f;
			this.xrTableCell37.Name = "xrTableCell37";
			this.xrTableCell37.StylePriority.UseBorders = false;
			this.xrTableCell37.Text = " days from the date of receipt.       Expiry date : ";
			this.xrTableCell37.Weight = 1.3915720432015446;
			this.xrTableCell36.Borders = BorderSide.None;
			this.xrTableCell36.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "QuotationMaster.ExpiresDay")
			});
			this.xrTableCell36.Dpi = 100f;
			this.xrTableCell36.Name = "xrTableCell36";
			this.xrTableCell36.StylePriority.UseBorders = false;
			this.xrTableCell36.StylePriority.UseTextAlignment = false;
			this.xrTableCell36.TextAlignment = TextAlignment.TopCenter;
			this.xrTableCell36.Weight = 0.13779193594409234;
			this.xrTableCell35.Borders = BorderSide.None;
			this.xrTableCell35.Dpi = 100f;
			this.xrTableCell35.Name = "xrTableCell35";
			this.xrTableCell35.Padding = new PaddingInfo(5, 0, 0, 0, 100f);
			this.xrTableCell35.StylePriority.UseBorders = false;
			this.xrTableCell35.StylePriority.UsePadding = false;
			this.xrTableCell35.Text = "This Quotation is valid for  ";
			this.xrTableCell35.Weight = 0.7625790902297767;
			this.xrTableRow12.Cells.AddRange(new XRTableCell[]
			{
				this.xrTableCell35,
				this.xrTableCell36,
				this.xrTableCell37,
				this.xrTableCell39
			});
			this.xrTableRow12.Dpi = 100f;
			this.xrTableRow12.Name = "xrTableRow12";
			this.xrTableRow12.Weight = 1.0;
			this.xrTable5.Borders = BorderSide.None;
			this.xrTable5.Dpi = 100f;
			this.xrTable5.Font = new Font("Arial", 9f);
			this.xrTable5.LocationFloat = new PointFloat(24.87815f, 42.1416f);
			this.xrTable5.Name = "xrTable5";
			this.xrTable5.Padding = new PaddingInfo(3, 0, 0, 0, 100f);
			this.xrTable5.Rows.AddRange(new XRTableRow[]
			{
				this.xrTableRow12
			});
			this.xrTable5.SizeF = new SizeF(771.2569f, 15.00001f);
			this.xrTable5.StylePriority.UseBorders = false;
			this.xrTable5.StylePriority.UseFont = false;
			this.xrTable5.StylePriority.UsePadding = false;
			this.xrLabel21.Dpi = 100f;
			this.xrLabel21.Font = new Font("Arial", 11f, FontStyle.Bold | FontStyle.Underline);
			this.xrLabel21.ForeColor = Color.FromArgb(0, 0, 0);
			this.xrLabel21.LocationFloat = new PointFloat(22.83334f, 12.5f);
			this.xrLabel21.Name = "xrLabel21";
			this.xrLabel21.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel21.SizeF = new SizeF(162f, 18f);
			this.xrLabel21.StyleName = "FieldCaption";
			this.xrLabel21.StylePriority.UseFont = false;
			this.xrLabel21.StylePriority.UseForeColor = false;
			this.xrLabel21.Text = "Terms & Conditions:";
			this.xrTableCell43.Borders = BorderSide.None;
			this.xrTableCell43.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "QuotationMaster.Description")
			});
			this.xrTableCell43.Dpi = 100f;
			this.xrTableCell43.Font = new Font("Arial", 9f);
			this.xrTableCell43.Multiline = true;
			this.xrTableCell43.Name = "xrTableCell43";
			this.xrTableCell43.Padding = new PaddingInfo(5, 0, 0, 0, 100f);
			this.xrTableCell43.StylePriority.UseBorders = false;
			this.xrTableCell43.StylePriority.UseFont = false;
			this.xrTableCell43.StylePriority.UsePadding = false;
			this.xrTableCell43.Weight = 2.2361390995939496;
			this.xrTableRow15.Cells.AddRange(new XRTableCell[]
			{
				this.xrTableCell43
			});
			this.xrTableRow15.Dpi = 100f;
			this.xrTableRow15.Name = "xrTableRow15";
			this.xrTableRow15.Weight = 1.0;
			this.xrTable9.Dpi = 100f;
			this.xrTable9.Font = new Font("Times New Roman", 9f);
			this.xrTable9.LocationFloat = new PointFloat(24.79482f, 57.14162f);
			this.xrTable9.Name = "xrTable9";
			this.xrTable9.Padding = new PaddingInfo(3, 0, 0, 0, 100f);
			this.xrTable9.Rows.AddRange(new XRTableRow[]
			{
				this.xrTableRow15
			});
			this.xrTable9.SizeF = new SizeF(771.3402f, 38.54167f);
			this.xrTable9.StylePriority.UseFont = false;
			this.xrTable9.StylePriority.UsePadding = false;
			this.xrLabel22.Dpi = 100f;
			this.xrLabel22.Font = new Font("Arial", 10f, FontStyle.Bold | FontStyle.Underline);
			this.xrLabel22.ForeColor = Color.FromArgb(0, 0, 0);
			this.xrLabel22.LocationFloat = new PointFloat(24.79482f, 112.9968f);
			this.xrLabel22.Name = "xrLabel22";
			this.xrLabel22.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel22.SizeF = new SizeF(162f, 18f);
			this.xrLabel22.StyleName = "FieldCaption";
			this.xrLabel22.StylePriority.UseFont = false;
			this.xrLabel22.StylePriority.UseForeColor = false;
			this.xrLabel22.Text = "Thanks & Regards";
			this.xrLabel26.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "QuotationMaster.ApprovedBy")
			});
			this.xrLabel26.Dpi = 100f;
			this.xrLabel26.Font = new Font("Arial", 10f, FontStyle.Bold);
			this.xrLabel26.ForeColor = Color.FromArgb(0, 0, 0);
			this.xrLabel26.LocationFloat = new PointFloat(24.79482f, 175.8301f);
			this.xrLabel26.Name = "xrLabel26";
			this.xrLabel26.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel26.SizeF = new SizeF(162f, 18f);
			this.xrLabel26.StyleName = "FieldCaption";
			this.xrLabel26.StylePriority.UseFont = false;
			this.xrLabel26.StylePriority.UseForeColor = false;
			base.Bands.AddRange(new Band[]
			{
				this.Detail,
				this.TopMargin,
				this.BottomMargin,
				this.reportHeaderBand1,
				this.DetailReport,
				this.DetailReport1,
				this.PageHeader,
				this.DetailReport3
			});
			base.CalculatedFields.AddRange(new CalculatedField[]
			{
				this.calculatedField1,
				this.ExpiresDay,
				this.calculatedField2
			});
			base.ComponentStorage.AddRange(new IComponent[]
			{
				this.sqlDataSource1
			});
			base.DataMember = "QuotationMaster";
			base.DataSource = this.sqlDataSource1;
			this.FilterString = "[QuotationMasterID] = ?QID";
			base.Margins = new Margins(2, 9, 0, 24);
			base.Parameters.AddRange(new Parameter[]
			{
				this.QID
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
			((ISupportInitialize)this.xrTable2).EndInit();
			((ISupportInitialize)this.xrTable4).EndInit();
			((ISupportInitialize)this.xrTable3).EndInit();
			((ISupportInitialize)this.xrTable7).EndInit();
			((ISupportInitialize)this.xrTable5).EndInit();
			((ISupportInitialize)this.xrTable9).EndInit();
			((ISupportInitialize)this).EndInit();
		}

		// Token: 0x040008C1 RID: 2241
		private IContainer components;

		// Token: 0x040008C2 RID: 2242
		private DetailBand Detail;

		// Token: 0x040008C3 RID: 2243
		private TopMarginBand TopMargin;

		// Token: 0x040008C4 RID: 2244
		private BottomMarginBand BottomMargin;

		// Token: 0x040008C5 RID: 2245
		private XRLabel xrLabel1;

		// Token: 0x040008C6 RID: 2246
		private XRLabel xrLabel2;

		// Token: 0x040008C7 RID: 2247
		private XRLabel xrLabel3;

		// Token: 0x040008C8 RID: 2248
		private XRLabel xrLabel35;

		// Token: 0x040008C9 RID: 2249
		private SqlDataSource sqlDataSource1;

		// Token: 0x040008CA RID: 2250
		private ReportHeaderBand reportHeaderBand1;

		// Token: 0x040008CB RID: 2251
		private XRControlStyle Title;

		// Token: 0x040008CC RID: 2252
		private XRControlStyle FieldCaption;

		// Token: 0x040008CD RID: 2253
		private XRControlStyle PageInfo;

		// Token: 0x040008CE RID: 2254
		private XRControlStyle DataField;

		// Token: 0x040008CF RID: 2255
		private XRTable xrTable1;

		// Token: 0x040008D0 RID: 2256
		private XRTableRow xrTableRow1;

		// Token: 0x040008D1 RID: 2257
		private XRTableCell xrTableCell1;

		// Token: 0x040008D2 RID: 2258
		private XRTableRow xrTableRow2;

		// Token: 0x040008D3 RID: 2259
		private XRTableCell xrTableCell2;

		// Token: 0x040008D4 RID: 2260
		private XRTableRow xrTableRow3;

		// Token: 0x040008D5 RID: 2261
		private XRTableCell xrTableCell3;

		// Token: 0x040008D6 RID: 2262
		private XRTableRow xrTableRow4;

		// Token: 0x040008D7 RID: 2263
		private XRTableCell xrTableCell4;

		// Token: 0x040008D8 RID: 2264
		private XRTableRow xrTableRow5;

		// Token: 0x040008D9 RID: 2265
		private XRTableCell xrTableCell5;

		// Token: 0x040008DA RID: 2266
		private XRTableRow xrTableRow6;

		// Token: 0x040008DB RID: 2267
		private XRTableCell xrTableCell6;

		// Token: 0x040008DC RID: 2268
		private XRTableRow xrTableRow7;

		// Token: 0x040008DD RID: 2269
		private XRTableCell xrTableCell7;

		// Token: 0x040008DE RID: 2270
		private XRTable xrTable2;

		// Token: 0x040008DF RID: 2271
		private XRTableRow xrTableRow8;

		// Token: 0x040008E0 RID: 2272
		private XRTableCell xrTableCell8;

		// Token: 0x040008E1 RID: 2273
		private XRTableRow xrTableRow9;

		// Token: 0x040008E2 RID: 2274
		private XRTableCell xrTableCell9;

		// Token: 0x040008E3 RID: 2275
		private DetailReportBand DetailReport;

		// Token: 0x040008E4 RID: 2276
		private DetailBand Detail1;

		// Token: 0x040008E5 RID: 2277
		private GroupHeaderBand GroupHeader1;

		// Token: 0x040008E6 RID: 2278
		private XRTable xrTable3;

		// Token: 0x040008E7 RID: 2279
		private XRTableRow xrTableRow10;

		// Token: 0x040008E8 RID: 2280
		private XRTableCell xrTableCell10;

		// Token: 0x040008E9 RID: 2281
		private XRTableCell xrTableCell11;

		// Token: 0x040008EA RID: 2282
		private XRTableCell xrTableCell12;

		// Token: 0x040008EB RID: 2283
		private XRTableCell xrTableCell13;

		// Token: 0x040008EC RID: 2284
		private XRTableCell xrTableCell14;

		// Token: 0x040008ED RID: 2285
		private XRTableCell xrTableCell15;

		// Token: 0x040008EE RID: 2286
		private XRTableCell xrTableCell16;

		// Token: 0x040008EF RID: 2287
		private XRTable xrTable4;

		// Token: 0x040008F0 RID: 2288
		private XRTableRow xrTableRow11;

		// Token: 0x040008F1 RID: 2289
		private XRTableCell xrTableCell18;

		// Token: 0x040008F2 RID: 2290
		private XRTableCell xrTableCell19;

		// Token: 0x040008F3 RID: 2291
		private XRTableCell xrTableCell20;

		// Token: 0x040008F4 RID: 2292
		private XRTableCell xrTableCell21;

		// Token: 0x040008F5 RID: 2293
		private XRTableCell xrTableCell22;

		// Token: 0x040008F6 RID: 2294
		private XRTableCell xrTableCell23;

		// Token: 0x040008F7 RID: 2295
		private XRTableCell xrTableCell24;

		// Token: 0x040008F8 RID: 2296
		private DetailReportBand DetailReport1;

		// Token: 0x040008F9 RID: 2297
		private DetailBand Detail2;

		// Token: 0x040008FA RID: 2298
		private XRTableCell xrTableCell17;

		// Token: 0x040008FB RID: 2299
		private XRLabel xrLabel28;

		// Token: 0x040008FC RID: 2300
		private XRTableCell xrTableCell25;

		// Token: 0x040008FD RID: 2301
		private XRTableCell xrTableCell27;

		// Token: 0x040008FE RID: 2302
		private XRTableCell xrTableCell26;

		// Token: 0x040008FF RID: 2303
		private CalculatedField calculatedField1;

		// Token: 0x04000900 RID: 2304
		private XRTableCell xrTableCell28;

		// Token: 0x04000901 RID: 2305
		private XRTableCell xrTableCell29;

		// Token: 0x04000902 RID: 2306
		private XRTableCell xrTableCell30;

		// Token: 0x04000903 RID: 2307
		private XRTableCell xrTableCell31;

		// Token: 0x04000904 RID: 2308
		private XRTableCell xrTableCell32;

		// Token: 0x04000905 RID: 2309
		private XRTableCell xrTableCell33;

		// Token: 0x04000906 RID: 2310
		private XRTableCell xrTableCell34;

		// Token: 0x04000907 RID: 2311
		private CalculatedField ExpiresDay;

		// Token: 0x04000908 RID: 2312
		private ReportFooterBand ReportFooter;

		// Token: 0x04000909 RID: 2313
		private DetailReportBand DetailReport2;

		// Token: 0x0400090A RID: 2314
		private DetailBand Detail3;

		// Token: 0x0400090B RID: 2315
		private XRLabel xrLabel4;

		// Token: 0x0400090C RID: 2316
		private Parameter QID;

		// Token: 0x0400090D RID: 2317
		private XRTable xrTable7;

		// Token: 0x0400090E RID: 2318
		private XRTableRow xrTableRow16;

		// Token: 0x0400090F RID: 2319
		private XRTableCell xrTableCell49;

		// Token: 0x04000910 RID: 2320
		private XRTableCell xrTableCell38;

		// Token: 0x04000911 RID: 2321
		private XRTableCell xrTableCell40;

		// Token: 0x04000912 RID: 2322
		private CalculatedField calculatedField2;

		// Token: 0x04000913 RID: 2323
		private XRPageInfo xrPageInfo4;

		// Token: 0x04000914 RID: 2324
		private PageHeaderBand PageHeader;

		// Token: 0x04000915 RID: 2325
		private DetailReportBand DetailReport3;

		// Token: 0x04000916 RID: 2326
		private DetailBand Detail4;

		// Token: 0x04000917 RID: 2327
		private XRLabel xrLabel5;

		// Token: 0x04000918 RID: 2328
		private XRTable xrTable5;

		// Token: 0x04000919 RID: 2329
		private XRTableRow xrTableRow12;

		// Token: 0x0400091A RID: 2330
		private XRTableCell xrTableCell35;

		// Token: 0x0400091B RID: 2331
		private XRTableCell xrTableCell36;

		// Token: 0x0400091C RID: 2332
		private XRTableCell xrTableCell37;

		// Token: 0x0400091D RID: 2333
		private XRTableCell xrTableCell39;

		// Token: 0x0400091E RID: 2334
		private XRLabel xrLabel21;

		// Token: 0x0400091F RID: 2335
		private XRTable xrTable9;

		// Token: 0x04000920 RID: 2336
		private XRTableRow xrTableRow15;

		// Token: 0x04000921 RID: 2337
		private XRTableCell xrTableCell43;

		// Token: 0x04000922 RID: 2338
		private XRLabel xrLabel22;

		// Token: 0x04000923 RID: 2339
		private XRLabel xrLabel26;
	}
}
