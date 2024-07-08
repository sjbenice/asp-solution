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
	// Token: 0x0200006C RID: 108
	public class ServiceInformationReport : XtraReport
	{
		// Token: 0x06000380 RID: 896 RVA: 0x000045E2 File Offset: 0x000027E2
		public ServiceInformationReport()
		{
			this.InitializeComponent();
			this.BeforePrint += this.ServiceInformationReport_BeforePrint;
		}

		// Token: 0x06000381 RID: 897 RVA: 0x00059FD4 File Offset: 0x000581D4
		private void ServiceInformationReport_BeforePrint(object sender, PrintEventArgs e)
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

		// Token: 0x06000382 RID: 898 RVA: 0x00004602 File Offset: 0x00002802
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000383 RID: 899 RVA: 0x0005A03C File Offset: 0x0005823C
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
			Column column18 = new Column();
			ColumnExpression columnExpression18 = new ColumnExpression();
			Column column19 = new Column();
			ColumnExpression columnExpression19 = new ColumnExpression();
			Column column20 = new Column();
			ColumnExpression columnExpression20 = new ColumnExpression();
			Column column21 = new Column();
			ColumnExpression columnExpression21 = new ColumnExpression();
			Column column22 = new Column();
			ColumnExpression columnExpression22 = new ColumnExpression();
			Column column23 = new Column();
			ColumnExpression columnExpression23 = new ColumnExpression();
			Table table2 = new Table();
			Column column24 = new Column();
			ColumnExpression columnExpression24 = new ColumnExpression();
			Column column25 = new Column();
			ColumnExpression columnExpression25 = new ColumnExpression();
			Column column26 = new Column();
			ColumnExpression columnExpression26 = new ColumnExpression();
			Column column27 = new Column();
			ColumnExpression columnExpression27 = new ColumnExpression();
			Join join = new Join();
			RelationColumnInfo relationColumnInfo = new RelationColumnInfo();
			CustomSqlQuery customSqlQuery = new CustomSqlQuery();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServiceInformationReport));
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(ServiceInformationReport));
			SelectQuery selectQuery2 = new SelectQuery();
			Column column28 = new Column();
			ColumnExpression columnExpression28 = new ColumnExpression();
			Table table3 = new Table();
			Column column29 = new Column();
			ColumnExpression columnExpression29 = new ColumnExpression();
			Column column30 = new Column();
			ColumnExpression columnExpression30 = new ColumnExpression();
			Column column31 = new Column();
			ColumnExpression columnExpression31 = new ColumnExpression();
			Column column32 = new Column();
			ColumnExpression columnExpression32 = new ColumnExpression();
			AllColumns allColumns = new AllColumns();
			Table table4 = new Table();
			Join join2 = new Join();
			RelationColumnInfo relationColumnInfo2 = new RelationColumnInfo();
			SelectQuery selectQuery3 = new SelectQuery();
			Column column33 = new Column();
			ColumnExpression columnExpression33 = new ColumnExpression();
			Table table5 = new Table();
			Column column34 = new Column();
			ColumnExpression columnExpression34 = new ColumnExpression();
			Column column35 = new Column();
			ColumnExpression columnExpression35 = new ColumnExpression();
			Column column36 = new Column();
			ColumnExpression columnExpression36 = new ColumnExpression();
			Table table6 = new Table();
			Column column37 = new Column();
			ColumnExpression columnExpression37 = new ColumnExpression();
			Column column38 = new Column();
			ColumnExpression columnExpression38 = new ColumnExpression();
			Column column39 = new Column();
			ColumnExpression columnExpression39 = new ColumnExpression();
			Column column40 = new Column();
			ColumnExpression columnExpression40 = new ColumnExpression();
			Column column41 = new Column();
			ColumnExpression columnExpression41 = new ColumnExpression();
			Column column42 = new Column();
			ColumnExpression columnExpression42 = new ColumnExpression();
			Column column43 = new Column();
			ColumnExpression columnExpression43 = new ColumnExpression();
			Join join3 = new Join();
			RelationColumnInfo relationColumnInfo3 = new RelationColumnInfo();
			SelectQuery selectQuery4 = new SelectQuery();
			Column column44 = new Column();
			ColumnExpression columnExpression44 = new ColumnExpression();
			Table table7 = new Table();
			Column column45 = new Column();
			ColumnExpression columnExpression45 = new ColumnExpression();
			Column column46 = new Column();
			ColumnExpression columnExpression46 = new ColumnExpression();
			Column column47 = new Column();
			ColumnExpression columnExpression47 = new ColumnExpression();
			Column column48 = new Column();
			ColumnExpression columnExpression48 = new ColumnExpression();
			Column column49 = new Column();
			ColumnExpression columnExpression49 = new ColumnExpression();
			Column column50 = new Column();
			ColumnExpression columnExpression50 = new ColumnExpression();
			Table table8 = new Table();
			Column column51 = new Column();
			ColumnExpression columnExpression51 = new ColumnExpression();
			Column column52 = new Column();
			ColumnExpression columnExpression52 = new ColumnExpression();
			Join join4 = new Join();
			RelationColumnInfo relationColumnInfo4 = new RelationColumnInfo();
			MasterDetailInfo masterDetailInfo = new MasterDetailInfo();
			RelationColumnInfo relationColumnInfo5 = new RelationColumnInfo();
			MasterDetailInfo masterDetailInfo2 = new MasterDetailInfo();
			RelationColumnInfo relationColumnInfo6 = new RelationColumnInfo();
			MasterDetailInfo masterDetailInfo3 = new MasterDetailInfo();
			RelationColumnInfo relationColumnInfo7 = new RelationColumnInfo();
			MasterDetailInfo masterDetailInfo4 = new MasterDetailInfo();
			RelationColumnInfo relationColumnInfo8 = new RelationColumnInfo();
			DynamicListLookUpSettings dynamicListLookUpSettings = new DynamicListLookUpSettings();
			this.sqlDataSource1 = new SqlDataSource(this.components);
			this.Detail = new DetailBand();
			this.xrLine3 = new XRLine();
			this.xrLabel1 = new XRLabel();
			this.xrLabel3 = new XRLabel();
			this.xrLabel4 = new XRLabel();
			this.xrLabel5 = new XRLabel();
			this.xrLabel6 = new XRLabel();
			this.xrLabel7 = new XRLabel();
			this.xrLabel8 = new XRLabel();
			this.xrLabel9 = new XRLabel();
			this.xrLabel13 = new XRLabel();
			this.xrLabel14 = new XRLabel();
			this.xrLabel15 = new XRLabel();
			this.xrLabel16 = new XRLabel();
			this.xrLabel17 = new XRLabel();
			this.xrLabel18 = new XRLabel();
			this.xrLabel19 = new XRLabel();
			this.xrLabel20 = new XRLabel();
			this.xrLabel23 = new XRLabel();
			this.xrLabel25 = new XRLabel();
			this.xrLabel26 = new XRLabel();
			this.xrLabel27 = new XRLabel();
			this.xrCheckBox1 = new XRCheckBox();
			this.xrCheckBox2 = new XRCheckBox();
			this.xrCheckBox3 = new XRCheckBox();
			this.xrCheckBox4 = new XRCheckBox();
			this.xrLabel31 = new XRLabel();
			this.xrLabel32 = new XRLabel();
			this.xrLabel33 = new XRLabel();
			this.xrLabel34 = new XRLabel();
			this.xrLabel35 = new XRLabel();
			this.xrLabel36 = new XRLabel();
			this.xrLabel37 = new XRLabel();
			this.xrLabel38 = new XRLabel();
			this.xrLine1 = new XRLine();
			this.TopMargin = new TopMarginBand();
			this.xrLine6 = new XRLine();
			this.xrLabel42 = new XRLabel();
			this.xrLabel43 = new XRLabel();
			this.xrPictureBox1 = new XRPictureBox();
			this.xrLabel44 = new XRLabel();
			this.xrLabel45 = new XRLabel();
			this.xrLabel46 = new XRLabel();
			this.xrLine7 = new XRLine();
			this.xrLabel47 = new XRLabel();
			this.BottomMargin = new BottomMarginBand();
			this.xrLabel11 = new XRLabel();
			this.xrLabel12 = new XRLabel();
			this.xrLabel21 = new XRLabel();
			this.xrLabel22 = new XRLabel();
			this.xrLabel29 = new XRLabel();
			this.xrLabel30 = new XRLabel();
			this.xrLabel39 = new XRLabel();
			this.xrLabel40 = new XRLabel();
			this.pageFooterBand1 = new PageFooterBand();
			this.xrPictureBox2 = new XRPictureBox();
			this.xrPageInfo1 = new XRPageInfo();
			this.xrPageInfo2 = new XRPageInfo();
			this.reportHeaderBand1 = new ReportHeaderBand();
			this.Title = new XRControlStyle();
			this.FieldCaption = new XRControlStyle();
			this.PageInfo = new XRControlStyle();
			this.DataField = new XRControlStyle();
			this.xrLine2 = new XRLine();
			this.xrLine4 = new XRLine();
			this.DetailReport = new DetailReportBand();
			this.Detail1 = new DetailBand();
			this.xrTable1 = new XRTable();
			this.xrTableRow1 = new XRTableRow();
			this.xrTableCell1 = new XRTableCell();
			this.xrTableCell2 = new XRTableCell();
			this.xrTableCell3 = new XRTableCell();
			this.GroupHeader1 = new GroupHeaderBand();
			this.xrLine5 = new XRLine();
			this.xrTable2 = new XRTable();
			this.xrTableRow2 = new XRTableRow();
			this.xrTableCell4 = new XRTableCell();
			this.xrTableCell5 = new XRTableCell();
			this.xrTableCell6 = new XRTableCell();
			this.DetailReport1 = new DetailReportBand();
			this.Detail2 = new DetailBand();
			this.xrTable4 = new XRTable();
			this.xrTableRow4 = new XRTableRow();
			this.xrTableCell10 = new XRTableCell();
			this.xrTableCell11 = new XRTableCell();
			this.xrTableCell12 = new XRTableCell();
			this.GroupHeader2 = new GroupHeaderBand();
			this.xrTable3 = new XRTable();
			this.xrTableRow3 = new XRTableRow();
			this.xrTableCell7 = new XRTableCell();
			this.xrTableCell8 = new XRTableCell();
			this.xrTableCell9 = new XRTableCell();
			this.PageHeader = new PageHeaderBand();
			this.xrLabel2 = new XRLabel();
			this.DetailReport2 = new DetailReportBand();
			this.Detail3 = new DetailBand();
			this.xrLabel10 = new XRLabel();
			this.GroupHeader3 = new GroupHeaderBand();
			this.xrLabel28 = new XRLabel();
			this.DetailReport3 = new DetailReportBand();
			this.Detail4 = new DetailBand();
			this.xrLabel24 = new XRLabel();
			this.GroupHeader4 = new GroupHeaderBand();
			this.xrLabel41 = new XRLabel();
			this.DetailReport5 = new DetailReportBand();
			this.Detail6 = new DetailBand();
			this.FilterExpression = new Parameter();
			this.Id = new Parameter();
			((ISupportInitialize)this.xrTable1).BeginInit();
			((ISupportInitialize)this.xrTable2).BeginInit();
			((ISupportInitialize)this.xrTable4).BeginInit();
			((ISupportInitialize)this.xrTable3).BeginInit();
			((ISupportInitialize)this).BeginInit();
			this.sqlDataSource1.ConnectionName = "localhost_LabSys_Connection";
			this.sqlDataSource1.Name = "sqlDataSource1";
			columnExpression.ColumnName = "TestID";
			table.MetaSerializable = "30|30|125|480";
			table.Name = "TestsList";
			columnExpression.Table = table;
			column.Expression = columnExpression;
			columnExpression2.ColumnName = "StandardNumber";
			columnExpression2.Table = table;
			column2.Expression = columnExpression2;
			columnExpression3.ColumnName = "AshghalTestNumber";
			columnExpression3.Table = table;
			column3.Expression = columnExpression3;
			columnExpression4.ColumnName = "TestName";
			columnExpression4.Table = table;
			column4.Expression = columnExpression4;
			columnExpression5.ColumnName = "TestDescription";
			columnExpression5.Table = table;
			column5.Expression = columnExpression5;
			columnExpression6.ColumnName = "ShortName";
			columnExpression6.Table = table;
			column6.Expression = columnExpression6;
			columnExpression7.ColumnName = "FKAccreditionID";
			columnExpression7.Table = table;
			column7.Expression = columnExpression7;
			columnExpression8.ColumnName = "FKLabID";
			columnExpression8.Table = table;
			column8.Expression = columnExpression8;
			columnExpression9.ColumnName = "ResultUnit";
			columnExpression9.Table = table;
			column9.Expression = columnExpression9;
			columnExpression10.ColumnName = "ResultSpecs";
			columnExpression10.Table = table;
			column10.Expression = columnExpression10;
			columnExpression11.ColumnName = "SamplingMethod";
			columnExpression11.Table = table;
			column11.Expression = columnExpression11;
			columnExpression12.ColumnName = "WorkFormFileName";
			columnExpression12.Table = table;
			column12.Expression = columnExpression12;
			columnExpression13.ColumnName = "WorkFormWorksheet";
			columnExpression13.Table = table;
			column13.Expression = columnExpression13;
			columnExpression14.ColumnName = "ReportFileName";
			columnExpression14.Table = table;
			column14.Expression = columnExpression14;
			columnExpression15.ColumnName = "ReportWorksheet";
			columnExpression15.Table = table;
			column15.Expression = columnExpression15;
			columnExpression16.ColumnName = "DefaultPrice";
			columnExpression16.Table = table;
			column16.Expression = columnExpression16;
			columnExpression17.ColumnName = "MinimumPrice";
			columnExpression17.Table = table;
			column17.Expression = columnExpression17;
			columnExpression18.ColumnName = "IsLocked";
			columnExpression18.Table = table;
			column18.Expression = columnExpression18;
			columnExpression19.ColumnName = "IsSubcontractedTest";
			columnExpression19.Table = table;
			column19.Expression = columnExpression19;
			columnExpression20.ColumnName = "IsSiteTest";
			columnExpression20.Table = table;
			column20.Expression = columnExpression20;
			columnExpression21.ColumnName = "FKTestID";
			columnExpression21.Table = table;
			column21.Expression = columnExpression21;
			columnExpression22.ColumnName = "IsUnavailable";
			columnExpression22.Table = table;
			column22.Expression = columnExpression22;
			columnExpression23.ColumnName = "LabID";
			table2.MetaSerializable = "185|30|125|140";
			table2.Name = "LabsList";
			columnExpression23.Table = table2;
			column23.Expression = columnExpression23;
			columnExpression24.ColumnName = "LabName";
			columnExpression24.Table = table2;
			column24.Expression = columnExpression24;
			columnExpression25.ColumnName = "Remarks";
			columnExpression25.Table = table2;
			column25.Expression = columnExpression25;
			columnExpression26.ColumnName = "LabInCharge";
			columnExpression26.Table = table2;
			column26.Expression = columnExpression26;
			column27.Alias = "LabsList_IsLocked";
			columnExpression27.ColumnName = "IsLocked";
			columnExpression27.Table = table2;
			column27.Expression = columnExpression27;
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
			selectQuery.Columns.Add(column21);
			selectQuery.Columns.Add(column22);
			selectQuery.Columns.Add(column23);
			selectQuery.Columns.Add(column24);
			selectQuery.Columns.Add(column25);
			selectQuery.Columns.Add(column26);
			selectQuery.Columns.Add(column27);
			selectQuery.Name = "TestsList";
			relationColumnInfo.NestedKeyColumn = "LabID";
			relationColumnInfo.ParentKeyColumn = "FKLabID";
			join.KeyColumns.Add(relationColumnInfo);
			join.Nested = table2;
			join.Parent = table;
			selectQuery.Relations.Add(join);
			selectQuery.Tables.Add(table);
			selectQuery.Tables.Add(table2);
			customSqlQuery.Name = "TestItems";
			customSqlQuery.Sql = resources.GetString("customSqlQuery1.Sql");
			columnExpression28.ColumnName = "TestPriceID";
			table3.MetaSerializable = "30|30|125|140";
			table3.Name = "TestPrices";
			columnExpression28.Table = table3;
			column28.Expression = columnExpression28;
			columnExpression29.ColumnName = "FKTestID";
			columnExpression29.Table = table3;
			column29.Expression = columnExpression29;
			columnExpression30.ColumnName = "FKPriceUnitID";
			columnExpression30.Table = table3;
			column30.Expression = columnExpression30;
			columnExpression31.ColumnName = "DefaultPrice";
			columnExpression31.Table = table3;
			column31.Expression = columnExpression31;
			columnExpression32.ColumnName = "MinimumPrice";
			columnExpression32.Table = table3;
			column32.Expression = columnExpression32;
			table4.MetaSerializable = "185|30|125|140";
			table4.Name = "PriceUnitList";
			allColumns.Table = table4;
			selectQuery2.Columns.Add(column28);
			selectQuery2.Columns.Add(column29);
			selectQuery2.Columns.Add(column30);
			selectQuery2.Columns.Add(column31);
			selectQuery2.Columns.Add(column32);
			selectQuery2.Columns.Add(allColumns);
			selectQuery2.Name = "TestPrices";
			relationColumnInfo2.NestedKeyColumn = "PriceUnitID";
			relationColumnInfo2.ParentKeyColumn = "FKPriceUnitID";
			join2.KeyColumns.Add(relationColumnInfo2);
			join2.Nested = table4;
			join2.Parent = table3;
			selectQuery2.Relations.Add(join2);
			selectQuery2.Tables.Add(table3);
			selectQuery2.Tables.Add(table4);
			columnExpression33.ColumnName = "TestEquipmentID";
			table5.MetaSerializable = "30|30|125|100";
			table5.Name = "TestEquipments";
			columnExpression33.Table = table5;
			column33.Expression = columnExpression33;
			columnExpression34.ColumnName = "FKEquipmentID";
			columnExpression34.Table = table5;
			column34.Expression = columnExpression34;
			columnExpression35.ColumnName = "FKTestID";
			columnExpression35.Table = table5;
			column35.Expression = columnExpression35;
			columnExpression36.ColumnName = "EquipmentID";
			table6.MetaSerializable = "185|30|125|200";
			table6.Name = "EquipmentsList";
			columnExpression36.Table = table6;
			column36.Expression = columnExpression36;
			columnExpression37.ColumnName = "EquipmentName";
			columnExpression37.Table = table6;
			column37.Expression = columnExpression37;
			columnExpression38.ColumnName = "FKLabID";
			columnExpression38.Table = table6;
			column38.Expression = columnExpression38;
			columnExpression39.ColumnName = "CalibrationDate";
			columnExpression39.Table = table6;
			column39.Expression = columnExpression39;
			columnExpression40.ColumnName = "ExpiryDate";
			columnExpression40.Table = table6;
			column40.Expression = columnExpression40;
			columnExpression41.ColumnName = "FKEmpID";
			columnExpression41.Table = table6;
			column41.Expression = columnExpression41;
			columnExpression42.ColumnName = "CalibratedBy";
			columnExpression42.Table = table6;
			column42.Expression = columnExpression42;
			columnExpression43.ColumnName = "Remarks";
			columnExpression43.Table = table6;
			column43.Expression = columnExpression43;
			selectQuery3.Columns.Add(column33);
			selectQuery3.Columns.Add(column34);
			selectQuery3.Columns.Add(column35);
			selectQuery3.Columns.Add(column36);
			selectQuery3.Columns.Add(column37);
			selectQuery3.Columns.Add(column38);
			selectQuery3.Columns.Add(column39);
			selectQuery3.Columns.Add(column40);
			selectQuery3.Columns.Add(column41);
			selectQuery3.Columns.Add(column42);
			selectQuery3.Columns.Add(column43);
			selectQuery3.Name = "TestEquipments";
			relationColumnInfo3.NestedKeyColumn = "EquipmentID";
			relationColumnInfo3.ParentKeyColumn = "FKEquipmentID";
			join3.KeyColumns.Add(relationColumnInfo3);
			join3.Nested = table6;
			join3.Parent = table5;
			selectQuery3.Relations.Add(join3);
			selectQuery3.Tables.Add(table5);
			selectQuery3.Tables.Add(table6);
			columnExpression44.ColumnName = "SubContractorID";
			table7.MetaSerializable = "185|30|125|160";
			table7.Name = "SubcontractorsList";
			columnExpression44.Table = table7;
			column44.Expression = columnExpression44;
			columnExpression45.ColumnName = "SubContractorCode";
			columnExpression45.Table = table7;
			column45.Expression = columnExpression45;
			columnExpression46.ColumnName = "SubContractorName";
			columnExpression46.Table = table7;
			column46.Expression = columnExpression46;
			columnExpression47.ColumnName = "AccreditationExpiryDate";
			columnExpression47.Table = table7;
			column47.Expression = columnExpression47;
			columnExpression48.ColumnName = "Address";
			columnExpression48.Table = table7;
			column48.Expression = columnExpression48;
			columnExpression49.ColumnName = "IsLocked";
			columnExpression49.Table = table7;
			column49.Expression = columnExpression49;
			columnExpression50.ColumnName = "TestContractorsID";
			table8.MetaSerializable = "30|30|125|100";
			table8.Name = "TestContractors";
			columnExpression50.Table = table8;
			column50.Expression = columnExpression50;
			columnExpression51.ColumnName = "FKTestID";
			columnExpression51.Table = table8;
			column51.Expression = columnExpression51;
			columnExpression52.ColumnName = "FKSubContractorID";
			columnExpression52.Table = table8;
			column52.Expression = columnExpression52;
			selectQuery4.Columns.Add(column44);
			selectQuery4.Columns.Add(column45);
			selectQuery4.Columns.Add(column46);
			selectQuery4.Columns.Add(column47);
			selectQuery4.Columns.Add(column48);
			selectQuery4.Columns.Add(column49);
			selectQuery4.Columns.Add(column50);
			selectQuery4.Columns.Add(column51);
			selectQuery4.Columns.Add(column52);
			selectQuery4.Name = "TestContractors";
			relationColumnInfo4.NestedKeyColumn = "SubContractorID";
			relationColumnInfo4.ParentKeyColumn = "FKSubContractorID";
			join4.KeyColumns.Add(relationColumnInfo4);
			join4.Nested = table7;
			join4.Parent = table8;
			selectQuery4.Relations.Add(join4);
			selectQuery4.Tables.Add(table8);
			selectQuery4.Tables.Add(table7);
			this.sqlDataSource1.Queries.AddRange(new SqlQuery[]
			{
				selectQuery,
				customSqlQuery,
				selectQuery2,
				selectQuery3,
				selectQuery4
			});
			masterDetailInfo.DetailQueryName = "TestContractors";
			relationColumnInfo5.NestedKeyColumn = "FKTestID";
			relationColumnInfo5.ParentKeyColumn = "TestID";
			masterDetailInfo.KeyColumns.Add(relationColumnInfo5);
			masterDetailInfo.MasterQueryName = "TestsList";
			masterDetailInfo.Name = "FK_TestContractors_TestsList";
			masterDetailInfo2.DetailQueryName = "TestEquipments";
			relationColumnInfo6.NestedKeyColumn = "FKTestID";
			relationColumnInfo6.ParentKeyColumn = "TestID";
			masterDetailInfo2.KeyColumns.Add(relationColumnInfo6);
			masterDetailInfo2.MasterQueryName = "TestsList";
			masterDetailInfo2.Name = "FK_TestEquipments_TestsList";
			masterDetailInfo3.DetailQueryName = "TestPrices";
			relationColumnInfo7.NestedKeyColumn = "FKTestID";
			relationColumnInfo7.ParentKeyColumn = "TestID";
			masterDetailInfo3.KeyColumns.Add(relationColumnInfo7);
			masterDetailInfo3.MasterQueryName = "TestsList";
			masterDetailInfo3.Name = "FK_TestPrices_TestsList";
			masterDetailInfo4.DetailQueryName = "TestItems";
			relationColumnInfo8.NestedKeyColumn = "FKTestID";
			relationColumnInfo8.ParentKeyColumn = "TestID";
			masterDetailInfo4.KeyColumns.Add(relationColumnInfo8);
			masterDetailInfo4.MasterQueryName = "TestsList";
			this.sqlDataSource1.Relations.AddRange(new MasterDetailInfo[]
			{
				masterDetailInfo,
				masterDetailInfo2,
				masterDetailInfo3,
				masterDetailInfo4
			});
			this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
			this.Detail.Controls.AddRange(new XRControl[]
			{
				this.xrLine3,
				this.xrLabel1,
				this.xrLabel3,
				this.xrLabel4,
				this.xrLabel5,
				this.xrLabel6,
				this.xrLabel7,
				this.xrLabel8,
				this.xrLabel9,
				this.xrLabel13,
				this.xrLabel14,
				this.xrLabel15,
				this.xrLabel16,
				this.xrLabel17,
				this.xrLabel18,
				this.xrLabel19,
				this.xrLabel20,
				this.xrLabel23,
				this.xrLabel25,
				this.xrLabel26,
				this.xrLabel27,
				this.xrCheckBox1,
				this.xrCheckBox2,
				this.xrCheckBox3,
				this.xrCheckBox4,
				this.xrLabel31,
				this.xrLabel32,
				this.xrLabel33,
				this.xrLabel34,
				this.xrLabel35,
				this.xrLabel36,
				this.xrLabel37,
				this.xrLabel38,
				this.xrLine1
			});
			this.Detail.Dpi = 100f;
			this.Detail.Expanded = false;
			this.Detail.HeightF = 226.1946f;
			this.Detail.KeepTogether = true;
			this.Detail.KeepTogetherWithDetailReports = true;
			this.Detail.Name = "Detail";
			this.Detail.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
			this.Detail.PageBreak = PageBreak.BeforeBand;
			this.Detail.TextAlignment = TextAlignment.TopLeft;
			this.xrLine3.Dpi = 100f;
			this.xrLine3.LocationFloat = new PointFloat(5.833313f, 219.3942f);
			this.xrLine3.Name = "xrLine3";
			this.xrLine3.SizeF = new SizeF(838f, 2f);
			this.xrLabel1.Dpi = 100f;
			this.xrLabel1.ForeColor = Color.Black;
			this.xrLabel1.LocationFloat = new PointFloat(268.0233f, 46.37508f);
			this.xrLabel1.Name = "xrLabel1";
			this.xrLabel1.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel1.SizeF = new SizeF(165.9348f, 18f);
			this.xrLabel1.StyleName = "FieldCaption";
			this.xrLabel1.StylePriority.UseForeColor = false;
			this.xrLabel1.Text = "Ashghal Test Number:";
			this.xrLabel3.Dpi = 100f;
			this.xrLabel3.ForeColor = Color.Black;
			this.xrLabel3.LocationFloat = new PointFloat(6.416609f, 126.7501f);
			this.xrLabel3.Name = "xrLabel3";
			this.xrLabel3.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel3.SizeF = new SizeF(142.5763f, 18.00001f);
			this.xrLabel3.StyleName = "FieldCaption";
			this.xrLabel3.StylePriority.UseForeColor = false;
			this.xrLabel3.Text = "Accredition Status:";
			this.xrLabel4.Dpi = 100f;
			this.xrLabel4.ForeColor = Color.Black;
			this.xrLabel4.LocationFloat = new PointFloat(579.6666f, 126.7501f);
			this.xrLabel4.Name = "xrLabel4";
			this.xrLabel4.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel4.SizeF = new SizeF(97.92957f, 18.00001f);
			this.xrLabel4.StyleName = "FieldCaption";
			this.xrLabel4.StylePriority.UseForeColor = false;
			this.xrLabel4.Text = "Lab Section:";
			this.xrLabel5.Dpi = 100f;
			this.xrLabel5.ForeColor = Color.Black;
			this.xrLabel5.LocationFloat = new PointFloat(570.2144f, 184.7501f);
			this.xrLabel5.Multiline = true;
			this.xrLabel5.Name = "xrLabel5";
			this.xrLabel5.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel5.SizeF = new SizeF(136.0355f, 18f);
			this.xrLabel5.StyleName = "FieldCaption";
			this.xrLabel5.StylePriority.UseForeColor = false;
			this.xrLabel5.Text = "Mandatory Service:";
			this.xrLabel6.Dpi = 100f;
			this.xrLabel6.ForeColor = Color.Black;
			this.xrLabel6.LocationFloat = new PointFloat(659.125f, 10.00001f);
			this.xrLabel6.Name = "xrLabel6";
			this.xrLabel6.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel6.SizeF = new SizeF(162f, 23f);
			this.xrLabel6.StyleName = "FieldCaption";
			this.xrLabel6.StylePriority.UseForeColor = false;
			this.xrLabel6.Text = "Inactive";
			this.xrLabel7.Dpi = 100f;
			this.xrLabel7.ForeColor = Color.Black;
			this.xrLabel7.LocationFloat = new PointFloat(525.7917f, 10.00001f);
			this.xrLabel7.Name = "xrLabel7";
			this.xrLabel7.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel7.SizeF = new SizeF(68.25f, 23f);
			this.xrLabel7.StyleName = "FieldCaption";
			this.xrLabel7.StylePriority.UseForeColor = false;
			this.xrLabel7.Text = "Site Test";
			this.xrLabel8.Dpi = 100f;
			this.xrLabel8.ForeColor = Color.Black;
			this.xrLabel8.LocationFloat = new PointFloat(254.7084f, 10.00001f);
			this.xrLabel8.Name = "xrLabel8";
			this.xrLabel8.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel8.SizeF = new SizeF(190.125f, 23f);
			this.xrLabel8.StyleName = "FieldCaption";
			this.xrLabel8.StylePriority.UseForeColor = false;
			this.xrLabel8.Text = "Service to be subcontracted";
			this.xrLabel9.Dpi = 100f;
			this.xrLabel9.ForeColor = Color.Black;
			this.xrLabel9.LocationFloat = new PointFloat(33.12505f, 10.00001f);
			this.xrLabel9.Multiline = true;
			this.xrLabel9.Name = "xrLabel9";
			this.xrLabel9.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel9.SizeF = new SizeF(178.875f, 23f);
			this.xrLabel9.StyleName = "FieldCaption";
			this.xrLabel9.StylePriority.UseForeColor = false;
			this.xrLabel9.Text = "Test not available\r\n\r\n";
			this.xrLabel13.Dpi = 100f;
			this.xrLabel13.ForeColor = Color.Black;
			this.xrLabel13.LocationFloat = new PointFloat(286.1666f, 156.6251f);
			this.xrLabel13.Name = "xrLabel13";
			this.xrLabel13.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel13.SizeF = new SizeF(94.62494f, 18f);
			this.xrLabel13.StyleName = "FieldCaption";
			this.xrLabel13.StylePriority.UseForeColor = false;
			this.xrLabel13.Text = "Result Specs";
			this.xrLabel14.Dpi = 100f;
			this.xrLabel14.ForeColor = Color.Black;
			this.xrLabel14.LocationFloat = new PointFloat(8.001344f, 156.6251f);
			this.xrLabel14.Name = "xrLabel14";
			this.xrLabel14.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel14.SizeF = new SizeF(116.8319f, 18.00002f);
			this.xrLabel14.StyleName = "FieldCaption";
			this.xrLabel14.StylePriority.UseForeColor = false;
			this.xrLabel14.Text = "Result Unit:";
			this.xrLabel15.Dpi = 100f;
			this.xrLabel15.ForeColor = Color.Black;
			this.xrLabel15.LocationFloat = new PointFloat(6.416609f, 184.7501f);
			this.xrLabel15.Name = "xrLabel15";
			this.xrLabel15.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel15.SizeF = new SizeF(142.5763f, 18f);
			this.xrLabel15.StyleName = "FieldCaption";
			this.xrLabel15.StylePriority.UseForeColor = false;
			this.xrLabel15.Text = "Sampling Method:";
			this.xrLabel16.Dpi = 100f;
			this.xrLabel16.ForeColor = Color.Black;
			this.xrLabel16.LocationFloat = new PointFloat(579.6666f, 70.37508f);
			this.xrLabel16.Name = "xrLabel16";
			this.xrLabel16.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel16.SizeF = new SizeF(97.92963f, 18f);
			this.xrLabel16.StyleName = "FieldCaption";
			this.xrLabel16.StylePriority.UseForeColor = false;
			this.xrLabel16.Text = "Short Name:";
			this.xrLabel17.Dpi = 100f;
			this.xrLabel17.ForeColor = Color.Black;
			this.xrLabel17.LocationFloat = new PointFloat(579.6666f, 46.37508f);
			this.xrLabel17.Name = "xrLabel17";
			this.xrLabel17.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel17.SizeF = new SizeF(126.5833f, 18f);
			this.xrLabel17.StyleName = "FieldCaption";
			this.xrLabel17.StylePriority.UseForeColor = false;
			this.xrLabel17.Text = "Standard Number:";
			this.xrLabel18.Dpi = 100f;
			this.xrLabel18.ForeColor = Color.Black;
			this.xrLabel18.LocationFloat = new PointFloat(6.416609f, 98.41676f);
			this.xrLabel18.Name = "xrLabel18";
			this.xrLabel18.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel18.SizeF = new SizeF(150.9797f, 18f);
			this.xrLabel18.StyleName = "FieldCaption";
			this.xrLabel18.StylePriority.UseForeColor = false;
			this.xrLabel18.Text = "Standard Description:";
			this.xrLabel19.Dpi = 100f;
			this.xrLabel19.ForeColor = Color.Black;
			this.xrLabel19.LocationFloat = new PointFloat(6.416609f, 46.37508f);
			this.xrLabel19.Name = "xrLabel19";
			this.xrLabel19.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel19.SizeF = new SizeF(116.8319f, 18f);
			this.xrLabel19.StyleName = "FieldCaption";
			this.xrLabel19.StylePriority.UseForeColor = false;
			this.xrLabel19.Text = "Service Number:";
			this.xrLabel20.Dpi = 100f;
			this.xrLabel20.ForeColor = Color.Black;
			this.xrLabel20.LocationFloat = new PointFloat(6.416609f, 70.37508f);
			this.xrLabel20.Name = "xrLabel20";
			this.xrLabel20.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel20.SizeF = new SizeF(116.8319f, 18f);
			this.xrLabel20.StyleName = "FieldCaption";
			this.xrLabel20.StylePriority.UseForeColor = false;
			this.xrLabel20.Text = "Service Name:";
			this.xrLabel23.Borders = BorderSide.All;
			this.xrLabel23.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "TestsList.AshghalTestNumber")
			});
			this.xrLabel23.Dpi = 100f;
			this.xrLabel23.LocationFloat = new PointFloat(435.2276f, 46.37508f);
			this.xrLabel23.Name = "xrLabel23";
			this.xrLabel23.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel23.SizeF = new SizeF(117.6891f, 18f);
			this.xrLabel23.StyleName = "DataField";
			this.xrLabel23.StylePriority.UseBorders = false;
			this.xrLabel23.Text = "xrLabel23";
			this.xrLabel25.Borders = BorderSide.All;
			this.xrLabel25.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "TestsList.AccreditionName")
			});
			this.xrLabel25.Dpi = 100f;
			this.xrLabel25.LocationFloat = new PointFloat(162.6484f, 126.7501f);
			this.xrLabel25.Name = "xrLabel25";
			this.xrLabel25.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel25.SizeF = new SizeF(255.9583f, 18f);
			this.xrLabel25.StyleName = "DataField";
			this.xrLabel25.StylePriority.UseBorders = false;
			this.xrLabel26.Borders = BorderSide.All;
			this.xrLabel26.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "TestsList.LabName")
			});
			this.xrLabel26.Dpi = 100f;
			this.xrLabel26.LocationFloat = new PointFloat(706.2499f, 126.7501f);
			this.xrLabel26.Name = "xrLabel26";
			this.xrLabel26.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel26.SizeF = new SizeF(131.7501f, 17.99999f);
			this.xrLabel26.StyleName = "DataField";
			this.xrLabel26.StylePriority.UseBorders = false;
			this.xrLabel27.Borders = BorderSide.All;
			this.xrLabel27.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "TestsList.FKTestID")
			});
			this.xrLabel27.Dpi = 100f;
			this.xrLabel27.LocationFloat = new PointFloat(706.2499f, 184.75f);
			this.xrLabel27.Name = "xrLabel27";
			this.xrLabel27.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel27.SizeF = new SizeF(131.7501f, 18f);
			this.xrLabel27.StyleName = "DataField";
			this.xrLabel27.StylePriority.UseBorders = false;
			this.xrLabel27.Text = "xrLabel27";
			this.xrCheckBox1.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("CheckState", null, "TestsList.IsLocked")
			});
			this.xrCheckBox1.Dpi = 100f;
			this.xrCheckBox1.LocationFloat = new PointFloat(638.0833f, 10.00001f);
			this.xrCheckBox1.Name = "xrCheckBox1";
			this.xrCheckBox1.SizeF = new SizeF(21.04169f, 23f);
			this.xrCheckBox1.StyleName = "DataField";
			this.xrCheckBox2.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("CheckState", null, "TestsList.IsSiteTest")
			});
			this.xrCheckBox2.Dpi = 100f;
			this.xrCheckBox2.LocationFloat = new PointFloat(501.625f, 10.00001f);
			this.xrCheckBox2.Name = "xrCheckBox2";
			this.xrCheckBox2.SizeF = new SizeF(24.16669f, 23f);
			this.xrCheckBox2.StyleName = "DataField";
			this.xrCheckBox3.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("CheckState", null, "TestsList.IsSubcontractedTest")
			});
			this.xrCheckBox3.Dpi = 100f;
			this.xrCheckBox3.LocationFloat = new PointFloat(229.5f, 10.00001f);
			this.xrCheckBox3.Name = "xrCheckBox3";
			this.xrCheckBox3.SizeF = new SizeF(25.20837f, 23f);
			this.xrCheckBox3.StyleName = "DataField";
			this.xrCheckBox4.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("CheckState", null, "TestsList.IsUnavailable")
			});
			this.xrCheckBox4.Dpi = 100f;
			this.xrCheckBox4.LocationFloat = new PointFloat(5.833308f, 10.00001f);
			this.xrCheckBox4.Name = "xrCheckBox4";
			this.xrCheckBox4.SizeF = new SizeF(27.29169f, 23f);
			this.xrCheckBox4.StyleName = "DataField";
			this.xrLabel31.Borders = BorderSide.All;
			this.xrLabel31.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "TestsList.ResultSpecs")
			});
			this.xrLabel31.Dpi = 100f;
			this.xrLabel31.LocationFloat = new PointFloat(380.7916f, 156.6251f);
			this.xrLabel31.Name = "xrLabel31";
			this.xrLabel31.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel31.SizeF = new SizeF(457.2084f, 18.00002f);
			this.xrLabel31.StyleName = "DataField";
			this.xrLabel31.StylePriority.UseBorders = false;
			this.xrLabel31.Text = "xrLabel31";
			this.xrLabel32.Borders = BorderSide.All;
			this.xrLabel32.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "TestsList.ResultUnit")
			});
			this.xrLabel32.Dpi = 100f;
			this.xrLabel32.LocationFloat = new PointFloat(162.6484f, 156.6251f);
			this.xrLabel32.Name = "xrLabel32";
			this.xrLabel32.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel32.SizeF = new SizeF(109.5833f, 18f);
			this.xrLabel32.StyleName = "DataField";
			this.xrLabel32.StylePriority.UseBorders = false;
			this.xrLabel32.Text = "xrLabel32";
			this.xrLabel33.Borders = BorderSide.All;
			this.xrLabel33.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "TestsList.SamplingMethod")
			});
			this.xrLabel33.Dpi = 100f;
			this.xrLabel33.LocationFloat = new PointFloat(162.6484f, 184.75f);
			this.xrLabel33.Name = "xrLabel33";
			this.xrLabel33.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel33.SizeF = new SizeF(193.0416f, 18f);
			this.xrLabel33.StyleName = "DataField";
			this.xrLabel33.StylePriority.UseBorders = false;
			this.xrLabel33.Text = "xrLabel33";
			this.xrLabel34.Borders = BorderSide.All;
			this.xrLabel34.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "TestsList.ShortName")
			});
			this.xrLabel34.Dpi = 100f;
			this.xrLabel34.LocationFloat = new PointFloat(706.2499f, 70.37508f);
			this.xrLabel34.Name = "xrLabel34";
			this.xrLabel34.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel34.SizeF = new SizeF(131.7501f, 18f);
			this.xrLabel34.StyleName = "DataField";
			this.xrLabel34.StylePriority.UseBorders = false;
			this.xrLabel34.Text = "xrLabel34";
			this.xrLabel35.Borders = BorderSide.All;
			this.xrLabel35.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "TestsList.StandardNumber")
			});
			this.xrLabel35.Dpi = 100f;
			this.xrLabel35.LocationFloat = new PointFloat(706.2499f, 46.37508f);
			this.xrLabel35.Name = "xrLabel35";
			this.xrLabel35.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel35.SizeF = new SizeF(131.7501f, 18f);
			this.xrLabel35.StyleName = "DataField";
			this.xrLabel35.StylePriority.UseBorders = false;
			this.xrLabel35.Text = "xrLabel35";
			this.xrLabel36.Borders = BorderSide.All;
			this.xrLabel36.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "TestsList.TestDescription")
			});
			this.xrLabel36.Dpi = 100f;
			this.xrLabel36.LocationFloat = new PointFloat(162.6484f, 98.41676f);
			this.xrLabel36.Name = "xrLabel36";
			this.xrLabel36.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel36.SizeF = new SizeF(667.9987f, 18f);
			this.xrLabel36.StyleName = "DataField";
			this.xrLabel36.StylePriority.UseBorders = false;
			this.xrLabel36.Text = "xrLabel36";
			this.xrLabel37.Borders = BorderSide.All;
			this.xrLabel37.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "TestsList.TestID")
			});
			this.xrLabel37.Dpi = 100f;
			this.xrLabel37.LocationFloat = new PointFloat(162.6484f, 46.37508f);
			this.xrLabel37.Name = "xrLabel37";
			this.xrLabel37.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel37.SizeF = new SizeF(100.2083f, 18f);
			this.xrLabel37.StyleName = "DataField";
			this.xrLabel37.StylePriority.UseBorders = false;
			this.xrLabel37.Text = "xrLabel37";
			this.xrLabel38.Borders = BorderSide.All;
			this.xrLabel38.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "TestsList.TestName")
			});
			this.xrLabel38.Dpi = 100f;
			this.xrLabel38.LocationFloat = new PointFloat(162.6484f, 70.37508f);
			this.xrLabel38.Name = "xrLabel38";
			this.xrLabel38.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel38.SizeF = new SizeF(362.8751f, 18f);
			this.xrLabel38.StyleName = "DataField";
			this.xrLabel38.StylePriority.UseBorders = false;
			this.xrLabel38.Text = "xrLabel38";
			this.xrLine1.Dpi = 100f;
			this.xrLine1.LocationFloat = new PointFloat(2.874978f, 33.00002f);
			this.xrLine1.Name = "xrLine1";
			this.xrLine1.SizeF = new SizeF(838f, 2f);
			this.TopMargin.Controls.AddRange(new XRControl[]
			{
				this.xrLine6,
				this.xrLabel42,
				this.xrLabel43,
				this.xrPictureBox1,
				this.xrLabel44,
				this.xrLabel45,
				this.xrLabel46,
				this.xrLine7,
				this.xrLabel47
			});
			this.TopMargin.Dpi = 100f;
			this.TopMargin.HeightF = 130f;
			this.TopMargin.Name = "TopMargin";
			this.TopMargin.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
			this.TopMargin.TextAlignment = TextAlignment.TopLeft;
			this.xrLine6.Dpi = 100f;
			this.xrLine6.ForeColor = Color.FromArgb(32, 150, 159);
			this.xrLine6.LocationFloat = new PointFloat(543.1331f, 99.47916f);
			this.xrLine6.Name = "xrLine6";
			this.xrLine6.SizeF = new SizeF(300.4026f, 13f);
			this.xrLine6.StylePriority.UseForeColor = false;
			this.xrLabel42.BackColor = Color.White;
			this.xrLabel42.Dpi = 100f;
			this.xrLabel42.Font = new Font("Times New Roman", 11f, FontStyle.Bold);
			this.xrLabel42.ForeColor = Color.FromArgb(45, 84, 108);
			this.xrLabel42.LocationFloat = new PointFloat(568.4379f, 71.52086f);
			this.xrLabel42.Name = "xrLabel42";
			this.xrLabel42.Padding = new PaddingInfo(2, 2, 0, 2, 100f);
			this.xrLabel42.SizeF = new SizeF(249.9936f, 22.99997f);
			this.xrLabel42.StylePriority.UseBackColor = false;
			this.xrLabel42.StylePriority.UseFont = false;
			this.xrLabel42.StylePriority.UseForeColor = false;
			this.xrLabel42.StylePriority.UsePadding = false;
			this.xrLabel42.StylePriority.UseTextAlignment = false;
			this.xrLabel42.Text = "اختبارات مواقع - تصميم خلطات - دراسات تربة";
			this.xrLabel42.TextAlignment = TextAlignment.TopRight;
			this.xrLabel43.BackColor = Color.White;
			this.xrLabel43.Dpi = 100f;
			this.xrLabel43.Font = new Font("Times New Roman", 11f, FontStyle.Bold);
			this.xrLabel43.ForeColor = Color.FromArgb(45, 84, 108);
			this.xrLabel43.LocationFloat = new PointFloat(568.4379f, 17.52084f);
			this.xrLabel43.Name = "xrLabel43";
			this.xrLabel43.Padding = new PaddingInfo(2, 2, 0, 2, 100f);
			this.xrLabel43.SizeF = new SizeF(249.9937f, 24f);
			this.xrLabel43.StylePriority.UseBackColor = false;
			this.xrLabel43.StylePriority.UseFont = false;
			this.xrLabel43.StylePriority.UseForeColor = false;
			this.xrLabel43.StylePriority.UsePadding = false;
			this.xrLabel43.StylePriority.UseTextAlignment = false;
			this.xrLabel43.Text = "إختبارات ميكانيكية وفزيائية  وكميائية لمواد البناء";
			this.xrLabel43.TextAlignment = TextAlignment.TopRight;
			this.xrPictureBox1.Dpi = 100f;
			this.xrPictureBox1.Image = (Image)resources.GetObject("xrPictureBox1.Image");
			this.xrPictureBox1.LocationFloat = new PointFloat(343.5699f, 17.52084f);
			this.xrPictureBox1.Name = "xrPictureBox1";
			this.xrPictureBox1.SizeF = new SizeF(189.2164f, 94.95832f);
			this.xrLabel44.BackColor = Color.White;
			this.xrLabel44.Dpi = 100f;
			this.xrLabel44.Font = new Font("Times New Roman", 11f, FontStyle.Bold);
			this.xrLabel44.ForeColor = Color.FromArgb(45, 84, 108);
			this.xrLabel44.LocationFloat = new PointFloat(568.4379f, 43.47918f);
			this.xrLabel44.Name = "xrLabel44";
			this.xrLabel44.Padding = new PaddingInfo(2, 2, 0, 2, 100f);
			this.xrLabel44.SizeF = new SizeF(249.9937f, 22.99997f);
			this.xrLabel44.StylePriority.UseBackColor = false;
			this.xrLabel44.StylePriority.UseFont = false;
			this.xrLabel44.StylePriority.UseForeColor = false;
			this.xrLabel44.StylePriority.UsePadding = false;
			this.xrLabel44.StylePriority.UseTextAlignment = false;
			this.xrLabel44.Text = "تربة - اسفلت - حصي - كونكريت - اسمنت - ماء";
			this.xrLabel44.TextAlignment = TextAlignment.TopRight;
			this.xrLabel45.BackColor = Color.White;
			this.xrLabel45.Dpi = 100f;
			this.xrLabel45.Font = new Font("Times New Roman", 9f, FontStyle.Bold);
			this.xrLabel45.ForeColor = Color.FromArgb(45, 84, 103);
			this.xrLabel45.LocationFloat = new PointFloat(6.464294f, 41.52085f);
			this.xrLabel45.Name = "xrLabel45";
			this.xrLabel45.Padding = new PaddingInfo(2, 2, 0, 2, 100f);
			this.xrLabel45.SizeF = new SizeF(310.5137f, 25f);
			this.xrLabel45.StylePriority.UseBackColor = false;
			this.xrLabel45.StylePriority.UseFont = false;
			this.xrLabel45.StylePriority.UseForeColor = false;
			this.xrLabel45.StylePriority.UsePadding = false;
			this.xrLabel45.StylePriority.UseTextAlignment = false;
			this.xrLabel45.Text = "Soil - Asphalt - Aggregate - Concrete - Cement - Water";
			this.xrLabel45.TextAlignment = TextAlignment.TopLeft;
			this.xrLabel46.BackColor = Color.White;
			this.xrLabel46.Dpi = 100f;
			this.xrLabel46.Font = new Font("Times New Roman", 9f, FontStyle.Bold);
			this.xrLabel46.ForeColor = Color.FromArgb(45, 84, 103);
			this.xrLabel46.LocationFloat = new PointFloat(6.464294f, 66.52084f);
			this.xrLabel46.Name = "xrLabel46";
			this.xrLabel46.Padding = new PaddingInfo(2, 2, 0, 2, 100f);
			this.xrLabel46.SizeF = new SizeF(288.8611f, 24f);
			this.xrLabel46.StylePriority.UseBackColor = false;
			this.xrLabel46.StylePriority.UseFont = false;
			this.xrLabel46.StylePriority.UseForeColor = false;
			this.xrLabel46.StylePriority.UsePadding = false;
			this.xrLabel46.StylePriority.UseTextAlignment = false;
			this.xrLabel46.Text = "Site testing - Material design mixes - Soil study";
			this.xrLabel46.TextAlignment = TextAlignment.TopLeft;
			this.xrLine7.Dpi = 100f;
			this.xrLine7.ForeColor = Color.FromArgb(32, 150, 159);
			this.xrLine7.LocationFloat = new PointFloat(7.326614f, 99.47916f);
			this.xrLine7.Name = "xrLine7";
			this.xrLine7.SizeF = new SizeF(300.4026f, 13f);
			this.xrLine7.StylePriority.UseForeColor = false;
			this.xrLabel47.BackColor = Color.White;
			this.xrLabel47.Dpi = 100f;
			this.xrLabel47.Font = new Font("Times New Roman", 9f, FontStyle.Bold);
			this.xrLabel47.ForeColor = Color.FromArgb(45, 84, 103);
			this.xrLabel47.LocationFloat = new PointFloat(6.464294f, 17.52084f);
			this.xrLabel47.Name = "xrLabel47";
			this.xrLabel47.Padding = new PaddingInfo(2, 2, 0, 2, 100f);
			this.xrLabel47.SizeF = new SizeF(285.9722f, 24f);
			this.xrLabel47.StylePriority.UseBackColor = false;
			this.xrLabel47.StylePriority.UseFont = false;
			this.xrLabel47.StylePriority.UseForeColor = false;
			this.xrLabel47.StylePriority.UsePadding = false;
			this.xrLabel47.StylePriority.UseTextAlignment = false;
			this.xrLabel47.Text = "Mechanical , physical and chimical material testing";
			this.xrLabel47.TextAlignment = TextAlignment.TopLeft;
			this.BottomMargin.Dpi = 100f;
			this.BottomMargin.HeightF = 9.095637f;
			this.BottomMargin.Name = "BottomMargin";
			this.BottomMargin.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
			this.BottomMargin.TextAlignment = TextAlignment.TopLeft;
			this.xrLabel11.Dpi = 100f;
			this.xrLabel11.ForeColor = Color.Black;
			this.xrLabel11.LocationFloat = new PointFloat(0f, 60.80884f);
			this.xrLabel11.Name = "xrLabel11";
			this.xrLabel11.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel11.SizeF = new SizeF(162f, 18f);
			this.xrLabel11.StyleName = "FieldCaption";
			this.xrLabel11.StylePriority.UseForeColor = false;
			this.xrLabel11.Text = "Report File Name";
			this.xrLabel12.Dpi = 100f;
			this.xrLabel12.ForeColor = Color.Black;
			this.xrLabel12.LocationFloat = new PointFloat(435.2276f, 60.80884f);
			this.xrLabel12.Name = "xrLabel12";
			this.xrLabel12.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel12.SizeF = new SizeF(162f, 18f);
			this.xrLabel12.StyleName = "FieldCaption";
			this.xrLabel12.StylePriority.UseForeColor = false;
			this.xrLabel12.Text = "Report Worksheet";
			this.xrLabel21.Dpi = 100f;
			this.xrLabel21.ForeColor = Color.Black;
			this.xrLabel21.LocationFloat = new PointFloat(0f, 32.05885f);
			this.xrLabel21.Name = "xrLabel21";
			this.xrLabel21.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel21.SizeF = new SizeF(162f, 18f);
			this.xrLabel21.StyleName = "FieldCaption";
			this.xrLabel21.StylePriority.UseForeColor = false;
			this.xrLabel21.Text = "Work Form File Name";
			this.xrLabel22.Dpi = 100f;
			this.xrLabel22.ForeColor = Color.Black;
			this.xrLabel22.LocationFloat = new PointFloat(435.2276f, 32.05885f);
			this.xrLabel22.Name = "xrLabel22";
			this.xrLabel22.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel22.SizeF = new SizeF(162f, 18f);
			this.xrLabel22.StyleName = "FieldCaption";
			this.xrLabel22.StylePriority.UseForeColor = false;
			this.xrLabel22.Text = "Work Form Worksheet";
			this.xrLabel29.Borders = BorderSide.All;
			this.xrLabel29.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "TestsList.ReportFileName")
			});
			this.xrLabel29.Dpi = 100f;
			this.xrLabel29.LocationFloat = new PointFloat(177.2521f, 60.80884f);
			this.xrLabel29.Name = "xrLabel29";
			this.xrLabel29.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel29.SizeF = new SizeF(203.5394f, 18f);
			this.xrLabel29.StyleName = "DataField";
			this.xrLabel29.StylePriority.UseBorders = false;
			this.xrLabel29.Text = "xrLabel29";
			this.xrLabel30.Borders = BorderSide.All;
			this.xrLabel30.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "TestsList.ReportWorksheet")
			});
			this.xrLabel30.Dpi = 100f;
			this.xrLabel30.LocationFloat = new PointFloat(608.0419f, 60.80884f);
			this.xrLabel30.Name = "xrLabel30";
			this.xrLabel30.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel30.SizeF = new SizeF(232.8332f, 18f);
			this.xrLabel30.StyleName = "DataField";
			this.xrLabel30.StylePriority.UseBorders = false;
			this.xrLabel30.Text = "xrLabel30";
			this.xrLabel39.Borders = BorderSide.All;
			this.xrLabel39.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "TestsList.WorkFormFileName")
			});
			this.xrLabel39.Dpi = 100f;
			this.xrLabel39.LocationFloat = new PointFloat(177.2521f, 32.05885f);
			this.xrLabel39.Name = "xrLabel39";
			this.xrLabel39.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel39.SizeF = new SizeF(203.5394f, 18f);
			this.xrLabel39.StyleName = "DataField";
			this.xrLabel39.StylePriority.UseBorders = false;
			this.xrLabel39.Text = "xrLabel39";
			this.xrLabel40.Borders = BorderSide.All;
			this.xrLabel40.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "TestsList.WorkFormWorksheet")
			});
			this.xrLabel40.Dpi = 100f;
			this.xrLabel40.LocationFloat = new PointFloat(605.1668f, 32.05885f);
			this.xrLabel40.Name = "xrLabel40";
			this.xrLabel40.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel40.SizeF = new SizeF(232.8332f, 18f);
			this.xrLabel40.StyleName = "DataField";
			this.xrLabel40.StylePriority.UseBorders = false;
			this.xrLabel40.Text = "xrLabel40";
			this.pageFooterBand1.Controls.AddRange(new XRControl[]
			{
				this.xrPictureBox2,
				this.xrPageInfo1,
				this.xrPageInfo2
			});
			this.pageFooterBand1.Dpi = 100f;
			this.pageFooterBand1.HeightF = 109.2083f;
			this.pageFooterBand1.Name = "pageFooterBand1";
			this.xrPictureBox2.Dpi = 100f;
			this.xrPictureBox2.Image = (Image)resources.GetObject("xrPictureBox2.Image");
			this.xrPictureBox2.LocationFloat = new PointFloat(136.4583f, 0f);
			this.xrPictureBox2.Name = "xrPictureBox2";
			this.xrPictureBox2.SizeF = new SizeF(581.3381f, 74.20829f);
			this.xrPageInfo1.Dpi = 100f;
			this.xrPageInfo1.LocationFloat = new PointFloat(2.000022f, 86.20828f);
			this.xrPageInfo1.Name = "xrPageInfo1";
			this.xrPageInfo1.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
			this.xrPageInfo1.SizeF = new SizeF(313f, 23f);
			this.xrPageInfo1.StyleName = "PageInfo";
			this.xrPageInfo2.Dpi = 100f;
			this.xrPageInfo2.Format = "Page {0} of {1}";
			this.xrPageInfo2.LocationFloat = new PointFloat(530.8333f, 86.20828f);
			this.xrPageInfo2.Name = "xrPageInfo2";
			this.xrPageInfo2.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrPageInfo2.SizeF = new SizeF(313f, 23f);
			this.xrPageInfo2.StyleName = "PageInfo";
			this.xrPageInfo2.TextAlignment = TextAlignment.TopRight;
			this.reportHeaderBand1.Dpi = 100f;
			this.reportHeaderBand1.HeightF = 14f;
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
			this.xrLine2.Dpi = 100f;
			this.xrLine2.LocationFloat = new PointFloat(2.875032f, 0f);
			this.xrLine2.Name = "xrLine2";
			this.xrLine2.SizeF = new SizeF(838f, 2f);
			this.xrLine4.Dpi = 100f;
			this.xrLine4.LocationFloat = new PointFloat(2.000023f, 9.999989f);
			this.xrLine4.Name = "xrLine4";
			this.xrLine4.SizeF = new SizeF(838f, 2f);
			this.DetailReport.Bands.AddRange(new Band[]
			{
				this.Detail1,
				this.GroupHeader1
			});
			this.DetailReport.DataMember = "TestsList.FK_TestPrices_TestsList";
			this.DetailReport.DataSource = this.sqlDataSource1;
			this.DetailReport.Dpi = 100f;
			this.DetailReport.Level = 3;
			this.DetailReport.Name = "DetailReport";
			this.Detail1.Controls.AddRange(new XRControl[]
			{
				this.xrTable1
			});
			this.Detail1.Dpi = 100f;
			this.Detail1.HeightF = 25f;
			this.Detail1.Name = "Detail1";
			this.xrTable1.Dpi = 100f;
			this.xrTable1.LocationFloat = new PointFloat(110.4167f, 0f);
			this.xrTable1.Name = "xrTable1";
			this.xrTable1.Rows.AddRange(new XRTableRow[]
			{
				this.xrTableRow1
			});
			this.xrTable1.SizeF = new SizeF(651.0416f, 25f);
			this.xrTable1.StylePriority.UseTextAlignment = false;
			this.xrTable1.TextAlignment = TextAlignment.TopCenter;
			this.xrTableRow1.Borders = (BorderSide.Left | BorderSide.Right | BorderSide.Bottom);
			this.xrTableRow1.Cells.AddRange(new XRTableCell[]
			{
				this.xrTableCell1,
				this.xrTableCell2,
				this.xrTableCell3
			});
			this.xrTableRow1.Dpi = 100f;
			this.xrTableRow1.Name = "xrTableRow1";
			this.xrTableRow1.StylePriority.UseBorders = false;
			this.xrTableRow1.Weight = 11.5;
			this.xrTableCell1.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "TestsList.FK_TestPrices_TestsList.UnitName")
			});
			this.xrTableCell1.Dpi = 100f;
			this.xrTableCell1.Name = "xrTableCell1";
			this.xrTableCell1.Weight = 0.30989015821614896;
			this.xrTableCell2.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "TestsList.FK_TestPrices_TestsList.DefaultPrice")
			});
			this.xrTableCell2.Dpi = 100f;
			this.xrTableCell2.Name = "xrTableCell2";
			this.xrTableCell2.Weight = 0.0743794589257129;
			this.xrTableCell3.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "TestsList.FK_TestPrices_TestsList.MinimumPrice")
			});
			this.xrTableCell3.Dpi = 100f;
			this.xrTableCell3.Name = "xrTableCell3";
			this.xrTableCell3.Weight = 0.07166573458623408;
			this.GroupHeader1.Controls.AddRange(new XRControl[]
			{
				this.xrLine5,
				this.xrTable2
			});
			this.GroupHeader1.Dpi = 100f;
			this.GroupHeader1.HeightF = 57.53676f;
			this.GroupHeader1.Name = "GroupHeader1";
			this.GroupHeader1.RepeatEveryPage = true;
			this.xrLine5.Dpi = 100f;
			this.xrLine5.LocationFloat = new PointFloat(2.875032f, 9.999989f);
			this.xrLine5.Name = "xrLine5";
			this.xrLine5.SizeF = new SizeF(838f, 2f);
			this.xrTable2.Dpi = 100f;
			this.xrTable2.Font = new Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTable2.LocationFloat = new PointFloat(110.4167f, 32.53674f);
			this.xrTable2.Name = "xrTable2";
			this.xrTable2.Rows.AddRange(new XRTableRow[]
			{
				this.xrTableRow2
			});
			this.xrTable2.SizeF = new SizeF(651.0416f, 25f);
			this.xrTable2.StylePriority.UseFont = false;
			this.xrTable2.StylePriority.UseTextAlignment = false;
			this.xrTable2.TextAlignment = TextAlignment.TopCenter;
			this.xrTableRow2.Cells.AddRange(new XRTableCell[]
			{
				this.xrTableCell4,
				this.xrTableCell5,
				this.xrTableCell6
			});
			this.xrTableRow2.Dpi = 100f;
			this.xrTableRow2.Name = "xrTableRow2";
			this.xrTableRow2.Weight = 11.5;
			this.xrTableCell4.Borders = BorderSide.All;
			this.xrTableCell4.Dpi = 100f;
			this.xrTableCell4.Name = "xrTableCell4";
			this.xrTableCell4.StylePriority.UseBorders = false;
			this.xrTableCell4.Text = "Unit";
			this.xrTableCell4.Weight = 0.30989015821614896;
			this.xrTableCell5.Borders = BorderSide.All;
			this.xrTableCell5.Dpi = 100f;
			this.xrTableCell5.Name = "xrTableCell5";
			this.xrTableCell5.StylePriority.UseBorders = false;
			this.xrTableCell5.Text = "Default Price";
			this.xrTableCell5.Weight = 0.0743794589257129;
			this.xrTableCell6.Borders = BorderSide.All;
			this.xrTableCell6.Dpi = 100f;
			this.xrTableCell6.Name = "xrTableCell6";
			this.xrTableCell6.StylePriority.UseBorders = false;
			this.xrTableCell6.Text = "Minimum Price";
			this.xrTableCell6.Weight = 0.07166573458623408;
			this.DetailReport1.Bands.AddRange(new Band[]
			{
				this.Detail2,
				this.GroupHeader2
			});
			this.DetailReport1.DataMember = "TestsList.TestsListTestItems";
			this.DetailReport1.DataSource = this.sqlDataSource1;
			this.DetailReport1.Dpi = 100f;
			this.DetailReport1.Level = 4;
			this.DetailReport1.Name = "DetailReport1";
			this.Detail2.Controls.AddRange(new XRControl[]
			{
				this.xrTable4
			});
			this.Detail2.Dpi = 100f;
			this.Detail2.HeightF = 29.16667f;
			this.Detail2.Name = "Detail2";
			this.xrTable4.Borders = (BorderSide.Left | BorderSide.Right | BorderSide.Bottom);
			this.xrTable4.Dpi = 100f;
			this.xrTable4.LocationFloat = new PointFloat(110.4167f, 0f);
			this.xrTable4.Name = "xrTable4";
			this.xrTable4.Rows.AddRange(new XRTableRow[]
			{
				this.xrTableRow4
			});
			this.xrTable4.SizeF = new SizeF(651.0416f, 25f);
			this.xrTable4.StylePriority.UseBorders = false;
			this.xrTable4.StylePriority.UseTextAlignment = false;
			this.xrTable4.TextAlignment = TextAlignment.TopCenter;
			this.xrTableRow4.Cells.AddRange(new XRTableCell[]
			{
				this.xrTableCell10,
				this.xrTableCell11,
				this.xrTableCell12
			});
			this.xrTableRow4.Dpi = 100f;
			this.xrTableRow4.Name = "xrTableRow4";
			this.xrTableRow4.Weight = 11.5;
			this.xrTableCell10.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "TestsList.TestsListTestItems.ItemName")
			});
			this.xrTableCell10.Dpi = 100f;
			this.xrTableCell10.Name = "xrTableCell10";
			this.xrTableCell10.Weight = 0.24235486300179698;
			this.xrTableCell11.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "TestsList.TestsListTestItems.Unit")
			});
			this.xrTableCell11.Dpi = 100f;
			this.xrTableCell11.Name = "xrTableCell11";
			this.xrTableCell11.Weight = 0.11870718774371006;
			this.xrTableCell12.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "TestsList.TestsListTestItems.Qty")
			});
			this.xrTableCell12.Dpi = 100f;
			this.xrTableCell12.Name = "xrTableCell12";
			this.xrTableCell12.Weight = 0.12661284150014712;
			this.GroupHeader2.Controls.AddRange(new XRControl[]
			{
				this.xrTable3,
				this.xrLine4
			});
			this.GroupHeader2.Dpi = 100f;
			this.GroupHeader2.HeightF = 52.18135f;
			this.GroupHeader2.KeepTogether = true;
			this.GroupHeader2.Name = "GroupHeader2";
			this.xrTable3.Borders = BorderSide.All;
			this.xrTable3.Dpi = 100f;
			this.xrTable3.Font = new Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrTable3.LocationFloat = new PointFloat(110.4167f, 27.18135f);
			this.xrTable3.Name = "xrTable3";
			this.xrTable3.Rows.AddRange(new XRTableRow[]
			{
				this.xrTableRow3
			});
			this.xrTable3.SizeF = new SizeF(651.0416f, 25f);
			this.xrTable3.StylePriority.UseBorders = false;
			this.xrTable3.StylePriority.UseFont = false;
			this.xrTable3.StylePriority.UseTextAlignment = false;
			this.xrTable3.TextAlignment = TextAlignment.TopCenter;
			this.xrTableRow3.Cells.AddRange(new XRTableCell[]
			{
				this.xrTableCell7,
				this.xrTableCell8,
				this.xrTableCell9
			});
			this.xrTableRow3.Dpi = 100f;
			this.xrTableRow3.Name = "xrTableRow3";
			this.xrTableRow3.Weight = 11.5;
			this.xrTableCell7.Dpi = 100f;
			this.xrTableCell7.Name = "xrTableCell7";
			this.xrTableCell7.Text = "Material Name";
			this.xrTableCell7.Weight = 0.24235486300179698;
			this.xrTableCell8.Dpi = 100f;
			this.xrTableCell8.Name = "xrTableCell8";
			this.xrTableCell8.Text = "Unit Of Measure";
			this.xrTableCell8.Weight = 0.11870718774371006;
			this.xrTableCell9.Dpi = 100f;
			this.xrTableCell9.Name = "xrTableCell9";
			this.xrTableCell9.Text = "Qty";
			this.xrTableCell9.Weight = 0.12661284150014712;
			this.PageHeader.Controls.AddRange(new XRControl[]
			{
				this.xrLabel2
			});
			this.PageHeader.Dpi = 100f;
			this.PageHeader.HeightF = 59.65512f;
			this.PageHeader.Name = "PageHeader";
			this.xrLabel2.Dpi = 100f;
			this.xrLabel2.LocationFloat = new PointFloat(92.70834f, 0f);
			this.xrLabel2.Name = "xrLabel2";
			this.xrLabel2.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel2.SizeF = new SizeF(638f, 33f);
			this.xrLabel2.StyleName = "Title";
			this.xrLabel2.StylePriority.UseTextAlignment = false;
			this.xrLabel2.Text = "Service Information";
			this.xrLabel2.TextAlignment = TextAlignment.TopCenter;
			this.DetailReport2.Bands.AddRange(new Band[]
			{
				this.Detail3,
				this.GroupHeader3
			});
			this.DetailReport2.DataMember = "TestsList.FK_TestEquipments_TestsList";
			this.DetailReport2.DataSource = this.sqlDataSource1;
			this.DetailReport2.Dpi = 100f;
			this.DetailReport2.Level = 0;
			this.DetailReport2.Name = "DetailReport2";
			this.Detail3.Controls.AddRange(new XRControl[]
			{
				this.xrLabel10
			});
			this.Detail3.Dpi = 100f;
			this.Detail3.HeightF = 27.52102f;
			this.Detail3.Name = "Detail3";
			this.xrLabel10.AnchorVertical = VerticalAnchorStyles.Both;
			this.xrLabel10.Borders = BorderSide.None;
			this.xrLabel10.CanGrow = false;
			this.xrLabel10.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "TestsList.FK_TestEquipments_TestsList.EquipmentName")
			});
			this.xrLabel10.Dpi = 100f;
			this.xrLabel10.LocationFloat = new PointFloat(220.5598f, 6.075659f);
			this.xrLabel10.Name = "xrLabel10";
			this.xrLabel10.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel10.SizeF = new SizeF(160.2317f, 21.44536f);
			this.xrLabel10.StylePriority.UseBorders = false;
			this.GroupHeader3.Borders = BorderSide.All;
			this.GroupHeader3.Controls.AddRange(new XRControl[]
			{
				this.xrLabel28
			});
			this.GroupHeader3.Dpi = 100f;
			this.GroupHeader3.HeightF = 29.62186f;
			this.GroupHeader3.Name = "GroupHeader3";
			this.GroupHeader3.StylePriority.UseBorders = false;
			this.xrLabel28.Borders = BorderSide.None;
			this.xrLabel28.Dpi = 100f;
			this.xrLabel28.Font = new Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrLabel28.LocationFloat = new PointFloat(11.76828f, 2.924398f);
			this.xrLabel28.Name = "xrLabel28";
			this.xrLabel28.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel28.SizeF = new SizeF(160.2317f, 23f);
			this.xrLabel28.StylePriority.UseBorders = false;
			this.xrLabel28.StylePriority.UseFont = false;
			this.xrLabel28.StylePriority.UseTextAlignment = false;
			this.xrLabel28.Text = "Equipment List:";
			this.xrLabel28.TextAlignment = TextAlignment.TopCenter;
			this.DetailReport3.Bands.AddRange(new Band[]
			{
				this.Detail4,
				this.GroupHeader4
			});
			this.DetailReport3.DataMember = "TestsList.FK_TestContractors_TestsList";
			this.DetailReport3.DataSource = this.sqlDataSource1;
			this.DetailReport3.Dpi = 100f;
			this.DetailReport3.Level = 1;
			this.DetailReport3.Name = "DetailReport3";
			this.Detail4.Controls.AddRange(new XRControl[]
			{
				this.xrLabel24
			});
			this.Detail4.Dpi = 100f;
			this.Detail4.HeightF = 28.57145f;
			this.Detail4.Name = "Detail4";
			this.xrLabel24.Borders = BorderSide.None;
			this.xrLabel24.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "TestsList.FK_TestContractors_TestsList.SubContractorName")
			});
			this.xrLabel24.Dpi = 100f;
			this.xrLabel24.LocationFloat = new PointFloat(220.5598f, 5.571445f);
			this.xrLabel24.Name = "xrLabel24";
			this.xrLabel24.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel24.SizeF = new SizeF(160.2317f, 23f);
			this.xrLabel24.StylePriority.UseBorders = false;
			this.GroupHeader4.Controls.AddRange(new XRControl[]
			{
				this.xrLabel41
			});
			this.GroupHeader4.Dpi = 100f;
			this.GroupHeader4.HeightF = 28.57144f;
			this.GroupHeader4.Name = "GroupHeader4";
			this.xrLabel41.Dpi = 100f;
			this.xrLabel41.Font = new Font("Times New Roman", 9.75f, FontStyle.Bold);
			this.xrLabel41.LocationFloat = new PointFloat(11.76828f, 0f);
			this.xrLabel41.Name = "xrLabel41";
			this.xrLabel41.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel41.SizeF = new SizeF(200.2318f, 23f);
			this.xrLabel41.StylePriority.UseFont = false;
			this.xrLabel41.StylePriority.UseTextAlignment = false;
			this.xrLabel41.Text = "Recommended Subcontractor:";
			this.xrLabel41.TextAlignment = TextAlignment.TopCenter;
			this.DetailReport5.Bands.AddRange(new Band[]
			{
				this.Detail6
			});
			this.DetailReport5.Dpi = 100f;
			this.DetailReport5.Level = 2;
			this.DetailReport5.Name = "DetailReport5";
			this.Detail6.Controls.AddRange(new XRControl[]
			{
				this.xrLabel21,
				this.xrLabel39,
				this.xrLabel30,
				this.xrLabel29,
				this.xrLabel22,
				this.xrLabel40,
				this.xrLabel12,
				this.xrLabel11,
				this.xrLine2
			});
			this.Detail6.Dpi = 100f;
			this.Detail6.HeightF = 83.19329f;
			this.Detail6.Name = "Detail6";
			this.FilterExpression.Description = "FilterExpression";
			this.FilterExpression.Name = "FilterExpression";
			this.Id.Description = "Id";
			dynamicListLookUpSettings.DataAdapter = null;
			dynamicListLookUpSettings.DataMember = "TestsList";
			dynamicListLookUpSettings.DataSource = this.sqlDataSource1;
			dynamicListLookUpSettings.DisplayMember = "TestName";
			dynamicListLookUpSettings.FilterString = null;
			dynamicListLookUpSettings.ValueMember = "TestID";
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
				this.DetailReport1,
				this.PageHeader,
				this.DetailReport2,
				this.DetailReport3,
				this.DetailReport5
			});
			base.ComponentStorage.AddRange(new IComponent[]
			{
				this.sqlDataSource1
			});
			base.DataMember = "TestsList";
			base.DataSource = this.sqlDataSource1;
			this.FilterString = "[TestID] = ?Id";
			base.Margins = new Margins(0, 0, 130, 9);
			base.Parameters.AddRange(new Parameter[]
			{
				this.FilterExpression,
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
			((ISupportInitialize)this.xrTable4).EndInit();
			((ISupportInitialize)this.xrTable3).EndInit();
			((ISupportInitialize)this).EndInit();
		}

		// Token: 0x04000AE8 RID: 2792
		private IContainer components;

		// Token: 0x04000AE9 RID: 2793
		private DetailBand Detail;

		// Token: 0x04000AEA RID: 2794
		private TopMarginBand TopMargin;

		// Token: 0x04000AEB RID: 2795
		private BottomMarginBand BottomMargin;

		// Token: 0x04000AEC RID: 2796
		private XRLabel xrLabel1;

		// Token: 0x04000AED RID: 2797
		private XRLabel xrLabel3;

		// Token: 0x04000AEE RID: 2798
		private XRLabel xrLabel4;

		// Token: 0x04000AEF RID: 2799
		private XRLabel xrLabel5;

		// Token: 0x04000AF0 RID: 2800
		private XRLabel xrLabel6;

		// Token: 0x04000AF1 RID: 2801
		private XRLabel xrLabel7;

		// Token: 0x04000AF2 RID: 2802
		private XRLabel xrLabel8;

		// Token: 0x04000AF3 RID: 2803
		private XRLabel xrLabel9;

		// Token: 0x04000AF4 RID: 2804
		private XRLabel xrLabel11;

		// Token: 0x04000AF5 RID: 2805
		private XRLabel xrLabel12;

		// Token: 0x04000AF6 RID: 2806
		private XRLabel xrLabel13;

		// Token: 0x04000AF7 RID: 2807
		private XRLabel xrLabel14;

		// Token: 0x04000AF8 RID: 2808
		private XRLabel xrLabel15;

		// Token: 0x04000AF9 RID: 2809
		private XRLabel xrLabel16;

		// Token: 0x04000AFA RID: 2810
		private XRLabel xrLabel17;

		// Token: 0x04000AFB RID: 2811
		private XRLabel xrLabel18;

		// Token: 0x04000AFC RID: 2812
		private XRLabel xrLabel19;

		// Token: 0x04000AFD RID: 2813
		private XRLabel xrLabel20;

		// Token: 0x04000AFE RID: 2814
		private XRLabel xrLabel21;

		// Token: 0x04000AFF RID: 2815
		private XRLabel xrLabel22;

		// Token: 0x04000B00 RID: 2816
		private XRLabel xrLabel23;

		// Token: 0x04000B01 RID: 2817
		private XRLabel xrLabel25;

		// Token: 0x04000B02 RID: 2818
		private XRLabel xrLabel26;

		// Token: 0x04000B03 RID: 2819
		private XRLabel xrLabel27;

		// Token: 0x04000B04 RID: 2820
		private XRCheckBox xrCheckBox1;

		// Token: 0x04000B05 RID: 2821
		private XRCheckBox xrCheckBox2;

		// Token: 0x04000B06 RID: 2822
		private XRCheckBox xrCheckBox3;

		// Token: 0x04000B07 RID: 2823
		private XRCheckBox xrCheckBox4;

		// Token: 0x04000B08 RID: 2824
		private XRLabel xrLabel29;

		// Token: 0x04000B09 RID: 2825
		private XRLabel xrLabel30;

		// Token: 0x04000B0A RID: 2826
		private XRLabel xrLabel31;

		// Token: 0x04000B0B RID: 2827
		private XRLabel xrLabel32;

		// Token: 0x04000B0C RID: 2828
		private XRLabel xrLabel33;

		// Token: 0x04000B0D RID: 2829
		private XRLabel xrLabel34;

		// Token: 0x04000B0E RID: 2830
		private XRLabel xrLabel35;

		// Token: 0x04000B0F RID: 2831
		private XRLabel xrLabel36;

		// Token: 0x04000B10 RID: 2832
		private XRLabel xrLabel37;

		// Token: 0x04000B11 RID: 2833
		private XRLabel xrLabel38;

		// Token: 0x04000B12 RID: 2834
		private XRLabel xrLabel39;

		// Token: 0x04000B13 RID: 2835
		private XRLabel xrLabel40;

		// Token: 0x04000B14 RID: 2836
		private XRLine xrLine1;

		// Token: 0x04000B15 RID: 2837
		private SqlDataSource sqlDataSource1;

		// Token: 0x04000B16 RID: 2838
		private PageFooterBand pageFooterBand1;

		// Token: 0x04000B17 RID: 2839
		private XRPageInfo xrPageInfo1;

		// Token: 0x04000B18 RID: 2840
		private XRPageInfo xrPageInfo2;

		// Token: 0x04000B19 RID: 2841
		private ReportHeaderBand reportHeaderBand1;

		// Token: 0x04000B1A RID: 2842
		private XRControlStyle Title;

		// Token: 0x04000B1B RID: 2843
		private XRControlStyle FieldCaption;

		// Token: 0x04000B1C RID: 2844
		private XRControlStyle PageInfo;

		// Token: 0x04000B1D RID: 2845
		private XRControlStyle DataField;

		// Token: 0x04000B1E RID: 2846
		private XRLine xrLine4;

		// Token: 0x04000B1F RID: 2847
		private XRLine xrLine3;

		// Token: 0x04000B20 RID: 2848
		private XRLine xrLine2;

		// Token: 0x04000B21 RID: 2849
		private DetailReportBand DetailReport;

		// Token: 0x04000B22 RID: 2850
		private DetailBand Detail1;

		// Token: 0x04000B23 RID: 2851
		private GroupHeaderBand GroupHeader1;

		// Token: 0x04000B24 RID: 2852
		private DetailReportBand DetailReport1;

		// Token: 0x04000B25 RID: 2853
		private DetailBand Detail2;

		// Token: 0x04000B26 RID: 2854
		private GroupHeaderBand GroupHeader2;

		// Token: 0x04000B27 RID: 2855
		private XRTable xrTable1;

		// Token: 0x04000B28 RID: 2856
		private XRTableRow xrTableRow1;

		// Token: 0x04000B29 RID: 2857
		private XRTableCell xrTableCell1;

		// Token: 0x04000B2A RID: 2858
		private XRTableCell xrTableCell2;

		// Token: 0x04000B2B RID: 2859
		private XRTableCell xrTableCell3;

		// Token: 0x04000B2C RID: 2860
		private PageHeaderBand PageHeader;

		// Token: 0x04000B2D RID: 2861
		private XRLabel xrLabel2;

		// Token: 0x04000B2E RID: 2862
		private DetailReportBand DetailReport2;

		// Token: 0x04000B2F RID: 2863
		private DetailBand Detail3;

		// Token: 0x04000B30 RID: 2864
		private XRLabel xrLabel10;

		// Token: 0x04000B31 RID: 2865
		private GroupHeaderBand GroupHeader3;

		// Token: 0x04000B32 RID: 2866
		private XRLabel xrLabel28;

		// Token: 0x04000B33 RID: 2867
		private DetailReportBand DetailReport3;

		// Token: 0x04000B34 RID: 2868
		private DetailBand Detail4;

		// Token: 0x04000B35 RID: 2869
		private XRLabel xrLabel24;

		// Token: 0x04000B36 RID: 2870
		private GroupHeaderBand GroupHeader4;

		// Token: 0x04000B37 RID: 2871
		private XRLabel xrLabel41;

		// Token: 0x04000B38 RID: 2872
		private DetailReportBand DetailReport5;

		// Token: 0x04000B39 RID: 2873
		private DetailBand Detail6;

		// Token: 0x04000B3A RID: 2874
		private XRLine xrLine5;

		// Token: 0x04000B3B RID: 2875
		private XRTable xrTable2;

		// Token: 0x04000B3C RID: 2876
		private XRTableRow xrTableRow2;

		// Token: 0x04000B3D RID: 2877
		private XRTableCell xrTableCell4;

		// Token: 0x04000B3E RID: 2878
		private XRTableCell xrTableCell5;

		// Token: 0x04000B3F RID: 2879
		private XRTableCell xrTableCell6;

		// Token: 0x04000B40 RID: 2880
		private XRTable xrTable4;

		// Token: 0x04000B41 RID: 2881
		private XRTableRow xrTableRow4;

		// Token: 0x04000B42 RID: 2882
		private XRTableCell xrTableCell10;

		// Token: 0x04000B43 RID: 2883
		private XRTableCell xrTableCell11;

		// Token: 0x04000B44 RID: 2884
		private XRTableCell xrTableCell12;

		// Token: 0x04000B45 RID: 2885
		private XRTable xrTable3;

		// Token: 0x04000B46 RID: 2886
		private XRTableRow xrTableRow3;

		// Token: 0x04000B47 RID: 2887
		private XRTableCell xrTableCell7;

		// Token: 0x04000B48 RID: 2888
		private XRTableCell xrTableCell8;

		// Token: 0x04000B49 RID: 2889
		private XRTableCell xrTableCell9;

		// Token: 0x04000B4A RID: 2890
		private Parameter FilterExpression;

		// Token: 0x04000B4B RID: 2891
		private Parameter Id;

		// Token: 0x04000B4C RID: 2892
		private XRPictureBox xrPictureBox2;

		// Token: 0x04000B4D RID: 2893
		private XRLine xrLine6;

		// Token: 0x04000B4E RID: 2894
		private XRLabel xrLabel42;

		// Token: 0x04000B4F RID: 2895
		private XRLabel xrLabel43;

		// Token: 0x04000B50 RID: 2896
		private XRPictureBox xrPictureBox1;

		// Token: 0x04000B51 RID: 2897
		private XRLabel xrLabel44;

		// Token: 0x04000B52 RID: 2898
		private XRLabel xrLabel45;

		// Token: 0x04000B53 RID: 2899
		private XRLabel xrLabel46;

		// Token: 0x04000B54 RID: 2900
		private XRLine xrLine7;

		// Token: 0x04000B55 RID: 2901
		private XRLabel xrLabel47;
	}
}
