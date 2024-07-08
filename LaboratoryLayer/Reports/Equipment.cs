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
	// Token: 0x0200005B RID: 91
	public class Equipment : XtraReport
	{
		// Token: 0x06000342 RID: 834 RVA: 0x000040C0 File Offset: 0x000022C0
		public Equipment()
		{
			this.InitializeComponent();
			this.BeforePrint += this.Equipment_BeforePrint;
		}

		// Token: 0x06000343 RID: 835 RVA: 0x0002FAF4 File Offset: 0x0002DCF4
		private void Equipment_BeforePrint(object sender, PrintEventArgs e)
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

		// Token: 0x06000344 RID: 836 RVA: 0x0002FB5C File Offset: 0x0002DD5C
		private void InitializeComponent()
		{
			this.components = new Container();
			CustomSqlQuery customSqlQuery = new CustomSqlQuery();
			QueryParameter queryParameter = new QueryParameter();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Equipment));
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Equipment));
			DynamicListLookUpSettings dynamicListLookUpSettings = new DynamicListLookUpSettings();
			this.sqlDataSource1 = new SqlDataSource(this.components);
			this.Detail = new DetailBand();
			this.xrLabel2 = new XRLabel();
			this.xrLabel4 = new XRLabel();
			this.xrLabel6 = new XRLabel();
			this.xrLabel7 = new XRLabel();
			this.xrLabel8 = new XRLabel();
			this.xrLabel11 = new XRLabel();
			this.xrLabel12 = new XRLabel();
			this.xrLabel15 = new XRLabel();
			this.xrLabel17 = new XRLabel();
			this.xrLabel19 = new XRLabel();
			this.xrLabel20 = new XRLabel();
			this.xrLabel21 = new XRLabel();
			this.xrLabel23 = new XRLabel();
			this.xrLabel24 = new XRLabel();
			this.TopMargin = new TopMarginBand();
			this.xrLine2 = new XRLine();
			this.xrLabel1 = new XRLabel();
			this.xrLabel3 = new XRLabel();
			this.xrPictureBox1 = new XRPictureBox();
			this.xrLabel5 = new XRLabel();
			this.xrLabel9 = new XRLabel();
			this.xrLabel10 = new XRLabel();
			this.xrLine1 = new XRLine();
			this.xrLabel13 = new XRLabel();
			this.BottomMargin = new BottomMarginBand();
			this.pageFooterBand1 = new PageFooterBand();
			this.xrPictureBox2 = new XRPictureBox();
			this.xrPageInfo1 = new XRPageInfo();
			this.xrPageInfo2 = new XRPageInfo();
			this.reportHeaderBand1 = new ReportHeaderBand();
			this.xrLabel26 = new XRLabel();
			this.Title = new XRControlStyle();
			this.FieldCaption = new XRControlStyle();
			this.PageInfo = new XRControlStyle();
			this.DataField = new XRControlStyle();
			this.PageHeader = new PageHeaderBand();
			this.Id = new Parameter();
			this.FilterExpression = new Parameter();
			((ISupportInitialize)this).BeginInit();
			this.sqlDataSource1.ConnectionName = "localhost_LabSys_Connection";
			this.sqlDataSource1.Name = "sqlDataSource1";
			customSqlQuery.Name = "Query";
			queryParameter.Name = "CustomerID";
			queryParameter.Type = typeof(int);
			queryParameter.ValueInfo = "0";
			customSqlQuery.Parameters.Add(queryParameter);
			customSqlQuery.Sql = resources.GetString("customSqlQuery1.Sql");
			this.sqlDataSource1.Queries.AddRange(new SqlQuery[]
			{
				customSqlQuery
			});
			this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
			this.Detail.Controls.AddRange(new XRControl[]
			{
				this.xrLabel2,
				this.xrLabel4,
				this.xrLabel6,
				this.xrLabel7,
				this.xrLabel8,
				this.xrLabel11,
				this.xrLabel12,
				this.xrLabel15,
				this.xrLabel17,
				this.xrLabel19,
				this.xrLabel20,
				this.xrLabel21,
				this.xrLabel23,
				this.xrLabel24
			});
			this.Detail.Dpi = 100f;
			this.Detail.HeightF = 355.0001f;
			this.Detail.KeepTogether = true;
			this.Detail.Name = "Detail";
			this.Detail.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
			this.Detail.PageBreak = PageBreak.BeforeBand;
			this.Detail.StyleName = "DataField";
			this.Detail.TextAlignment = TextAlignment.TopLeft;
			this.xrLabel2.Dpi = 100f;
			this.xrLabel2.ForeColor = Color.Black;
			this.xrLabel2.LocationFloat = new PointFloat(346.3705f, 68.79171f);
			this.xrLabel2.Name = "xrLabel2";
			this.xrLabel2.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel2.SizeF = new SizeF(113.0572f, 18f);
			this.xrLabel2.StyleName = "FieldCaption";
			this.xrLabel2.StylePriority.UseForeColor = false;
			this.xrLabel2.Text = "Expiry Date:";
			this.xrLabel4.Dpi = 100f;
			this.xrLabel4.ForeColor = Color.Black;
			this.xrLabel4.LocationFloat = new PointFloat(6.00001f, 14.99999f);
			this.xrLabel4.Name = "xrLabel4";
			this.xrLabel4.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel4.SizeF = new SizeF(145.7708f, 18f);
			this.xrLabel4.StyleName = "FieldCaption";
			this.xrLabel4.StylePriority.UseForeColor = false;
			this.xrLabel4.Text = "Equipment Name:";
			this.xrLabel6.Dpi = 100f;
			this.xrLabel6.ForeColor = Color.Black;
			this.xrLabel6.LocationFloat = new PointFloat(6.00001f, 44.45836f);
			this.xrLabel6.Name = "xrLabel6";
			this.xrLabel6.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel6.SizeF = new SizeF(129.1041f, 18f);
			this.xrLabel6.StyleName = "FieldCaption";
			this.xrLabel6.StylePriority.UseForeColor = false;
			this.xrLabel6.Text = "Lab Section:\t";
			this.xrLabel7.Dpi = 100f;
			this.xrLabel7.ForeColor = Color.Black;
			this.xrLabel7.LocationFloat = new PointFloat(6.00001f, 132.7084f);
			this.xrLabel7.Name = "xrLabel7";
			this.xrLabel7.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel7.SizeF = new SizeF(110.2464f, 18.00002f);
			this.xrLabel7.StyleName = "FieldCaption";
			this.xrLabel7.StylePriority.UseForeColor = false;
			this.xrLabel7.Text = "Remarks:";
			this.xrLabel8.Dpi = 100f;
			this.xrLabel8.ForeColor = Color.Black;
			this.xrLabel8.LocationFloat = new PointFloat(346.3705f, 99.29174f);
			this.xrLabel8.Name = "xrLabel8";
			this.xrLabel8.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel8.SizeF = new SizeF(106.5422f, 18f);
			this.xrLabel8.StyleName = "FieldCaption";
			this.xrLabel8.StylePriority.UseForeColor = false;
			this.xrLabel8.Text = "Calibrated By:";
			this.xrLabel11.Dpi = 100f;
			this.xrLabel11.ForeColor = Color.Black;
			this.xrLabel11.LocationFloat = new PointFloat(6.00001f, 73.79169f);
			this.xrLabel11.Name = "xrLabel11";
			this.xrLabel11.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel11.SizeF = new SizeF(124.9375f, 18f);
			this.xrLabel11.StyleName = "FieldCaption";
			this.xrLabel11.StylePriority.UseForeColor = false;
			this.xrLabel11.Text = "Calibration Date:";
			this.xrLabel12.Dpi = 100f;
			this.xrLabel12.ForeColor = Color.Black;
			this.xrLabel12.LocationFloat = new PointFloat(6.00001f, 104.2917f);
			this.xrLabel12.Name = "xrLabel12";
			this.xrLabel12.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel12.SizeF = new SizeF(94.15083f, 18f);
			this.xrLabel12.StyleName = "FieldCaption";
			this.xrLabel12.StylePriority.UseForeColor = false;
			this.xrLabel12.Text = "Responsible:\t";
			this.xrLabel15.Borders = BorderSide.All;
			this.xrLabel15.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "Query.ExpiryDate", "{0:dd MMM yyyy}")
			});
			this.xrLabel15.Dpi = 100f;
			this.xrLabel15.LocationFloat = new PointFloat(470.3566f, 68.79171f);
			this.xrLabel15.Name = "xrLabel15";
			this.xrLabel15.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel15.SizeF = new SizeF(169.6434f, 23f);
			this.xrLabel15.StylePriority.UseBorders = false;
			this.xrLabel17.Borders = BorderSide.All;
			this.xrLabel17.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "Query.EquipmentName")
			});
			this.xrLabel17.Dpi = 100f;
			this.xrLabel17.LocationFloat = new PointFloat(151.7708f, 10.00001f);
			this.xrLabel17.Name = "xrLabel17";
			this.xrLabel17.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel17.SizeF = new SizeF(488.2292f, 23f);
			this.xrLabel17.StylePriority.UseBorders = false;
			this.xrLabel19.Borders = BorderSide.All;
			this.xrLabel19.Dpi = 100f;
			this.xrLabel19.LocationFloat = new PointFloat(151.7708f, 39.45834f);
			this.xrLabel19.Name = "xrLabel19";
			this.xrLabel19.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel19.SizeF = new SizeF(163.23f, 23.00001f);
			this.xrLabel19.StylePriority.UseBorders = false;
			this.xrLabel19.Text = "[LabName]";
			this.xrLabel20.Borders = BorderSide.All;
			this.xrLabel20.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "Query.Remarks")
			});
			this.xrLabel20.Dpi = 100f;
			this.xrLabel20.LocationFloat = new PointFloat(151.7708f, 132.7084f);
			this.xrLabel20.Name = "xrLabel20";
			this.xrLabel20.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel20.SizeF = new SizeF(488.2292f, 52.16667f);
			this.xrLabel20.StylePriority.UseBorders = false;
			this.xrLabel21.Borders = BorderSide.All;
			this.xrLabel21.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "Query.CalibratedBy")
			});
			this.xrLabel21.Dpi = 100f;
			this.xrLabel21.LocationFloat = new PointFloat(470.3566f, 99.29174f);
			this.xrLabel21.Name = "xrLabel21";
			this.xrLabel21.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel21.SizeF = new SizeF(169.6434f, 23f);
			this.xrLabel21.StylePriority.UseBorders = false;
			this.xrLabel23.Borders = BorderSide.All;
			this.xrLabel23.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "Query.CalibrationDate", "{0:dd MMM yyyy}")
			});
			this.xrLabel23.Dpi = 100f;
			this.xrLabel23.LocationFloat = new PointFloat(151.7708f, 68.79171f);
			this.xrLabel23.Name = "xrLabel23";
			this.xrLabel23.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel23.SizeF = new SizeF(163.2292f, 23f);
			this.xrLabel23.StylePriority.UseBorders = false;
			this.xrLabel24.Borders = BorderSide.All;
			this.xrLabel24.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "Query.EmpName")
			});
			this.xrLabel24.Dpi = 100f;
			this.xrLabel24.LocationFloat = new PointFloat(151.7708f, 99.29174f);
			this.xrLabel24.Name = "xrLabel24";
			this.xrLabel24.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel24.SizeF = new SizeF(163.2292f, 22.99998f);
			this.xrLabel24.StylePriority.UseBorders = false;
			this.TopMargin.Controls.AddRange(new XRControl[]
			{
				this.xrLine2,
				this.xrLabel1,
				this.xrLabel3,
				this.xrPictureBox1,
				this.xrLabel5,
				this.xrLabel9,
				this.xrLabel10,
				this.xrLine1,
				this.xrLabel13
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
			this.xrLabel1.BackColor = Color.White;
			this.xrLabel1.Dpi = 100f;
			this.xrLabel1.Font = new Font("Times New Roman", 11f, FontStyle.Bold);
			this.xrLabel1.ForeColor = Color.FromArgb(45, 84, 108);
			this.xrLabel1.LocationFloat = new PointFloat(568.4379f, 71.52086f);
			this.xrLabel1.Name = "xrLabel1";
			this.xrLabel1.Padding = new PaddingInfo(2, 2, 0, 2, 100f);
			this.xrLabel1.SizeF = new SizeF(249.9936f, 22.99997f);
			this.xrLabel1.StylePriority.UseBackColor = false;
			this.xrLabel1.StylePriority.UseFont = false;
			this.xrLabel1.StylePriority.UseForeColor = false;
			this.xrLabel1.StylePriority.UsePadding = false;
			this.xrLabel1.StylePriority.UseTextAlignment = false;
			this.xrLabel1.Text = "اختبارات مواقع - تصميم خلطات - دراسات تربة";
			this.xrLabel1.TextAlignment = TextAlignment.TopRight;
			this.xrLabel3.BackColor = Color.White;
			this.xrLabel3.Dpi = 100f;
			this.xrLabel3.Font = new Font("Times New Roman", 11f, FontStyle.Bold);
			this.xrLabel3.ForeColor = Color.FromArgb(45, 84, 108);
			this.xrLabel3.LocationFloat = new PointFloat(568.4379f, 17.52084f);
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
			this.xrPictureBox1.LocationFloat = new PointFloat(343.5699f, 17.52084f);
			this.xrPictureBox1.Name = "xrPictureBox1";
			this.xrPictureBox1.SizeF = new SizeF(189.2164f, 94.95832f);
			this.xrLabel5.BackColor = Color.White;
			this.xrLabel5.Dpi = 100f;
			this.xrLabel5.Font = new Font("Times New Roman", 11f, FontStyle.Bold);
			this.xrLabel5.ForeColor = Color.FromArgb(45, 84, 108);
			this.xrLabel5.LocationFloat = new PointFloat(568.4379f, 43.47918f);
			this.xrLabel5.Name = "xrLabel5";
			this.xrLabel5.Padding = new PaddingInfo(2, 2, 0, 2, 100f);
			this.xrLabel5.SizeF = new SizeF(249.9937f, 22.99997f);
			this.xrLabel5.StylePriority.UseBackColor = false;
			this.xrLabel5.StylePriority.UseFont = false;
			this.xrLabel5.StylePriority.UseForeColor = false;
			this.xrLabel5.StylePriority.UsePadding = false;
			this.xrLabel5.StylePriority.UseTextAlignment = false;
			this.xrLabel5.Text = "تربة - اسفلت - حصي - كونكريت - اسمنت - ماء";
			this.xrLabel5.TextAlignment = TextAlignment.TopRight;
			this.xrLabel9.BackColor = Color.White;
			this.xrLabel9.Dpi = 100f;
			this.xrLabel9.Font = new Font("Times New Roman", 9f, FontStyle.Bold);
			this.xrLabel9.ForeColor = Color.FromArgb(45, 84, 103);
			this.xrLabel9.LocationFloat = new PointFloat(6.464294f, 41.52085f);
			this.xrLabel9.Name = "xrLabel9";
			this.xrLabel9.Padding = new PaddingInfo(2, 2, 0, 2, 100f);
			this.xrLabel9.SizeF = new SizeF(310.5137f, 25f);
			this.xrLabel9.StylePriority.UseBackColor = false;
			this.xrLabel9.StylePriority.UseFont = false;
			this.xrLabel9.StylePriority.UseForeColor = false;
			this.xrLabel9.StylePriority.UsePadding = false;
			this.xrLabel9.StylePriority.UseTextAlignment = false;
			this.xrLabel9.Text = "Soil - Asphalt - Aggregate - Concrete - Cement - Water";
			this.xrLabel9.TextAlignment = TextAlignment.TopLeft;
			this.xrLabel10.BackColor = Color.White;
			this.xrLabel10.Dpi = 100f;
			this.xrLabel10.Font = new Font("Times New Roman", 9f, FontStyle.Bold);
			this.xrLabel10.ForeColor = Color.FromArgb(45, 84, 103);
			this.xrLabel10.LocationFloat = new PointFloat(6.464294f, 66.52084f);
			this.xrLabel10.Name = "xrLabel10";
			this.xrLabel10.Padding = new PaddingInfo(2, 2, 0, 2, 100f);
			this.xrLabel10.SizeF = new SizeF(288.8611f, 24f);
			this.xrLabel10.StylePriority.UseBackColor = false;
			this.xrLabel10.StylePriority.UseFont = false;
			this.xrLabel10.StylePriority.UseForeColor = false;
			this.xrLabel10.StylePriority.UsePadding = false;
			this.xrLabel10.StylePriority.UseTextAlignment = false;
			this.xrLabel10.Text = "Site testing - Material design mixes - Soil study";
			this.xrLabel10.TextAlignment = TextAlignment.TopLeft;
			this.xrLine1.Dpi = 100f;
			this.xrLine1.ForeColor = Color.FromArgb(32, 150, 159);
			this.xrLine1.LocationFloat = new PointFloat(7.326614f, 99.47916f);
			this.xrLine1.Name = "xrLine1";
			this.xrLine1.SizeF = new SizeF(300.4026f, 13f);
			this.xrLine1.StylePriority.UseForeColor = false;
			this.xrLabel13.BackColor = Color.White;
			this.xrLabel13.Dpi = 100f;
			this.xrLabel13.Font = new Font("Times New Roman", 9f, FontStyle.Bold);
			this.xrLabel13.ForeColor = Color.FromArgb(45, 84, 103);
			this.xrLabel13.LocationFloat = new PointFloat(6.464294f, 17.52084f);
			this.xrLabel13.Name = "xrLabel13";
			this.xrLabel13.Padding = new PaddingInfo(2, 2, 0, 2, 100f);
			this.xrLabel13.SizeF = new SizeF(285.9722f, 24f);
			this.xrLabel13.StylePriority.UseBackColor = false;
			this.xrLabel13.StylePriority.UseFont = false;
			this.xrLabel13.StylePriority.UseForeColor = false;
			this.xrLabel13.StylePriority.UsePadding = false;
			this.xrLabel13.StylePriority.UseTextAlignment = false;
			this.xrLabel13.Text = "Mechanical , physical and chimical material testing";
			this.xrLabel13.TextAlignment = TextAlignment.TopLeft;
			this.BottomMargin.Dpi = 100f;
			this.BottomMargin.HeightF = 6f;
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
			this.pageFooterBand1.HeightF = 116.5f;
			this.pageFooterBand1.Name = "pageFooterBand1";
			this.xrPictureBox2.Dpi = 100f;
			this.xrPictureBox2.Image = (Image)resources.GetObject("xrPictureBox2.Image");
			this.xrPictureBox2.LocationFloat = new PointFloat(139.5833f, 0f);
			this.xrPictureBox2.Name = "xrPictureBox2";
			this.xrPictureBox2.SizeF = new SizeF(581.3381f, 74.20829f);
			this.xrPageInfo1.Dpi = 100f;
			this.xrPageInfo1.LocationFloat = new PointFloat(6.00001f, 93.49995f);
			this.xrPageInfo1.Name = "xrPageInfo1";
			this.xrPageInfo1.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
			this.xrPageInfo1.SizeF = new SizeF(313f, 23f);
			this.xrPageInfo1.StyleName = "PageInfo";
			this.xrPageInfo2.Dpi = 100f;
			this.xrPageInfo2.Format = "Page {0} of {1}";
			this.xrPageInfo2.LocationFloat = new PointFloat(537f, 93.49995f);
			this.xrPageInfo2.Name = "xrPageInfo2";
			this.xrPageInfo2.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrPageInfo2.SizeF = new SizeF(313f, 23f);
			this.xrPageInfo2.StyleName = "PageInfo";
			this.xrPageInfo2.TextAlignment = TextAlignment.TopRight;
			this.reportHeaderBand1.Dpi = 100f;
			this.reportHeaderBand1.HeightF = 2.041658f;
			this.reportHeaderBand1.Name = "reportHeaderBand1";
			this.xrLabel26.Dpi = 100f;
			this.xrLabel26.LocationFloat = new PointFloat(11.99999f, 28.75001f);
			this.xrLabel26.Name = "xrLabel26";
			this.xrLabel26.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel26.SizeF = new SizeF(828f, 33f);
			this.xrLabel26.StyleName = "Title";
			this.xrLabel26.StylePriority.UseTextAlignment = false;
			this.xrLabel26.Text = "Equipment Information";
			this.xrLabel26.TextAlignment = TextAlignment.TopCenter;
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
			this.PageHeader.Controls.AddRange(new XRControl[]
			{
				this.xrLabel26
			});
			this.PageHeader.Dpi = 100f;
			this.PageHeader.HeightF = 77.08334f;
			this.PageHeader.Name = "PageHeader";
			this.Id.Description = "id";
			dynamicListLookUpSettings.DataAdapter = null;
			dynamicListLookUpSettings.DataMember = "Query";
			dynamicListLookUpSettings.DataSource = this.sqlDataSource1;
			dynamicListLookUpSettings.DisplayMember = "EquipmentName";
			dynamicListLookUpSettings.FilterString = null;
			dynamicListLookUpSettings.ValueMember = "EquipmentID";
			this.Id.LookUpSettings = dynamicListLookUpSettings;
			this.Id.Name = "Id";
			this.Id.Type = typeof(int);
			this.Id.ValueInfo = "0";
			this.FilterExpression.Description = "FilterExpression";
			this.FilterExpression.Name = "FilterExpression";
			base.Bands.AddRange(new Band[]
			{
				this.Detail,
				this.TopMargin,
				this.BottomMargin,
				this.pageFooterBand1,
				this.reportHeaderBand1,
				this.PageHeader
			});
			base.ComponentStorage.AddRange(new IComponent[]
			{
				this.sqlDataSource1
			});
			base.DataMember = "Query";
			base.DataSource = this.sqlDataSource1;
			this.FilterString = "[EquipmentID] = ?Id";
			base.Margins = new Margins(0, 0, 130, 6);
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
			((ISupportInitialize)this).EndInit();
		}

		// Token: 0x040006ED RID: 1773
		private IContainer components;

		// Token: 0x040006EE RID: 1774
		private DetailBand Detail;

		// Token: 0x040006EF RID: 1775
		private TopMarginBand TopMargin;

		// Token: 0x040006F0 RID: 1776
		private BottomMarginBand BottomMargin;

		// Token: 0x040006F1 RID: 1777
		private XRLabel xrLabel2;

		// Token: 0x040006F2 RID: 1778
		private XRLabel xrLabel4;

		// Token: 0x040006F3 RID: 1779
		private XRLabel xrLabel6;

		// Token: 0x040006F4 RID: 1780
		private XRLabel xrLabel7;

		// Token: 0x040006F5 RID: 1781
		private XRLabel xrLabel8;

		// Token: 0x040006F6 RID: 1782
		private XRLabel xrLabel11;

		// Token: 0x040006F7 RID: 1783
		private XRLabel xrLabel12;

		// Token: 0x040006F8 RID: 1784
		private XRLabel xrLabel15;

		// Token: 0x040006F9 RID: 1785
		private XRLabel xrLabel17;

		// Token: 0x040006FA RID: 1786
		private XRLabel xrLabel19;

		// Token: 0x040006FB RID: 1787
		private XRLabel xrLabel20;

		// Token: 0x040006FC RID: 1788
		private XRLabel xrLabel21;

		// Token: 0x040006FD RID: 1789
		private XRLabel xrLabel23;

		// Token: 0x040006FE RID: 1790
		private XRLabel xrLabel24;

		// Token: 0x040006FF RID: 1791
		private SqlDataSource sqlDataSource1;

		// Token: 0x04000700 RID: 1792
		private PageFooterBand pageFooterBand1;

		// Token: 0x04000701 RID: 1793
		private XRPageInfo xrPageInfo1;

		// Token: 0x04000702 RID: 1794
		private XRPageInfo xrPageInfo2;

		// Token: 0x04000703 RID: 1795
		private ReportHeaderBand reportHeaderBand1;

		// Token: 0x04000704 RID: 1796
		private XRLabel xrLabel26;

		// Token: 0x04000705 RID: 1797
		private XRControlStyle Title;

		// Token: 0x04000706 RID: 1798
		private XRControlStyle FieldCaption;

		// Token: 0x04000707 RID: 1799
		private XRControlStyle PageInfo;

		// Token: 0x04000708 RID: 1800
		private XRControlStyle DataField;

		// Token: 0x04000709 RID: 1801
		private PageHeaderBand PageHeader;

		// Token: 0x0400070A RID: 1802
		private Parameter Id;

		// Token: 0x0400070B RID: 1803
		private Parameter FilterExpression;

		// Token: 0x0400070C RID: 1804
		private XRPictureBox xrPictureBox2;

		// Token: 0x0400070D RID: 1805
		private XRLine xrLine2;

		// Token: 0x0400070E RID: 1806
		private XRLabel xrLabel1;

		// Token: 0x0400070F RID: 1807
		private XRLabel xrLabel3;

		// Token: 0x04000710 RID: 1808
		private XRPictureBox xrPictureBox1;

		// Token: 0x04000711 RID: 1809
		private XRLabel xrLabel5;

		// Token: 0x04000712 RID: 1810
		private XRLabel xrLabel9;

		// Token: 0x04000713 RID: 1811
		private XRLabel xrLabel10;

		// Token: 0x04000714 RID: 1812
		private XRLine xrLine1;

		// Token: 0x04000715 RID: 1813
		private XRLabel xrLabel13;
	}
}
