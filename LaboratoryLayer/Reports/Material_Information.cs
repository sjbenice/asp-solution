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
	// Token: 0x02000062 RID: 98
	public class Material_Information : XtraReport
	{
		// Token: 0x0600035D RID: 861 RVA: 0x0000432A File Offset: 0x0000252A
		public Material_Information()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600035E RID: 862 RVA: 0x00004338 File Offset: 0x00002538
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600035F RID: 863 RVA: 0x0003C1D4 File Offset: 0x0003A3D4
		private void InitializeComponent()
		{
			this.components = new Container();
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
			Table table2 = new Table();
			Column column10 = new Column();
			ColumnExpression columnExpression10 = new ColumnExpression();
			Column column11 = new Column();
			ColumnExpression columnExpression11 = new ColumnExpression();
			Column column12 = new Column();
			ColumnExpression columnExpression12 = new ColumnExpression();
			Join join = new Join();
			RelationColumnInfo relationColumnInfo = new RelationColumnInfo();
			SelectQuery selectQuery2 = new SelectQuery();
			Column column13 = new Column();
			ColumnExpression columnExpression13 = new ColumnExpression();
			Table table3 = new Table();
			Column column14 = new Column();
			ColumnExpression columnExpression14 = new ColumnExpression();
			Column column15 = new Column();
			ColumnExpression columnExpression15 = new ColumnExpression();
			Column column16 = new Column();
			ColumnExpression columnExpression16 = new ColumnExpression();
			Table table4 = new Table();
			Column column17 = new Column();
			ColumnExpression columnExpression17 = new ColumnExpression();
			Join join2 = new Join();
			RelationColumnInfo relationColumnInfo2 = new RelationColumnInfo();
			MasterDetailInfo masterDetailInfo = new MasterDetailInfo();
			RelationColumnInfo relationColumnInfo3 = new RelationColumnInfo();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Material_Information));
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Material_Information));
			DynamicListLookUpSettings dynamicListLookUpSettings = new DynamicListLookUpSettings();
			this.sqlDataSource1 = new SqlDataSource(this.components);
			this.Detail = new DetailBand();
			this.xrLabel1 = new XRLabel();
			this.xrLabel2 = new XRLabel();
			this.xrLabel3 = new XRLabel();
			this.xrLabel5 = new XRLabel();
			this.xrLabel6 = new XRLabel();
			this.xrLabel7 = new XRLabel();
			this.xrLabel8 = new XRLabel();
			this.xrLabel9 = new XRLabel();
			this.xrCheckBox1 = new XRCheckBox();
			this.xrLabel10 = new XRLabel();
			this.xrLabel12 = new XRLabel();
			this.xrLabel13 = new XRLabel();
			this.xrLabel14 = new XRLabel();
			this.xrLabel15 = new XRLabel();
			this.TopMargin = new TopMarginBand();
			this.xrLine2 = new XRLine();
			this.xrLabel4 = new XRLabel();
			this.xrLabel11 = new XRLabel();
			this.xrPictureBox1 = new XRPictureBox();
			this.xrLabel16 = new XRLabel();
			this.xrLabel17 = new XRLabel();
			this.xrLabel18 = new XRLabel();
			this.xrLine1 = new XRLine();
			this.xrLabel19 = new XRLabel();
			this.BottomMargin = new BottomMarginBand();
			this.xrPictureBox2 = new XRPictureBox();
			this.xrPageInfo2 = new XRPageInfo();
			this.xrPageInfo1 = new XRPageInfo();
			this.pageFooterBand1 = new PageFooterBand();
			this.reportHeaderBand1 = new ReportHeaderBand();
			this.Title = new XRControlStyle();
			this.FieldCaption = new XRControlStyle();
			this.PageInfo = new XRControlStyle();
			this.DataField = new XRControlStyle();
			this.DetailReport = new DetailReportBand();
			this.Detail1 = new DetailBand();
			this.xrTable1 = new XRTable();
			this.xrTableRow1 = new XRTableRow();
			this.xrTableCell1 = new XRTableCell();
			this.xrTableCell2 = new XRTableCell();
			this.GroupHeader1 = new GroupHeaderBand();
			this.xrTable2 = new XRTable();
			this.xrTableRow2 = new XRTableRow();
			this.xrTableCell3 = new XRTableCell();
			this.xrTableCell4 = new XRTableCell();
			this.xrLabel26 = new XRLabel();
			this.PageHeader = new PageHeaderBand();
			this.Id = new Parameter();
			((ISupportInitialize)this.xrTable1).BeginInit();
			((ISupportInitialize)this.xrTable2).BeginInit();
			((ISupportInitialize)this).BeginInit();
			this.sqlDataSource1.ConnectionName = "localhost_LabSys_Connection";
			this.sqlDataSource1.Name = "sqlDataSource1";
			columnExpression.ColumnName = "MaterialDetailsID";
			table.MetaSerializable = "30|30|125|200";
			table.Name = "MaterialsDetails";
			columnExpression.Table = table;
			column.Expression = columnExpression;
			columnExpression2.ColumnName = "FKMaterialTypeID";
			columnExpression2.Table = table;
			column2.Expression = columnExpression2;
			columnExpression3.ColumnName = "MaterialName";
			columnExpression3.Table = table;
			column3.Expression = columnExpression3;
			columnExpression4.ColumnName = "MaterialDescription";
			columnExpression4.Table = table;
			column4.Expression = columnExpression4;
			columnExpression5.ColumnName = "MaterialUse";
			columnExpression5.Table = table;
			column5.Expression = columnExpression5;
			columnExpression6.ColumnName = "StandardSpecs";
			columnExpression6.Table = table;
			column6.Expression = columnExpression6;
			columnExpression7.ColumnName = "StandardNumber";
			columnExpression7.Table = table;
			column7.Expression = columnExpression7;
			columnExpression8.ColumnName = "IsLocked";
			columnExpression8.Table = table;
			column8.Expression = columnExpression8;
			columnExpression9.ColumnName = "MaterialTypeID";
			table2.MetaSerializable = "185|30|125|120";
			table2.Name = "MaterialsTypes";
			columnExpression9.Table = table2;
			column9.Expression = columnExpression9;
			column10.Alias = "MaterialsTypes_MaterialName";
			columnExpression10.ColumnName = "MaterialName";
			columnExpression10.Table = table2;
			column10.Expression = columnExpression10;
			columnExpression11.ColumnName = "FKLabID";
			columnExpression11.Table = table2;
			column11.Expression = columnExpression11;
			column12.Alias = "MaterialsTypes_IsLocked";
			columnExpression12.ColumnName = "IsLocked";
			columnExpression12.Table = table2;
			column12.Expression = columnExpression12;
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
			selectQuery.Name = "MaterialsDetails";
			relationColumnInfo.NestedKeyColumn = "MaterialTypeID";
			relationColumnInfo.ParentKeyColumn = "FKMaterialTypeID";
			join.KeyColumns.Add(relationColumnInfo);
			join.Nested = table2;
			join.Parent = table;
			selectQuery.Relations.Add(join);
			selectQuery.Tables.Add(table);
			selectQuery.Tables.Add(table2);
			columnExpression13.ColumnName = "MaterialTestID";
			table3.MetaSerializable = "30|30|125|100";
			table3.Name = "MaterialsDetailsTests";
			columnExpression13.Table = table3;
			column13.Expression = columnExpression13;
			columnExpression14.ColumnName = "FKMaterialDetailsID";
			columnExpression14.Table = table3;
			column14.Expression = columnExpression14;
			columnExpression15.ColumnName = "FKTestID";
			columnExpression15.Table = table3;
			column15.Expression = columnExpression15;
			columnExpression16.ColumnName = "StandardNumber";
			table4.MetaSerializable = "185|30|125|480";
			table4.Name = "TestsList";
			columnExpression16.Table = table4;
			column16.Expression = columnExpression16;
			columnExpression17.ColumnName = "TestName";
			columnExpression17.Table = table4;
			column17.Expression = columnExpression17;
			selectQuery2.Columns.Add(column13);
			selectQuery2.Columns.Add(column14);
			selectQuery2.Columns.Add(column15);
			selectQuery2.Columns.Add(column16);
			selectQuery2.Columns.Add(column17);
			selectQuery2.Name = "MaterialsDetailsTests";
			relationColumnInfo2.NestedKeyColumn = "TestID";
			relationColumnInfo2.ParentKeyColumn = "FKTestID";
			join2.KeyColumns.Add(relationColumnInfo2);
			join2.Nested = table4;
			join2.Parent = table3;
			selectQuery2.Relations.Add(join2);
			selectQuery2.Tables.Add(table3);
			selectQuery2.Tables.Add(table4);
			this.sqlDataSource1.Queries.AddRange(new SqlQuery[]
			{
				selectQuery,
				selectQuery2
			});
			masterDetailInfo.DetailQueryName = "MaterialsDetailsTests";
			relationColumnInfo3.NestedKeyColumn = "FKMaterialDetailsID";
			relationColumnInfo3.ParentKeyColumn = "MaterialDetailsID";
			masterDetailInfo.KeyColumns.Add(relationColumnInfo3);
			masterDetailInfo.MasterQueryName = "MaterialsDetails";
			masterDetailInfo.Name = "FK_MaterialsDetailsTests_MaterialsDetails";
			this.sqlDataSource1.Relations.AddRange(new MasterDetailInfo[]
			{
				masterDetailInfo
			});
			this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
			this.Detail.Controls.AddRange(new XRControl[]
			{
				this.xrLabel1,
				this.xrLabel2,
				this.xrLabel3,
				this.xrLabel5,
				this.xrLabel6,
				this.xrLabel7,
				this.xrLabel8,
				this.xrLabel9,
				this.xrCheckBox1,
				this.xrLabel10,
				this.xrLabel12,
				this.xrLabel13,
				this.xrLabel14,
				this.xrLabel15
			});
			this.Detail.Dpi = 100f;
			this.Detail.HeightF = 149.7917f;
			this.Detail.KeepTogether = true;
			this.Detail.KeepTogetherWithDetailReports = true;
			this.Detail.Name = "Detail";
			this.Detail.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
			this.Detail.PageBreak = PageBreak.BeforeBand;
			this.Detail.TextAlignment = TextAlignment.TopLeft;
			this.xrLabel1.Dpi = 100f;
			this.xrLabel1.ForeColor = Color.FromArgb(0, 0, 0);
			this.xrLabel1.LocationFloat = new PointFloat(394.75f, 48.54171f);
			this.xrLabel1.Name = "xrLabel1";
			this.xrLabel1.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel1.SizeF = new SizeF(162f, 18f);
			this.xrLabel1.StyleName = "FieldCaption";
			this.xrLabel1.StylePriority.UseForeColor = false;
			this.xrLabel1.Text = "Service Section:";
			this.xrLabel2.Dpi = 100f;
			this.xrLabel2.LocationFloat = new PointFloat(706.4167f, 0f);
			this.xrLabel2.Name = "xrLabel2";
			this.xrLabel2.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel2.SizeF = new SizeF(71.37503f, 23f);
			this.xrLabel2.StyleName = "FieldCaption";
			this.xrLabel2.Text = "Inactive";
			this.xrLabel3.Dpi = 100f;
			this.xrLabel3.ForeColor = Color.FromArgb(0, 0, 0);
			this.xrLabel3.LocationFloat = new PointFloat(394.7501f, 77.45835f);
			this.xrLabel3.Name = "xrLabel3";
			this.xrLabel3.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel3.SizeF = new SizeF(162f, 18f);
			this.xrLabel3.StyleName = "FieldCaption";
			this.xrLabel3.StylePriority.UseForeColor = false;
			this.xrLabel3.Text = "Material Description:";
			this.xrLabel5.Dpi = 100f;
			this.xrLabel5.ForeColor = Color.FromArgb(0, 0, 0);
			this.xrLabel5.LocationFloat = new PointFloat(9.999998f, 48.54171f);
			this.xrLabel5.Name = "xrLabel5";
			this.xrLabel5.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel5.SizeF = new SizeF(137f, 18f);
			this.xrLabel5.StyleName = "FieldCaption";
			this.xrLabel5.StylePriority.UseForeColor = false;
			this.xrLabel5.Text = "Material Name:";
			this.xrLabel6.Dpi = 100f;
			this.xrLabel6.ForeColor = Color.FromArgb(0, 0, 0);
			this.xrLabel6.LocationFloat = new PointFloat(10.00001f, 77.45835f);
			this.xrLabel6.Name = "xrLabel6";
			this.xrLabel6.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel6.SizeF = new SizeF(137f, 18f);
			this.xrLabel6.StyleName = "FieldCaption";
			this.xrLabel6.StylePriority.UseForeColor = false;
			this.xrLabel6.Text = "Material Use:";
			this.xrLabel7.Dpi = 100f;
			this.xrLabel7.ForeColor = Color.FromArgb(0, 0, 0);
			this.xrLabel7.LocationFloat = new PointFloat(394.7501f, 108.08f);
			this.xrLabel7.Name = "xrLabel7";
			this.xrLabel7.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel7.SizeF = new SizeF(162f, 18f);
			this.xrLabel7.StyleName = "FieldCaption";
			this.xrLabel7.StylePriority.UseForeColor = false;
			this.xrLabel7.Text = "Standard Number:";
			this.xrLabel8.Dpi = 100f;
			this.xrLabel8.ForeColor = Color.FromArgb(0, 0, 0);
			this.xrLabel8.LocationFloat = new PointFloat(10.00001f, 108.08f);
			this.xrLabel8.Name = "xrLabel8";
			this.xrLabel8.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel8.SizeF = new SizeF(137f, 18f);
			this.xrLabel8.StyleName = "FieldCaption";
			this.xrLabel8.StylePriority.UseForeColor = false;
			this.xrLabel8.Text = "Specification value:";
			this.xrLabel9.Borders = BorderSide.All;
			this.xrLabel9.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "MaterialsDetails.MaterialsTypes_MaterialName")
			});
			this.xrLabel9.Dpi = 100f;
			this.xrLabel9.LocationFloat = new PointFloat(556.7501f, 48.54172f);
			this.xrLabel9.Name = "xrLabel9";
			this.xrLabel9.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel9.SizeF = new SizeF(221.0417f, 17.99999f);
			this.xrLabel9.StyleName = "DataField";
			this.xrLabel9.StylePriority.UseBorders = false;
			this.xrCheckBox1.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("CheckState", null, "MaterialsDetails.IsLocked")
			});
			this.xrCheckBox1.Dpi = 100f;
			this.xrCheckBox1.LocationFloat = new PointFloat(679.1251f, 0f);
			this.xrCheckBox1.Name = "xrCheckBox1";
			this.xrCheckBox1.SizeF = new SizeF(27.29166f, 23f);
			this.xrCheckBox1.StyleName = "DataField";
			this.xrLabel10.Borders = BorderSide.All;
			this.xrLabel10.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "MaterialsDetails.MaterialDescription")
			});
			this.xrLabel10.Dpi = 100f;
			this.xrLabel10.LocationFloat = new PointFloat(556.7501f, 77.45835f);
			this.xrLabel10.Name = "xrLabel10";
			this.xrLabel10.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel10.SizeF = new SizeF(221.0417f, 18f);
			this.xrLabel10.StyleName = "DataField";
			this.xrLabel10.StylePriority.UseBorders = false;
			this.xrLabel10.Text = "xrLabel10";
			this.xrLabel12.Borders = BorderSide.All;
			this.xrLabel12.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "MaterialsDetails.MaterialName")
			});
			this.xrLabel12.Dpi = 100f;
			this.xrLabel12.LocationFloat = new PointFloat(147f, 48.54171f);
			this.xrLabel12.Name = "xrLabel12";
			this.xrLabel12.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel12.SizeF = new SizeF(217.6251f, 18f);
			this.xrLabel12.StyleName = "DataField";
			this.xrLabel12.StylePriority.UseBorders = false;
			this.xrLabel12.Text = "xrLabel12";
			this.xrLabel13.Borders = BorderSide.All;
			this.xrLabel13.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "MaterialsDetails.MaterialUse")
			});
			this.xrLabel13.Dpi = 100f;
			this.xrLabel13.LocationFloat = new PointFloat(147f, 77.45835f);
			this.xrLabel13.Name = "xrLabel13";
			this.xrLabel13.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel13.SizeF = new SizeF(217.6251f, 18f);
			this.xrLabel13.StyleName = "DataField";
			this.xrLabel13.StylePriority.UseBorders = false;
			this.xrLabel13.Text = "xrLabel13";
			this.xrLabel14.Borders = BorderSide.All;
			this.xrLabel14.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "MaterialsDetails.StandardNumber")
			});
			this.xrLabel14.Dpi = 100f;
			this.xrLabel14.LocationFloat = new PointFloat(556.7501f, 108.08f);
			this.xrLabel14.Name = "xrLabel14";
			this.xrLabel14.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel14.SizeF = new SizeF(221.0417f, 18f);
			this.xrLabel14.StyleName = "DataField";
			this.xrLabel14.StylePriority.UseBorders = false;
			this.xrLabel14.Text = "xrLabel14";
			this.xrLabel15.Borders = BorderSide.All;
			this.xrLabel15.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "MaterialsDetails.StandardSpecs")
			});
			this.xrLabel15.Dpi = 100f;
			this.xrLabel15.LocationFloat = new PointFloat(147f, 108.08f);
			this.xrLabel15.Name = "xrLabel15";
			this.xrLabel15.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel15.SizeF = new SizeF(217.6251f, 18f);
			this.xrLabel15.StyleName = "DataField";
			this.xrLabel15.StylePriority.UseBorders = false;
			this.xrLabel15.Text = "xrLabel15";
			this.TopMargin.Controls.AddRange(new XRControl[]
			{
				this.xrLine2,
				this.xrLabel4,
				this.xrLabel11,
				this.xrPictureBox1,
				this.xrLabel16,
				this.xrLabel17,
				this.xrLabel18,
				this.xrLine1,
				this.xrLabel19
			});
			this.TopMargin.Dpi = 100f;
			this.TopMargin.HeightF = 130f;
			this.TopMargin.Name = "TopMargin";
			this.TopMargin.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
			this.TopMargin.TextAlignment = TextAlignment.TopLeft;
			this.xrLine2.Dpi = 100f;
			this.xrLine2.ForeColor = Color.FromArgb(32, 150, 159);
			this.xrLine2.LocationFloat = new PointFloat(540.1331f, 99.47916f);
			this.xrLine2.Name = "xrLine2";
			this.xrLine2.SizeF = new SizeF(300.4026f, 13f);
			this.xrLine2.StylePriority.UseForeColor = false;
			this.xrLabel4.BackColor = Color.White;
			this.xrLabel4.Dpi = 100f;
			this.xrLabel4.Font = new Font("Times New Roman", 11f, FontStyle.Bold);
			this.xrLabel4.ForeColor = Color.FromArgb(45, 84, 108);
			this.xrLabel4.LocationFloat = new PointFloat(565.4379f, 71.52086f);
			this.xrLabel4.Name = "xrLabel4";
			this.xrLabel4.Padding = new PaddingInfo(2, 2, 0, 2, 100f);
			this.xrLabel4.SizeF = new SizeF(249.9936f, 22.99997f);
			this.xrLabel4.StylePriority.UseBackColor = false;
			this.xrLabel4.StylePriority.UseFont = false;
			this.xrLabel4.StylePriority.UseForeColor = false;
			this.xrLabel4.StylePriority.UsePadding = false;
			this.xrLabel4.StylePriority.UseTextAlignment = false;
			this.xrLabel4.Text = "اختبارات مواقع - تصميم خلطات - دراسات تربة";
			this.xrLabel4.TextAlignment = TextAlignment.TopRight;
			this.xrLabel11.BackColor = Color.White;
			this.xrLabel11.Dpi = 100f;
			this.xrLabel11.Font = new Font("Times New Roman", 11f, FontStyle.Bold);
			this.xrLabel11.ForeColor = Color.FromArgb(45, 84, 108);
			this.xrLabel11.LocationFloat = new PointFloat(565.4379f, 17.52084f);
			this.xrLabel11.Name = "xrLabel11";
			this.xrLabel11.Padding = new PaddingInfo(2, 2, 0, 2, 100f);
			this.xrLabel11.SizeF = new SizeF(249.9937f, 24f);
			this.xrLabel11.StylePriority.UseBackColor = false;
			this.xrLabel11.StylePriority.UseFont = false;
			this.xrLabel11.StylePriority.UseForeColor = false;
			this.xrLabel11.StylePriority.UsePadding = false;
			this.xrLabel11.StylePriority.UseTextAlignment = false;
			this.xrLabel11.Text = "إختبارات ميكانيكية وفزيائية  وكميائية لمواد البناء";
			this.xrLabel11.TextAlignment = TextAlignment.TopRight;
			this.xrPictureBox1.Dpi = 100f;
			this.xrPictureBox1.Image = (Image)resources.GetObject("xrPictureBox1.Image");
			this.xrPictureBox1.LocationFloat = new PointFloat(340.5699f, 17.52084f);
			this.xrPictureBox1.Name = "xrPictureBox1";
			this.xrPictureBox1.SizeF = new SizeF(189.2164f, 94.95832f);
			this.xrLabel16.BackColor = Color.White;
			this.xrLabel16.Dpi = 100f;
			this.xrLabel16.Font = new Font("Times New Roman", 11f, FontStyle.Bold);
			this.xrLabel16.ForeColor = Color.FromArgb(45, 84, 108);
			this.xrLabel16.LocationFloat = new PointFloat(565.4379f, 43.47918f);
			this.xrLabel16.Name = "xrLabel16";
			this.xrLabel16.Padding = new PaddingInfo(2, 2, 0, 2, 100f);
			this.xrLabel16.SizeF = new SizeF(249.9937f, 22.99997f);
			this.xrLabel16.StylePriority.UseBackColor = false;
			this.xrLabel16.StylePriority.UseFont = false;
			this.xrLabel16.StylePriority.UseForeColor = false;
			this.xrLabel16.StylePriority.UsePadding = false;
			this.xrLabel16.StylePriority.UseTextAlignment = false;
			this.xrLabel16.Text = "تربة - اسفلت - حصي - كونكريت - اسمنت - ماء";
			this.xrLabel16.TextAlignment = TextAlignment.TopRight;
			this.xrLabel17.BackColor = Color.White;
			this.xrLabel17.Dpi = 100f;
			this.xrLabel17.Font = new Font("Times New Roman", 9f, FontStyle.Bold);
			this.xrLabel17.ForeColor = Color.FromArgb(45, 84, 103);
			this.xrLabel17.LocationFloat = new PointFloat(3.464294f, 41.52085f);
			this.xrLabel17.Name = "xrLabel17";
			this.xrLabel17.Padding = new PaddingInfo(2, 2, 0, 2, 100f);
			this.xrLabel17.SizeF = new SizeF(310.5137f, 25f);
			this.xrLabel17.StylePriority.UseBackColor = false;
			this.xrLabel17.StylePriority.UseFont = false;
			this.xrLabel17.StylePriority.UseForeColor = false;
			this.xrLabel17.StylePriority.UsePadding = false;
			this.xrLabel17.StylePriority.UseTextAlignment = false;
			this.xrLabel17.Text = "Soil - Asphalt - Aggregate - Concrete - Cement - Water";
			this.xrLabel17.TextAlignment = TextAlignment.TopLeft;
			this.xrLabel18.BackColor = Color.White;
			this.xrLabel18.Dpi = 100f;
			this.xrLabel18.Font = new Font("Times New Roman", 9f, FontStyle.Bold);
			this.xrLabel18.ForeColor = Color.FromArgb(45, 84, 103);
			this.xrLabel18.LocationFloat = new PointFloat(3.464294f, 66.52084f);
			this.xrLabel18.Name = "xrLabel18";
			this.xrLabel18.Padding = new PaddingInfo(2, 2, 0, 2, 100f);
			this.xrLabel18.SizeF = new SizeF(288.8611f, 24f);
			this.xrLabel18.StylePriority.UseBackColor = false;
			this.xrLabel18.StylePriority.UseFont = false;
			this.xrLabel18.StylePriority.UseForeColor = false;
			this.xrLabel18.StylePriority.UsePadding = false;
			this.xrLabel18.StylePriority.UseTextAlignment = false;
			this.xrLabel18.Text = "Site testing - Material design mixes - Soil study";
			this.xrLabel18.TextAlignment = TextAlignment.TopLeft;
			this.xrLine1.Dpi = 100f;
			this.xrLine1.ForeColor = Color.FromArgb(32, 150, 159);
			this.xrLine1.LocationFloat = new PointFloat(4.326614f, 99.47916f);
			this.xrLine1.Name = "xrLine1";
			this.xrLine1.SizeF = new SizeF(300.4026f, 13f);
			this.xrLine1.StylePriority.UseForeColor = false;
			this.xrLabel19.BackColor = Color.White;
			this.xrLabel19.Dpi = 100f;
			this.xrLabel19.Font = new Font("Times New Roman", 9f, FontStyle.Bold);
			this.xrLabel19.ForeColor = Color.FromArgb(45, 84, 103);
			this.xrLabel19.LocationFloat = new PointFloat(3.464294f, 17.52084f);
			this.xrLabel19.Name = "xrLabel19";
			this.xrLabel19.Padding = new PaddingInfo(2, 2, 0, 2, 100f);
			this.xrLabel19.SizeF = new SizeF(285.9722f, 24f);
			this.xrLabel19.StylePriority.UseBackColor = false;
			this.xrLabel19.StylePriority.UseFont = false;
			this.xrLabel19.StylePriority.UseForeColor = false;
			this.xrLabel19.StylePriority.UsePadding = false;
			this.xrLabel19.StylePriority.UseTextAlignment = false;
			this.xrLabel19.Text = "Mechanical , physical and chimical material testing";
			this.xrLabel19.TextAlignment = TextAlignment.TopLeft;
			this.BottomMargin.Controls.AddRange(new XRControl[]
			{
				this.xrPictureBox2,
				this.xrPageInfo2,
				this.xrPageInfo1
			});
			this.BottomMargin.Dpi = 100f;
			this.BottomMargin.HeightF = 114.0417f;
			this.BottomMargin.Name = "BottomMargin";
			this.BottomMargin.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
			this.BottomMargin.TextAlignment = TextAlignment.TopLeft;
			this.xrPictureBox2.Dpi = 100f;
			this.xrPictureBox2.Image = (Image)resources.GetObject("xrPictureBox2.Image");
			this.xrPictureBox2.LocationFloat = new PointFloat(135.5f, 0f);
			this.xrPictureBox2.Name = "xrPictureBox2";
			this.xrPictureBox2.SizeF = new SizeF(581.3381f, 74.20829f);
			this.xrPageInfo2.Dpi = 100f;
			this.xrPageInfo2.Format = "Page {0} of {1}";
			this.xrPageInfo2.LocationFloat = new PointFloat(521.0001f, 91.04169f);
			this.xrPageInfo2.Name = "xrPageInfo2";
			this.xrPageInfo2.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrPageInfo2.SizeF = new SizeF(313f, 23f);
			this.xrPageInfo2.StyleName = "PageInfo";
			this.xrPageInfo2.TextAlignment = TextAlignment.TopRight;
			this.xrPageInfo1.Dpi = 100f;
			this.xrPageInfo1.LocationFloat = new PointFloat(1.478004f, 91.04169f);
			this.xrPageInfo1.Name = "xrPageInfo1";
			this.xrPageInfo1.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
			this.xrPageInfo1.SizeF = new SizeF(313f, 23f);
			this.xrPageInfo1.StyleName = "PageInfo";
			this.pageFooterBand1.Dpi = 100f;
			this.pageFooterBand1.HeightF = 9.208298f;
			this.pageFooterBand1.Name = "pageFooterBand1";
			this.reportHeaderBand1.Dpi = 100f;
			this.reportHeaderBand1.HeightF = 0f;
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
			this.DetailReport.DataMember = "MaterialsDetails.FK_MaterialsDetailsTests_MaterialsDetails";
			this.DetailReport.DataSource = this.sqlDataSource1;
			this.DetailReport.Dpi = 100f;
			this.DetailReport.Level = 0;
			this.DetailReport.Name = "DetailReport";
			this.Detail1.Controls.AddRange(new XRControl[]
			{
				this.xrTable1
			});
			this.Detail1.Dpi = 100f;
			this.Detail1.HeightF = 25f;
			this.Detail1.Name = "Detail1";
			this.xrTable1.Borders = (BorderSide.Left | BorderSide.Right | BorderSide.Bottom);
			this.xrTable1.Dpi = 100f;
			this.xrTable1.LocationFloat = new PointFloat(121.875f, 0f);
			this.xrTable1.Name = "xrTable1";
			this.xrTable1.Rows.AddRange(new XRTableRow[]
			{
				this.xrTableRow1
			});
			this.xrTable1.SizeF = new SizeF(484.5834f, 25f);
			this.xrTable1.StylePriority.UseBorders = false;
			this.xrTable1.StylePriority.UseTextAlignment = false;
			this.xrTable1.TextAlignment = TextAlignment.TopCenter;
			this.xrTableRow1.Cells.AddRange(new XRTableCell[]
			{
				this.xrTableCell1,
				this.xrTableCell2
			});
			this.xrTableRow1.Dpi = 100f;
			this.xrTableRow1.Name = "xrTableRow1";
			this.xrTableRow1.Weight = 11.5;
			this.xrTableCell1.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "MaterialsDetails.FK_MaterialsDetailsTests_MaterialsDetails.TestName")
			});
			this.xrTableCell1.Dpi = 100f;
			this.xrTableCell1.Name = "xrTableCell1";
			this.xrTableCell1.Text = "xrTableCell1";
			this.xrTableCell1.Weight = 0.15503875968992248;
			this.xrTableCell2.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "MaterialsDetails.FK_MaterialsDetailsTests_MaterialsDetails.StandardNumber")
			});
			this.xrTableCell2.Dpi = 100f;
			this.xrTableCell2.Name = "xrTableCell2";
			this.xrTableCell2.Text = "xrTableCell2";
			this.xrTableCell2.Weight = 0.15503875968992248;
			this.GroupHeader1.Controls.AddRange(new XRControl[]
			{
				this.xrTable2
			});
			this.GroupHeader1.Dpi = 100f;
			this.GroupHeader1.Font = new Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.GroupHeader1.HeightF = 35.00001f;
			this.GroupHeader1.Name = "GroupHeader1";
			this.GroupHeader1.RepeatEveryPage = true;
			this.GroupHeader1.StylePriority.UseFont = false;
			this.GroupHeader1.StylePriority.UseTextAlignment = false;
			this.GroupHeader1.TextAlignment = TextAlignment.TopCenter;
			this.xrTable2.BackColor = SystemColors.ScrollBar;
			this.xrTable2.Borders = BorderSide.All;
			this.xrTable2.Dpi = 100f;
			this.xrTable2.LocationFloat = new PointFloat(121.875f, 10.00001f);
			this.xrTable2.Name = "xrTable2";
			this.xrTable2.Rows.AddRange(new XRTableRow[]
			{
				this.xrTableRow2
			});
			this.xrTable2.SizeF = new SizeF(484.5833f, 25f);
			this.xrTable2.StylePriority.UseBackColor = false;
			this.xrTable2.StylePriority.UseBorders = false;
			this.xrTableRow2.Cells.AddRange(new XRTableCell[]
			{
				this.xrTableCell3,
				this.xrTableCell4
			});
			this.xrTableRow2.Dpi = 100f;
			this.xrTableRow2.Name = "xrTableRow2";
			this.xrTableRow2.Weight = 11.5;
			this.xrTableCell3.Dpi = 100f;
			this.xrTableCell3.Name = "xrTableCell3";
			this.xrTableCell3.Text = "Service Name";
			this.xrTableCell3.Weight = 0.15503875968992248;
			this.xrTableCell4.Dpi = 100f;
			this.xrTableCell4.Name = "xrTableCell4";
			this.xrTableCell4.Text = "Standard Number";
			this.xrTableCell4.Weight = 0.15503875968992248;
			this.xrLabel26.Dpi = 100f;
			this.xrLabel26.LocationFloat = new PointFloat(101.125f, 10.00001f);
			this.xrLabel26.Name = "xrLabel26";
			this.xrLabel26.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel26.SizeF = new SizeF(638f, 33f);
			this.xrLabel26.StyleName = "Title";
			this.xrLabel26.StylePriority.UseTextAlignment = false;
			this.xrLabel26.Text = "Material Information";
			this.xrLabel26.TextAlignment = TextAlignment.TopCenter;
			this.PageHeader.Controls.AddRange(new XRControl[]
			{
				this.xrLabel26
			});
			this.PageHeader.Dpi = 100f;
			this.PageHeader.HeightF = 65.625f;
			this.PageHeader.Name = "PageHeader";
			this.Id.Description = "Id";
			dynamicListLookUpSettings.DataAdapter = null;
			dynamicListLookUpSettings.DataMember = "MaterialsDetails";
			dynamicListLookUpSettings.DataSource = this.sqlDataSource1;
			dynamicListLookUpSettings.DisplayMember = "MaterialName";
			dynamicListLookUpSettings.FilterString = null;
			dynamicListLookUpSettings.ValueMember = "MaterialDetailsID";
			this.Id.LookUpSettings = dynamicListLookUpSettings;
			this.Id.Name = "Id";
			this.Id.Type = typeof(int);
			this.Id.ValueInfo = "0";
			base.Bands.AddRange(new Band[]
			{
				this.Detail,
				this.TopMargin,
				this.BottomMargin,
				this.pageFooterBand1,
				this.reportHeaderBand1,
				this.DetailReport,
				this.PageHeader
			});
			base.ComponentStorage.AddRange(new IComponent[]
			{
				this.sqlDataSource1
			});
			base.DataMember = "MaterialsDetails";
			base.DataSource = this.sqlDataSource1;
			this.FilterString = "[MaterialDetailsID] = ?Id";
			base.Margins = new Margins(1, 5, 130, 114);
			base.Parameters.AddRange(new Parameter[]
			{
				this.Id
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
			((ISupportInitialize)this).EndInit();
		}

		// Token: 0x0400080C RID: 2060
		private IContainer components;

		// Token: 0x0400080D RID: 2061
		private DetailBand Detail;

		// Token: 0x0400080E RID: 2062
		private TopMarginBand TopMargin;

		// Token: 0x0400080F RID: 2063
		private BottomMarginBand BottomMargin;

		// Token: 0x04000810 RID: 2064
		private XRLabel xrLabel1;

		// Token: 0x04000811 RID: 2065
		private XRLabel xrLabel2;

		// Token: 0x04000812 RID: 2066
		private XRLabel xrLabel3;

		// Token: 0x04000813 RID: 2067
		private XRLabel xrLabel5;

		// Token: 0x04000814 RID: 2068
		private XRLabel xrLabel6;

		// Token: 0x04000815 RID: 2069
		private XRLabel xrLabel7;

		// Token: 0x04000816 RID: 2070
		private XRLabel xrLabel8;

		// Token: 0x04000817 RID: 2071
		private XRLabel xrLabel9;

		// Token: 0x04000818 RID: 2072
		private XRCheckBox xrCheckBox1;

		// Token: 0x04000819 RID: 2073
		private XRLabel xrLabel10;

		// Token: 0x0400081A RID: 2074
		private XRLabel xrLabel12;

		// Token: 0x0400081B RID: 2075
		private XRLabel xrLabel13;

		// Token: 0x0400081C RID: 2076
		private XRLabel xrLabel14;

		// Token: 0x0400081D RID: 2077
		private XRLabel xrLabel15;

		// Token: 0x0400081E RID: 2078
		private SqlDataSource sqlDataSource1;

		// Token: 0x0400081F RID: 2079
		private PageFooterBand pageFooterBand1;

		// Token: 0x04000820 RID: 2080
		private XRPageInfo xrPageInfo1;

		// Token: 0x04000821 RID: 2081
		private XRPageInfo xrPageInfo2;

		// Token: 0x04000822 RID: 2082
		private ReportHeaderBand reportHeaderBand1;

		// Token: 0x04000823 RID: 2083
		private XRControlStyle Title;

		// Token: 0x04000824 RID: 2084
		private XRControlStyle FieldCaption;

		// Token: 0x04000825 RID: 2085
		private XRControlStyle PageInfo;

		// Token: 0x04000826 RID: 2086
		private XRControlStyle DataField;

		// Token: 0x04000827 RID: 2087
		private DetailReportBand DetailReport;

		// Token: 0x04000828 RID: 2088
		private DetailBand Detail1;

		// Token: 0x04000829 RID: 2089
		private XRTable xrTable1;

		// Token: 0x0400082A RID: 2090
		private XRTableRow xrTableRow1;

		// Token: 0x0400082B RID: 2091
		private XRTableCell xrTableCell1;

		// Token: 0x0400082C RID: 2092
		private XRTableCell xrTableCell2;

		// Token: 0x0400082D RID: 2093
		private GroupHeaderBand GroupHeader1;

		// Token: 0x0400082E RID: 2094
		private XRTable xrTable2;

		// Token: 0x0400082F RID: 2095
		private XRTableRow xrTableRow2;

		// Token: 0x04000830 RID: 2096
		private XRTableCell xrTableCell3;

		// Token: 0x04000831 RID: 2097
		private XRTableCell xrTableCell4;

		// Token: 0x04000832 RID: 2098
		private XRLabel xrLabel26;

		// Token: 0x04000833 RID: 2099
		private PageHeaderBand PageHeader;

		// Token: 0x04000834 RID: 2100
		private XRPictureBox xrPictureBox2;

		// Token: 0x04000835 RID: 2101
		private Parameter Id;

		// Token: 0x04000836 RID: 2102
		private XRLine xrLine2;

		// Token: 0x04000837 RID: 2103
		private XRLabel xrLabel4;

		// Token: 0x04000838 RID: 2104
		private XRLabel xrLabel11;

		// Token: 0x04000839 RID: 2105
		private XRPictureBox xrPictureBox1;

		// Token: 0x0400083A RID: 2106
		private XRLabel xrLabel16;

		// Token: 0x0400083B RID: 2107
		private XRLabel xrLabel17;

		// Token: 0x0400083C RID: 2108
		private XRLabel xrLabel18;

		// Token: 0x0400083D RID: 2109
		private XRLine xrLine1;

		// Token: 0x0400083E RID: 2110
		private XRLabel xrLabel19;
	}
}
