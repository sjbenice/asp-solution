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
	// Token: 0x0200006D RID: 109
	public class ServiceSection : XtraReport
	{
		// Token: 0x06000384 RID: 900 RVA: 0x00004621 File Offset: 0x00002821
		public ServiceSection()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000385 RID: 901 RVA: 0x0000462F File Offset: 0x0000282F
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000386 RID: 902 RVA: 0x0005F9C4 File Offset: 0x0005DBC4
		private void InitializeComponent()
		{
			this.components = new Container();
			CustomSqlQuery customSqlQuery = new CustomSqlQuery();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServiceSection));
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(ServiceSection));
			CustomSqlQuery customSqlQuery2 = new CustomSqlQuery();
			CustomSqlQuery customSqlQuery3 = new CustomSqlQuery();
			MasterDetailInfo masterDetailInfo = new MasterDetailInfo();
			RelationColumnInfo relationColumnInfo = new RelationColumnInfo();
			MasterDetailInfo masterDetailInfo2 = new MasterDetailInfo();
			RelationColumnInfo relationColumnInfo2 = new RelationColumnInfo();
			DynamicListLookUpSettings dynamicListLookUpSettings = new DynamicListLookUpSettings();
			this.sqlDataSource1 = new SqlDataSource(this.components);
			this.Detail = new DetailBand();
			this.xrTable2 = new XRTable();
			this.xrTableRow2 = new XRTableRow();
			this.xrTableCell4 = new XRTableCell();
			this.xrTableCell5 = new XRTableCell();
			this.xrTableCell6 = new XRTableCell();
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
			this.xrPictureBox2 = new XRPictureBox();
			this.xrPageInfo2 = new XRPageInfo();
			this.xrPageInfo1 = new XRPageInfo();
			this.pageFooterBand1 = new PageFooterBand();
			this.reportHeaderBand1 = new ReportHeaderBand();
			this.xrLabel10 = new XRLabel();
			this.Title = new XRControlStyle();
			this.FieldCaption = new XRControlStyle();
			this.PageInfo = new XRControlStyle();
			this.DataField = new XRControlStyle();
			this.GroupHeader1 = new GroupHeaderBand();
			this.xrTable1 = new XRTable();
			this.xrTableRow1 = new XRTableRow();
			this.xrTableCell1 = new XRTableCell();
			this.xrTableCell2 = new XRTableCell();
			this.xrTableCell3 = new XRTableCell();
			this.DetailReport = new DetailReportBand();
			this.Detail1 = new DetailBand();
			this.xrTable3 = new XRTable();
			this.xrTableRow3 = new XRTableRow();
			this.xrTableCell7 = new XRTableCell();
			this.xrTableCell8 = new XRTableCell();
			this.xrTableCell9 = new XRTableCell();
			this.xrTableCell10 = new XRTableCell();
			this.GroupHeader2 = new GroupHeaderBand();
			this.xrRichText1 = new XRRichText();
			this.xrTable4 = new XRTable();
			this.xrTableRow4 = new XRTableRow();
			this.xrTableCell11 = new XRTableCell();
			this.xrTableCell12 = new XRTableCell();
			this.xrTableCell13 = new XRTableCell();
			this.xrTableCell14 = new XRTableCell();
			this.DetailReport1 = new DetailReportBand();
			this.Detail2 = new DetailBand();
			this.xrTable6 = new XRTable();
			this.xrTableRow6 = new XRTableRow();
			this.xrTableCell19 = new XRTableCell();
			this.xrTableCell21 = new XRTableCell();
			this.xrTableCell22 = new XRTableCell();
			this.GroupHeader3 = new GroupHeaderBand();
			this.xrRichText2 = new XRRichText();
			this.xrTable5 = new XRTable();
			this.xrTableRow5 = new XRTableRow();
			this.xrTableCell15 = new XRTableCell();
			this.xrTableCell17 = new XRTableCell();
			this.xrTableCell18 = new XRTableCell();
			this.Id = new Parameter();
			((ISupportInitialize)this.xrTable2).BeginInit();
			((ISupportInitialize)this.xrTable1).BeginInit();
			((ISupportInitialize)this.xrTable3).BeginInit();
			((ISupportInitialize)this.xrRichText1).BeginInit();
			((ISupportInitialize)this.xrTable4).BeginInit();
			((ISupportInitialize)this.xrTable6).BeginInit();
			((ISupportInitialize)this.xrRichText2).BeginInit();
			((ISupportInitialize)this.xrTable5).BeginInit();
			((ISupportInitialize)this).BeginInit();
			this.sqlDataSource1.ConnectionName = "localhost_LabSys_Connection";
			this.sqlDataSource1.Name = "sqlDataSource1";
			customSqlQuery.Name = "MaterialsTypes";
			customSqlQuery.Sql = resources.GetString("customSqlQuery1.Sql");
			customSqlQuery2.Name = "MaterialTypesCustomFields";
			customSqlQuery2.Sql = resources.GetString("customSqlQuery2.Sql");
			customSqlQuery3.Name = "MaterialTypesTableCustomFields";
			customSqlQuery3.Sql = resources.GetString("customSqlQuery3.Sql");
			this.sqlDataSource1.Queries.AddRange(new SqlQuery[]
			{
				customSqlQuery,
				customSqlQuery2,
				customSqlQuery3
			});
			masterDetailInfo.DetailQueryName = "MaterialTypesCustomFields";
			relationColumnInfo.NestedKeyColumn = "FKMaterialTypeID";
			relationColumnInfo.ParentKeyColumn = "MaterialTypeID";
			masterDetailInfo.KeyColumns.Add(relationColumnInfo);
			masterDetailInfo.MasterQueryName = "MaterialsTypes";
			masterDetailInfo.Name = "FK_MaterialTypesCustomFields_MaterialsTypes";
			masterDetailInfo2.DetailQueryName = "MaterialTypesTableCustomFields";
			relationColumnInfo2.NestedKeyColumn = "FKMaterialTypeID";
			relationColumnInfo2.ParentKeyColumn = "MaterialTypeID";
			masterDetailInfo2.KeyColumns.Add(relationColumnInfo2);
			masterDetailInfo2.MasterQueryName = "MaterialsTypes";
			masterDetailInfo2.Name = "FK_MaterialTypesCustomFields_MaterialsTypes_1";
			this.sqlDataSource1.Relations.AddRange(new MasterDetailInfo[]
			{
				masterDetailInfo,
				masterDetailInfo2
			});
			this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
			this.Detail.Controls.AddRange(new XRControl[]
			{
				this.xrTable2
			});
			this.Detail.Dpi = 100f;
			this.Detail.HeightF = 25f;
			this.Detail.KeepTogether = true;
			this.Detail.KeepTogetherWithDetailReports = true;
			this.Detail.Name = "Detail";
			this.Detail.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
			this.Detail.TextAlignment = TextAlignment.TopLeft;
			this.xrTable2.Borders = (BorderSide.Left | BorderSide.Right | BorderSide.Bottom);
			this.xrTable2.Dpi = 100f;
			this.xrTable2.Font = new Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTable2.LocationFloat = new PointFloat(0f, 0f);
			this.xrTable2.Name = "xrTable2";
			this.xrTable2.Padding = new PaddingInfo(5, 0, 0, 0, 100f);
			this.xrTable2.Rows.AddRange(new XRTableRow[]
			{
				this.xrTableRow2
			});
			this.xrTable2.SizeF = new SizeF(849f, 25f);
			this.xrTable2.StylePriority.UseBorders = false;
			this.xrTable2.StylePriority.UseFont = false;
			this.xrTable2.StylePriority.UsePadding = false;
			this.xrTableRow2.Cells.AddRange(new XRTableCell[]
			{
				this.xrTableCell4,
				this.xrTableCell5,
				this.xrTableCell6
			});
			this.xrTableRow2.Dpi = 100f;
			this.xrTableRow2.Name = "xrTableRow2";
			this.xrTableRow2.Weight = 11.5;
			this.xrTableCell4.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "MaterialsTypes.MaterialName")
			});
			this.xrTableCell4.Dpi = 100f;
			this.xrTableCell4.Name = "xrTableCell4";
			this.xrTableCell4.Text = "xrTableCell4";
			this.xrTableCell4.Weight = 0.259922212249615;
			this.xrTableCell5.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "MaterialsTypes.LabName")
			});
			this.xrTableCell5.Dpi = 100f;
			this.xrTableCell5.Name = "xrTableCell5";
			this.xrTableCell5.Text = "xrTableCell5";
			this.xrTableCell5.Weight = 0.21097894436665482;
			this.xrTableCell6.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "MaterialsTypes.Column6")
			});
			this.xrTableCell6.Dpi = 100f;
			this.xrTableCell6.Name = "xrTableCell6";
			this.xrTableCell6.Weight = 0.07554693081542412;
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
			this.xrLine2.LocationFloat = new PointFloat(542.6331f, 99.47916f);
			this.xrLine2.Name = "xrLine2";
			this.xrLine2.SizeF = new SizeF(300.4026f, 13f);
			this.xrLine2.StylePriority.UseForeColor = false;
			this.xrLabel7.BackColor = Color.White;
			this.xrLabel7.Dpi = 100f;
			this.xrLabel7.Font = new Font("Times New Roman", 11f, FontStyle.Bold);
			this.xrLabel7.ForeColor = Color.FromArgb(45, 84, 108);
			this.xrLabel7.LocationFloat = new PointFloat(567.9379f, 71.52086f);
			this.xrLabel7.Name = "xrLabel7";
			this.xrLabel7.Padding = new PaddingInfo(2, 2, 0, 2, 100f);
			this.xrLabel7.SizeF = new SizeF(249.9936f, 22.99997f);
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
			this.xrLabel3.LocationFloat = new PointFloat(567.9379f, 17.52084f);
			this.xrLabel3.Name = "xrLabel3";
			this.xrLabel3.Padding = new PaddingInfo(2, 2, 0, 2, 100f);
			this.xrLabel3.SizeF = new SizeF(249.9937f, 24f);
			this.xrLabel3.StylePriority.UseBackColor = false;
			this.xrLabel3.StylePriority.UseFont = false;
			this.xrLabel3.StylePriority.UseForeColor = false;
			this.xrLabel3.StylePriority.UsePadding = false;
			this.xrLabel3.StylePriority.UseTextAlignment = false;
			this.xrLabel3.Text = "إختبارات ميكانيكية وفزيائية  وكميائية لمواد البناء";
			this.xrLabel3.TextAlignment = TextAlignment.TopRight;
			this.xrPictureBox1.Dpi = 100f;
			this.xrPictureBox1.Image = (Image)resources.GetObject("xrPictureBox1.Image");
			this.xrPictureBox1.LocationFloat = new PointFloat(343.0699f, 17.52084f);
			this.xrPictureBox1.Name = "xrPictureBox1";
			this.xrPictureBox1.SizeF = new SizeF(189.2164f, 94.95832f);
			this.xrLabel8.BackColor = Color.White;
			this.xrLabel8.Dpi = 100f;
			this.xrLabel8.Font = new Font("Times New Roman", 11f, FontStyle.Bold);
			this.xrLabel8.ForeColor = Color.FromArgb(45, 84, 108);
			this.xrLabel8.LocationFloat = new PointFloat(567.9379f, 43.47918f);
			this.xrLabel8.Name = "xrLabel8";
			this.xrLabel8.Padding = new PaddingInfo(2, 2, 0, 2, 100f);
			this.xrLabel8.SizeF = new SizeF(249.9937f, 22.99997f);
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
			this.xrLabel4.LocationFloat = new PointFloat(5.964294f, 41.52085f);
			this.xrLabel4.Name = "xrLabel4";
			this.xrLabel4.Padding = new PaddingInfo(2, 2, 0, 2, 100f);
			this.xrLabel4.SizeF = new SizeF(310.5137f, 25f);
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
			this.xrLabel5.LocationFloat = new PointFloat(5.964294f, 66.52084f);
			this.xrLabel5.Name = "xrLabel5";
			this.xrLabel5.Padding = new PaddingInfo(2, 2, 0, 2, 100f);
			this.xrLabel5.SizeF = new SizeF(288.8611f, 24f);
			this.xrLabel5.StylePriority.UseBackColor = false;
			this.xrLabel5.StylePriority.UseFont = false;
			this.xrLabel5.StylePriority.UseForeColor = false;
			this.xrLabel5.StylePriority.UsePadding = false;
			this.xrLabel5.StylePriority.UseTextAlignment = false;
			this.xrLabel5.Text = "Site testing - Material design mixes - Soil study";
			this.xrLabel5.TextAlignment = TextAlignment.TopLeft;
			this.xrLine1.Dpi = 100f;
			this.xrLine1.ForeColor = Color.FromArgb(32, 150, 159);
			this.xrLine1.LocationFloat = new PointFloat(6.826614f, 99.47916f);
			this.xrLine1.Name = "xrLine1";
			this.xrLine1.SizeF = new SizeF(300.4026f, 13f);
			this.xrLine1.StylePriority.UseForeColor = false;
			this.xrLabel2.BackColor = Color.White;
			this.xrLabel2.Dpi = 100f;
			this.xrLabel2.Font = new Font("Times New Roman", 9f, FontStyle.Bold);
			this.xrLabel2.ForeColor = Color.FromArgb(45, 84, 103);
			this.xrLabel2.LocationFloat = new PointFloat(5.964294f, 17.52084f);
			this.xrLabel2.Name = "xrLabel2";
			this.xrLabel2.Padding = new PaddingInfo(2, 2, 0, 2, 100f);
			this.xrLabel2.SizeF = new SizeF(285.9722f, 24f);
			this.xrLabel2.StylePriority.UseBackColor = false;
			this.xrLabel2.StylePriority.UseFont = false;
			this.xrLabel2.StylePriority.UseForeColor = false;
			this.xrLabel2.StylePriority.UsePadding = false;
			this.xrLabel2.StylePriority.UseTextAlignment = false;
			this.xrLabel2.Text = "Mechanical , physical and chimical material testing";
			this.xrLabel2.TextAlignment = TextAlignment.TopLeft;
			this.BottomMargin.Controls.AddRange(new XRControl[]
			{
				this.xrPictureBox2,
				this.xrPageInfo2,
				this.xrPageInfo1
			});
			this.BottomMargin.Dpi = 100f;
			this.BottomMargin.HeightF = 141.8333f;
			this.BottomMargin.Name = "BottomMargin";
			this.BottomMargin.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
			this.BottomMargin.TextAlignment = TextAlignment.TopLeft;
			this.xrPictureBox2.Dpi = 100f;
			this.xrPictureBox2.Image = (Image)resources.GetObject("xrPictureBox2.Image");
			this.xrPictureBox2.LocationFloat = new PointFloat(131.25f, 10.00001f);
			this.xrPictureBox2.Name = "xrPictureBox2";
			this.xrPictureBox2.SizeF = new SizeF(581.3381f, 74.20829f);
			this.xrPageInfo2.Dpi = 100f;
			this.xrPageInfo2.Format = "Page {0} of {1}";
			this.xrPageInfo2.LocationFloat = new PointFloat(501.8333f, 108.8333f);
			this.xrPageInfo2.Name = "xrPageInfo2";
			this.xrPageInfo2.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrPageInfo2.SizeF = new SizeF(313f, 23f);
			this.xrPageInfo2.StyleName = "PageInfo";
			this.xrPageInfo2.TextAlignment = TextAlignment.TopRight;
			this.xrPageInfo1.Dpi = 100f;
			this.xrPageInfo1.LocationFloat = new PointFloat(9.999998f, 108.8333f);
			this.xrPageInfo1.Name = "xrPageInfo1";
			this.xrPageInfo1.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
			this.xrPageInfo1.SizeF = new SizeF(313f, 23f);
			this.xrPageInfo1.StyleName = "PageInfo";
			this.pageFooterBand1.Dpi = 100f;
			this.pageFooterBand1.Expanded = false;
			this.pageFooterBand1.HeightF = 7.124996f;
			this.pageFooterBand1.Name = "pageFooterBand1";
			this.reportHeaderBand1.Controls.AddRange(new XRControl[]
			{
				this.xrLabel10
			});
			this.reportHeaderBand1.Dpi = 100f;
			this.reportHeaderBand1.HeightF = 80.16666f;
			this.reportHeaderBand1.KeepTogether = true;
			this.reportHeaderBand1.Name = "reportHeaderBand1";
			this.xrLabel10.Dpi = 100f;
			this.xrLabel10.LocationFloat = new PointFloat(6.000002f, 6.00001f);
			this.xrLabel10.Name = "xrLabel10";
			this.xrLabel10.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel10.SizeF = new SizeF(833f, 33f);
			this.xrLabel10.StyleName = "Title";
			this.xrLabel10.StylePriority.UseTextAlignment = false;
			this.xrLabel10.Text = "Service Section";
			this.xrLabel10.TextAlignment = TextAlignment.TopCenter;
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
			this.GroupHeader1.Controls.AddRange(new XRControl[]
			{
				this.xrTable1
			});
			this.GroupHeader1.Dpi = 100f;
			this.GroupHeader1.HeightF = 26.04167f;
			this.GroupHeader1.KeepTogether = true;
			this.GroupHeader1.Name = "GroupHeader1";
			this.GroupHeader1.RepeatEveryPage = true;
			this.xrTable1.BackColor = Color.LightGray;
			this.xrTable1.Borders = BorderSide.All;
			this.xrTable1.Dpi = 100f;
			this.xrTable1.Font = new Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTable1.LocationFloat = new PointFloat(0f, 0f);
			this.xrTable1.Name = "xrTable1";
			this.xrTable1.Padding = new PaddingInfo(6, 0, 0, 0, 100f);
			this.xrTable1.Rows.AddRange(new XRTableRow[]
			{
				this.xrTableRow1
			});
			this.xrTable1.SizeF = new SizeF(849f, 25f);
			this.xrTable1.StylePriority.UseBackColor = false;
			this.xrTable1.StylePriority.UseBorders = false;
			this.xrTable1.StylePriority.UseFont = false;
			this.xrTable1.StylePriority.UsePadding = false;
			this.xrTable1.StylePriority.UseTextAlignment = false;
			this.xrTable1.TextAlignment = TextAlignment.TopLeft;
			this.xrTableRow1.Cells.AddRange(new XRTableCell[]
			{
				this.xrTableCell1,
				this.xrTableCell2,
				this.xrTableCell3
			});
			this.xrTableRow1.Dpi = 100f;
			this.xrTableRow1.Name = "xrTableRow1";
			this.xrTableRow1.Weight = 11.5;
			this.xrTableCell1.Dpi = 100f;
			this.xrTableCell1.Name = "xrTableCell1";
			this.xrTableCell1.Text = "Service Section Name";
			this.xrTableCell1.Weight = 0.259922212249615;
			this.xrTableCell2.Dpi = 100f;
			this.xrTableCell2.Name = "xrTableCell2";
			this.xrTableCell2.Text = "Lab Section";
			this.xrTableCell2.Weight = 0.21097894436665482;
			this.xrTableCell3.Dpi = 100f;
			this.xrTableCell3.Name = "xrTableCell3";
			this.xrTableCell3.Text = "Inactive";
			this.xrTableCell3.Weight = 0.07554693081542412;
			this.DetailReport.Bands.AddRange(new Band[]
			{
				this.Detail1,
				this.GroupHeader2
			});
			this.DetailReport.DataMember = "MaterialsTypes.FK_MaterialTypesCustomFields_MaterialsTypes";
			this.DetailReport.DataSource = this.sqlDataSource1;
			this.DetailReport.Dpi = 100f;
			this.DetailReport.Level = 0;
			this.DetailReport.Name = "DetailReport";
			this.Detail1.Controls.AddRange(new XRControl[]
			{
				this.xrTable3
			});
			this.Detail1.Dpi = 100f;
			this.Detail1.HeightF = 25f;
			this.Detail1.Name = "Detail1";
			this.xrTable3.Borders = (BorderSide.Left | BorderSide.Right | BorderSide.Bottom);
			this.xrTable3.Dpi = 100f;
			this.xrTable3.LocationFloat = new PointFloat(0f, 0f);
			this.xrTable3.Name = "xrTable3";
			this.xrTable3.Padding = new PaddingInfo(5, 0, 0, 0, 100f);
			this.xrTable3.Rows.AddRange(new XRTableRow[]
			{
				this.xrTableRow3
			});
			this.xrTable3.SizeF = new SizeF(849f, 25f);
			this.xrTable3.StylePriority.UseBorders = false;
			this.xrTable3.StylePriority.UsePadding = false;
			this.xrTableRow3.Cells.AddRange(new XRTableCell[]
			{
				this.xrTableCell7,
				this.xrTableCell8,
				this.xrTableCell9,
				this.xrTableCell10
			});
			this.xrTableRow3.Dpi = 100f;
			this.xrTableRow3.Name = "xrTableRow3";
			this.xrTableRow3.Weight = 11.5;
			this.xrTableCell7.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "MaterialsTypes.FK_MaterialTypesCustomFields_MaterialsTypes.CustomFieldName")
			});
			this.xrTableCell7.Dpi = 100f;
			this.xrTableCell7.Name = "xrTableCell7";
			this.xrTableCell7.Text = "xrTableCell7";
			this.xrTableCell7.Weight = 0.35998844205960245;
			this.xrTableCell8.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "MaterialsTypes.FK_MaterialTypesCustomFields_MaterialsTypes.Column9")
			});
			this.xrTableCell8.Dpi = 100f;
			this.xrTableCell8.Name = "xrTableCell8";
			this.xrTableCell8.Weight = 0.27891334466183854;
			this.xrTableCell9.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "MaterialsTypes.FK_MaterialTypesCustomFields_MaterialsTypes.Column8")
			});
			this.xrTableCell9.Dpi = 100f;
			this.xrTableCell9.Name = "xrTableCell9";
			this.xrTableCell9.Weight = 0.12880343965519506;
			this.xrTableCell10.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "MaterialsTypes.FK_MaterialTypesCustomFields_MaterialsTypes.Column7")
			});
			this.xrTableCell10.Dpi = 100f;
			this.xrTableCell10.Name = "xrTableCell10";
			this.xrTableCell10.Weight = 0.12316337050532397;
			this.GroupHeader2.Controls.AddRange(new XRControl[]
			{
				this.xrRichText1,
				this.xrTable4
			});
			this.GroupHeader2.Dpi = 100f;
			this.GroupHeader2.HeightF = 48.95833f;
			this.GroupHeader2.Name = "GroupHeader2";
			this.GroupHeader2.RepeatEveryPage = true;
			this.xrRichText1.BackColor = Color.LightBlue;
			this.xrRichText1.Dpi = 100f;
			this.xrRichText1.Font = new Font("Times New Roman", 11f, FontStyle.Bold);
			this.xrRichText1.LocationFloat = new PointFloat(0f, 0f);
			this.xrRichText1.Name = "xrRichText1";
			//this.xrRichText1.SerializableRtfString = resources.GetString("xrRichText1.SerializableRtfString");
			this.xrRichText1.SizeF = new SizeF(212.25f, 23f);
			this.xrRichText1.StylePriority.UseBackColor = false;
			this.xrRichText1.StylePriority.UseFont = false;
			this.xrTable4.BackColor = Color.WhiteSmoke;
			this.xrTable4.Borders = BorderSide.All;
			this.xrTable4.Dpi = 100f;
			this.xrTable4.Font = new Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTable4.LocationFloat = new PointFloat(0f, 22.99999f);
			this.xrTable4.Name = "xrTable4";
			this.xrTable4.Padding = new PaddingInfo(5, 0, 0, 0, 100f);
			this.xrTable4.Rows.AddRange(new XRTableRow[]
			{
				this.xrTableRow4
			});
			this.xrTable4.SizeF = new SizeF(849f, 25f);
			this.xrTable4.StylePriority.UseBackColor = false;
			this.xrTable4.StylePriority.UseBorders = false;
			this.xrTable4.StylePriority.UseFont = false;
			this.xrTable4.StylePriority.UsePadding = false;
			this.xrTableRow4.Cells.AddRange(new XRTableCell[]
			{
				this.xrTableCell11,
				this.xrTableCell12,
				this.xrTableCell13,
				this.xrTableCell14
			});
			this.xrTableRow4.Dpi = 100f;
			this.xrTableRow4.Name = "xrTableRow4";
			this.xrTableRow4.Weight = 11.5;
			this.xrTableCell11.Dpi = 100f;
			this.xrTableCell11.Name = "xrTableCell11";
			this.xrTableCell11.Text = "Field Name";
			this.xrTableCell11.Weight = 0.35998844205960245;
			this.xrTableCell12.Dpi = 100f;
			this.xrTableCell12.Name = "xrTableCell12";
			this.xrTableCell12.Text = "Type";
			this.xrTableCell12.Weight = 0.27891334466183854;
			this.xrTableCell13.Dpi = 100f;
			this.xrTableCell13.Name = "xrTableCell13";
			this.xrTableCell13.Text = "IsRequired";
			this.xrTableCell13.Weight = 0.12880343965519506;
			this.xrTableCell14.Dpi = 100f;
			this.xrTableCell14.Name = "xrTableCell14";
			this.xrTableCell14.Text = "Inactive";
			this.xrTableCell14.Weight = 0.12316337050532397;
			this.DetailReport1.Bands.AddRange(new Band[]
			{
				this.Detail2,
				this.GroupHeader3
			});
			this.DetailReport1.DataMember = "MaterialsTypes.FK_MaterialTypesCustomFields_MaterialsTypes_1";
			this.DetailReport1.DataSource = this.sqlDataSource1;
			this.DetailReport1.Dpi = 100f;
			this.DetailReport1.Level = 1;
			this.DetailReport1.Name = "DetailReport1";
			this.DetailReport1.PageBreak = PageBreak.AfterBand;
			this.Detail2.Controls.AddRange(new XRControl[]
			{
				this.xrTable6
			});
			this.Detail2.Dpi = 100f;
			this.Detail2.HeightF = 25f;
			this.Detail2.Name = "Detail2";
			this.xrTable6.Borders = (BorderSide.Left | BorderSide.Right | BorderSide.Bottom);
			this.xrTable6.Dpi = 100f;
			this.xrTable6.LocationFloat = new PointFloat(0f, 0f);
			this.xrTable6.Name = "xrTable6";
			this.xrTable6.Padding = new PaddingInfo(5, 0, 0, 0, 100f);
			this.xrTable6.Rows.AddRange(new XRTableRow[]
			{
				this.xrTableRow6
			});
			this.xrTable6.SizeF = new SizeF(848.9999f, 25f);
			this.xrTable6.StylePriority.UseBorders = false;
			this.xrTable6.StylePriority.UsePadding = false;
			this.xrTableRow6.Cells.AddRange(new XRTableCell[]
			{
				this.xrTableCell19,
				this.xrTableCell21,
				this.xrTableCell22
			});
			this.xrTableRow6.Dpi = 100f;
			this.xrTableRow6.Name = "xrTableRow6";
			this.xrTableRow6.Weight = 11.5;
			this.xrTableCell19.Borders = (BorderSide.Left | BorderSide.Right | BorderSide.Bottom);
			this.xrTableCell19.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "MaterialsTypes.FK_MaterialTypesCustomFields_MaterialsTypes_1.CustomFieldName")
			});
			this.xrTableCell19.Dpi = 100f;
			this.xrTableCell19.Name = "xrTableCell19";
			this.xrTableCell19.Padding = new PaddingInfo(5, 0, 0, 0, 100f);
			this.xrTableCell19.StylePriority.UseBorders = false;
			this.xrTableCell19.StylePriority.UsePadding = false;
			this.xrTableCell19.Text = "xrTableCell19";
			this.xrTableCell19.Weight = 0.638901786721441;
			this.xrTableCell21.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "MaterialsTypes.FK_MaterialTypesCustomFields_MaterialsTypes_1.Column8")
			});
			this.xrTableCell21.Dpi = 100f;
			this.xrTableCell21.Name = "xrTableCell21";
			this.xrTableCell21.Weight = 0.12880343965519503;
			this.xrTableCell22.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "MaterialsTypes.FK_MaterialTypesCustomFields_MaterialsTypes_1.Column7")
			});
			this.xrTableCell22.Dpi = 100f;
			this.xrTableCell22.Name = "xrTableCell22";
			this.xrTableCell22.Weight = 0.1231633064602074;
			this.GroupHeader3.Controls.AddRange(new XRControl[]
			{
				this.xrRichText2,
				this.xrTable5
			});
			this.GroupHeader3.Dpi = 100f;
			this.GroupHeader3.HeightF = 47.99998f;
			this.GroupHeader3.Name = "GroupHeader3";
			this.GroupHeader3.RepeatEveryPage = true;
			this.xrRichText2.BackColor = Color.LightBlue;
			this.xrRichText2.Dpi = 100f;
			this.xrRichText2.Font = new Font("Times New Roman", 11f, FontStyle.Bold);
			this.xrRichText2.LocationFloat = new PointFloat(0f, 0f);
			this.xrRichText2.Name = "xrRichText2";
			//this.xrRichText2.SerializableRtfString = resources.GetString("xrRichText2.SerializableRtfString");
			this.xrRichText2.SizeF = new SizeF(212.25f, 23f);
			this.xrRichText2.StylePriority.UseBackColor = false;
			this.xrRichText2.StylePriority.UseFont = false;
			this.xrTable5.BackColor = Color.WhiteSmoke;
			this.xrTable5.Borders = BorderSide.All;
			this.xrTable5.Dpi = 100f;
			this.xrTable5.Font = new Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTable5.LocationFloat = new PointFloat(0f, 22.99999f);
			this.xrTable5.Name = "xrTable5";
			this.xrTable5.Padding = new PaddingInfo(5, 0, 0, 0, 100f);
			this.xrTable5.Rows.AddRange(new XRTableRow[]
			{
				this.xrTableRow5
			});
			this.xrTable5.SizeF = new SizeF(849f, 25f);
			this.xrTable5.StylePriority.UseBackColor = false;
			this.xrTable5.StylePriority.UseBorders = false;
			this.xrTable5.StylePriority.UseFont = false;
			this.xrTable5.StylePriority.UsePadding = false;
			this.xrTableRow5.Cells.AddRange(new XRTableCell[]
			{
				this.xrTableCell15,
				this.xrTableCell17,
				this.xrTableCell18
			});
			this.xrTableRow5.Dpi = 100f;
			this.xrTableRow5.Name = "xrTableRow5";
			this.xrTableRow5.Weight = 11.5;
			this.xrTableCell15.Dpi = 100f;
			this.xrTableCell15.Name = "xrTableCell15";
			this.xrTableCell15.Text = "Field Name";
			this.xrTableCell15.Weight = 0.638901786721441;
			this.xrTableCell17.Dpi = 100f;
			this.xrTableCell17.Name = "xrTableCell17";
			this.xrTableCell17.Text = "IsRequired";
			this.xrTableCell17.Weight = 0.12880343965519508;
			this.xrTableCell18.Dpi = 100f;
			this.xrTableCell18.Name = "xrTableCell18";
			this.xrTableCell18.Text = "Inactive";
			this.xrTableCell18.Weight = 0.12316337050532397;
			this.Id.Description = "Id";
			dynamicListLookUpSettings.DataAdapter = null;
			dynamicListLookUpSettings.DataMember = "MaterialsTypes";
			dynamicListLookUpSettings.DataSource = this.sqlDataSource1;
			dynamicListLookUpSettings.DisplayMember = "MaterialName";
			dynamicListLookUpSettings.FilterString = null;
			dynamicListLookUpSettings.ValueMember = "MaterialTypeID";
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
				this.GroupHeader1,
				this.DetailReport,
				this.DetailReport1
			});
			base.ComponentStorage.AddRange(new IComponent[]
			{
				this.sqlDataSource1
			});
			base.DataMember = "MaterialsTypes";
			base.DataSource = this.sqlDataSource1;
			this.FilterString = "[MaterialTypeID] = ?Id";
			base.Margins = new Margins(0, 1, 130, 142);
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
			((ISupportInitialize)this.xrTable2).EndInit();
			((ISupportInitialize)this.xrTable1).EndInit();
			((ISupportInitialize)this.xrTable3).EndInit();
			((ISupportInitialize)this.xrRichText1).EndInit();
			((ISupportInitialize)this.xrTable4).EndInit();
			((ISupportInitialize)this.xrTable6).EndInit();
			((ISupportInitialize)this.xrRichText2).EndInit();
			((ISupportInitialize)this.xrTable5).EndInit();
			((ISupportInitialize)this).EndInit();
		}

		// Token: 0x04000B56 RID: 2902
		private IContainer components;

		// Token: 0x04000B57 RID: 2903
		private DetailBand Detail;

		// Token: 0x04000B58 RID: 2904
		private TopMarginBand TopMargin;

		// Token: 0x04000B59 RID: 2905
		private BottomMarginBand BottomMargin;

		// Token: 0x04000B5A RID: 2906
		private XRPageInfo xrPageInfo2;

		// Token: 0x04000B5B RID: 2907
		private XRPageInfo xrPageInfo1;

		// Token: 0x04000B5C RID: 2908
		private SqlDataSource sqlDataSource1;

		// Token: 0x04000B5D RID: 2909
		private PageFooterBand pageFooterBand1;

		// Token: 0x04000B5E RID: 2910
		private ReportHeaderBand reportHeaderBand1;

		// Token: 0x04000B5F RID: 2911
		private XRLabel xrLabel10;

		// Token: 0x04000B60 RID: 2912
		private XRControlStyle Title;

		// Token: 0x04000B61 RID: 2913
		private XRControlStyle FieldCaption;

		// Token: 0x04000B62 RID: 2914
		private XRControlStyle PageInfo;

		// Token: 0x04000B63 RID: 2915
		private XRControlStyle DataField;

		// Token: 0x04000B64 RID: 2916
		private XRPictureBox xrPictureBox2;

		// Token: 0x04000B65 RID: 2917
		private XRTable xrTable2;

		// Token: 0x04000B66 RID: 2918
		private XRTableRow xrTableRow2;

		// Token: 0x04000B67 RID: 2919
		private XRTableCell xrTableCell4;

		// Token: 0x04000B68 RID: 2920
		private XRTableCell xrTableCell5;

		// Token: 0x04000B69 RID: 2921
		private XRTableCell xrTableCell6;

		// Token: 0x04000B6A RID: 2922
		private GroupHeaderBand GroupHeader1;

		// Token: 0x04000B6B RID: 2923
		private XRTable xrTable1;

		// Token: 0x04000B6C RID: 2924
		private XRTableRow xrTableRow1;

		// Token: 0x04000B6D RID: 2925
		private XRTableCell xrTableCell1;

		// Token: 0x04000B6E RID: 2926
		private XRTableCell xrTableCell2;

		// Token: 0x04000B6F RID: 2927
		private XRTableCell xrTableCell3;

		// Token: 0x04000B70 RID: 2928
		private DetailReportBand DetailReport;

		// Token: 0x04000B71 RID: 2929
		private DetailBand Detail1;

		// Token: 0x04000B72 RID: 2930
		private XRTable xrTable3;

		// Token: 0x04000B73 RID: 2931
		private XRTableRow xrTableRow3;

		// Token: 0x04000B74 RID: 2932
		private XRTableCell xrTableCell7;

		// Token: 0x04000B75 RID: 2933
		private XRTableCell xrTableCell8;

		// Token: 0x04000B76 RID: 2934
		private XRTableCell xrTableCell9;

		// Token: 0x04000B77 RID: 2935
		private XRTableCell xrTableCell10;

		// Token: 0x04000B78 RID: 2936
		private GroupHeaderBand GroupHeader2;

		// Token: 0x04000B79 RID: 2937
		private XRRichText xrRichText1;

		// Token: 0x04000B7A RID: 2938
		private XRTable xrTable4;

		// Token: 0x04000B7B RID: 2939
		private XRTableRow xrTableRow4;

		// Token: 0x04000B7C RID: 2940
		private XRTableCell xrTableCell11;

		// Token: 0x04000B7D RID: 2941
		private XRTableCell xrTableCell12;

		// Token: 0x04000B7E RID: 2942
		private XRTableCell xrTableCell13;

		// Token: 0x04000B7F RID: 2943
		private XRTableCell xrTableCell14;

		// Token: 0x04000B80 RID: 2944
		private DetailReportBand DetailReport1;

		// Token: 0x04000B81 RID: 2945
		private DetailBand Detail2;

		// Token: 0x04000B82 RID: 2946
		private XRTable xrTable6;

		// Token: 0x04000B83 RID: 2947
		private XRTableRow xrTableRow6;

		// Token: 0x04000B84 RID: 2948
		private XRTableCell xrTableCell19;

		// Token: 0x04000B85 RID: 2949
		private XRTableCell xrTableCell21;

		// Token: 0x04000B86 RID: 2950
		private XRTableCell xrTableCell22;

		// Token: 0x04000B87 RID: 2951
		private GroupHeaderBand GroupHeader3;

		// Token: 0x04000B88 RID: 2952
		private XRRichText xrRichText2;

		// Token: 0x04000B89 RID: 2953
		private XRTable xrTable5;

		// Token: 0x04000B8A RID: 2954
		private XRTableRow xrTableRow5;

		// Token: 0x04000B8B RID: 2955
		private XRTableCell xrTableCell15;

		// Token: 0x04000B8C RID: 2956
		private XRTableCell xrTableCell17;

		// Token: 0x04000B8D RID: 2957
		private XRTableCell xrTableCell18;

		// Token: 0x04000B8E RID: 2958
		private Parameter Id;

		// Token: 0x04000B8F RID: 2959
		private XRLine xrLine2;

		// Token: 0x04000B90 RID: 2960
		private XRLabel xrLabel7;

		// Token: 0x04000B91 RID: 2961
		private XRLabel xrLabel3;

		// Token: 0x04000B92 RID: 2962
		private XRPictureBox xrPictureBox1;

		// Token: 0x04000B93 RID: 2963
		private XRLabel xrLabel8;

		// Token: 0x04000B94 RID: 2964
		private XRLabel xrLabel4;

		// Token: 0x04000B95 RID: 2965
		private XRLabel xrLabel5;

		// Token: 0x04000B96 RID: 2966
		private XRLine xrLine1;

		// Token: 0x04000B97 RID: 2967
		private XRLabel xrLabel2;
	}
}
