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
	// Token: 0x02000059 RID: 89
	public class InvoiceList : XtraReport
	{
		// Token: 0x0600033A RID: 826 RVA: 0x0000400E File Offset: 0x0000220E
		public InvoiceList()
		{
			this.InitializeComponent();
			this.BeforePrint += this.InvoiceList_BeforePrint;
		}

		// Token: 0x0600033B RID: 827 RVA: 0x0000402E File Offset: 0x0000222E
		private void InvoiceList_BeforePrint(object sender, PrintEventArgs e)
		{
			if (this.FilterExpression.Value.ToString() != "")
			{
				this.FilterString = this.FilterExpression.Value.ToString();
			}
		}

		// Token: 0x0600033C RID: 828 RVA: 0x00004062 File Offset: 0x00002262
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600033D RID: 829 RVA: 0x0002C680 File Offset: 0x0002A880
		private void InitializeComponent()
		{
			this.components = new Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvoiceList));
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(InvoiceList));
			SelectQuery selectQuery = new SelectQuery();
			Column column = new Column();
			ColumnExpression columnExpression = new ColumnExpression();
			Table table = new Table();
			Column column2 = new Column();
			ColumnExpression columnExpression2 = new ColumnExpression();
			Column column3 = new Column();
			ColumnExpression columnExpression3 = new ColumnExpression();
			Column column4 = new Column();
			ColumnExpression columnExpression4 = new ColumnExpression();
			Table table2 = new Table();
			Column column5 = new Column();
			ColumnExpression columnExpression5 = new ColumnExpression();
			Column column6 = new Column();
			ColumnExpression columnExpression6 = new ColumnExpression();
			Column column7 = new Column();
			ColumnExpression columnExpression7 = new ColumnExpression();
			Column column8 = new Column();
			ColumnExpression columnExpression8 = new ColumnExpression();
			Column column9 = new Column();
			ColumnExpression columnExpression9 = new ColumnExpression();
			Column column10 = new Column();
			ColumnExpression columnExpression10 = new ColumnExpression();
			Column column11 = new Column();
			ColumnExpression columnExpression11 = new ColumnExpression();
			Column column12 = new Column();
			ColumnExpression columnExpression12 = new ColumnExpression();
			Column column13 = new Column();
			ColumnExpression columnExpression13 = new ColumnExpression();
			Join join = new Join();
			RelationColumnInfo relationColumnInfo = new RelationColumnInfo();
			this.Detail = new DetailBand();
			this.xrTable2 = new XRTable();
			this.xrTableRow2 = new XRTableRow();
			this.xrTableCell18 = new XRTableCell();
			this.xrTableCell19 = new XRTableCell();
			this.xrTableCell20 = new XRTableCell();
			this.xrTableCell21 = new XRTableCell();
			this.TopMargin = new TopMarginBand();
			this.xrLine2 = new XRLine();
			this.xrLabel7 = new XRLabel();
			this.xrLabel3 = new XRLabel();
			this.xrPictureBox1 = new XRPictureBox();
			this.xrLabel8 = new XRLabel();
			this.xrLabel4 = new XRLabel();
			this.xrLabel5 = new XRLabel();
			this.xrLine1 = new XRLine();
			this.xrLabel2 = new XRLabel();
			this.BottomMargin = new BottomMarginBand();
			this.xrPageInfo2 = new XRPageInfo();
			this.xrPageInfo1 = new XRPageInfo();
			this.xrPictureBox2 = new XRPictureBox();
			this.sqlDataSource1 = new SqlDataSource(this.components);
			this.xrLabel29 = new XRLabel();
			this.ReportHeader = new ReportHeaderBand();
			this.PageHeader = new PageHeaderBand();
			this.xrTable1 = new XRTable();
			this.xrTableRow1 = new XRTableRow();
			this.xrTableCell1 = new XRTableCell();
			this.xrTableCell2 = new XRTableCell();
			this.xrTableCell3 = new XRTableCell();
			this.xrTableCell4 = new XRTableCell();
			this.FilterExpression = new Parameter();
			((ISupportInitialize)this.xrTable2).BeginInit();
			((ISupportInitialize)this.xrTable1).BeginInit();
			((ISupportInitialize)this).BeginInit();
			this.Detail.Controls.AddRange(new XRControl[]
			{
				this.xrTable2
			});
			this.Detail.Dpi = 100f;
			this.Detail.HeightF = 25f;
			this.Detail.Name = "Detail";
			this.Detail.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
			this.Detail.TextAlignment = TextAlignment.TopLeft;
			this.xrTable2.Borders = (BorderSide.Left | BorderSide.Right | BorderSide.Bottom);
			this.xrTable2.Dpi = 100f;
			this.xrTable2.LocationFloat = new PointFloat(10f, 0f);
			this.xrTable2.Name = "xrTable2";
			this.xrTable2.Padding = new PaddingInfo(5, 0, 0, 0, 100f);
			this.xrTable2.Rows.AddRange(new XRTableRow[]
			{
				this.xrTableRow2
			});
			this.xrTable2.SizeF = new SizeF(785.1666f, 25f);
			this.xrTable2.StylePriority.UseBorders = false;
			this.xrTable2.StylePriority.UsePadding = false;
			this.xrTableRow2.Cells.AddRange(new XRTableCell[]
			{
				this.xrTableCell18,
				this.xrTableCell19,
				this.xrTableCell20,
				this.xrTableCell21
			});
			this.xrTableRow2.Dpi = 100f;
			this.xrTableRow2.Name = "xrTableRow2";
			this.xrTableRow2.Weight = 11.5;
			this.xrTableCell18.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "Invoice.InvoiceNumber")
			});
			this.xrTableCell18.Dpi = 100f;
			this.xrTableCell18.Name = "xrTableCell18";
			this.xrTableCell18.Text = "xrTableCell18";
			this.xrTableCell18.Weight = 0.22374927350846507;
			this.xrTableCell19.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "Invoice.InvoiceDate", "{0:dd MMM yyyy}")
			});
			this.xrTableCell19.Dpi = 100f;
			this.xrTableCell19.Name = "xrTableCell19";
			this.xrTableCell19.Weight = 0.22389179880855592;
			this.xrTableCell20.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "Invoice.CustomerName")
			});
			this.xrTableCell20.Dpi = 100f;
			this.xrTableCell20.Name = "xrTableCell20";
			this.xrTableCell20.Weight = 0.23456531378162188;
			this.xrTableCell21.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "Invoice.NetAmount")
			});
			this.xrTableCell21.Dpi = 100f;
			this.xrTableCell21.Name = "xrTableCell21";
			this.xrTableCell21.Text = "xrTableCell21";
			this.xrTableCell21.Weight = 0.21293321583932392;
			this.TopMargin.Controls.AddRange(new XRControl[]
			{
				this.xrLine2,
				this.xrLabel7,
				this.xrLabel3,
				this.xrPictureBox1,
				this.xrLabel8,
				this.xrLabel4,
				this.xrLabel5,
				this.xrLine1,
				this.xrLabel2
			});
			this.TopMargin.Dpi = 100f;
			this.TopMargin.HeightF = 130f;
			this.TopMargin.Name = "TopMargin";
			this.TopMargin.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
			this.TopMargin.TextAlignment = TextAlignment.TopLeft;
			this.xrLine2.Dpi = 100f;
			this.xrLine2.ForeColor = Color.FromArgb(32, 150, 159);
			this.xrLine2.LocationFloat = new PointFloat(528.7581f, 99.47916f);
			this.xrLine2.Name = "xrLine2";
			this.xrLine2.SizeF = new SizeF(282.2419f, 13f);
			this.xrLine2.StylePriority.UseForeColor = false;
			this.xrLabel7.BackColor = Color.White;
			this.xrLabel7.Dpi = 100f;
			this.xrLabel7.Font = new Font("Times New Roman", 11f, FontStyle.Bold);
			this.xrLabel7.ForeColor = Color.FromArgb(45, 84, 108);
			this.xrLabel7.LocationFloat = new PointFloat(554.0629f, 71.52087f);
			this.xrLabel7.Name = "xrLabel7";
			this.xrLabel7.Padding = new PaddingInfo(2, 2, 0, 2, 100f);
			this.xrLabel7.SizeF = new SizeF(231.8328f, 22.99997f);
			this.xrLabel7.StylePriority.UseBackColor = false;
			this.xrLabel7.StylePriority.UseFont = false;
			this.xrLabel7.StylePriority.UseForeColor = false;
			this.xrLabel7.StylePriority.UsePadding = false;
			this.xrLabel7.StylePriority.UseTextAlignment = false;
			this.xrLabel7.Text = "اختبارات مواقع - تصميم خلطات - دراسات تربة";
			this.xrLabel7.TextAlignment = TextAlignment.TopRight;
			this.xrLabel3.BackColor = Color.White;
			this.xrLabel3.Dpi = 100f;
			this.xrLabel3.Font = new Font("Times New Roman", 11f, FontStyle.Bold);
			this.xrLabel3.ForeColor = Color.FromArgb(45, 84, 108);
			this.xrLabel3.LocationFloat = new PointFloat(554.0629f, 17.52084f);
			this.xrLabel3.Name = "xrLabel3";
			this.xrLabel3.Padding = new PaddingInfo(2, 2, 0, 2, 100f);
			this.xrLabel3.SizeF = new SizeF(231.833f, 24f);
			this.xrLabel3.StylePriority.UseBackColor = false;
			this.xrLabel3.StylePriority.UseFont = false;
			this.xrLabel3.StylePriority.UseForeColor = false;
			this.xrLabel3.StylePriority.UsePadding = false;
			this.xrLabel3.StylePriority.UseTextAlignment = false;
			this.xrLabel3.Text = "إختبارات ميكانيكية وفزيائية  وكميائية لمواد البناء";
			this.xrLabel3.TextAlignment = TextAlignment.TopRight;
			this.xrPictureBox1.Dpi = 100f;
			this.xrPictureBox1.Image = (Image)resources.GetObject("xrPictureBox1.Image");
			this.xrPictureBox1.LocationFloat = new PointFloat(329.1949f, 17.52084f);
			this.xrPictureBox1.Name = "xrPictureBox1";
			this.xrPictureBox1.SizeF = new SizeF(171.0558f, 94.95831f);
			this.xrLabel8.BackColor = Color.White;
			this.xrLabel8.Dpi = 100f;
			this.xrLabel8.Font = new Font("Times New Roman", 11f, FontStyle.Bold);
			this.xrLabel8.ForeColor = Color.FromArgb(45, 84, 108);
			this.xrLabel8.LocationFloat = new PointFloat(554.0629f, 43.47919f);
			this.xrLabel8.Name = "xrLabel8";
			this.xrLabel8.Padding = new PaddingInfo(2, 2, 0, 2, 100f);
			this.xrLabel8.SizeF = new SizeF(231.833f, 22.99997f);
			this.xrLabel8.StylePriority.UseBackColor = false;
			this.xrLabel8.StylePriority.UseFont = false;
			this.xrLabel8.StylePriority.UseForeColor = false;
			this.xrLabel8.StylePriority.UsePadding = false;
			this.xrLabel8.StylePriority.UseTextAlignment = false;
			this.xrLabel8.Text = "تربة - اسفلت - حصي - كونكريت - اسمنت - ماء";
			this.xrLabel8.TextAlignment = TextAlignment.TopRight;
			this.xrLabel4.BackColor = Color.White;
			this.xrLabel4.Dpi = 100f;
			this.xrLabel4.Font = new Font("Times New Roman", 9f, FontStyle.Bold);
			this.xrLabel4.ForeColor = Color.FromArgb(45, 84, 103);
			this.xrLabel4.LocationFloat = new PointFloat(0.1250029f, 41.52085f);
			this.xrLabel4.Name = "xrLabel4";
			this.xrLabel4.Padding = new PaddingInfo(2, 2, 0, 2, 100f);
			this.xrLabel4.SizeF = new SizeF(292.3529f, 25f);
			this.xrLabel4.StylePriority.UseBackColor = false;
			this.xrLabel4.StylePriority.UseFont = false;
			this.xrLabel4.StylePriority.UseForeColor = false;
			this.xrLabel4.StylePriority.UsePadding = false;
			this.xrLabel4.StylePriority.UseTextAlignment = false;
			this.xrLabel4.Text = "Soil - Asphalt - Aggregate - Concrete - Cement - Water";
			this.xrLabel4.TextAlignment = TextAlignment.TopLeft;
			this.xrLabel5.BackColor = Color.White;
			this.xrLabel5.Dpi = 100f;
			this.xrLabel5.Font = new Font("Times New Roman", 9f, FontStyle.Bold);
			this.xrLabel5.ForeColor = Color.FromArgb(45, 84, 103);
			this.xrLabel5.LocationFloat = new PointFloat(0.1250029f, 66.52085f);
			this.xrLabel5.Name = "xrLabel5";
			this.xrLabel5.Padding = new PaddingInfo(2, 2, 0, 2, 100f);
			this.xrLabel5.SizeF = new SizeF(270.7004f, 24f);
			this.xrLabel5.StylePriority.UseBackColor = false;
			this.xrLabel5.StylePriority.UseFont = false;
			this.xrLabel5.StylePriority.UseForeColor = false;
			this.xrLabel5.StylePriority.UsePadding = false;
			this.xrLabel5.StylePriority.UseTextAlignment = false;
			this.xrLabel5.Text = "Site testing - Material design mixes - Soil study";
			this.xrLabel5.TextAlignment = TextAlignment.TopLeft;
			this.xrLine1.Dpi = 100f;
			this.xrLine1.ForeColor = Color.FromArgb(32, 150, 159);
			this.xrLine1.LocationFloat = new PointFloat(0.1250029f, 99.47916f);
			this.xrLine1.Name = "xrLine1";
			this.xrLine1.SizeF = new SizeF(282.2419f, 13f);
			this.xrLine1.StylePriority.UseForeColor = false;
			this.xrLabel2.BackColor = Color.White;
			this.xrLabel2.Dpi = 100f;
			this.xrLabel2.Font = new Font("Times New Roman", 9f, FontStyle.Bold);
			this.xrLabel2.ForeColor = Color.FromArgb(45, 84, 103);
			this.xrLabel2.LocationFloat = new PointFloat(0.1250029f, 17.52084f);
			this.xrLabel2.Name = "xrLabel2";
			this.xrLabel2.Padding = new PaddingInfo(2, 2, 0, 2, 100f);
			this.xrLabel2.SizeF = new SizeF(267.8115f, 24f);
			this.xrLabel2.StylePriority.UseBackColor = false;
			this.xrLabel2.StylePriority.UseFont = false;
			this.xrLabel2.StylePriority.UseForeColor = false;
			this.xrLabel2.StylePriority.UsePadding = false;
			this.xrLabel2.StylePriority.UseTextAlignment = false;
			this.xrLabel2.Text = "Mechanical , physical and chimical material testing";
			this.xrLabel2.TextAlignment = TextAlignment.TopLeft;
			this.BottomMargin.Controls.AddRange(new XRControl[]
			{
				this.xrPageInfo2,
				this.xrPageInfo1,
				this.xrPictureBox2
			});
			this.BottomMargin.Dpi = 100f;
			this.BottomMargin.HeightF = 153f;
			this.BottomMargin.Name = "BottomMargin";
			this.BottomMargin.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
			this.BottomMargin.TextAlignment = TextAlignment.TopLeft;
			this.xrPageInfo2.Dpi = 100f;
			this.xrPageInfo2.Format = "Page {0} of {1}";
			this.xrPageInfo2.LocationFloat = new PointFloat(457.6012f, 114.9375f);
			this.xrPageInfo2.Name = "xrPageInfo2";
			this.xrPageInfo2.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrPageInfo2.SizeF = new SizeF(313f, 23f);
			this.xrPageInfo2.TextAlignment = TextAlignment.TopRight;
			this.xrPageInfo1.Dpi = 100f;
			this.xrPageInfo1.LocationFloat = new PointFloat(6.732147f, 114.9375f);
			this.xrPageInfo1.Name = "xrPageInfo1";
			this.xrPageInfo1.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrPageInfo1.PageInfo = PageInfo.DateTime;
			this.xrPageInfo1.SizeF = new SizeF(313f, 23f);
			this.xrPictureBox2.Dpi = 100f;
			this.xrPictureBox2.Image = (Image)resources.GetObject("xrPictureBox2.Image");
			this.xrPictureBox2.LocationFloat = new PointFloat(136.3154f, 15.18753f);
			this.xrPictureBox2.Name = "xrPictureBox2";
			this.xrPictureBox2.SizeF = new SizeF(581.3381f, 74.20829f);
			this.sqlDataSource1.ConnectionName = "localhost_LabSys_Connection";
			this.sqlDataSource1.Name = "sqlDataSource1";
			columnExpression.ColumnName = "CustomerID";
			table.MetaSerializable = "185|30|125|300";
			table.Name = "CustomersList";
			columnExpression.Table = table;
			column.Expression = columnExpression;
			columnExpression2.ColumnName = "CustomerCode";
			columnExpression2.Table = table;
			column2.Expression = columnExpression2;
			columnExpression3.ColumnName = "CustomerName";
			columnExpression3.Table = table;
			column3.Expression = columnExpression3;
			columnExpression4.ColumnName = "InvoiceId";
			table2.MetaSerializable = "30|30|125|240";
			table2.Name = "Invoice";
			columnExpression4.Table = table2;
			column4.Expression = columnExpression4;
			columnExpression5.ColumnName = "InvoiceNumber";
			columnExpression5.Table = table2;
			column5.Expression = columnExpression5;
			columnExpression6.ColumnName = "InvoiceDate";
			columnExpression6.Table = table2;
			column6.Expression = columnExpression6;
			columnExpression7.ColumnName = "InvoiceRefNo";
			columnExpression7.Table = table2;
			column7.Expression = columnExpression7;
			columnExpression8.ColumnName = "FkCustomerId";
			columnExpression8.Table = table2;
			column8.Expression = columnExpression8;
			columnExpression9.ColumnName = "SRTTotal";
			columnExpression9.Table = table2;
			column9.Expression = columnExpression9;
			columnExpression10.ColumnName = "TSTotal";
			columnExpression10.Table = table2;
			column10.Expression = columnExpression10;
			columnExpression11.ColumnName = "InvoiceTotal";
			columnExpression11.Table = table2;
			column11.Expression = columnExpression11;
			columnExpression12.ColumnName = "Disount";
			columnExpression12.Table = table2;
			column12.Expression = columnExpression12;
			columnExpression13.ColumnName = "NetAmount";
			columnExpression13.Table = table2;
			column13.Expression = columnExpression13;
			selectQuery.Columns.Add(column);
			selectQuery.Columns.Add(column2);
			selectQuery.Columns.Add(column3);
			selectQuery.Columns.Add(column4);
			selectQuery.Columns.Add(column5);
			selectQuery.Columns.Add(column6);
			selectQuery.Columns.Add(column7);
			selectQuery.Columns.Add(column8);
			selectQuery.Columns.Add(column9);
			selectQuery.Columns.Add(column10);
			selectQuery.Columns.Add(column11);
			selectQuery.Columns.Add(column12);
			selectQuery.Columns.Add(column13);
			selectQuery.Name = "Invoice";
			relationColumnInfo.NestedKeyColumn = "CustomerID";
			relationColumnInfo.ParentKeyColumn = "FkCustomerId";
			join.KeyColumns.Add(relationColumnInfo);
			join.Nested = table;
			join.Parent = table2;
			selectQuery.Relations.Add(join);
			selectQuery.Tables.Add(table2);
			selectQuery.Tables.Add(table);
			this.sqlDataSource1.Queries.AddRange(new SqlQuery[]
			{
				selectQuery
			});
			this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
			this.xrLabel29.Dpi = 100f;
			this.xrLabel29.Font = new Font("Times New Roman", 20f, FontStyle.Bold);
			this.xrLabel29.ForeColor = Color.Maroon;
			this.xrLabel29.LocationFloat = new PointFloat(44.91666f, 9.083335f);
			this.xrLabel29.Name = "xrLabel29";
			this.xrLabel29.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel29.SizeF = new SizeF(638f, 33f);
			this.xrLabel29.StylePriority.UseFont = false;
			this.xrLabel29.StylePriority.UseForeColor = false;
			this.xrLabel29.StylePriority.UseTextAlignment = false;
			this.xrLabel29.Text = "Invoice";
			this.xrLabel29.TextAlignment = TextAlignment.TopCenter;
			this.ReportHeader.Controls.AddRange(new XRControl[]
			{
				this.xrLabel29
			});
			this.ReportHeader.Dpi = 100f;
			this.ReportHeader.HeightF = 73.95834f;
			this.ReportHeader.Name = "ReportHeader";
			this.PageHeader.Controls.AddRange(new XRControl[]
			{
				this.xrTable1
			});
			this.PageHeader.Dpi = 100f;
			this.PageHeader.HeightF = 38.95833f;
			this.PageHeader.Name = "PageHeader";
			this.xrTable1.BackColor = Color.LightGray;
			this.xrTable1.Borders = BorderSide.All;
			this.xrTable1.Dpi = 100f;
			this.xrTable1.Font = new Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTable1.LocationFloat = new PointFloat(10.125f, 13.95833f);
			this.xrTable1.Name = "xrTable1";
			this.xrTable1.Padding = new PaddingInfo(6, 0, 0, 0, 100f);
			this.xrTable1.Rows.AddRange(new XRTableRow[]
			{
				this.xrTableRow1
			});
			this.xrTable1.SizeF = new SizeF(785.0416f, 25f);
			this.xrTable1.StylePriority.UseBackColor = false;
			this.xrTable1.StylePriority.UseBorders = false;
			this.xrTable1.StylePriority.UseFont = false;
			this.xrTable1.StylePriority.UsePadding = false;
			this.xrTableRow1.Cells.AddRange(new XRTableCell[]
			{
				this.xrTableCell1,
				this.xrTableCell2,
				this.xrTableCell3,
				this.xrTableCell4
			});
			this.xrTableRow1.Dpi = 100f;
			this.xrTableRow1.Name = "xrTableRow1";
			this.xrTableRow1.Weight = 11.5;
			this.xrTableCell1.Dpi = 100f;
			this.xrTableCell1.Name = "xrTableCell1";
			this.xrTableCell1.Text = "Invoice No";
			this.xrTableCell1.Weight = 0.22371364653243847;
			this.xrTableCell2.Dpi = 100f;
			this.xrTableCell2.Name = "xrTableCell2";
			this.xrTableCell2.Text = "Date";
			this.xrTableCell2.Weight = 0.22371364653243847;
			this.xrTableCell3.Dpi = 100f;
			this.xrTableCell3.Name = "xrTableCell3";
			this.xrTableCell3.Text = "Customer";
			this.xrTableCell3.Weight = 0.23467050423926836;
			this.xrTableCell4.Dpi = 100f;
			this.xrTableCell4.Name = "xrTableCell4";
			this.xrTableCell4.Text = "Net Amount";
			this.xrTableCell4.Weight = 0.21275678882560858;
			this.FilterExpression.Description = "FilterExpression";
			this.FilterExpression.Name = "FilterExpression";
			base.Bands.AddRange(new Band[]
			{
				this.Detail,
				this.TopMargin,
				this.BottomMargin,
				this.ReportHeader,
				this.PageHeader
			});
			base.ComponentStorage.AddRange(new IComponent[]
			{
				this.sqlDataSource1
			});
			base.DataMember = "Invoice";
			base.DataSource = this.sqlDataSource1;
			base.Margins = new Margins(3, 26, 130, 153);
			base.Parameters.AddRange(new Parameter[]
			{
				this.FilterExpression
			});
			base.Version = "16.1";
			((ISupportInitialize)this.xrTable2).EndInit();
			((ISupportInitialize)this.xrTable1).EndInit();
			((ISupportInitialize)this).EndInit();
		}

		// Token: 0x040006A2 RID: 1698
		private IContainer components;

		// Token: 0x040006A3 RID: 1699
		private DetailBand Detail;

		// Token: 0x040006A4 RID: 1700
		private TopMarginBand TopMargin;

		// Token: 0x040006A5 RID: 1701
		private BottomMarginBand BottomMargin;

		// Token: 0x040006A6 RID: 1702
		private SqlDataSource sqlDataSource1;

		// Token: 0x040006A7 RID: 1703
		private XRLabel xrLabel29;

		// Token: 0x040006A8 RID: 1704
		private XRTable xrTable2;

		// Token: 0x040006A9 RID: 1705
		private XRTableRow xrTableRow2;

		// Token: 0x040006AA RID: 1706
		private XRTableCell xrTableCell18;

		// Token: 0x040006AB RID: 1707
		private XRTableCell xrTableCell19;

		// Token: 0x040006AC RID: 1708
		private XRTableCell xrTableCell20;

		// Token: 0x040006AD RID: 1709
		private XRTableCell xrTableCell21;

		// Token: 0x040006AE RID: 1710
		private XRPageInfo xrPageInfo2;

		// Token: 0x040006AF RID: 1711
		private XRPageInfo xrPageInfo1;

		// Token: 0x040006B0 RID: 1712
		private XRPictureBox xrPictureBox2;

		// Token: 0x040006B1 RID: 1713
		private ReportHeaderBand ReportHeader;

		// Token: 0x040006B2 RID: 1714
		private PageHeaderBand PageHeader;

		// Token: 0x040006B3 RID: 1715
		private XRTable xrTable1;

		// Token: 0x040006B4 RID: 1716
		private XRTableRow xrTableRow1;

		// Token: 0x040006B5 RID: 1717
		private XRTableCell xrTableCell1;

		// Token: 0x040006B6 RID: 1718
		private XRTableCell xrTableCell2;

		// Token: 0x040006B7 RID: 1719
		private XRTableCell xrTableCell3;

		// Token: 0x040006B8 RID: 1720
		private XRTableCell xrTableCell4;

		// Token: 0x040006B9 RID: 1721
		private Parameter FilterExpression;

		// Token: 0x040006BA RID: 1722
		private XRLine xrLine2;

		// Token: 0x040006BB RID: 1723
		private XRLabel xrLabel7;

		// Token: 0x040006BC RID: 1724
		private XRLabel xrLabel3;

		// Token: 0x040006BD RID: 1725
		private XRPictureBox xrPictureBox1;

		// Token: 0x040006BE RID: 1726
		private XRLabel xrLabel8;

		// Token: 0x040006BF RID: 1727
		private XRLabel xrLabel4;

		// Token: 0x040006C0 RID: 1728
		private XRLabel xrLabel5;

		// Token: 0x040006C1 RID: 1729
		private XRLine xrLine1;

		// Token: 0x040006C2 RID: 1730
		private XRLabel xrLabel2;
	}
}
