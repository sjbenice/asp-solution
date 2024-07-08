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
	// Token: 0x02000065 RID: 101
	public class ProjectsList : XtraReport
	{
		// Token: 0x06000367 RID: 871 RVA: 0x000043F7 File Offset: 0x000025F7
		public ProjectsList()
		{
			this.InitializeComponent();
			this.BeforePrint += this.ProjectsList_BeforePrint;
		}

		// Token: 0x06000368 RID: 872 RVA: 0x00004417 File Offset: 0x00002617
		private void ProjectsList_BeforePrint(object sender, PrintEventArgs e)
		{
			if (this.FilterExpression.Value.ToString() != "")
			{
				this.FilterString = this.FilterExpression.Value.ToString();
			}
		}

		// Token: 0x06000369 RID: 873 RVA: 0x0000444B File Offset: 0x0000264B
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600036A RID: 874 RVA: 0x00042A20 File Offset: 0x00040C20
		private void InitializeComponent()
		{
			this.components = new Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectsList));
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(ProjectsList));
			CustomSqlQuery customSqlQuery = new CustomSqlQuery();
			this.Detail = new DetailBand();
			this.xrTable2 = new XRTable();
			this.xrTableRow2 = new XRTableRow();
			this.xrTableCell10 = new XRTableCell();
			this.xrTableCell11 = new XRTableCell();
			this.xrTableCell12 = new XRTableCell();
			this.xrTableCell13 = new XRTableCell();
			this.xrTableCell14 = new XRTableCell();
			this.xrTableCell15 = new XRTableCell();
			this.xrTableCell16 = new XRTableCell();
			this.xrTableCell17 = new XRTableCell();
			this.xrTableCell18 = new XRTableCell();
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
			this.sqlDataSource1 = new SqlDataSource(this.components);
			this.pageFooterBand1 = new PageFooterBand();
			this.reportHeaderBand1 = new ReportHeaderBand();
			this.xrLabel26 = new XRLabel();
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
			this.xrTableCell4 = new XRTableCell();
			this.xrTableCell5 = new XRTableCell();
			this.xrTableCell6 = new XRTableCell();
			this.xrTableCell7 = new XRTableCell();
			this.xrTableCell8 = new XRTableCell();
			this.xrTableCell9 = new XRTableCell();
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
			this.xrTable2.LocationFloat = new PointFloat(7.326626f, 0f);
			this.xrTable2.Name = "xrTable2";
			this.xrTable2.Padding = new PaddingInfo(5, 0, 0, 0, 100f);
			this.xrTable2.Rows.AddRange(new XRTableRow[]
			{
				this.xrTableRow2
			});
			this.xrTable2.SizeF = new SizeF(832.6734f, 25f);
			this.xrTable2.StylePriority.UseBorders = false;
			this.xrTable2.StylePriority.UsePadding = false;
			this.xrTableRow2.Cells.AddRange(new XRTableCell[]
			{
				this.xrTableCell10,
				this.xrTableCell11,
				this.xrTableCell12,
				this.xrTableCell13,
				this.xrTableCell14,
				this.xrTableCell15,
				this.xrTableCell16,
				this.xrTableCell17,
				this.xrTableCell18
			});
			this.xrTableRow2.Dpi = 100f;
			this.xrTableRow2.Name = "xrTableRow2";
			this.xrTableRow2.Weight = 11.5;
			this.xrTableCell10.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "ProjectsList.ProjectCode")
			});
			this.xrTableCell10.Dpi = 100f;
			this.xrTableCell10.Name = "xrTableCell10";
			this.xrTableCell10.Text = "xrTableCell10";
			this.xrTableCell10.Weight = 0.07856751285916912;
			this.xrTableCell11.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "ProjectsList.ProjectName")
			});
			this.xrTableCell11.Dpi = 100f;
			this.xrTableCell11.Name = "xrTableCell11";
			this.xrTableCell11.Text = "xrTableCell11";
			this.xrTableCell11.Weight = 0.17603806228373703;
			this.xrTableCell12.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "ProjectsList.ProjectOwner")
			});
			this.xrTableCell12.Dpi = 100f;
			this.xrTableCell12.Name = "xrTableCell12";
			this.xrTableCell12.Text = "xrTableCell12";
			this.xrTableCell12.Weight = 0.13321801208707287;
			this.xrTableCell13.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "ProjectsList.AshghalCode")
			});
			this.xrTableCell13.Dpi = 100f;
			this.xrTableCell13.Name = "xrTableCell13";
			this.xrTableCell13.Text = "xrTableCell13";
			this.xrTableCell13.Weight = 0.12153973536507895;
			this.xrTableCell14.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "ProjectsList.StartDate", "{0:dd MMM yyyy}")
			});
			this.xrTableCell14.Dpi = 100f;
			this.xrTableCell14.Name = "xrTableCell14";
			this.xrTableCell14.Text = "xrTableCell14";
			this.xrTableCell14.Weight = 0.111004759052633;
			this.xrTableCell15.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "ProjectsList.EndDate", "{0:dd MMM yyyy}")
			});
			this.xrTableCell15.Dpi = 100f;
			this.xrTableCell15.Name = "xrTableCell15";
			this.xrTableCell15.Text = "xrTableCell15";
			this.xrTableCell15.Weight = 0.1074208591553579;
			this.xrTableCell16.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "ProjectsList.ProjectTypeName")
			});
			this.xrTableCell16.Dpi = 100f;
			this.xrTableCell16.Name = "xrTableCell16";
			this.xrTableCell16.Text = "xrTableCell16";
			this.xrTableCell16.Weight = 0.1098615346730374;
			this.xrTableCell17.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "ProjectsList.ProjectLocation")
			});
			this.xrTableCell17.Dpi = 100f;
			this.xrTableCell17.Name = "xrTableCell17";
			this.xrTableCell17.Text = "xrTableCell17";
			this.xrTableCell17.Weight = 0.12932535455301147;
			this.xrTableCell18.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "ProjectsList.Column14")
			});
			this.xrTableCell18.Dpi = 100f;
			this.xrTableCell18.Name = "xrTableCell18";
			this.xrTableCell18.Weight = 0.08261245674740483;
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
			this.xrLine2.LocationFloat = new PointFloat(539.6331f, 99.47916f);
			this.xrLine2.Name = "xrLine2";
			this.xrLine2.SizeF = new SizeF(300.4026f, 13f);
			this.xrLine2.StylePriority.UseForeColor = false;
			this.xrLabel7.BackColor = Color.White;
			this.xrLabel7.Dpi = 100f;
			this.xrLabel7.Font = new Font("Times New Roman", 11f, FontStyle.Bold);
			this.xrLabel7.ForeColor = Color.FromArgb(45, 84, 108);
			this.xrLabel7.LocationFloat = new PointFloat(564.9379f, 71.52086f);
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
			this.xrLabel3.LocationFloat = new PointFloat(564.9379f, 17.52084f);
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
			this.xrPictureBox1.LocationFloat = new PointFloat(340.0699f, 17.52084f);
			this.xrPictureBox1.Name = "xrPictureBox1";
			this.xrPictureBox1.SizeF = new SizeF(189.2164f, 94.95832f);
			this.xrLabel8.BackColor = Color.White;
			this.xrLabel8.Dpi = 100f;
			this.xrLabel8.Font = new Font("Times New Roman", 11f, FontStyle.Bold);
			this.xrLabel8.ForeColor = Color.FromArgb(45, 84, 108);
			this.xrLabel8.LocationFloat = new PointFloat(564.9379f, 43.47918f);
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
			this.xrLabel4.LocationFloat = new PointFloat(2.964294f, 41.52085f);
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
			this.xrLabel5.LocationFloat = new PointFloat(2.964294f, 66.52084f);
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
			this.xrLine1.LocationFloat = new PointFloat(3.826614f, 99.47916f);
			this.xrLine1.Name = "xrLine1";
			this.xrLine1.SizeF = new SizeF(300.4026f, 13f);
			this.xrLine1.StylePriority.UseForeColor = false;
			this.xrLabel2.BackColor = Color.White;
			this.xrLabel2.Dpi = 100f;
			this.xrLabel2.Font = new Font("Times New Roman", 9f, FontStyle.Bold);
			this.xrLabel2.ForeColor = Color.FromArgb(45, 84, 103);
			this.xrLabel2.LocationFloat = new PointFloat(2.964294f, 17.52084f);
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
			this.BottomMargin.HeightF = 143f;
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
			this.xrPageInfo2.LocationFloat = new PointFloat(505.4316f, 119.875f);
			this.xrPageInfo2.Name = "xrPageInfo2";
			this.xrPageInfo2.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrPageInfo2.SizeF = new SizeF(313f, 23f);
			this.xrPageInfo2.StyleName = "PageInfo";
			this.xrPageInfo2.TextAlignment = TextAlignment.TopRight;
			this.xrPageInfo1.Dpi = 100f;
			this.xrPageInfo1.LocationFloat = new PointFloat(9.999998f, 119.875f);
			this.xrPageInfo1.Name = "xrPageInfo1";
			this.xrPageInfo1.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
			this.xrPageInfo1.SizeF = new SizeF(313f, 23f);
			this.xrPageInfo1.StyleName = "PageInfo";
			this.sqlDataSource1.ConnectionName = "localhost_LabSys_Connection";
			this.sqlDataSource1.Name = "sqlDataSource1";
			customSqlQuery.Name = "ProjectsList";
			customSqlQuery.Sql = resources.GetString("customSqlQuery1.Sql");
			this.sqlDataSource1.Queries.AddRange(new SqlQuery[]
			{
				customSqlQuery
			});
			this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
			this.pageFooterBand1.Dpi = 100f;
			this.pageFooterBand1.HeightF = 5.041663f;
			this.pageFooterBand1.Name = "pageFooterBand1";
			this.reportHeaderBand1.Controls.AddRange(new XRControl[]
			{
				this.xrLabel26
			});
			this.reportHeaderBand1.Dpi = 100f;
			this.reportHeaderBand1.HeightF = 81.20833f;
			this.reportHeaderBand1.Name = "reportHeaderBand1";
			this.xrLabel26.Dpi = 100f;
			this.xrLabel26.LocationFloat = new PointFloat(0f, 12.5f);
			this.xrLabel26.Name = "xrLabel26";
			this.xrLabel26.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel26.SizeF = new SizeF(840f, 33f);
			this.xrLabel26.StyleName = "Title";
			this.xrLabel26.StylePriority.UseTextAlignment = false;
			this.xrLabel26.Text = "Project Information";
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
			this.GroupHeader1.Controls.AddRange(new XRControl[]
			{
				this.xrTable1
			});
			this.GroupHeader1.Dpi = 100f;
			this.GroupHeader1.HeightF = 25f;
			this.GroupHeader1.Name = "GroupHeader1";
			this.GroupHeader1.RepeatEveryPage = true;
			this.xrTable1.BackColor = Color.LightGray;
			this.xrTable1.Borders = BorderSide.All;
			this.xrTable1.Dpi = 100f;
			this.xrTable1.Font = new Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTable1.LocationFloat = new PointFloat(7.326626f, 0f);
			this.xrTable1.Name = "xrTable1";
			this.xrTable1.Padding = new PaddingInfo(5, 0, 0, 0, 100f);
			this.xrTable1.Rows.AddRange(new XRTableRow[]
			{
				this.xrTableRow1
			});
			this.xrTable1.SizeF = new SizeF(832.6734f, 25f);
			this.xrTable1.StylePriority.UseBackColor = false;
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
				this.xrTableCell6,
				this.xrTableCell7,
				this.xrTableCell8,
				this.xrTableCell9
			});
			this.xrTableRow1.Dpi = 100f;
			this.xrTableRow1.Name = "xrTableRow1";
			this.xrTableRow1.Weight = 11.5;
			this.xrTableCell1.Dpi = 100f;
			this.xrTableCell1.Name = "xrTableCell1";
			this.xrTableCell1.Text = "P.Code";
			this.xrTableCell1.Weight = 0.07856751285916912;
			this.xrTableCell2.Dpi = 100f;
			this.xrTableCell2.Name = "xrTableCell2";
			this.xrTableCell2.Text = "Project Name";
			this.xrTableCell2.Weight = 0.17603806228373703;
			this.xrTableCell3.Dpi = 100f;
			this.xrTableCell3.Name = "xrTableCell3";
			this.xrTableCell3.Text = "Project Owner";
			this.xrTableCell3.Weight = 0.13321801208707287;
			this.xrTableCell4.Dpi = 100f;
			this.xrTableCell4.Name = "xrTableCell4";
			this.xrTableCell4.Text = "Ashghal Code";
			this.xrTableCell4.Weight = 0.12153977338005514;
			this.xrTableCell5.Dpi = 100f;
			this.xrTableCell5.Name = "xrTableCell5";
			this.xrTableCell5.Text = "Start Date";
			this.xrTableCell5.Weight = 0.11100479706760921;
			this.xrTableCell6.Dpi = 100f;
			this.xrTableCell6.Name = "xrTableCell6";
			this.xrTableCell6.Text = "End Date";
			this.xrTableCell6.Weight = 0.10742085915535793;
			this.xrTableCell7.Dpi = 100f;
			this.xrTableCell7.Name = "xrTableCell7";
			this.xrTableCell7.Text = "Project Type ";
			this.xrTableCell7.Weight = 0.1098615346730374;
			this.xrTableCell8.Dpi = 100f;
			this.xrTableCell8.Name = "xrTableCell8";
			this.xrTableCell8.Text = "Location";
			this.xrTableCell8.Weight = 0.12932527852305906;
			this.xrTableCell9.Dpi = 100f;
			this.xrTableCell9.Name = "xrTableCell9";
			this.xrTableCell9.Text = "Inactive";
			this.xrTableCell9.Weight = 0.08261245674740483;
			this.FilterExpression.Description = "FilterExpression";
			this.FilterExpression.Name = "FilterExpression";
			base.Bands.AddRange(new Band[]
			{
				this.Detail,
				this.TopMargin,
				this.BottomMargin,
				this.pageFooterBand1,
				this.reportHeaderBand1,
				this.GroupHeader1
			});
			base.ComponentStorage.AddRange(new IComponent[]
			{
				this.sqlDataSource1
			});
			base.DataMember = "ProjectsList";
			base.DataSource = this.sqlDataSource1;
			base.Margins = new Margins(2, 5, 130, 143);
			base.Parameters.AddRange(new Parameter[]
			{
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

		// Token: 0x04000891 RID: 2193
		private IContainer components;

		// Token: 0x04000892 RID: 2194
		private DetailBand Detail;

		// Token: 0x04000893 RID: 2195
		private TopMarginBand TopMargin;

		// Token: 0x04000894 RID: 2196
		private BottomMarginBand BottomMargin;

		// Token: 0x04000895 RID: 2197
		private SqlDataSource sqlDataSource1;

		// Token: 0x04000896 RID: 2198
		private PageFooterBand pageFooterBand1;

		// Token: 0x04000897 RID: 2199
		private XRPageInfo xrPageInfo1;

		// Token: 0x04000898 RID: 2200
		private XRPageInfo xrPageInfo2;

		// Token: 0x04000899 RID: 2201
		private ReportHeaderBand reportHeaderBand1;

		// Token: 0x0400089A RID: 2202
		private XRControlStyle Title;

		// Token: 0x0400089B RID: 2203
		private XRControlStyle FieldCaption;

		// Token: 0x0400089C RID: 2204
		private XRControlStyle PageInfo;

		// Token: 0x0400089D RID: 2205
		private XRControlStyle DataField;

		// Token: 0x0400089E RID: 2206
		private XRLabel xrLabel26;

		// Token: 0x0400089F RID: 2207
		private XRPictureBox xrPictureBox2;

		// Token: 0x040008A0 RID: 2208
		private GroupHeaderBand GroupHeader1;

		// Token: 0x040008A1 RID: 2209
		private XRTable xrTable2;

		// Token: 0x040008A2 RID: 2210
		private XRTableRow xrTableRow2;

		// Token: 0x040008A3 RID: 2211
		private XRTableCell xrTableCell10;

		// Token: 0x040008A4 RID: 2212
		private XRTableCell xrTableCell11;

		// Token: 0x040008A5 RID: 2213
		private XRTableCell xrTableCell12;

		// Token: 0x040008A6 RID: 2214
		private XRTableCell xrTableCell13;

		// Token: 0x040008A7 RID: 2215
		private XRTableCell xrTableCell14;

		// Token: 0x040008A8 RID: 2216
		private XRTableCell xrTableCell15;

		// Token: 0x040008A9 RID: 2217
		private XRTableCell xrTableCell16;

		// Token: 0x040008AA RID: 2218
		private XRTableCell xrTableCell17;

		// Token: 0x040008AB RID: 2219
		private XRTableCell xrTableCell18;

		// Token: 0x040008AC RID: 2220
		private XRTable xrTable1;

		// Token: 0x040008AD RID: 2221
		private XRTableRow xrTableRow1;

		// Token: 0x040008AE RID: 2222
		private XRTableCell xrTableCell1;

		// Token: 0x040008AF RID: 2223
		private XRTableCell xrTableCell2;

		// Token: 0x040008B0 RID: 2224
		private XRTableCell xrTableCell3;

		// Token: 0x040008B1 RID: 2225
		private XRTableCell xrTableCell4;

		// Token: 0x040008B2 RID: 2226
		private XRTableCell xrTableCell5;

		// Token: 0x040008B3 RID: 2227
		private XRTableCell xrTableCell6;

		// Token: 0x040008B4 RID: 2228
		private XRTableCell xrTableCell7;

		// Token: 0x040008B5 RID: 2229
		private XRTableCell xrTableCell8;

		// Token: 0x040008B6 RID: 2230
		private XRTableCell xrTableCell9;

		// Token: 0x040008B7 RID: 2231
		private Parameter FilterExpression;

		// Token: 0x040008B8 RID: 2232
		private XRLine xrLine2;

		// Token: 0x040008B9 RID: 2233
		private XRLabel xrLabel7;

		// Token: 0x040008BA RID: 2234
		private XRLabel xrLabel3;

		// Token: 0x040008BB RID: 2235
		private XRPictureBox xrPictureBox1;

		// Token: 0x040008BC RID: 2236
		private XRLabel xrLabel8;

		// Token: 0x040008BD RID: 2237
		private XRLabel xrLabel4;

		// Token: 0x040008BE RID: 2238
		private XRLabel xrLabel5;

		// Token: 0x040008BF RID: 2239
		private XRLine xrLine1;

		// Token: 0x040008C0 RID: 2240
		private XRLabel xrLabel2;
	}
}
