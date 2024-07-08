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
	// Token: 0x02000067 RID: 103
	public class QuotationReport : XtraReport
	{
		// Token: 0x0600036E RID: 878 RVA: 0x00004497 File Offset: 0x00002697
		public QuotationReport()
		{
			this.InitializeComponent();
			this.BeforePrint += this.QuotationReport_BeforePrint;
		}

		// Token: 0x0600036F RID: 879 RVA: 0x000482CC File Offset: 0x000464CC
		private void QuotationReport_BeforePrint(object sender, PrintEventArgs e)
		{
			if (this.FilterExpression.Value.ToString() != "")
			{
				this.FilterString = this.FilterExpression.Value.ToString();
				return;
			}
			if (this.Id.Value.ToString() == "0")
			{
				this.FilterString = "";
			}
		}

		// Token: 0x06000370 RID: 880 RVA: 0x000044B7 File Offset: 0x000026B7
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000371 RID: 881 RVA: 0x00048334 File Offset: 0x00046534
		private void InitializeComponent()
		{
			this.components = new Container();
			CustomSqlQuery customSqlQuery = new CustomSqlQuery();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuotationReport));
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(QuotationReport));
			CustomSqlQuery customSqlQuery2 = new CustomSqlQuery();
			MasterDetailInfo masterDetailInfo = new MasterDetailInfo();
			RelationColumnInfo relationColumnInfo = new RelationColumnInfo();
			DynamicListLookUpSettings dynamicListLookUpSettings = new DynamicListLookUpSettings();
			this.sqlDataSource1 = new SqlDataSource(this.components);
			this.Detail = new DetailBand();
			this.xrLabel1 = new XRLabel();
			this.xrLabel2 = new XRLabel();
			this.xrLabel3 = new XRLabel();
			this.xrLabel4 = new XRLabel();
			this.xrLabel5 = new XRLabel();
			this.xrLabel6 = new XRLabel();
			this.xrLabel9 = new XRLabel();
			this.xrLabel11 = new XRLabel();
			this.xrLabel12 = new XRLabel();
			this.xrLabel14 = new XRLabel();
			this.xrLabel16 = new XRLabel();
			this.xrLabel17 = new XRLabel();
			this.xrLabel18 = new XRLabel();
			this.xrLabel19 = new XRLabel();
			this.xrLabel20 = new XRLabel();
			this.xrLabel21 = new XRLabel();
			this.xrLabel22 = new XRLabel();
			this.xrLabel24 = new XRLabel();
			this.xrLabel25 = new XRLabel();
			this.xrLabel26 = new XRLabel();
			this.formattingRule1 = new FormattingRule();
			this.TopMargin = new TopMarginBand();
			this.xrLine2 = new XRLine();
			this.xrLabel7 = new XRLabel();
			this.xrLabel8 = new XRLabel();
			this.xrPictureBox1 = new XRPictureBox();
			this.xrLabel10 = new XRLabel();
			this.xrLabel13 = new XRLabel();
			this.xrLabel15 = new XRLabel();
			this.xrLine1 = new XRLine();
			this.xrLabel23 = new XRLabel();
			this.BottomMargin = new BottomMarginBand();
			this.pageFooterBand1 = new PageFooterBand();
			this.xrPictureBox2 = new XRPictureBox();
			this.xrPageInfo1 = new XRPageInfo();
			this.xrPageInfo2 = new XRPageInfo();
			this.reportHeaderBand1 = new ReportHeaderBand();
			this.xrLabel28 = new XRLabel();
			this.Title = new XRControlStyle();
			this.FieldCaption = new XRControlStyle();
			this.PageInfo = new XRControlStyle();
			this.DataField = new XRControlStyle();
			this.DetailReport = new DetailReportBand();
			this.Detail1 = new DetailBand();
			this.xrTable2 = new XRTable();
			this.xrTableRow2 = new XRTableRow();
			this.xrTableCell11 = new XRTableCell();
			this.xrTableCell12 = new XRTableCell();
			this.xrTableCell13 = new XRTableCell();
			this.xrTableCell14 = new XRTableCell();
			this.xrTableCell15 = new XRTableCell();
			this.xrTableCell18 = new XRTableCell();
			this.xrTableCell19 = new XRTableCell();
			this.xrTableCell20 = new XRTableCell();
			this.GroupHeader1 = new GroupHeaderBand();
			this.xrTable1 = new XRTable();
			this.xrTableRow1 = new XRTableRow();
			this.xrTableCell1 = new XRTableCell();
			this.xrTableCell2 = new XRTableCell();
			this.xrTableCell3 = new XRTableCell();
			this.xrTableCell4 = new XRTableCell();
			this.xrTableCell5 = new XRTableCell();
			this.xrTableCell8 = new XRTableCell();
			this.xrTableCell9 = new XRTableCell();
			this.xrTableCell10 = new XRTableCell();
			this.Id = new Parameter();
			this.PageHeader = new PageHeaderBand();
			this.printableComponentContainer1 = new PrintableComponentContainer();
			this.FilterExpression = new Parameter();
			((ISupportInitialize)this.xrTable2).BeginInit();
			((ISupportInitialize)this.xrTable1).BeginInit();
			((ISupportInitialize)this).BeginInit();
			this.sqlDataSource1.ConnectionName = "localhost_LabSys_Connection";
			this.sqlDataSource1.Name = "sqlDataSource1";
			customSqlQuery.Name = "QuotationDetails";
			customSqlQuery.Sql = resources.GetString("customSqlQuery1.Sql");
			customSqlQuery2.Name = "QuotationMaster";
			customSqlQuery2.Sql = resources.GetString("customSqlQuery2.Sql");
			this.sqlDataSource1.Queries.AddRange(new SqlQuery[]
			{
				customSqlQuery,
				customSqlQuery2
			});
			masterDetailInfo.DetailQueryName = "QuotationDetails";
			relationColumnInfo.NestedKeyColumn = "FKQuotationMasterID";
			relationColumnInfo.ParentKeyColumn = "QuotationMasterID";
			masterDetailInfo.KeyColumns.Add(relationColumnInfo);
			masterDetailInfo.MasterQueryName = "QuotationMaster";
			masterDetailInfo.Name = "FK_QuotationDetails_QuotationMaster";
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
				this.xrLabel4,
				this.xrLabel5,
				this.xrLabel6,
				this.xrLabel9,
				this.xrLabel11,
				this.xrLabel12,
				this.xrLabel14,
				this.xrLabel16,
				this.xrLabel17,
				this.xrLabel18,
				this.xrLabel19,
				this.xrLabel20,
				this.xrLabel21,
				this.xrLabel22,
				this.xrLabel24,
				this.xrLabel25,
				this.xrLabel26
			});
			this.Detail.Dpi = 100f;
			this.Detail.HeightF = 183.0001f;
			this.Detail.KeepTogether = true;
			this.Detail.KeepTogetherWithDetailReports = true;
			this.Detail.Name = "Detail";
			this.Detail.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
			this.Detail.PageBreak = PageBreak.BeforeBand;
			this.Detail.TextAlignment = TextAlignment.TopLeft;
			this.xrLabel1.Dpi = 100f;
			this.xrLabel1.ForeColor = Color.Black;
			this.xrLabel1.LocationFloat = new PointFloat(300.75f, 10.00007f);
			this.xrLabel1.Name = "xrLabel1";
			this.xrLabel1.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel1.SizeF = new SizeF(82.83334f, 18f);
			this.xrLabel1.StyleName = "FieldCaption";
			this.xrLabel1.StylePriority.UseForeColor = false;
			this.xrLabel1.Text = "Entry Date";
			this.xrLabel2.Dpi = 100f;
			this.xrLabel2.ForeColor = Color.Black;
			this.xrLabel2.LocationFloat = new PointFloat(570.0833f, 10.00007f);
			this.xrLabel2.Name = "xrLabel2";
			this.xrLabel2.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel2.SizeF = new SizeF(91.16666f, 18f);
			this.xrLabel2.StyleName = "FieldCaption";
			this.xrLabel2.StylePriority.UseForeColor = false;
			this.xrLabel2.Text = "Expiry Date";
			this.xrLabel3.Dpi = 100f;
			this.xrLabel3.ForeColor = Color.Black;
			this.xrLabel3.LocationFloat = new PointFloat(10.00001f, 65f);
			this.xrLabel3.Name = "xrLabel3";
			this.xrLabel3.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel3.SizeF = new SizeF(135.9583f, 18f);
			this.xrLabel3.StyleName = "FieldCaption";
			this.xrLabel3.StylePriority.UseForeColor = false;
			this.xrLabel3.Text = "Customer:";
			this.xrLabel4.Dpi = 100f;
			this.xrLabel4.ForeColor = Color.Black;
			this.xrLabel4.LocationFloat = new PointFloat(10.00001f, 39f);
			this.xrLabel4.Name = "xrLabel4";
			this.xrLabel4.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel4.SizeF = new SizeF(135.9583f, 18f);
			this.xrLabel4.StyleName = "FieldCaption";
			this.xrLabel4.StylePriority.UseForeColor = false;
			this.xrLabel4.Text = "Customer Enquiry:";
			this.xrLabel5.Dpi = 100f;
			this.xrLabel5.ForeColor = Color.Black;
			this.xrLabel5.LocationFloat = new PointFloat(547.875f, 57f);
			this.xrLabel5.Name = "xrLabel5";
			this.xrLabel5.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel5.SizeF = new SizeF(65.20819f, 18f);
			this.xrLabel5.StyleName = "FieldCaption";
			this.xrLabel5.StylePriority.UseForeColor = false;
			this.xrLabel5.Text = "Project:";
			this.xrLabel6.Dpi = 100f;
			this.xrLabel6.ForeColor = Color.Black;
			this.xrLabel6.LocationFloat = new PointFloat(530.4998f, 141.2083f);
			this.xrLabel6.Name = "xrLabel6";
			this.xrLabel6.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel6.SizeF = new SizeF(143.25f, 18f);
			this.xrLabel6.StyleName = "FieldCaption";
			this.xrLabel6.StylePriority.UseForeColor = false;
			this.xrLabel6.Text = "Terms & Conditions:";
			this.xrLabel9.Dpi = 100f;
			this.xrLabel9.ForeColor = Color.Black;
			this.xrLabel9.LocationFloat = new PointFloat(10.00001f, 141.2083f);
			this.xrLabel9.Name = "xrLabel9";
			this.xrLabel9.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel9.SizeF = new SizeF(131.9584f, 18f);
			this.xrLabel9.StyleName = "FieldCaption";
			this.xrLabel9.StylePriority.UseForeColor = false;
			this.xrLabel9.Text = "Payment Terms:";
			this.xrLabel11.Dpi = 100f;
			this.xrLabel11.ForeColor = Color.Black;
			this.xrLabel11.LocationFloat = new PointFloat(10.00001f, 10.00007f);
			this.xrLabel11.Name = "xrLabel11";
			this.xrLabel11.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel11.SizeF = new SizeF(102.625f, 18.00006f);
			this.xrLabel11.StyleName = "FieldCaption";
			this.xrLabel11.StylePriority.UseForeColor = false;
			this.xrLabel11.Text = "Quotation No:";
			this.xrLabel12.Dpi = 100f;
			this.xrLabel12.ForeColor = Color.Black;
			this.xrLabel12.LocationFloat = new PointFloat(10.00001f, 100.5833f);
			this.xrLabel12.Name = "xrLabel12";
			this.xrLabel12.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel12.SizeF = new SizeF(131.9584f, 18f);
			this.xrLabel12.StyleName = "FieldCaption";
			this.xrLabel12.StylePriority.UseForeColor = false;
			this.xrLabel12.Text = "Remarks:";
			this.xrLabel14.Dpi = 100f;
			this.xrLabel14.ForeColor = Color.Black;
			this.xrLabel14.LocationFloat = new PointFloat(547.875f, 100.5833f);
			this.xrLabel14.Name = "xrLabel14";
			this.xrLabel14.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel14.SizeF = new SizeF(65.20819f, 18f);
			this.xrLabel14.StyleName = "FieldCaption";
			this.xrLabel14.StylePriority.UseForeColor = false;
			this.xrLabel14.Text = "Status:";
			this.xrLabel16.Borders = BorderSide.All;
			this.xrLabel16.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "QuotationMaster.EntryDate", "{0:dd MMM yyyy}")
			});
			this.xrLabel16.Dpi = 100f;
			this.xrLabel16.LocationFloat = new PointFloat(402.875f, 10.00007f);
			this.xrLabel16.Name = "xrLabel16";
			this.xrLabel16.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel16.SizeF = new SizeF(145f, 18f);
			this.xrLabel16.StyleName = "DataField";
			this.xrLabel16.StylePriority.UseBorders = false;
			this.xrLabel16.Text = "xrLabel16";
			this.xrLabel17.Borders = BorderSide.All;
			this.xrLabel17.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "QuotationMaster.ExpiryDate", "{0:dd MMM yyyy}")
			});
			this.xrLabel17.Dpi = 100f;
			this.xrLabel17.LocationFloat = new PointFloat(673.7499f, 10.00007f);
			this.xrLabel17.Name = "xrLabel17";
			this.xrLabel17.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel17.SizeF = new SizeF(176.25f, 18f);
			this.xrLabel17.StyleName = "DataField";
			this.xrLabel17.StylePriority.UseBorders = false;
			this.xrLabel17.Text = "xrLabel17";
			this.xrLabel18.Borders = BorderSide.All;
			this.xrLabel18.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "QuotationMaster.CustomerName")
			});
			this.xrLabel18.Dpi = 100f;
			this.xrLabel18.LocationFloat = new PointFloat(156.125f, 64.99999f);
			this.xrLabel18.Name = "xrLabel18";
			this.xrLabel18.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel18.SizeF = new SizeF(356.6251f, 18f);
			this.xrLabel18.StyleName = "DataField";
			this.xrLabel18.StylePriority.UseBorders = false;
			this.xrLabel19.Borders = BorderSide.All;
			this.xrLabel19.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "QuotationMaster.FKEnquiryMasterID")
			});
			this.xrLabel19.Dpi = 100f;
			this.xrLabel19.LocationFloat = new PointFloat(156.125f, 39f);
			this.xrLabel19.Name = "xrLabel19";
			this.xrLabel19.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel19.SizeF = new SizeF(356.6251f, 18f);
			this.xrLabel19.StyleName = "DataField";
			this.xrLabel19.StylePriority.UseBorders = false;
			this.xrLabel19.Text = "xrLabel19";
			this.xrLabel20.Borders = BorderSide.All;
			this.xrLabel20.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "QuotationMaster.ProjectName")
			});
			this.xrLabel20.Dpi = 100f;
			this.xrLabel20.LocationFloat = new PointFloat(623.7501f, 57f);
			this.xrLabel20.Name = "xrLabel20";
			this.xrLabel20.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel20.SizeF = new SizeF(226.2499f, 18f);
			this.xrLabel20.StyleName = "DataField";
			this.xrLabel20.StylePriority.UseBorders = false;
			this.xrLabel21.Borders = BorderSide.All;
			this.xrLabel21.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "QuotationMaster.TermName")
			});
			this.xrLabel21.Dpi = 100f;
			this.xrLabel21.LocationFloat = new PointFloat(673.7499f, 141.2083f);
			this.xrLabel21.Name = "xrLabel21";
			this.xrLabel21.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel21.SizeF = new SizeF(176.25f, 18f);
			this.xrLabel21.StyleName = "DataField";
			this.xrLabel21.StylePriority.UseBorders = false;
			this.xrLabel22.Borders = BorderSide.All;
			this.xrLabel22.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "QuotationMaster.PaymentTerms")
			});
			this.xrLabel22.Dpi = 100f;
			this.xrLabel22.LocationFloat = new PointFloat(156.125f, 141.2083f);
			this.xrLabel22.Name = "xrLabel22";
			this.xrLabel22.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel22.SizeF = new SizeF(356.6251f, 18f);
			this.xrLabel22.StyleName = "DataField";
			this.xrLabel22.StylePriority.UseBorders = false;
			this.xrLabel22.Text = "xrLabel22";
			this.xrLabel24.Borders = BorderSide.All;
			this.xrLabel24.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "QuotationMaster.QuotationNo")
			});
			this.xrLabel24.Dpi = 100f;
			this.xrLabel24.LocationFloat = new PointFloat(156.125f, 5.000003f);
			this.xrLabel24.Name = "xrLabel24";
			this.xrLabel24.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel24.SizeF = new SizeF(109.5834f, 18.00006f);
			this.xrLabel24.StyleName = "DataField";
			this.xrLabel24.StylePriority.UseBorders = false;
			this.xrLabel24.Text = "xrLabel24";
			this.xrLabel25.Borders = BorderSide.All;
			this.xrLabel25.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "QuotationMaster.Remarks")
			});
			this.xrLabel25.Dpi = 100f;
			this.xrLabel25.LocationFloat = new PointFloat(156.125f, 89.24999f);
			this.xrLabel25.Multiline = true;
			this.xrLabel25.Name = "xrLabel25";
			this.xrLabel25.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel25.SizeF = new SizeF(356.6251f, 39.75001f);
			this.xrLabel25.StyleName = "DataField";
			this.xrLabel25.StylePriority.UseBorders = false;
			this.xrLabel25.Text = "xrLabel25";
			this.xrLabel26.Borders = BorderSide.All;
			this.xrLabel26.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "QuotationMaster.Column23")
			});
			this.xrLabel26.Dpi = 100f;
			this.xrLabel26.FormattingRules.Add(this.formattingRule1);
			this.xrLabel26.LocationFloat = new PointFloat(623.7502f, 100.5833f);
			this.xrLabel26.Name = "xrLabel26";
			this.xrLabel26.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel26.SizeF = new SizeF(226.2498f, 18f);
			this.xrLabel26.StyleName = "DataField";
			this.xrLabel26.StylePriority.UseBorders = false;
			this.formattingRule1.Condition = "IIf([StatusID] ==1, 'y','i' )==TRUE";
			this.formattingRule1.DataMember = "QuotationMaster";
			this.formattingRule1.Name = "formattingRule1";
			this.TopMargin.Controls.AddRange(new XRControl[]
			{
				this.xrLine2,
				this.xrLabel7,
				this.xrLabel8,
				this.xrPictureBox1,
				this.xrLabel10,
				this.xrLabel13,
				this.xrLabel15,
				this.xrLine1,
				this.xrLabel23
			});
			this.TopMargin.Dpi = 100f;
			this.TopMargin.HeightF = 130f;
			this.TopMargin.Name = "TopMargin";
			this.TopMargin.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
			this.TopMargin.TextAlignment = TextAlignment.TopLeft;
			this.xrLine2.Dpi = 100f;
			this.xrLine2.ForeColor = Color.FromArgb(32, 150, 159);
			this.xrLine2.LocationFloat = new PointFloat(543.1331f, 99.47916f);
			this.xrLine2.Name = "xrLine2";
			this.xrLine2.SizeF = new SizeF(300.4026f, 13f);
			this.xrLine2.StylePriority.UseForeColor = false;
			this.xrLabel7.BackColor = Color.White;
			this.xrLabel7.Dpi = 100f;
			this.xrLabel7.Font = new Font("Times New Roman", 11f, FontStyle.Bold);
			this.xrLabel7.ForeColor = Color.FromArgb(45, 84, 108);
			this.xrLabel7.LocationFloat = new PointFloat(568.4379f, 71.52086f);
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
			this.xrLabel8.BackColor = Color.White;
			this.xrLabel8.Dpi = 100f;
			this.xrLabel8.Font = new Font("Times New Roman", 11f, FontStyle.Bold);
			this.xrLabel8.ForeColor = Color.FromArgb(45, 84, 108);
			this.xrLabel8.LocationFloat = new PointFloat(568.4379f, 17.52084f);
			this.xrLabel8.Name = "xrLabel8";
			this.xrLabel8.Padding = new PaddingInfo(2, 2, 0, 2, 100f);
			this.xrLabel8.SizeF = new SizeF(249.9937f, 24f);
			this.xrLabel8.StylePriority.UseBackColor = false;
			this.xrLabel8.StylePriority.UseFont = false;
			this.xrLabel8.StylePriority.UseForeColor = false;
			this.xrLabel8.StylePriority.UsePadding = false;
			this.xrLabel8.StylePriority.UseTextAlignment = false;
			this.xrLabel8.Text = "إختبارات ميكانيكية وفزيائية  وكميائية لمواد البناء";
			this.xrLabel8.TextAlignment = TextAlignment.TopRight;
			this.xrPictureBox1.Dpi = 100f;
			this.xrPictureBox1.Image = (Image)resources.GetObject("xrPictureBox1.Image");
			this.xrPictureBox1.LocationFloat = new PointFloat(343.5699f, 17.52084f);
			this.xrPictureBox1.Name = "xrPictureBox1";
			this.xrPictureBox1.SizeF = new SizeF(189.2164f, 94.95832f);
			this.xrLabel10.BackColor = Color.White;
			this.xrLabel10.Dpi = 100f;
			this.xrLabel10.Font = new Font("Times New Roman", 11f, FontStyle.Bold);
			this.xrLabel10.ForeColor = Color.FromArgb(45, 84, 108);
			this.xrLabel10.LocationFloat = new PointFloat(568.4379f, 43.47918f);
			this.xrLabel10.Name = "xrLabel10";
			this.xrLabel10.Padding = new PaddingInfo(2, 2, 0, 2, 100f);
			this.xrLabel10.SizeF = new SizeF(249.9937f, 22.99997f);
			this.xrLabel10.StylePriority.UseBackColor = false;
			this.xrLabel10.StylePriority.UseFont = false;
			this.xrLabel10.StylePriority.UseForeColor = false;
			this.xrLabel10.StylePriority.UsePadding = false;
			this.xrLabel10.StylePriority.UseTextAlignment = false;
			this.xrLabel10.Text = "تربة - اسفلت - حصي - كونكريت - اسمنت - ماء";
			this.xrLabel10.TextAlignment = TextAlignment.TopRight;
			this.xrLabel13.BackColor = Color.White;
			this.xrLabel13.Dpi = 100f;
			this.xrLabel13.Font = new Font("Times New Roman", 9f, FontStyle.Bold);
			this.xrLabel13.ForeColor = Color.FromArgb(45, 84, 103);
			this.xrLabel13.LocationFloat = new PointFloat(6.464294f, 41.52085f);
			this.xrLabel13.Name = "xrLabel13";
			this.xrLabel13.Padding = new PaddingInfo(2, 2, 0, 2, 100f);
			this.xrLabel13.SizeF = new SizeF(310.5137f, 25f);
			this.xrLabel13.StylePriority.UseBackColor = false;
			this.xrLabel13.StylePriority.UseFont = false;
			this.xrLabel13.StylePriority.UseForeColor = false;
			this.xrLabel13.StylePriority.UsePadding = false;
			this.xrLabel13.StylePriority.UseTextAlignment = false;
			this.xrLabel13.Text = "Soil - Asphalt - Aggregate - Concrete - Cement - Water";
			this.xrLabel13.TextAlignment = TextAlignment.TopLeft;
			this.xrLabel15.BackColor = Color.White;
			this.xrLabel15.Dpi = 100f;
			this.xrLabel15.Font = new Font("Times New Roman", 9f, FontStyle.Bold);
			this.xrLabel15.ForeColor = Color.FromArgb(45, 84, 103);
			this.xrLabel15.LocationFloat = new PointFloat(6.464294f, 66.52084f);
			this.xrLabel15.Name = "xrLabel15";
			this.xrLabel15.Padding = new PaddingInfo(2, 2, 0, 2, 100f);
			this.xrLabel15.SizeF = new SizeF(288.8611f, 24f);
			this.xrLabel15.StylePriority.UseBackColor = false;
			this.xrLabel15.StylePriority.UseFont = false;
			this.xrLabel15.StylePriority.UseForeColor = false;
			this.xrLabel15.StylePriority.UsePadding = false;
			this.xrLabel15.StylePriority.UseTextAlignment = false;
			this.xrLabel15.Text = "Site testing - Material design mixes - Soil study";
			this.xrLabel15.TextAlignment = TextAlignment.TopLeft;
			this.xrLine1.Dpi = 100f;
			this.xrLine1.ForeColor = Color.FromArgb(32, 150, 159);
			this.xrLine1.LocationFloat = new PointFloat(7.326614f, 99.47916f);
			this.xrLine1.Name = "xrLine1";
			this.xrLine1.SizeF = new SizeF(300.4026f, 13f);
			this.xrLine1.StylePriority.UseForeColor = false;
			this.xrLabel23.BackColor = Color.White;
			this.xrLabel23.Dpi = 100f;
			this.xrLabel23.Font = new Font("Times New Roman", 9f, FontStyle.Bold);
			this.xrLabel23.ForeColor = Color.FromArgb(45, 84, 103);
			this.xrLabel23.LocationFloat = new PointFloat(6.464294f, 17.52084f);
			this.xrLabel23.Name = "xrLabel23";
			this.xrLabel23.Padding = new PaddingInfo(2, 2, 0, 2, 100f);
			this.xrLabel23.SizeF = new SizeF(285.9722f, 24f);
			this.xrLabel23.StylePriority.UseBackColor = false;
			this.xrLabel23.StylePriority.UseFont = false;
			this.xrLabel23.StylePriority.UseForeColor = false;
			this.xrLabel23.StylePriority.UsePadding = false;
			this.xrLabel23.StylePriority.UseTextAlignment = false;
			this.xrLabel23.Text = "Mechanical , physical and chimical material testing";
			this.xrLabel23.TextAlignment = TextAlignment.TopLeft;
			this.BottomMargin.Dpi = 100f;
			this.BottomMargin.HeightF = 4.333369f;
			this.BottomMargin.Name = "BottomMargin";
			this.BottomMargin.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
			this.BottomMargin.TextAlignment = TextAlignment.TopLeft;
			this.pageFooterBand1.Controls.AddRange(new XRControl[]
			{
				this.xrPictureBox2,
				this.xrPageInfo1,
				this.xrPageInfo2
			});
			this.pageFooterBand1.Dpi = 100f;
			this.pageFooterBand1.HeightF = 123.7916f;
			this.pageFooterBand1.Name = "pageFooterBand1";
			this.xrPictureBox2.Dpi = 100f;
			this.xrPictureBox2.Image = (Image)resources.GetObject("xrPictureBox2.Image");
			this.xrPictureBox2.LocationFloat = new PointFloat(138.5417f, 9.999974f);
			this.xrPictureBox2.Name = "xrPictureBox2";
			this.xrPictureBox2.SizeF = new SizeF(581.3381f, 74.20829f);
			this.xrPageInfo1.Dpi = 100f;
			this.xrPageInfo1.LocationFloat = new PointFloat(7.326611f, 100.7916f);
			this.xrPageInfo1.Name = "xrPageInfo1";
			this.xrPageInfo1.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
			this.xrPageInfo1.SizeF = new SizeF(313f, 23f);
			this.xrPageInfo1.StyleName = "PageInfo";
			this.xrPageInfo2.Dpi = 100f;
			this.xrPageInfo2.Format = "Page {0} of {1}";
			this.xrPageInfo2.LocationFloat = new PointFloat(527.0001f, 100.7916f);
			this.xrPageInfo2.Name = "xrPageInfo2";
			this.xrPageInfo2.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrPageInfo2.SizeF = new SizeF(313f, 23f);
			this.xrPageInfo2.StyleName = "PageInfo";
			this.xrPageInfo2.TextAlignment = TextAlignment.TopRight;
			this.reportHeaderBand1.Dpi = 100f;
			this.reportHeaderBand1.HeightF = 0.9999911f;
			this.reportHeaderBand1.Name = "reportHeaderBand1";
			this.xrLabel28.Dpi = 100f;
			this.xrLabel28.LocationFloat = new PointFloat(81.87975f, 10.00001f);
			this.xrLabel28.Name = "xrLabel28";
			this.xrLabel28.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel28.SizeF = new SizeF(638f, 33f);
			this.xrLabel28.StyleName = "Title";
			this.xrLabel28.StylePriority.UseTextAlignment = false;
			this.xrLabel28.Text = "Quotation";
			this.xrLabel28.TextAlignment = TextAlignment.TopCenter;
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
			this.DetailReport.DataMember = "QuotationMaster.FK_QuotationDetails_QuotationMaster";
			this.DetailReport.DataSource = this.sqlDataSource1;
			this.DetailReport.Dpi = 100f;
			this.DetailReport.Level = 0;
			this.DetailReport.Name = "DetailReport";
			this.Detail1.Controls.AddRange(new XRControl[]
			{
				this.xrTable2
			});
			this.Detail1.Dpi = 100f;
			this.Detail1.HeightF = 25.41666f;
			this.Detail1.Name = "Detail1";
			this.xrTable2.Borders = (BorderSide.Left | BorderSide.Right | BorderSide.Bottom);
			this.xrTable2.Dpi = 100f;
			this.xrTable2.LocationFloat = new PointFloat(0f, 0f);
			this.xrTable2.Name = "xrTable2";
			this.xrTable2.Rows.AddRange(new XRTableRow[]
			{
				this.xrTableRow2
			});
			this.xrTable2.SizeF = new SizeF(850f, 25f);
			this.xrTable2.StylePriority.UseBorders = false;
			this.xrTable2.StylePriority.UseTextAlignment = false;
			this.xrTable2.TextAlignment = TextAlignment.TopCenter;
			this.xrTableRow2.Cells.AddRange(new XRTableCell[]
			{
				this.xrTableCell11,
				this.xrTableCell12,
				this.xrTableCell13,
				this.xrTableCell14,
				this.xrTableCell15,
				this.xrTableCell18,
				this.xrTableCell19,
				this.xrTableCell20
			});
			this.xrTableRow2.Dpi = 100f;
			this.xrTableRow2.Name = "xrTableRow2";
			this.xrTableRow2.Weight = 11.5;
			this.xrTableCell11.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "QuotationMaster.FK_QuotationDetails_QuotationMaster.MaterialName")
			});
			this.xrTableCell11.Dpi = 100f;
			this.xrTableCell11.Name = "xrTableCell11";
			this.xrTableCell11.Weight = 0.15369089515976428;
			this.xrTableCell12.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "QuotationMaster.FK_QuotationDetails_QuotationMaster.MaterialsDetails_MaterialName")
			});
			this.xrTableCell12.Dpi = 100f;
			this.xrTableCell12.Name = "xrTableCell12";
			this.xrTableCell12.Weight = 0.14504035500919116;
			this.xrTableCell13.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "QuotationMaster.FK_QuotationDetails_QuotationMaster.TestName")
			});
			this.xrTableCell13.Dpi = 100f;
			this.xrTableCell13.Name = "xrTableCell13";
			this.xrTableCell13.Weight = 0.17185704848345584;
			this.xrTableCell14.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "QuotationMaster.FK_QuotationDetails_QuotationMaster.StandardNumber")
			});
			this.xrTableCell14.Dpi = 100f;
			this.xrTableCell14.Name = "xrTableCell14";
			this.xrTableCell14.Weight = 0.14538637577043687;
			this.xrTableCell15.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "QuotationMaster.FK_QuotationDetails_QuotationMaster.UnitName")
			});
			this.xrTableCell15.Dpi = 100f;
			this.xrTableCell15.Name = "xrTableCell15";
			this.xrTableCell15.Weight = 0.142329823847048;
			this.xrTableCell18.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "QuotationMaster.FK_QuotationDetails_QuotationMaster.Price")
			});
			this.xrTableCell18.Dpi = 100f;
			this.xrTableCell18.Name = "xrTableCell18";
			this.xrTableCell18.Weight = 0.10501738551578718;
			this.xrTableCell19.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "QuotationMaster.FK_QuotationDetails_QuotationMaster.MinQty")
			});
			this.xrTableCell19.Dpi = 100f;
			this.xrTableCell19.Name = "xrTableCell19";
			this.xrTableCell19.Weight = 0.10467111132136678;
			this.xrTableCell20.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "QuotationMaster.FK_QuotationDetails_QuotationMaster.Remarks")
			});
			this.xrTableCell20.Dpi = 100f;
			this.xrTableCell20.Name = "xrTableCell20";
			this.xrTableCell20.Weight = 0.20847759312824393;
			this.GroupHeader1.Controls.AddRange(new XRControl[]
			{
				this.xrTable1
			});
			this.GroupHeader1.Dpi = 100f;
			this.GroupHeader1.HeightF = 27.08333f;
			this.GroupHeader1.Name = "GroupHeader1";
			this.GroupHeader1.RepeatEveryPage = true;
			this.xrTable1.Borders = BorderSide.All;
			this.xrTable1.Dpi = 100f;
			this.xrTable1.Font = new Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTable1.LocationFloat = new PointFloat(0f, 0f);
			this.xrTable1.Name = "xrTable1";
			this.xrTable1.Rows.AddRange(new XRTableRow[]
			{
				this.xrTableRow1
			});
			this.xrTable1.SizeF = new SizeF(850f, 25f);
			this.xrTable1.StylePriority.UseBorders = false;
			this.xrTable1.StylePriority.UseFont = false;
			this.xrTable1.StylePriority.UseTextAlignment = false;
			this.xrTable1.TextAlignment = TextAlignment.TopCenter;
			this.xrTableRow1.Cells.AddRange(new XRTableCell[]
			{
				this.xrTableCell1,
				this.xrTableCell2,
				this.xrTableCell3,
				this.xrTableCell4,
				this.xrTableCell5,
				this.xrTableCell8,
				this.xrTableCell9,
				this.xrTableCell10
			});
			this.xrTableRow1.Dpi = 100f;
			this.xrTableRow1.Name = "xrTableRow1";
			this.xrTableRow1.Weight = 11.5;
			this.xrTableCell1.Dpi = 100f;
			this.xrTableCell1.Name = "xrTableCell1";
			this.xrTableCell1.Text = "Material Name";
			this.xrTableCell1.Weight = 0.15369089515976428;
			this.xrTableCell2.Dpi = 100f;
			this.xrTableCell2.Name = "xrTableCell2";
			this.xrTableCell2.Text = "Materials Details Material Name";
			this.xrTableCell2.Weight = 0.1450403761286224;
			this.xrTableCell3.Dpi = 100f;
			this.xrTableCell3.Name = "xrTableCell3";
			this.xrTableCell3.Text = "Test Name";
			this.xrTableCell3.Weight = 0.17185696400573094;
			this.xrTableCell4.Dpi = 100f;
			this.xrTableCell4.Name = "xrTableCell4";
			this.xrTableCell4.Text = "Standard Number";
			this.xrTableCell4.Weight = 0.14538643912873056;
			this.xrTableCell5.Dpi = 100f;
			this.xrTableCell5.Name = "xrTableCell5";
			this.xrTableCell5.Text = "Unit Name";
			this.xrTableCell5.Weight = 0.14232988720534168;
			this.xrTableCell8.Dpi = 100f;
			this.xrTableCell8.Name = "xrTableCell8";
			this.xrTableCell8.Text = "Price";
			this.xrTableCell8.Weight = 0.1050174066352184;
			this.xrTableCell9.Dpi = 100f;
			this.xrTableCell9.Name = "xrTableCell9";
			this.xrTableCell9.Text = "Min Qty";
			this.xrTableCell9.Weight = 0.10467111132136678;
			this.xrTableCell10.Dpi = 100f;
			this.xrTableCell10.Name = "xrTableCell10";
			this.xrTableCell10.Text = "Remarks";
			this.xrTableCell10.Weight = 0.20847750865051903;
			this.Id.Description = "Id";
			dynamicListLookUpSettings.DataAdapter = null;
			dynamicListLookUpSettings.DataMember = "QuotationMaster";
			dynamicListLookUpSettings.DataSource = this.sqlDataSource1;
			dynamicListLookUpSettings.DisplayMember = "QuotationNo";
			dynamicListLookUpSettings.FilterString = null;
			dynamicListLookUpSettings.ValueMember = "QuotationMasterID";
			this.Id.LookUpSettings = dynamicListLookUpSettings;
			this.Id.Name = "Id";
			this.Id.Type = typeof(int);
			this.Id.ValueInfo = "0";
			this.PageHeader.Controls.AddRange(new XRControl[]
			{
				this.printableComponentContainer1,
				this.xrLabel28
			});
			this.PageHeader.Dpi = 100f;
			this.PageHeader.HeightF = 72.91666f;
			this.PageHeader.Name = "PageHeader";
			this.printableComponentContainer1.Dpi = 100f;
			this.printableComponentContainer1.LocationFloat = new PointFloat(389.5833f, 26.04167f);
			this.printableComponentContainer1.Name = "printableComponentContainer1";
			this.printableComponentContainer1.SizeF = new SizeF(2f, 2.083334f);
			this.FilterExpression.Description = "FilterExpression";
			this.FilterExpression.Name = "FilterExpression";
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
			base.DataMember = "QuotationMaster";
			base.DataSource = this.sqlDataSource1;
			this.FilterString = "[QuotationMasterID] = ?Id";
			base.FormattingRuleSheet.AddRange(new FormattingRule[]
			{
				this.formattingRule1
			});
			base.Margins = new Margins(0, 0, 130, 4);
			base.Parameters.AddRange(new Parameter[]
			{
				this.Id,
				this.FilterExpression
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
			((ISupportInitialize)this).EndInit();
		}

		// Token: 0x04000924 RID: 2340
		private IContainer components;

		// Token: 0x04000925 RID: 2341
		private DetailBand Detail;

		// Token: 0x04000926 RID: 2342
		private TopMarginBand TopMargin;

		// Token: 0x04000927 RID: 2343
		private BottomMarginBand BottomMargin;

		// Token: 0x04000928 RID: 2344
		private XRLabel xrLabel1;

		// Token: 0x04000929 RID: 2345
		private XRLabel xrLabel2;

		// Token: 0x0400092A RID: 2346
		private XRLabel xrLabel3;

		// Token: 0x0400092B RID: 2347
		private XRLabel xrLabel4;

		// Token: 0x0400092C RID: 2348
		private XRLabel xrLabel5;

		// Token: 0x0400092D RID: 2349
		private XRLabel xrLabel6;

		// Token: 0x0400092E RID: 2350
		private XRLabel xrLabel9;

		// Token: 0x0400092F RID: 2351
		private XRLabel xrLabel11;

		// Token: 0x04000930 RID: 2352
		private XRLabel xrLabel12;

		// Token: 0x04000931 RID: 2353
		private XRLabel xrLabel14;

		// Token: 0x04000932 RID: 2354
		private XRLabel xrLabel16;

		// Token: 0x04000933 RID: 2355
		private XRLabel xrLabel17;

		// Token: 0x04000934 RID: 2356
		private XRLabel xrLabel18;

		// Token: 0x04000935 RID: 2357
		private XRLabel xrLabel19;

		// Token: 0x04000936 RID: 2358
		private XRLabel xrLabel20;

		// Token: 0x04000937 RID: 2359
		private XRLabel xrLabel21;

		// Token: 0x04000938 RID: 2360
		private XRLabel xrLabel22;

		// Token: 0x04000939 RID: 2361
		private XRLabel xrLabel24;

		// Token: 0x0400093A RID: 2362
		private XRLabel xrLabel25;

		// Token: 0x0400093B RID: 2363
		private XRLabel xrLabel26;

		// Token: 0x0400093C RID: 2364
		private SqlDataSource sqlDataSource1;

		// Token: 0x0400093D RID: 2365
		private PageFooterBand pageFooterBand1;

		// Token: 0x0400093E RID: 2366
		private XRPageInfo xrPageInfo1;

		// Token: 0x0400093F RID: 2367
		private XRPageInfo xrPageInfo2;

		// Token: 0x04000940 RID: 2368
		private ReportHeaderBand reportHeaderBand1;

		// Token: 0x04000941 RID: 2369
		private XRLabel xrLabel28;

		// Token: 0x04000942 RID: 2370
		private XRControlStyle Title;

		// Token: 0x04000943 RID: 2371
		private XRControlStyle FieldCaption;

		// Token: 0x04000944 RID: 2372
		private XRControlStyle PageInfo;

		// Token: 0x04000945 RID: 2373
		private XRControlStyle DataField;

		// Token: 0x04000946 RID: 2374
		private DetailReportBand DetailReport;

		// Token: 0x04000947 RID: 2375
		private DetailBand Detail1;

		// Token: 0x04000948 RID: 2376
		private GroupHeaderBand GroupHeader1;

		// Token: 0x04000949 RID: 2377
		private XRTable xrTable2;

		// Token: 0x0400094A RID: 2378
		private XRTableRow xrTableRow2;

		// Token: 0x0400094B RID: 2379
		private XRTableCell xrTableCell11;

		// Token: 0x0400094C RID: 2380
		private XRTableCell xrTableCell12;

		// Token: 0x0400094D RID: 2381
		private XRTableCell xrTableCell13;

		// Token: 0x0400094E RID: 2382
		private XRTableCell xrTableCell14;

		// Token: 0x0400094F RID: 2383
		private XRTableCell xrTableCell15;

		// Token: 0x04000950 RID: 2384
		private XRTableCell xrTableCell18;

		// Token: 0x04000951 RID: 2385
		private XRTableCell xrTableCell19;

		// Token: 0x04000952 RID: 2386
		private XRTableCell xrTableCell20;

		// Token: 0x04000953 RID: 2387
		private XRTable xrTable1;

		// Token: 0x04000954 RID: 2388
		private XRTableRow xrTableRow1;

		// Token: 0x04000955 RID: 2389
		private XRTableCell xrTableCell1;

		// Token: 0x04000956 RID: 2390
		private XRTableCell xrTableCell2;

		// Token: 0x04000957 RID: 2391
		private XRTableCell xrTableCell3;

		// Token: 0x04000958 RID: 2392
		private XRTableCell xrTableCell4;

		// Token: 0x04000959 RID: 2393
		private XRTableCell xrTableCell5;

		// Token: 0x0400095A RID: 2394
		private XRTableCell xrTableCell8;

		// Token: 0x0400095B RID: 2395
		private XRTableCell xrTableCell9;

		// Token: 0x0400095C RID: 2396
		private XRTableCell xrTableCell10;

		// Token: 0x0400095D RID: 2397
		private Parameter Id;

		// Token: 0x0400095E RID: 2398
		private PageHeaderBand PageHeader;

		// Token: 0x0400095F RID: 2399
		private FormattingRule formattingRule1;

		// Token: 0x04000960 RID: 2400
		private Parameter FilterExpression;

		// Token: 0x04000961 RID: 2401
		private XRPictureBox xrPictureBox2;

		// Token: 0x04000962 RID: 2402
		private PrintableComponentContainer printableComponentContainer1;

		// Token: 0x04000963 RID: 2403
		private XRLine xrLine2;

		// Token: 0x04000964 RID: 2404
		private XRLabel xrLabel7;

		// Token: 0x04000965 RID: 2405
		private XRLabel xrLabel8;

		// Token: 0x04000966 RID: 2406
		private XRPictureBox xrPictureBox1;

		// Token: 0x04000967 RID: 2407
		private XRLabel xrLabel10;

		// Token: 0x04000968 RID: 2408
		private XRLabel xrLabel13;

		// Token: 0x04000969 RID: 2409
		private XRLabel xrLabel15;

		// Token: 0x0400096A RID: 2410
		private XRLine xrLine1;

		// Token: 0x0400096B RID: 2411
		private XRLabel xrLabel23;
	}
}
