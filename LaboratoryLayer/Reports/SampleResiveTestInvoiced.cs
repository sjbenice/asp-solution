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
	// Token: 0x0200006A RID: 106
	public class SampleResiveTestInvoiced : XtraReport
	{
		// Token: 0x06000379 RID: 889 RVA: 0x00004542 File Offset: 0x00002742
		public SampleResiveTestInvoiced()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600037A RID: 890 RVA: 0x00004550 File Offset: 0x00002750
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600037B RID: 891 RVA: 0x00056830 File Offset: 0x00054A30
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery1 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            DevExpress.DataAccess.Sql.SelectQuery selectQuery1 = new DevExpress.DataAccess.Sql.SelectQuery();
            DevExpress.DataAccess.Sql.Column column1 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression1 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Table table1 = new DevExpress.DataAccess.Sql.Table();
            DevExpress.DataAccess.Sql.Column column2 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression2 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Table table2 = new DevExpress.DataAccess.Sql.Table();
            DevExpress.DataAccess.Sql.Column column3 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression3 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Table table3 = new DevExpress.DataAccess.Sql.Table();
            DevExpress.DataAccess.Sql.Column column4 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression4 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Join join1 = new DevExpress.DataAccess.Sql.Join();
            DevExpress.DataAccess.Sql.RelationColumnInfo relationColumnInfo1 = new DevExpress.DataAccess.Sql.RelationColumnInfo();
            DevExpress.DataAccess.Sql.Table table4 = new DevExpress.DataAccess.Sql.Table();
            DevExpress.DataAccess.Sql.Join join2 = new DevExpress.DataAccess.Sql.Join();
            DevExpress.DataAccess.Sql.RelationColumnInfo relationColumnInfo2 = new DevExpress.DataAccess.Sql.RelationColumnInfo();
            DevExpress.DataAccess.Sql.Table table5 = new DevExpress.DataAccess.Sql.Table();
            DevExpress.DataAccess.Sql.Join join3 = new DevExpress.DataAccess.Sql.Join();
            DevExpress.DataAccess.Sql.RelationColumnInfo relationColumnInfo3 = new DevExpress.DataAccess.Sql.RelationColumnInfo();
            DevExpress.DataAccess.Sql.Table table6 = new DevExpress.DataAccess.Sql.Table();
            DevExpress.DataAccess.Sql.Join join4 = new DevExpress.DataAccess.Sql.Join();
            DevExpress.DataAccess.Sql.RelationColumnInfo relationColumnInfo4 = new DevExpress.DataAccess.Sql.RelationColumnInfo();
            DevExpress.DataAccess.Sql.Join join5 = new DevExpress.DataAccess.Sql.Join();
            DevExpress.DataAccess.Sql.RelationColumnInfo relationColumnInfo5 = new DevExpress.DataAccess.Sql.RelationColumnInfo();
            DevExpress.DataAccess.Sql.MasterDetailInfo masterDetailInfo1 = new DevExpress.DataAccess.Sql.MasterDetailInfo();
            DevExpress.DataAccess.Sql.RelationColumnInfo relationColumnInfo6 = new DevExpress.DataAccess.Sql.RelationColumnInfo();
            DevExpress.XtraReports.Parameters.DynamicListLookUpSettings dynamicListLookUpSettings1 = new DevExpress.XtraReports.Parameters.DynamicListLookUpSettings();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrRichText1 = new DevExpress.XtraReports.UI.XRRichText();
            this.DetailReport = new DevExpress.XtraReports.UI.DetailReportBand();
            this.Detail1 = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell22 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell19 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell21 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.InvoiceId = new DevExpress.XtraReports.Parameters.Parameter();
            this.DetailReport1 = new DevExpress.XtraReports.UI.DetailReportBand();
            this.Detail2 = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "localhost_LabSys_Connection";
            this.sqlDataSource1.Name = "sqlDataSource1";
            customSqlQuery1.Name = "Sample Resive Invoice";
            customSqlQuery1.Sql = null;
            columnExpression1.ColumnName = "InvoiceId";
            table1.MetaSerializable = "30|30|125|300";
            table1.Name = "Invoice";
            columnExpression1.Table = table1;
            column1.Expression = columnExpression1;
            columnExpression2.ColumnName = "CustomerName";
            table2.MetaSerializable = "650|30|125|300";
            table2.Name = "CustomersList";
            columnExpression2.Table = table2;
            column2.Expression = columnExpression2;
            columnExpression3.ColumnName = "ProjectName";
            table3.MetaSerializable = "805|30|125|280";
            table3.Name = "ProjectsList";
            columnExpression3.Table = table3;
            column3.Expression = columnExpression3;
            columnExpression4.ColumnName = "SRTTotal";
            columnExpression4.Table = table1;
            column4.Expression = columnExpression4;
            selectQuery1.Columns.Add(column1);
            selectQuery1.Columns.Add(column2);
            selectQuery1.Columns.Add(column3);
            selectQuery1.Columns.Add(column4);
            selectQuery1.Distinct = true;
            selectQuery1.FilterString = "";
            selectQuery1.GroupFilterString = "";
            selectQuery1.Name = "Invoice";
            relationColumnInfo1.NestedKeyColumn = "FkInvoiceId";
            relationColumnInfo1.ParentKeyColumn = "InvoiceId";
            join1.KeyColumns.Add(relationColumnInfo1);
            table4.MetaSerializable = "185|30|125|100";
            table4.Name = "SampleReceiveTestInvoice";
            join1.Nested = table4;
            join1.Parent = table1;
            relationColumnInfo2.NestedKeyColumn = "SampleReceiveTestID";
            relationColumnInfo2.ParentKeyColumn = "FkSampleReceiveTestID";
            join2.KeyColumns.Add(relationColumnInfo2);
            table5.MetaSerializable = "340|30|125|440";
            table5.Name = "SampleReceiveTestList";
            join2.Nested = table5;
            join2.Parent = table4;
            relationColumnInfo3.NestedKeyColumn = "JobOrderMasterID";
            relationColumnInfo3.ParentKeyColumn = "FKJobOrderMasterID";
            join3.KeyColumns.Add(relationColumnInfo3);
            table6.MetaSerializable = "495|30|125|360";
            table6.Name = "JobOrderMaster";
            join3.Nested = table6;
            join3.Parent = table1;
            relationColumnInfo4.NestedKeyColumn = "CustomerID";
            relationColumnInfo4.ParentKeyColumn = "FKCustomerID";
            join4.KeyColumns.Add(relationColumnInfo4);
            join4.Nested = table2;
            join4.Parent = table6;
            relationColumnInfo5.NestedKeyColumn = "ProjectID";
            relationColumnInfo5.ParentKeyColumn = "FKProjectID";
            join5.KeyColumns.Add(relationColumnInfo5);
            join5.Nested = table3;
            join5.Parent = table6;
            selectQuery1.Relations.Add(join1);
            selectQuery1.Relations.Add(join2);
            selectQuery1.Relations.Add(join3);
            selectQuery1.Relations.Add(join4);
            selectQuery1.Relations.Add(join5);
            selectQuery1.Tables.Add(table1);
            selectQuery1.Tables.Add(table4);
            selectQuery1.Tables.Add(table5);
            selectQuery1.Tables.Add(table6);
            selectQuery1.Tables.Add(table2);
            selectQuery1.Tables.Add(table3);
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery1,
            selectQuery1});
            masterDetailInfo1.DetailQueryName = "Sample Resive Invoice";
            relationColumnInfo6.NestedKeyColumn = "FkInvoiceId";
            relationColumnInfo6.ParentKeyColumn = "InvoiceId";
            masterDetailInfo1.KeyColumns.Add(relationColumnInfo6);
            masterDetailInfo1.MasterQueryName = "Invoice";
            this.sqlDataSource1.Relations.AddRange(new DevExpress.DataAccess.Sql.MasterDetailInfo[] {
            masterDetailInfo1});
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 60.41667F;
            this.Detail.KeepTogether = true;
            this.Detail.KeepTogetherWithDetailReports = true;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.PageBreak = DevExpress.XtraReports.UI.PageBreak.BeforeBand;
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTable1
            // 
            this.xrTable1.Dpi = 100F;
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(21.45833F, 2.083333F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1,
            this.xrTableRow2});
            this.xrTable1.SizeF = new System.Drawing.SizeF(805F, 50F);
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell2});
            this.xrTableRow1.Dpi = 100F;
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell1.Dpi = 100F;
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.StylePriority.UseBorders = false;
            this.xrTableCell1.StylePriority.UseTextAlignment = false;
            this.xrTableCell1.Text = "Creditor Name";
            this.xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell1.Weight = 0.30973885777484944D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Invoice.CustomerName")});
            this.xrTableCell2.Dpi = 100F;
            this.xrTableCell2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell2.StylePriority.UseBorders = false;
            this.xrTableCell2.StylePriority.UseFont = false;
            this.xrTableCell2.StylePriority.UsePadding = false;
            this.xrTableCell2.Weight = 1.6902611422251506D;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell4,
            this.xrTableCell5});
            this.xrTableRow2.Dpi = 100F;
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 1D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell4.Dpi = 100F;
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.StylePriority.UseBorders = false;
            this.xrTableCell4.StylePriority.UseTextAlignment = false;
            this.xrTableCell4.Text = "Project Name";
            this.xrTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell4.Weight = 0.30973885777484944D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell5.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Invoice.ProjectName")});
            this.xrTableCell5.Dpi = 100F;
            this.xrTableCell5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell5.StylePriority.UseBorders = false;
            this.xrTableCell5.StylePriority.UseFont = false;
            this.xrTableCell5.StylePriority.UsePadding = false;
            this.xrTableCell5.Weight = 1.6902611422251506D;
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 88.29166F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 0F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Dpi = 100F;
            this.ReportHeader.HeightF = 2.083333F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo2});
            this.PageFooter.Dpi = 100F;
            this.PageFooter.HeightF = 54.16667F;
            this.PageFooter.Name = "PageFooter";
            // 
            // xrPageInfo2
            // 
            this.xrPageInfo2.Dpi = 100F;
            this.xrPageInfo2.Format = "Page {0} of {1}";
            this.xrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(275.5416F, 31.16665F);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo2.SizeF = new System.Drawing.SizeF(313F, 23F);
            this.xrPageInfo2.StylePriority.UseTextAlignment = false;
            this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrRichText1
            // 
            this.xrRichText1.Dpi = 100F;
            this.xrRichText1.Font = new System.Drawing.Font("Times New Roman", 20F);
            this.xrRichText1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.xrRichText1.LocationFloat = new DevExpress.Utils.PointFloat(258.3333F, 0F);
            this.xrRichText1.Name = "xrRichText1";
            this.xrRichText1.SizeF = new System.Drawing.SizeF(330.2083F, 48F);
            this.xrRichText1.StylePriority.UseFont = false;
            this.xrRichText1.StylePriority.UseForeColor = false;
            // 
            // DetailReport
            // 
            this.DetailReport.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail1,
            this.GroupHeader1});
            this.DetailReport.DataMember = "Invoice.InvoiceSample Resive Invoice";
            this.DetailReport.DataSource = this.sqlDataSource1;
            this.DetailReport.Dpi = 100F;
            this.DetailReport.Level = 0;
            this.DetailReport.Name = "DetailReport";
            // 
            // Detail1
            // 
            this.Detail1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable3});
            this.Detail1.Dpi = 100F;
            this.Detail1.HeightF = 25F;
            this.Detail1.Name = "Detail1";
            // 
            // xrTable3
            // 
            this.xrTable3.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable3.Dpi = 100F;
            this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(21.45833F, 0F);
            this.xrTable3.Name = "xrTable3";
            this.xrTable3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 0, 0, 0, 100F);
            this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow4});
            this.xrTable3.SizeF = new System.Drawing.SizeF(805F, 25F);
            this.xrTable3.StylePriority.UseBorders = false;
            this.xrTable3.StylePriority.UsePadding = false;
            this.xrTable3.StylePriority.UseTextAlignment = false;
            this.xrTable3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrTableRow4
            // 
            this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell13,
            this.xrTableCell14,
            this.xrTableCell15,
            this.xrTableCell16,
            this.xrTableCell22,
            this.xrTableCell17,
            this.xrTableCell18,
            this.xrTableCell19,
            this.xrTableCell20});
            this.xrTableRow4.Dpi = 100F;
            this.xrTableRow4.Name = "xrTableRow4";
            this.xrTableRow4.Weight = 11.5D;
            // 
            // xrTableCell13
            // 
            this.xrTableCell13.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Invoice.InvoiceSample Resive Invoice.ReceiveDate", "{0:dd MMM yyyy}")});
            this.xrTableCell13.Dpi = 100F;
            this.xrTableCell13.Name = "xrTableCell13";
            this.xrTableCell13.Text = "xrTableCell13";
            this.xrTableCell13.Weight = 2.1094186531226939D;
            // 
            // xrTableCell14
            // 
            this.xrTableCell14.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Invoice.InvoiceSample Resive Invoice.SampleNo")});
            this.xrTableCell14.Dpi = 100F;
            this.xrTableCell14.Name = "xrTableCell14";
            this.xrTableCell14.Text = "xrTableCell14";
            this.xrTableCell14.Weight = 1.5151993222505391D;
            // 
            // xrTableCell15
            // 
            this.xrTableCell15.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Invoice.InvoiceSample Resive Invoice.MaterialDescription")});
            this.xrTableCell15.Dpi = 100F;
            this.xrTableCell15.Name = "xrTableCell15";
            this.xrTableCell15.Text = "xrTableCell15";
            this.xrTableCell15.Weight = 3.0695016143144667D;
            // 
            // xrTableCell16
            // 
            this.xrTableCell16.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Invoice.InvoiceSample Resive Invoice.TestName")});
            this.xrTableCell16.Dpi = 100F;
            this.xrTableCell16.Name = "xrTableCell16";
            this.xrTableCell16.Text = "xrTableCell16";
            this.xrTableCell16.Weight = 6.54160075814184D;
            // 
            // xrTableCell22
            // 
            this.xrTableCell22.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Invoice.InvoiceSample Resive Invoice.ReportNumber")});
            this.xrTableCell22.Dpi = 100F;
            this.xrTableCell22.Name = "xrTableCell22";
            this.xrTableCell22.Weight = 1.4813326908118176D;
            // 
            // xrTableCell17
            // 
            this.xrTableCell17.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Invoice.InvoiceSample Resive Invoice.Qty", "{0:#}")});
            this.xrTableCell17.Dpi = 100F;
            this.xrTableCell17.Name = "xrTableCell17";
            this.xrTableCell17.Text = "xrTableCell17";
            this.xrTableCell17.Weight = 0.66034021631600537D;
            // 
            // xrTableCell18
            // 
            this.xrTableCell18.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Invoice.InvoiceSample Resive Invoice.unit")});
            this.xrTableCell18.Dpi = 100F;
            this.xrTableCell18.Name = "xrTableCell18";
            this.xrTableCell18.Text = "xrTableCell18";
            this.xrTableCell18.Weight = 1.0745390645233275D;
            // 
            // xrTableCell19
            // 
            this.xrTableCell19.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Invoice.InvoiceSample Resive Invoice.Rate", "{0:#.00}")});
            this.xrTableCell19.Dpi = 100F;
            this.xrTableCell19.Name = "xrTableCell19";
            this.xrTableCell19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 10, 0, 0, 100F);
            this.xrTableCell19.StylePriority.UsePadding = false;
            this.xrTableCell19.StylePriority.UseTextAlignment = false;
            this.xrTableCell19.Text = "xrTableCell19";
            this.xrTableCell19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell19.Weight = 1.554602337254549D;
            // 
            // xrTableCell20
            // 
            this.xrTableCell20.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Invoice.InvoiceSample Resive Invoice.Price", "{0:#.00}")});
            this.xrTableCell20.Dpi = 100F;
            this.xrTableCell20.Name = "xrTableCell20";
            this.xrTableCell20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 10, 0, 0, 100F);
            this.xrTableCell20.StylePriority.UsePadding = false;
            this.xrTableCell20.StylePriority.UseTextAlignment = false;
            this.xrTableCell20.Text = "xrTableCell20";
            this.xrTableCell20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell20.Weight = 1.665564537375763D;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2});
            this.GroupHeader1.Dpi = 100F;
            this.GroupHeader1.HeightF = 27.08333F;
            this.GroupHeader1.Name = "GroupHeader1";
            this.GroupHeader1.RepeatEveryPage = true;
            // 
            // xrTable2
            // 
            this.xrTable2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.xrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable2.Dpi = 100F;
            this.xrTable2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(21.45833F, 2.083333F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
            this.xrTable2.SizeF = new System.Drawing.SizeF(805F, 25F);
            this.xrTable2.StylePriority.UseBackColor = false;
            this.xrTable2.StylePriority.UseBorders = false;
            this.xrTable2.StylePriority.UseFont = false;
            this.xrTable2.StylePriority.UseTextAlignment = false;
            this.xrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrTableRow3
            // 
            this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell3,
            this.xrTableCell6,
            this.xrTableCell7,
            this.xrTableCell8,
            this.xrTableCell21,
            this.xrTableCell9,
            this.xrTableCell10,
            this.xrTableCell11,
            this.xrTableCell12});
            this.xrTableRow3.Dpi = 100F;
            this.xrTableRow3.Name = "xrTableRow3";
            this.xrTableRow3.Weight = 11.5D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Dpi = 100F;
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.Text = "Recieved Date";
            this.xrTableCell3.Weight = 2.4611640444658822D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.Dpi = 100F;
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.Text = "Sample No";
            this.xrTableCell6.Weight = 1.7678592694938966D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.Dpi = 100F;
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.Text = "Material Description";
            this.xrTableCell7.Weight = 3.5813412238108508D;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.Dpi = 100F;
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.Text = "Test Name";
            this.xrTableCell8.Weight = 7.632415680151599D;
            // 
            // xrTableCell21
            // 
            this.xrTableCell21.Dpi = 100F;
            this.xrTableCell21.Name = "xrTableCell21";
            this.xrTableCell21.Text = "Report No";
            this.xrTableCell21.Weight = 1.7283455046762133D;
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.Dpi = 100F;
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.Text = "Qty";
            this.xrTableCell9.Weight = 0.77045396685355816D;
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.Dpi = 100F;
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.Text = "Unit";
            this.xrTableCell10.Weight = 1.253718910399289D;
            // 
            // xrTableCell11
            // 
            this.xrTableCell11.Dpi = 100F;
            this.xrTableCell11.Name = "xrTableCell11";
            this.xrTableCell11.Text = "Rate";
            this.xrTableCell11.Weight = 1.8138330427701024D;
            // 
            // xrTableCell12
            // 
            this.xrTableCell12.Dpi = 100F;
            this.xrTableCell12.Name = "xrTableCell12";
            this.xrTableCell12.Text = "Price";
            this.xrTableCell12.Weight = 1.9432973081452669D;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrRichText1});
            this.PageHeader.Dpi = 100F;
            this.PageHeader.HeightF = 64.58334F;
            this.PageHeader.Name = "PageHeader";
            // 
            // InvoiceId
            // 
            this.InvoiceId.Description = "Parameter1";
            dynamicListLookUpSettings1.DataAdapter = null;
            dynamicListLookUpSettings1.DataMember = "Invoice";
            dynamicListLookUpSettings1.DataSource = this.sqlDataSource1;
            dynamicListLookUpSettings1.DisplayMember = "InvoiceId";
            dynamicListLookUpSettings1.FilterString = null;
            dynamicListLookUpSettings1.ValueMember = "InvoiceId";
            this.InvoiceId.LookUpSettings = dynamicListLookUpSettings1;
            this.InvoiceId.Name = "InvoiceId";
            this.InvoiceId.Type = typeof(int);
            this.InvoiceId.ValueInfo = "0";
            // 
            // DetailReport1
            // 
            this.DetailReport1.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail2});
            this.DetailReport1.Dpi = 100F;
            this.DetailReport1.Level = 1;
            this.DetailReport1.Name = "DetailReport1";
            // 
            // Detail2
            // 
            this.Detail2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel19,
            this.xrLabel21});
            this.Detail2.Dpi = 100F;
            this.Detail2.HeightF = 27.08333F;
            this.Detail2.Name = "Detail2";
            // 
            // xrLabel19
            // 
            this.xrLabel19.BackColor = System.Drawing.Color.WhiteSmoke;
            this.xrLabel19.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel19.Dpi = 100F;
            this.xrLabel19.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel19.LocationFloat = new DevExpress.Utils.PointFloat(563.0759F, 0F);
            this.xrLabel19.Name = "xrLabel19";
            this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel19.SizeF = new System.Drawing.SizeF(141.0598F, 20.64583F);
            this.xrLabel19.StylePriority.UseBackColor = false;
            this.xrLabel19.StylePriority.UseBorders = false;
            this.xrLabel19.StylePriority.UseFont = false;
            this.xrLabel19.StylePriority.UsePadding = false;
            this.xrLabel19.StylePriority.UseTextAlignment = false;
            this.xrLabel19.Text = "TOTAL(QAR):";
            this.xrLabel19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel21
            // 
            this.xrLabel21.BackColor = System.Drawing.Color.WhiteSmoke;
            this.xrLabel21.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel21.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Invoice.SRTTotal", "{0:n2}")});
            this.xrLabel21.Dpi = 100F;
            this.xrLabel21.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel21.LocationFloat = new DevExpress.Utils.PointFloat(704.1356F, 0F);
            this.xrLabel21.Name = "xrLabel21";
            this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 10, 0, 0, 100F);
            this.xrLabel21.SizeF = new System.Drawing.SizeF(122.3227F, 20.64583F);
            this.xrLabel21.StylePriority.UseBackColor = false;
            this.xrLabel21.StylePriority.UseBorders = false;
            this.xrLabel21.StylePriority.UseFont = false;
            this.xrLabel21.StylePriority.UsePadding = false;
            this.xrLabel21.StylePriority.UseTextAlignment = false;
            this.xrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // SampleResiveTestInvoiced
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.PageFooter,
            this.DetailReport,
            this.PageHeader,
            this.DetailReport1});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "Invoice";
            this.DataSource = this.sqlDataSource1;
            this.FilterString = "[InvoiceId] = ?InvoiceId";
            this.Margins = new System.Drawing.Printing.Margins(0, 0, 88, 0);
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.InvoiceId});
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		}

		// Token: 0x04000A90 RID: 2704
		private IContainer components;

		// Token: 0x04000A91 RID: 2705
		private DetailBand Detail;

		// Token: 0x04000A92 RID: 2706
		private TopMarginBand TopMargin;

		// Token: 0x04000A93 RID: 2707
		private BottomMarginBand BottomMargin;

		// Token: 0x04000A94 RID: 2708
		private SqlDataSource sqlDataSource1;

		// Token: 0x04000A95 RID: 2709
		private ReportHeaderBand ReportHeader;

		// Token: 0x04000A96 RID: 2710
		private XRRichText xrRichText1;

		// Token: 0x04000A97 RID: 2711
		private PageFooterBand PageFooter;

		// Token: 0x04000A98 RID: 2712
		private XRPageInfo xrPageInfo2;

		// Token: 0x04000A99 RID: 2713
		private XRTable xrTable1;

		// Token: 0x04000A9A RID: 2714
		private XRTableRow xrTableRow1;

		// Token: 0x04000A9B RID: 2715
		private XRTableCell xrTableCell1;

		// Token: 0x04000A9C RID: 2716
		private XRTableCell xrTableCell2;

		// Token: 0x04000A9D RID: 2717
		private XRTableRow xrTableRow2;

		// Token: 0x04000A9E RID: 2718
		private XRTableCell xrTableCell4;

		// Token: 0x04000A9F RID: 2719
		private XRTableCell xrTableCell5;

		// Token: 0x04000AA0 RID: 2720
		private DetailReportBand DetailReport;

		// Token: 0x04000AA1 RID: 2721
		private DetailBand Detail1;

		// Token: 0x04000AA2 RID: 2722
		private XRTable xrTable2;

		// Token: 0x04000AA3 RID: 2723
		private XRTableRow xrTableRow3;

		// Token: 0x04000AA4 RID: 2724
		private XRTableCell xrTableCell3;

		// Token: 0x04000AA5 RID: 2725
		private XRTableCell xrTableCell6;

		// Token: 0x04000AA6 RID: 2726
		private XRTableCell xrTableCell7;

		// Token: 0x04000AA7 RID: 2727
		private XRTableCell xrTableCell8;

		// Token: 0x04000AA8 RID: 2728
		private XRTableCell xrTableCell9;

		// Token: 0x04000AA9 RID: 2729
		private XRTableCell xrTableCell10;

		// Token: 0x04000AAA RID: 2730
		private XRTableCell xrTableCell11;

		// Token: 0x04000AAB RID: 2731
		private XRTableCell xrTableCell12;

		// Token: 0x04000AAC RID: 2732
		private PageHeaderBand PageHeader;

		// Token: 0x04000AAD RID: 2733
		private Parameter InvoiceId;

		// Token: 0x04000AAE RID: 2734
		private DetailReportBand DetailReport1;

		// Token: 0x04000AAF RID: 2735
		private DetailBand Detail2;

		// Token: 0x04000AB0 RID: 2736
		private XRLabel xrLabel19;

		// Token: 0x04000AB1 RID: 2737
		private XRLabel xrLabel21;

		// Token: 0x04000AB2 RID: 2738
		private XRTableCell xrTableCell21;

		// Token: 0x04000AB3 RID: 2739
		private XRTable xrTable3;

		// Token: 0x04000AB4 RID: 2740
		private XRTableRow xrTableRow4;

		// Token: 0x04000AB5 RID: 2741
		private XRTableCell xrTableCell13;

		// Token: 0x04000AB6 RID: 2742
		private XRTableCell xrTableCell14;

		// Token: 0x04000AB7 RID: 2743
		private XRTableCell xrTableCell15;

		// Token: 0x04000AB8 RID: 2744
		private XRTableCell xrTableCell16;

		// Token: 0x04000AB9 RID: 2745
		private XRTableCell xrTableCell22;

		// Token: 0x04000ABA RID: 2746
		private XRTableCell xrTableCell17;

		// Token: 0x04000ABB RID: 2747
		private XRTableCell xrTableCell18;

		// Token: 0x04000ABC RID: 2748
		private XRTableCell xrTableCell19;

		// Token: 0x04000ABD RID: 2749
		private XRTableCell xrTableCell20;

		// Token: 0x04000ABE RID: 2750
		private GroupHeaderBand GroupHeader1;
	}
}
