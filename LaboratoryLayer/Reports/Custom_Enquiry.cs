﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using DevExpress.DataAccess.Sql;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

namespace LaboratoryLayer.Reports
{
	// Token: 0x02000055 RID: 85
	public class Custom_Enquiry : XtraReport
	{
		// Token: 0x0600032C RID: 812 RVA: 0x00003ECE File Offset: 0x000020CE
		public Custom_Enquiry()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600032D RID: 813 RVA: 0x00003EDC File Offset: 0x000020DC
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600032E RID: 814 RVA: 0x00024258 File Offset: 0x00022458
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
			Column column10 = new Column();
			ColumnExpression columnExpression10 = new ColumnExpression();
			Column column11 = new Column();
			ColumnExpression columnExpression11 = new ColumnExpression();
			Column column12 = new Column();
			ColumnExpression columnExpression12 = new ColumnExpression();
			Column column13 = new Column();
			ColumnExpression columnExpression13 = new ColumnExpression();
			Column column14 = new Column();
			ColumnExpression columnExpression14 = new ColumnExpression();
			Column column15 = new Column();
			ColumnExpression columnExpression15 = new ColumnExpression();
			Column column16 = new Column();
			ColumnExpression columnExpression16 = new ColumnExpression();
			Column column17 = new Column();
			ColumnExpression columnExpression17 = new ColumnExpression();
			Table table2 = new Table();
			Column column18 = new Column();
			ColumnExpression columnExpression18 = new ColumnExpression();
			Table table3 = new Table();
			Column column19 = new Column();
			ColumnExpression columnExpression19 = new ColumnExpression();
			Column column20 = new Column();
			ColumnExpression columnExpression20 = new ColumnExpression();
			Join join = new Join();
			RelationColumnInfo relationColumnInfo = new RelationColumnInfo();
			Join join2 = new Join();
			RelationColumnInfo relationColumnInfo2 = new RelationColumnInfo();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Custom_Enquiry));
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Custom_Enquiry));
			this.Detail = new DetailBand();
			this.TopMargin = new TopMarginBand();
			this.BottomMargin = new BottomMarginBand();
			this.xrPageInfo3 = new XRPageInfo();
			this.xrPageInfo4 = new XRPageInfo();
			this.xrPictureBox2 = new XRPictureBox();
			this.sqlDataSource1 = new SqlDataSource(this.components);
			this.pageFooterBand1 = new PageFooterBand();
			this.reportHeaderBand1 = new ReportHeaderBand();
			this.xrLabel26 = new XRLabel();
			this.Title = new XRControlStyle();
			this.FieldCaption = new XRControlStyle();
			this.PageInfo = new XRControlStyle();
			this.DataField = new XRControlStyle();
			this.xrLine2 = new XRLine();
			this.xrLabel7 = new XRLabel();
			this.xrLabel3 = new XRLabel();
			this.xrPictureBox1 = new XRPictureBox();
			this.xrLabel8 = new XRLabel();
			this.xrLabel4 = new XRLabel();
			this.xrLabel5 = new XRLabel();
			this.xrLine1 = new XRLine();
			this.xrLabel2 = new XRLabel();
			((ISupportInitialize)this).BeginInit();
			this.Detail.Dpi = 100f;
			this.Detail.HeightF = 288.8333f;
			this.Detail.Name = "Detail";
			this.Detail.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
			this.Detail.TextAlignment = TextAlignment.TopLeft;
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
			this.BottomMargin.Controls.AddRange(new XRControl[]
			{
				this.xrPageInfo3,
				this.xrPageInfo4,
				this.xrPictureBox2
			});
			this.BottomMargin.Dpi = 100f;
			this.BottomMargin.HeightF = 129.3333f;
			this.BottomMargin.Name = "BottomMargin";
			this.BottomMargin.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
			this.BottomMargin.TextAlignment = TextAlignment.TopLeft;
			this.xrPageInfo3.Dpi = 100f;
			this.xrPageInfo3.Format = "Page {0} of {1}";
			this.xrPageInfo3.LocationFloat = new PointFloat(515.5525f, 93.5625f);
			this.xrPageInfo3.Name = "xrPageInfo3";
			this.xrPageInfo3.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrPageInfo3.SizeF = new SizeF(313f, 23f);
			this.xrPageInfo3.StyleName = "PageInfo";
			this.xrPageInfo3.TextAlignment = TextAlignment.TopRight;
			this.xrPageInfo4.Dpi = 100f;
			this.xrPageInfo4.LocationFloat = new PointFloat(17.44748f, 103.5625f);
			this.xrPageInfo4.Name = "xrPageInfo4";
			this.xrPageInfo4.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrPageInfo4.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
			this.xrPageInfo4.SizeF = new SizeF(313f, 23f);
			this.xrPageInfo4.StyleName = "PageInfo";
			this.xrPictureBox2.Dpi = 100f;
			this.xrPictureBox2.Image = (Image)resources.GetObject("xrPictureBox2.Image");
			this.xrPictureBox2.LocationFloat = new PointFloat(133.0376f, 2.770855f);
			this.xrPictureBox2.Name = "xrPictureBox2";
			this.xrPictureBox2.SizeF = new SizeF(581.3381f, 74.20829f);
			this.sqlDataSource1.ConnectionName = "localhost_LabSys_Connection";
			this.sqlDataSource1.Name = "sqlDataSource1";
			columnExpression.ColumnName = "EnquiryMasterID";
			table.MetaSerializable = "30|30|125|360";
			table.Name = "EnquiryMaster";
			columnExpression.Table = table;
			column.Expression = columnExpression;
			columnExpression2.ColumnName = "EnquiryCode";
			columnExpression2.Table = table;
			column2.Expression = columnExpression2;
			columnExpression3.ColumnName = "TransactionDate";
			columnExpression3.Table = table;
			column3.Expression = columnExpression3;
			columnExpression4.ColumnName = "EntryDate";
			columnExpression4.Table = table;
			column4.Expression = columnExpression4;
			columnExpression5.ColumnName = "FKCustomerID";
			columnExpression5.Table = table;
			column5.Expression = columnExpression5;
			columnExpression6.ColumnName = "FKProjectID";
			columnExpression6.Table = table;
			column6.Expression = columnExpression6;
			columnExpression7.ColumnName = "EnquiryMethodID";
			columnExpression7.Table = table;
			column7.Expression = columnExpression7;
			columnExpression8.ColumnName = "CustomerReference";
			columnExpression8.Table = table;
			column8.Expression = columnExpression8;
			columnExpression9.ColumnName = "ContactPerson";
			columnExpression9.Table = table;
			column9.Expression = columnExpression9;
			columnExpression10.ColumnName = "ContactNumber";
			columnExpression10.Table = table;
			column10.Expression = columnExpression10;
			columnExpression11.ColumnName = "ContactJobTitle";
			columnExpression11.Table = table;
			column11.Expression = columnExpression11;
			columnExpression12.ColumnName = "ContactEmail";
			columnExpression12.Table = table;
			column12.Expression = columnExpression12;
			columnExpression13.ColumnName = "Remarks";
			columnExpression13.Table = table;
			column13.Expression = columnExpression13;
			columnExpression14.ColumnName = "EnterdBy";
			columnExpression14.Table = table;
			column14.Expression = columnExpression14;
			columnExpression15.ColumnName = "IsClosed";
			columnExpression15.Table = table;
			column15.Expression = columnExpression15;
			columnExpression16.ColumnName = "ReceivingDate";
			columnExpression16.Table = table;
			column16.Expression = columnExpression16;
			columnExpression17.ColumnName = "ProjectName";
			table2.MetaSerializable = "185|30|125|280";
			table2.Name = "ProjectsList";
			columnExpression17.Table = table2;
			column17.Expression = columnExpression17;
			columnExpression18.ColumnName = "CustomerCode";
			table3.MetaSerializable = "340|30|125|300";
			table3.Name = "CustomersList";
			columnExpression18.Table = table3;
			column18.Expression = columnExpression18;
			columnExpression19.ColumnName = "CustomerName";
			columnExpression19.Table = table3;
			column19.Expression = columnExpression19;
			columnExpression20.ColumnName = "AshghalCode";
			columnExpression20.Table = table2;
			column20.Expression = columnExpression20;
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
			selectQuery.Columns.Add(column14);
			selectQuery.Columns.Add(column15);
			selectQuery.Columns.Add(column16);
			selectQuery.Columns.Add(column17);
			selectQuery.Columns.Add(column18);
			selectQuery.Columns.Add(column19);
			selectQuery.Columns.Add(column20);
			selectQuery.Name = "EnquiryMaster";
			relationColumnInfo.NestedKeyColumn = "ProjectID";
			relationColumnInfo.ParentKeyColumn = "FKProjectID";
			join.KeyColumns.Add(relationColumnInfo);
			join.Nested = table2;
			join.Parent = table;
			relationColumnInfo2.NestedKeyColumn = "CustomerID";
			relationColumnInfo2.ParentKeyColumn = "FKCustomerID";
			join2.KeyColumns.Add(relationColumnInfo2);
			join2.Nested = table3;
			join2.Parent = table;
			selectQuery.Relations.Add(join);
			selectQuery.Relations.Add(join2);
			selectQuery.Tables.Add(table);
			selectQuery.Tables.Add(table2);
			selectQuery.Tables.Add(table3);
			this.sqlDataSource1.Queries.AddRange(new SqlQuery[]
			{
				selectQuery
			});
			this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
			this.pageFooterBand1.Dpi = 100f;
			this.pageFooterBand1.HeightF = 11.29163f;
			this.pageFooterBand1.Name = "pageFooterBand1";
			this.reportHeaderBand1.Controls.AddRange(new XRControl[]
			{
				this.xrLabel26
			});
			this.reportHeaderBand1.Dpi = 100f;
			this.reportHeaderBand1.HeightF = 51f;
			this.reportHeaderBand1.Name = "reportHeaderBand1";
			this.xrLabel26.Dpi = 100f;
			this.xrLabel26.LocationFloat = new PointFloat(100f, 12.5f);
			this.xrLabel26.Name = "xrLabel26";
			this.xrLabel26.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel26.SizeF = new SizeF(638f, 33f);
			this.xrLabel26.StyleName = "Title";
			this.xrLabel26.StylePriority.UseForeColor = false;
			this.xrLabel26.StylePriority.UseTextAlignment = false;
			this.xrLabel26.Text = "Lab Sections";
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
			this.xrLine2.Dpi = 100f;
			this.xrLine2.ForeColor = Color.FromArgb(32, 150, 159);
			this.xrLine2.LocationFloat = new PointFloat(541.1331f, 99.47916f);
			this.xrLine2.Name = "xrLine2";
			this.xrLine2.SizeF = new SizeF(300.4026f, 13f);
			this.xrLine2.StylePriority.UseForeColor = false;
			this.xrLabel7.BackColor = Color.White;
			this.xrLabel7.Dpi = 100f;
			this.xrLabel7.Font = new Font("Times New Roman", 11f, FontStyle.Bold);
			this.xrLabel7.ForeColor = Color.FromArgb(45, 84, 108);
			this.xrLabel7.LocationFloat = new PointFloat(566.4379f, 71.52086f);
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
			this.xrLabel3.LocationFloat = new PointFloat(566.4379f, 17.52084f);
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
			this.xrPictureBox1.LocationFloat = new PointFloat(341.5699f, 17.52084f);
			this.xrPictureBox1.Name = "xrPictureBox1";
			this.xrPictureBox1.SizeF = new SizeF(189.2164f, 94.95832f);
			this.xrLabel8.BackColor = Color.White;
			this.xrLabel8.Dpi = 100f;
			this.xrLabel8.Font = new Font("Times New Roman", 11f, FontStyle.Bold);
			this.xrLabel8.ForeColor = Color.FromArgb(45, 84, 108);
			this.xrLabel8.LocationFloat = new PointFloat(566.4379f, 43.47918f);
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
			this.xrLabel4.LocationFloat = new PointFloat(4.464294f, 41.52085f);
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
			this.xrLabel5.LocationFloat = new PointFloat(4.464294f, 66.52084f);
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
			this.xrLine1.LocationFloat = new PointFloat(5.326614f, 99.47916f);
			this.xrLine1.Name = "xrLine1";
			this.xrLine1.SizeF = new SizeF(300.4026f, 13f);
			this.xrLine1.StylePriority.UseForeColor = false;
			this.xrLabel2.BackColor = Color.White;
			this.xrLabel2.Dpi = 100f;
			this.xrLabel2.Font = new Font("Times New Roman", 9f, FontStyle.Bold);
			this.xrLabel2.ForeColor = Color.FromArgb(45, 84, 103);
			this.xrLabel2.LocationFloat = new PointFloat(4.464294f, 17.52084f);
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
			base.Bands.AddRange(new Band[]
			{
				this.Detail,
				this.TopMargin,
				this.BottomMargin,
				this.pageFooterBand1,
				this.reportHeaderBand1
			});
			base.ComponentStorage.AddRange(new IComponent[]
			{
				this.sqlDataSource1
			});
			base.DataMember = "EnquiryMaster";
			base.DataSource = this.sqlDataSource1;
			base.Margins = new Margins(1, 3, 130, 129);
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

		// Token: 0x040005E7 RID: 1511
		private IContainer components;

		// Token: 0x040005E8 RID: 1512
		private DetailBand Detail;

		// Token: 0x040005E9 RID: 1513
		private TopMarginBand TopMargin;

		// Token: 0x040005EA RID: 1514
		private BottomMarginBand BottomMargin;

		// Token: 0x040005EB RID: 1515
		private SqlDataSource sqlDataSource1;

		// Token: 0x040005EC RID: 1516
		private PageFooterBand pageFooterBand1;

		// Token: 0x040005ED RID: 1517
		private ReportHeaderBand reportHeaderBand1;

		// Token: 0x040005EE RID: 1518
		private XRControlStyle Title;

		// Token: 0x040005EF RID: 1519
		private XRControlStyle FieldCaption;

		// Token: 0x040005F0 RID: 1520
		private XRControlStyle PageInfo;

		// Token: 0x040005F1 RID: 1521
		private XRControlStyle DataField;

		// Token: 0x040005F2 RID: 1522
		private XRLabel xrLabel26;

		// Token: 0x040005F3 RID: 1523
		private XRPageInfo xrPageInfo3;

		// Token: 0x040005F4 RID: 1524
		private XRPageInfo xrPageInfo4;

		// Token: 0x040005F5 RID: 1525
		private XRPictureBox xrPictureBox2;

		// Token: 0x040005F6 RID: 1526
		private XRLine xrLine2;

		// Token: 0x040005F7 RID: 1527
		private XRLabel xrLabel7;

		// Token: 0x040005F8 RID: 1528
		private XRLabel xrLabel3;

		// Token: 0x040005F9 RID: 1529
		private XRPictureBox xrPictureBox1;

		// Token: 0x040005FA RID: 1530
		private XRLabel xrLabel8;

		// Token: 0x040005FB RID: 1531
		private XRLabel xrLabel4;

		// Token: 0x040005FC RID: 1532
		private XRLabel xrLabel5;

		// Token: 0x040005FD RID: 1533
		private XRLine xrLine1;

		// Token: 0x040005FE RID: 1534
		private XRLabel xrLabel2;
	}
}
