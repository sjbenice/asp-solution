﻿using System;
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
	// Token: 0x02000064 RID: 100
	public class Projects_Information : XtraReport
	{
		// Token: 0x06000364 RID: 868 RVA: 0x000043CA File Offset: 0x000025CA
		public Projects_Information()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000365 RID: 869 RVA: 0x000043D8 File Offset: 0x000025D8
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000366 RID: 870 RVA: 0x000400F0 File Offset: 0x0003E2F0
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
			Table table2 = new Table();
			Column column14 = new Column();
			ColumnExpression columnExpression14 = new ColumnExpression();
			Column column15 = new Column();
			ColumnExpression columnExpression15 = new ColumnExpression();
			Table table3 = new Table();
			Join join = new Join();
			RelationColumnInfo relationColumnInfo = new RelationColumnInfo();
			Join join2 = new Join();
			RelationColumnInfo relationColumnInfo2 = new RelationColumnInfo();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Projects_Information));
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Projects_Information));
			DynamicListLookUpSettings dynamicListLookUpSettings = new DynamicListLookUpSettings();
			this.sqlDataSource1 = new SqlDataSource(this.components);
			this.Detail = new DetailBand();
			this.xrLabel21 = new XRLabel();
			this.xrLabel22 = new XRLabel();
			this.xrLabel1 = new XRLabel();
			this.xrLabel2 = new XRLabel();
			this.xrLabel3 = new XRLabel();
			this.xrLabel4 = new XRLabel();
			this.xrLabel5 = new XRLabel();
			this.xrLabel6 = new XRLabel();
			this.xrLabel7 = new XRLabel();
			this.xrLabel8 = new XRLabel();
			this.xrLabel9 = new XRLabel();
			this.xrLabel10 = new XRLabel();
			this.xrLabel11 = new XRLabel();
			this.xrLabel12 = new XRLabel();
			this.xrLabel13 = new XRLabel();
			this.xrLabel14 = new XRLabel();
			this.xrLabel15 = new XRLabel();
			this.xrLabel16 = new XRLabel();
			this.xrLabel17 = new XRLabel();
			this.xrLabel18 = new XRLabel();
			this.xrLabel19 = new XRLabel();
			this.xrCheckBox1 = new XRCheckBox();
			this.TopMargin = new TopMarginBand();
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
			this.xrLabel26 = new XRLabel();
			this.PageHeader = new PageHeaderBand();
			this.Id = new Parameter();
			this.xrLine2 = new XRLine();
			this.xrLabel20 = new XRLabel();
			this.xrLabel23 = new XRLabel();
			this.xrPictureBox1 = new XRPictureBox();
			this.xrLabel24 = new XRLabel();
			this.xrLabel25 = new XRLabel();
			this.xrLabel27 = new XRLabel();
			this.xrLine1 = new XRLine();
			this.xrLabel28 = new XRLabel();
			((ISupportInitialize)this).BeginInit();
			this.sqlDataSource1.ConnectionName = "localhost_LabSys_Connection";
			this.sqlDataSource1.Name = "sqlDataSource1";
			columnExpression.ColumnName = "ProjectID";
			table.MetaSerializable = "30|30|125|280";
			table.Name = "ProjectsList";
			columnExpression.Table = table;
			column.Expression = columnExpression;
			columnExpression2.ColumnName = "ProjectCode";
			columnExpression2.Table = table;
			column2.Expression = columnExpression2;
			columnExpression3.ColumnName = "ProjectName";
			columnExpression3.Table = table;
			column3.Expression = columnExpression3;
			columnExpression4.ColumnName = "AshghalCode";
			columnExpression4.Table = table;
			column4.Expression = columnExpression4;
			columnExpression5.ColumnName = "StartDate";
			columnExpression5.Table = table;
			column5.Expression = columnExpression5;
			columnExpression6.ColumnName = "EndDate";
			columnExpression6.Table = table;
			column6.Expression = columnExpression6;
			columnExpression7.ColumnName = "ProjectLocation";
			columnExpression7.Table = table;
			column7.Expression = columnExpression7;
			columnExpression8.ColumnName = "FKProjectTypeID";
			columnExpression8.Table = table;
			column8.Expression = columnExpression8;
			columnExpression9.ColumnName = "ProjectConsultant";
			columnExpression9.Table = table;
			column9.Expression = columnExpression9;
			columnExpression10.ColumnName = "FKContractorID";
			columnExpression10.Table = table;
			column10.Expression = columnExpression10;
			columnExpression11.ColumnName = "ProjectOwner";
			columnExpression11.Table = table;
			column11.Expression = columnExpression11;
			columnExpression12.ColumnName = "IsClosed";
			columnExpression12.Table = table;
			column12.Expression = columnExpression12;
			columnExpression13.ColumnName = "ProjectTypeID";
			table2.MetaSerializable = "185|30|125|80";
			table2.Name = "ProjectsTypes";
			columnExpression13.Table = table2;
			column13.Expression = columnExpression13;
			columnExpression14.ColumnName = "ProjectTypeName";
			columnExpression14.Table = table2;
			column14.Expression = columnExpression14;
			columnExpression15.ColumnName = "ContractorName";
			table3.MetaSerializable = "340|30|125|320";
			table3.Name = "ContractorsList";
			columnExpression15.Table = table3;
			column15.Expression = columnExpression15;
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
			selectQuery.Name = "ProjectsList";
			relationColumnInfo.NestedKeyColumn = "ProjectTypeID";
			relationColumnInfo.ParentKeyColumn = "FKProjectTypeID";
			join.KeyColumns.Add(relationColumnInfo);
			join.Nested = table2;
			join.Parent = table;
			relationColumnInfo2.NestedKeyColumn = "ContractorID";
			relationColumnInfo2.ParentKeyColumn = "FKContractorID";
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
			this.Detail.Controls.AddRange(new XRControl[]
			{
				this.xrLabel21,
				this.xrLabel22,
				this.xrLabel1,
				this.xrLabel2,
				this.xrLabel3,
				this.xrLabel4,
				this.xrLabel5,
				this.xrLabel6,
				this.xrLabel7,
				this.xrLabel8,
				this.xrLabel9,
				this.xrLabel10,
				this.xrLabel11,
				this.xrLabel12,
				this.xrLabel13,
				this.xrLabel14,
				this.xrLabel15,
				this.xrLabel16,
				this.xrLabel17,
				this.xrLabel18,
				this.xrLabel19,
				this.xrCheckBox1
			});
			this.Detail.Dpi = 100f;
			this.Detail.HeightF = 245.9167f;
			this.Detail.Name = "Detail";
			this.Detail.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
			this.Detail.PageBreak = PageBreak.BeforeBand;
			this.Detail.TextAlignment = TextAlignment.TopLeft;
			this.xrLabel21.Borders = BorderSide.All;
			this.xrLabel21.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "ProjectsList.AshghalCode")
			});
			this.xrLabel21.Dpi = 100f;
			this.xrLabel21.LocationFloat = new PointFloat(472.75f, 46.50002f);
			this.xrLabel21.Name = "xrLabel21";
			this.xrLabel21.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel21.SizeF = new SizeF(175f, 17.99999f);
			this.xrLabel21.StyleName = "DataField";
			this.xrLabel21.StylePriority.UseBorders = false;
			this.xrLabel22.Dpi = 100f;
			this.xrLabel22.ForeColor = Color.FromArgb(0, 0, 0);
			this.xrLabel22.LocationFloat = new PointFloat(364.2501f, 46.50002f);
			this.xrLabel22.Multiline = true;
			this.xrLabel22.Name = "xrLabel22";
			this.xrLabel22.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel22.SizeF = new SizeF(108.4999f, 18f);
			this.xrLabel22.StyleName = "FieldCaption";
			this.xrLabel22.StylePriority.UseForeColor = false;
			this.xrLabel22.Text = "Ashghal Code:";
			this.xrLabel1.Dpi = 100f;
			this.xrLabel1.ForeColor = Color.FromArgb(0, 0, 0);
			this.xrLabel1.LocationFloat = new PointFloat(10.12499f, 46.50002f);
			this.xrLabel1.Name = "xrLabel1";
			this.xrLabel1.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel1.SizeF = new SizeF(131.6666f, 17.99999f);
			this.xrLabel1.StyleName = "FieldCaption";
			this.xrLabel1.StylePriority.UseForeColor = false;
			this.xrLabel1.Text = "Project Code:";
			this.xrLabel2.Dpi = 100f;
			this.xrLabel2.ForeColor = Color.FromArgb(0, 0, 0);
			this.xrLabel2.LocationFloat = new PointFloat(10.12499f, 70.49999f);
			this.xrLabel2.Name = "xrLabel2";
			this.xrLabel2.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel2.SizeF = new SizeF(131.5417f, 18f);
			this.xrLabel2.StyleName = "FieldCaption";
			this.xrLabel2.StylePriority.UseForeColor = false;
			this.xrLabel2.Text = "Start Date:";
			this.xrLabel3.Dpi = 100f;
			this.xrLabel3.ForeColor = Color.FromArgb(0, 0, 0);
			this.xrLabel3.LocationFloat = new PointFloat(364.2501f, 70.49999f);
			this.xrLabel3.Name = "xrLabel3";
			this.xrLabel3.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel3.SizeF = new SizeF(108.4999f, 18f);
			this.xrLabel3.StyleName = "FieldCaption";
			this.xrLabel3.StylePriority.UseForeColor = false;
			this.xrLabel3.Text = "End Date:";
			this.xrLabel4.Dpi = 100f;
			this.xrLabel4.ForeColor = Color.FromArgb(0, 0, 0);
			this.xrLabel4.LocationFloat = new PointFloat(9.99999f, 98.70834f);
			this.xrLabel4.Name = "xrLabel4";
			this.xrLabel4.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel4.SizeF = new SizeF(131.6667f, 18.00001f);
			this.xrLabel4.StyleName = "FieldCaption";
			this.xrLabel4.StylePriority.UseForeColor = false;
			this.xrLabel4.Text = "Project Name:";
			this.xrLabel5.Dpi = 100f;
			this.xrLabel5.ForeColor = Color.FromArgb(0, 0, 0);
			this.xrLabel5.LocationFloat = new PointFloat(9.99999f, 122.7083f);
			this.xrLabel5.Name = "xrLabel5";
			this.xrLabel5.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel5.SizeF = new SizeF(131.6667f, 18f);
			this.xrLabel5.StyleName = "FieldCaption";
			this.xrLabel5.StylePriority.UseForeColor = false;
			this.xrLabel5.Text = "Location:";
			this.xrLabel6.Dpi = 100f;
			this.xrLabel6.ForeColor = Color.FromArgb(0, 0, 0);
			this.xrLabel6.LocationFloat = new PointFloat(9.99999f, 146.7083f);
			this.xrLabel6.Name = "xrLabel6";
			this.xrLabel6.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel6.SizeF = new SizeF(145.3333f, 18f);
			this.xrLabel6.StyleName = "FieldCaption";
			this.xrLabel6.StylePriority.UseForeColor = false;
			this.xrLabel6.Text = "Project Type :";
			this.xrLabel7.Dpi = 100f;
			this.xrLabel7.ForeColor = Color.FromArgb(0, 0, 0);
			this.xrLabel7.LocationFloat = new PointFloat(10.12499f, 170.7083f);
			this.xrLabel7.Name = "xrLabel7";
			this.xrLabel7.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel7.SizeF = new SizeF(145.2083f, 18f);
			this.xrLabel7.StyleName = "FieldCaption";
			this.xrLabel7.StylePriority.UseForeColor = false;
			this.xrLabel7.Text = "Project Consultant:";
			this.xrLabel8.Dpi = 100f;
			this.xrLabel8.ForeColor = Color.FromArgb(0, 0, 0);
			this.xrLabel8.LocationFloat = new PointFloat(9.874988f, 194.7083f);
			this.xrLabel8.Name = "xrLabel8";
			this.xrLabel8.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel8.SizeF = new SizeF(131.7917f, 18f);
			this.xrLabel8.StyleName = "FieldCaption";
			this.xrLabel8.StylePriority.UseForeColor = false;
			this.xrLabel8.Text = "Contractor:";
			this.xrLabel9.Dpi = 100f;
			this.xrLabel9.ForeColor = Color.FromArgb(0, 0, 0);
			this.xrLabel9.LocationFloat = new PointFloat(9.874988f, 218.7084f);
			this.xrLabel9.Name = "xrLabel9";
			this.xrLabel9.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel9.SizeF = new SizeF(131.7917f, 18f);
			this.xrLabel9.StyleName = "FieldCaption";
			this.xrLabel9.StylePriority.UseForeColor = false;
			this.xrLabel9.Text = "Project Owner:";
			this.xrLabel10.Dpi = 100f;
			this.xrLabel10.ForeColor = Color.FromArgb(0, 0, 0);
			this.xrLabel10.LocationFloat = new PointFloat(581.8333f, 12f);
			this.xrLabel10.Multiline = true;
			this.xrLabel10.Name = "xrLabel10";
			this.xrLabel10.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel10.SizeF = new SizeF(66.16672f, 23f);
			this.xrLabel10.StyleName = "FieldCaption";
			this.xrLabel10.StylePriority.UseForeColor = false;
			this.xrLabel10.Text = "Inactive";
			this.xrLabel11.Borders = BorderSide.All;
			this.xrLabel11.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "ProjectsList.ProjectCode")
			});
			this.xrLabel11.Dpi = 100f;
			this.xrLabel11.LocationFloat = new PointFloat(177.9999f, 46.50002f);
			this.xrLabel11.Name = "xrLabel11";
			this.xrLabel11.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel11.SizeF = new SizeF(175f, 17.99999f);
			this.xrLabel11.StyleName = "DataField";
			this.xrLabel11.StylePriority.UseBorders = false;
			this.xrLabel11.Text = "xrLabel11";
			this.xrLabel12.Borders = BorderSide.All;
			this.xrLabel12.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "ProjectsList.StartDate", "{0:dd MMM yyyy}")
			});
			this.xrLabel12.Dpi = 100f;
			this.xrLabel12.LocationFloat = new PointFloat(177.75f, 70.49999f);
			this.xrLabel12.Name = "xrLabel12";
			this.xrLabel12.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel12.SizeF = new SizeF(175f, 18f);
			this.xrLabel12.StyleName = "DataField";
			this.xrLabel12.StylePriority.UseBorders = false;
			this.xrLabel12.Text = "xrLabel12";
			this.xrLabel13.Borders = BorderSide.All;
			this.xrLabel13.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "ProjectsList.EndDate", "{0:dd MMM yyyy}")
			});
			this.xrLabel13.Dpi = 100f;
			this.xrLabel13.LocationFloat = new PointFloat(472.75f, 70.49999f);
			this.xrLabel13.Name = "xrLabel13";
			this.xrLabel13.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel13.SizeF = new SizeF(175f, 18.00001f);
			this.xrLabel13.StyleName = "DataField";
			this.xrLabel13.StylePriority.UseBorders = false;
			this.xrLabel13.Text = "xrLabel13";
			this.xrLabel14.Borders = BorderSide.All;
			this.xrLabel14.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "ProjectsList.ProjectName")
			});
			this.xrLabel14.Dpi = 100f;
			this.xrLabel14.LocationFloat = new PointFloat(177.75f, 98.70834f);
			this.xrLabel14.Name = "xrLabel14";
			this.xrLabel14.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel14.SizeF = new SizeF(470f, 18f);
			this.xrLabel14.StyleName = "DataField";
			this.xrLabel14.StylePriority.UseBorders = false;
			this.xrLabel14.Text = "xrLabel14";
			this.xrLabel15.Borders = BorderSide.All;
			this.xrLabel15.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "ProjectsList.ProjectLocation")
			});
			this.xrLabel15.Dpi = 100f;
			this.xrLabel15.LocationFloat = new PointFloat(177.75f, 122.7083f);
			this.xrLabel15.Name = "xrLabel15";
			this.xrLabel15.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel15.SizeF = new SizeF(470f, 18f);
			this.xrLabel15.StyleName = "DataField";
			this.xrLabel15.StylePriority.UseBorders = false;
			this.xrLabel15.Text = "xrLabel15";
			this.xrLabel16.Borders = BorderSide.All;
			this.xrLabel16.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "ProjectsList.ProjectTypeName")
			});
			this.xrLabel16.Dpi = 100f;
			this.xrLabel16.LocationFloat = new PointFloat(177.75f, 146.7083f);
			this.xrLabel16.Name = "xrLabel16";
			this.xrLabel16.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel16.SizeF = new SizeF(470f, 18f);
			this.xrLabel16.StyleName = "DataField";
			this.xrLabel16.StylePriority.UseBorders = false;
			this.xrLabel16.Text = "xrLabel16";
			this.xrLabel17.Borders = BorderSide.All;
			this.xrLabel17.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "ProjectsList.ProjectConsultant")
			});
			this.xrLabel17.Dpi = 100f;
			this.xrLabel17.LocationFloat = new PointFloat(177.75f, 170.7083f);
			this.xrLabel17.Name = "xrLabel17";
			this.xrLabel17.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel17.SizeF = new SizeF(470f, 18f);
			this.xrLabel17.StyleName = "DataField";
			this.xrLabel17.StylePriority.UseBorders = false;
			this.xrLabel17.Text = "xrLabel17";
			this.xrLabel18.Borders = BorderSide.All;
			this.xrLabel18.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "ProjectsList.ContractorName")
			});
			this.xrLabel18.Dpi = 100f;
			this.xrLabel18.LocationFloat = new PointFloat(177.75f, 194.7083f);
			this.xrLabel18.Name = "xrLabel18";
			this.xrLabel18.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel18.SizeF = new SizeF(470f, 18f);
			this.xrLabel18.StyleName = "DataField";
			this.xrLabel18.StylePriority.UseBorders = false;
			this.xrLabel19.Borders = BorderSide.All;
			this.xrLabel19.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "ProjectsList.ProjectOwner")
			});
			this.xrLabel19.Dpi = 100f;
			this.xrLabel19.LocationFloat = new PointFloat(177.75f, 218.7084f);
			this.xrLabel19.Name = "xrLabel19";
			this.xrLabel19.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel19.SizeF = new SizeF(470f, 18f);
			this.xrLabel19.StyleName = "DataField";
			this.xrLabel19.StylePriority.UseBorders = false;
			this.xrLabel19.Text = "xrLabel19";
			this.xrCheckBox1.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("CheckState", null, "ProjectsList.IsClosed")
			});
			this.xrCheckBox1.Dpi = 100f;
			this.xrCheckBox1.LocationFloat = new PointFloat(559.7499f, 10.00001f);
			this.xrCheckBox1.Name = "xrCheckBox1";
			this.xrCheckBox1.SizeF = new SizeF(22.08334f, 23f);
			this.xrCheckBox1.StyleName = "DataField";
			this.TopMargin.Controls.AddRange(new XRControl[]
			{
				this.xrLine2,
				this.xrLabel20,
				this.xrLabel23,
				this.xrPictureBox1,
				this.xrLabel24,
				this.xrLabel25,
				this.xrLabel27,
				this.xrLine1,
				this.xrLabel28
			});
			this.TopMargin.Dpi = 100f;
			this.TopMargin.HeightF = 130f;
			this.TopMargin.Name = "TopMargin";
			this.TopMargin.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
			this.TopMargin.TextAlignment = TextAlignment.TopLeft;
			this.BottomMargin.Controls.AddRange(new XRControl[]
			{
				this.xrPictureBox2,
				this.xrPageInfo2,
				this.xrPageInfo1
			});
			this.BottomMargin.Dpi = 100f;
			this.BottomMargin.HeightF = 135.5834f;
			this.BottomMargin.Name = "BottomMargin";
			this.BottomMargin.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
			this.BottomMargin.TextAlignment = TextAlignment.TopLeft;
			this.xrPictureBox2.Dpi = 100f;
			this.xrPictureBox2.Image = (Image)resources.GetObject("xrPictureBox2.Image");
			this.xrPictureBox2.LocationFloat = new PointFloat(125.125f, 10.00001f);
			this.xrPictureBox2.Name = "xrPictureBox2";
			this.xrPictureBox2.SizeF = new SizeF(581.3381f, 74.20829f);
			this.xrPageInfo2.Dpi = 100f;
			this.xrPageInfo2.Format = "Page {0} of {1}";
			this.xrPageInfo2.LocationFloat = new PointFloat(517f, 102.5834f);
			this.xrPageInfo2.Name = "xrPageInfo2";
			this.xrPageInfo2.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrPageInfo2.SizeF = new SizeF(313f, 23f);
			this.xrPageInfo2.StyleName = "PageInfo";
			this.xrPageInfo2.TextAlignment = TextAlignment.TopRight;
			this.xrPageInfo1.Dpi = 100f;
			this.xrPageInfo1.LocationFloat = new PointFloat(9.99999f, 102.5834f);
			this.xrPageInfo1.Name = "xrPageInfo1";
			this.xrPageInfo1.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
			this.xrPageInfo1.SizeF = new SizeF(313f, 23f);
			this.xrPageInfo1.StyleName = "PageInfo";
			this.pageFooterBand1.Dpi = 100f;
			this.pageFooterBand1.HeightF = 3.999996f;
			this.pageFooterBand1.Name = "pageFooterBand1";
			this.reportHeaderBand1.Dpi = 100f;
			this.reportHeaderBand1.HeightF = 2.041658f;
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
			this.xrLabel26.Dpi = 100f;
			this.xrLabel26.LocationFloat = new PointFloat(82.41667f, 21.875f);
			this.xrLabel26.Name = "xrLabel26";
			this.xrLabel26.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel26.SizeF = new SizeF(638f, 33f);
			this.xrLabel26.StyleName = "Title";
			this.xrLabel26.StylePriority.UseTextAlignment = false;
			this.xrLabel26.Text = "Project Information";
			this.xrLabel26.TextAlignment = TextAlignment.TopCenter;
			this.PageHeader.Controls.AddRange(new XRControl[]
			{
				this.xrLabel26
			});
			this.PageHeader.Dpi = 100f;
			this.PageHeader.HeightF = 100f;
			this.PageHeader.Name = "PageHeader";
			this.Id.Description = "Id";
			dynamicListLookUpSettings.DataAdapter = null;
			dynamicListLookUpSettings.DataMember = "ProjectsList";
			dynamicListLookUpSettings.DataSource = this.sqlDataSource1;
			dynamicListLookUpSettings.DisplayMember = "ProjectName";
			dynamicListLookUpSettings.FilterString = null;
			dynamicListLookUpSettings.ValueMember = "ProjectID";
			this.Id.LookUpSettings = dynamicListLookUpSettings;
			this.Id.Name = "Id";
			this.Id.Type = typeof(int);
			this.Id.ValueInfo = "0";
			this.xrLine2.Dpi = 100f;
			this.xrLine2.ForeColor = Color.FromArgb(32, 150, 159);
			this.xrLine2.LocationFloat = new PointFloat(538.1331f, 99.47916f);
			this.xrLine2.Name = "xrLine2";
			this.xrLine2.SizeF = new SizeF(300.4026f, 13f);
			this.xrLine2.StylePriority.UseForeColor = false;
			this.xrLabel20.BackColor = Color.White;
			this.xrLabel20.Dpi = 100f;
			this.xrLabel20.Font = new Font("Times New Roman", 11f, FontStyle.Bold);
			this.xrLabel20.ForeColor = Color.FromArgb(45, 84, 108);
			this.xrLabel20.LocationFloat = new PointFloat(563.4379f, 71.52086f);
			this.xrLabel20.Name = "xrLabel20";
			this.xrLabel20.Padding = new PaddingInfo(2, 2, 0, 2, 100f);
			this.xrLabel20.SizeF = new SizeF(249.9936f, 22.99997f);
			this.xrLabel20.StylePriority.UseBackColor = false;
			this.xrLabel20.StylePriority.UseFont = false;
			this.xrLabel20.StylePriority.UseForeColor = false;
			this.xrLabel20.StylePriority.UsePadding = false;
			this.xrLabel20.StylePriority.UseTextAlignment = false;
			this.xrLabel20.Text = "اختبارات مواقع - تصميم خلطات - دراسات تربة";
			this.xrLabel20.TextAlignment = TextAlignment.TopRight;
			this.xrLabel23.BackColor = Color.White;
			this.xrLabel23.Dpi = 100f;
			this.xrLabel23.Font = new Font("Times New Roman", 11f, FontStyle.Bold);
			this.xrLabel23.ForeColor = Color.FromArgb(45, 84, 108);
			this.xrLabel23.LocationFloat = new PointFloat(563.4379f, 17.52084f);
			this.xrLabel23.Name = "xrLabel23";
			this.xrLabel23.Padding = new PaddingInfo(2, 2, 0, 2, 100f);
			this.xrLabel23.SizeF = new SizeF(249.9937f, 24f);
			this.xrLabel23.StylePriority.UseBackColor = false;
			this.xrLabel23.StylePriority.UseFont = false;
			this.xrLabel23.StylePriority.UseForeColor = false;
			this.xrLabel23.StylePriority.UsePadding = false;
			this.xrLabel23.StylePriority.UseTextAlignment = false;
			this.xrLabel23.Text = "إختبارات ميكانيكية وفزيائية  وكميائية لمواد البناء";
			this.xrLabel23.TextAlignment = TextAlignment.TopRight;
			this.xrPictureBox1.Dpi = 100f;
			this.xrPictureBox1.Image = (Image)resources.GetObject("xrPictureBox1.Image");
			this.xrPictureBox1.LocationFloat = new PointFloat(338.5699f, 17.52084f);
			this.xrPictureBox1.Name = "xrPictureBox1";
			this.xrPictureBox1.SizeF = new SizeF(189.2164f, 94.95832f);
			this.xrLabel24.BackColor = Color.White;
			this.xrLabel24.Dpi = 100f;
			this.xrLabel24.Font = new Font("Times New Roman", 11f, FontStyle.Bold);
			this.xrLabel24.ForeColor = Color.FromArgb(45, 84, 108);
			this.xrLabel24.LocationFloat = new PointFloat(563.4379f, 43.47918f);
			this.xrLabel24.Name = "xrLabel24";
			this.xrLabel24.Padding = new PaddingInfo(2, 2, 0, 2, 100f);
			this.xrLabel24.SizeF = new SizeF(249.9937f, 22.99997f);
			this.xrLabel24.StylePriority.UseBackColor = false;
			this.xrLabel24.StylePriority.UseFont = false;
			this.xrLabel24.StylePriority.UseForeColor = false;
			this.xrLabel24.StylePriority.UsePadding = false;
			this.xrLabel24.StylePriority.UseTextAlignment = false;
			this.xrLabel24.Text = "تربة - اسفلت - حصي - كونكريت - اسمنت - ماء";
			this.xrLabel24.TextAlignment = TextAlignment.TopRight;
			this.xrLabel25.BackColor = Color.White;
			this.xrLabel25.Dpi = 100f;
			this.xrLabel25.Font = new Font("Times New Roman", 9f, FontStyle.Bold);
			this.xrLabel25.ForeColor = Color.FromArgb(45, 84, 103);
			this.xrLabel25.LocationFloat = new PointFloat(1.464294f, 41.52085f);
			this.xrLabel25.Name = "xrLabel25";
			this.xrLabel25.Padding = new PaddingInfo(2, 2, 0, 2, 100f);
			this.xrLabel25.SizeF = new SizeF(310.5137f, 25f);
			this.xrLabel25.StylePriority.UseBackColor = false;
			this.xrLabel25.StylePriority.UseFont = false;
			this.xrLabel25.StylePriority.UseForeColor = false;
			this.xrLabel25.StylePriority.UsePadding = false;
			this.xrLabel25.StylePriority.UseTextAlignment = false;
			this.xrLabel25.Text = "Soil - Asphalt - Aggregate - Concrete - Cement - Water";
			this.xrLabel25.TextAlignment = TextAlignment.TopLeft;
			this.xrLabel27.BackColor = Color.White;
			this.xrLabel27.Dpi = 100f;
			this.xrLabel27.Font = new Font("Times New Roman", 9f, FontStyle.Bold);
			this.xrLabel27.ForeColor = Color.FromArgb(45, 84, 103);
			this.xrLabel27.LocationFloat = new PointFloat(1.464294f, 66.52084f);
			this.xrLabel27.Name = "xrLabel27";
			this.xrLabel27.Padding = new PaddingInfo(2, 2, 0, 2, 100f);
			this.xrLabel27.SizeF = new SizeF(288.8611f, 24f);
			this.xrLabel27.StylePriority.UseBackColor = false;
			this.xrLabel27.StylePriority.UseFont = false;
			this.xrLabel27.StylePriority.UseForeColor = false;
			this.xrLabel27.StylePriority.UsePadding = false;
			this.xrLabel27.StylePriority.UseTextAlignment = false;
			this.xrLabel27.Text = "Site testing - Material design mixes - Soil study";
			this.xrLabel27.TextAlignment = TextAlignment.TopLeft;
			this.xrLine1.Dpi = 100f;
			this.xrLine1.ForeColor = Color.FromArgb(32, 150, 159);
			this.xrLine1.LocationFloat = new PointFloat(2.326614f, 99.47916f);
			this.xrLine1.Name = "xrLine1";
			this.xrLine1.SizeF = new SizeF(300.4026f, 13f);
			this.xrLine1.StylePriority.UseForeColor = false;
			this.xrLabel28.BackColor = Color.White;
			this.xrLabel28.Dpi = 100f;
			this.xrLabel28.Font = new Font("Times New Roman", 9f, FontStyle.Bold);
			this.xrLabel28.ForeColor = Color.FromArgb(45, 84, 103);
			this.xrLabel28.LocationFloat = new PointFloat(1.464294f, 17.52084f);
			this.xrLabel28.Name = "xrLabel28";
			this.xrLabel28.Padding = new PaddingInfo(2, 2, 0, 2, 100f);
			this.xrLabel28.SizeF = new SizeF(285.9722f, 24f);
			this.xrLabel28.StylePriority.UseBackColor = false;
			this.xrLabel28.StylePriority.UseFont = false;
			this.xrLabel28.StylePriority.UseForeColor = false;
			this.xrLabel28.StylePriority.UsePadding = false;
			this.xrLabel28.StylePriority.UseTextAlignment = false;
			this.xrLabel28.Text = "Mechanical , physical and chimical material testing";
			this.xrLabel28.TextAlignment = TextAlignment.TopLeft;
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
			base.DataMember = "ProjectsList";
			base.DataSource = this.sqlDataSource1;
			this.FilterString = "[ProjectID] = ?Id";
			base.Margins = new Margins(3, 7, 130, 136);
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
			((ISupportInitialize)this).EndInit();
		}

		// Token: 0x04000861 RID: 2145
		private IContainer components;

		// Token: 0x04000862 RID: 2146
		private DetailBand Detail;

		// Token: 0x04000863 RID: 2147
		private TopMarginBand TopMargin;

		// Token: 0x04000864 RID: 2148
		private BottomMarginBand BottomMargin;

		// Token: 0x04000865 RID: 2149
		private XRLabel xrLabel21;

		// Token: 0x04000866 RID: 2150
		private XRLabel xrLabel22;

		// Token: 0x04000867 RID: 2151
		private XRLabel xrLabel1;

		// Token: 0x04000868 RID: 2152
		private XRLabel xrLabel2;

		// Token: 0x04000869 RID: 2153
		private XRLabel xrLabel3;

		// Token: 0x0400086A RID: 2154
		private XRLabel xrLabel4;

		// Token: 0x0400086B RID: 2155
		private XRLabel xrLabel5;

		// Token: 0x0400086C RID: 2156
		private XRLabel xrLabel6;

		// Token: 0x0400086D RID: 2157
		private XRLabel xrLabel7;

		// Token: 0x0400086E RID: 2158
		private XRLabel xrLabel8;

		// Token: 0x0400086F RID: 2159
		private XRLabel xrLabel9;

		// Token: 0x04000870 RID: 2160
		private XRLabel xrLabel10;

		// Token: 0x04000871 RID: 2161
		private XRLabel xrLabel11;

		// Token: 0x04000872 RID: 2162
		private XRLabel xrLabel12;

		// Token: 0x04000873 RID: 2163
		private XRLabel xrLabel13;

		// Token: 0x04000874 RID: 2164
		private XRLabel xrLabel14;

		// Token: 0x04000875 RID: 2165
		private XRLabel xrLabel15;

		// Token: 0x04000876 RID: 2166
		private XRLabel xrLabel16;

		// Token: 0x04000877 RID: 2167
		private XRLabel xrLabel17;

		// Token: 0x04000878 RID: 2168
		private XRLabel xrLabel18;

		// Token: 0x04000879 RID: 2169
		private XRLabel xrLabel19;

		// Token: 0x0400087A RID: 2170
		private XRCheckBox xrCheckBox1;

		// Token: 0x0400087B RID: 2171
		private SqlDataSource sqlDataSource1;

		// Token: 0x0400087C RID: 2172
		private PageFooterBand pageFooterBand1;

		// Token: 0x0400087D RID: 2173
		private XRPageInfo xrPageInfo1;

		// Token: 0x0400087E RID: 2174
		private XRPageInfo xrPageInfo2;

		// Token: 0x0400087F RID: 2175
		private ReportHeaderBand reportHeaderBand1;

		// Token: 0x04000880 RID: 2176
		private XRControlStyle Title;

		// Token: 0x04000881 RID: 2177
		private XRControlStyle FieldCaption;

		// Token: 0x04000882 RID: 2178
		private XRControlStyle PageInfo;

		// Token: 0x04000883 RID: 2179
		private XRControlStyle DataField;

		// Token: 0x04000884 RID: 2180
		private XRLabel xrLabel26;

		// Token: 0x04000885 RID: 2181
		private XRPictureBox xrPictureBox2;

		// Token: 0x04000886 RID: 2182
		private PageHeaderBand PageHeader;

		// Token: 0x04000887 RID: 2183
		private Parameter Id;

		// Token: 0x04000888 RID: 2184
		private XRLine xrLine2;

		// Token: 0x04000889 RID: 2185
		private XRLabel xrLabel20;

		// Token: 0x0400088A RID: 2186
		private XRLabel xrLabel23;

		// Token: 0x0400088B RID: 2187
		private XRPictureBox xrPictureBox1;

		// Token: 0x0400088C RID: 2188
		private XRLabel xrLabel24;

		// Token: 0x0400088D RID: 2189
		private XRLabel xrLabel25;

		// Token: 0x0400088E RID: 2190
		private XRLabel xrLabel27;

		// Token: 0x0400088F RID: 2191
		private XRLine xrLine1;

		// Token: 0x04000890 RID: 2192
		private XRLabel xrLabel28;
	}
}
