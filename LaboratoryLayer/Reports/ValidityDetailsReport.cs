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
	// Token: 0x02000071 RID: 113
	public class ValidityDetailsReport : XtraReport
	{
		// Token: 0x06000392 RID: 914 RVA: 0x00004761 File Offset: 0x00002961
		public ValidityDetailsReport()
		{
			this.InitializeComponent();
			this.BeforePrint += this.ValidityDetailsReport_BeforePrint;
		}

		// Token: 0x06000393 RID: 915 RVA: 0x00069F4C File Offset: 0x0006814C
		private void ValidityDetailsReport_BeforePrint(object sender, PrintEventArgs e)
		{
			if (this.FilterExpression.Value.ToString() != "")
			{
				this.FilterString = this.FilterExpression.Value.ToString();
				return;
			}
			if (this.ValidityID.Value.ToString() == "0")
			{
				this.FilterString = "";
			}
		}

		// Token: 0x06000394 RID: 916 RVA: 0x00004781 File Offset: 0x00002981
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000395 RID: 917 RVA: 0x00069FB4 File Offset: 0x000681B4
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
			Table table2 = new Table();
			Join join = new Join();
			RelationColumnInfo relationColumnInfo = new RelationColumnInfo();
			CustomSqlQuery customSqlQuery = new CustomSqlQuery();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ValidityDetailsReport));
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(ValidityDetailsReport));
			MasterDetailInfo masterDetailInfo = new MasterDetailInfo();
			RelationColumnInfo relationColumnInfo2 = new RelationColumnInfo();
			DynamicListLookUpSettings dynamicListLookUpSettings = new DynamicListLookUpSettings();
			this.sqlDataSource1 = new SqlDataSource(this.components);
			this.Detail = new DetailBand();
			this.TopMargin = new TopMarginBand();
			this.BottomMargin = new BottomMarginBand();
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
			this.xrTableCell3 = new XRTableCell();
			this.xrTableCell4 = new XRTableCell();
			this.xrTableCell5 = new XRTableCell();
			this.xrTableCell6 = new XRTableCell();
			this.xrTableCell7 = new XRTableCell();
			this.xrTableCell9 = new XRTableCell();
			this.xrTableCell12 = new XRTableCell();
			this.xrTableCell13 = new XRTableCell();
			this.GroupHeader1 = new GroupHeaderBand();
			this.xrTable4 = new XRTable();
			this.xrTableRow4 = new XRTableRow();
			this.xrTableCell8 = new XRTableCell();
			this.xrTableCell18 = new XRTableCell();
			this.xrTableCell19 = new XRTableCell();
			this.xrTableCell20 = new XRTableCell();
			this.xrTableCell21 = new XRTableCell();
			this.xrTableCell22 = new XRTableCell();
			this.xrTableCell23 = new XRTableCell();
			this.xrTableCell25 = new XRTableCell();
			this.xrTableCell10 = new XRTableCell();
			this.xrTableCell11 = new XRTableCell();
			this.xrLabel26 = new XRLabel();
			this.PageHeader = new PageHeaderBand();
			this.ValidityID = new Parameter();
			this.FilterExpression = new Parameter();
			this.xrLabel10 = new XRLabel();
			this.xrLabel6 = new XRLabel();
			this.xrLabel5 = new XRLabel();
			((ISupportInitialize)this.xrTable1).BeginInit();
			((ISupportInitialize)this.xrTable4).BeginInit();
			((ISupportInitialize)this).BeginInit();
			this.sqlDataSource1.ConnectionName = "localhost_LabSys_Connection";
			this.sqlDataSource1.Name = "sqlDataSource1";
			columnExpression.ColumnName = "ValidityID";
			table.MetaSerializable = "30|30|125|140";
			table.Name = "ValidityList";
			columnExpression.Table = table;
			column.Expression = columnExpression;
			columnExpression2.ColumnName = "ValidityCode";
			columnExpression2.Table = table;
			column2.Expression = columnExpression2;
			columnExpression3.ColumnName = "ValidityName";
			columnExpression3.Table = table;
			column3.Expression = columnExpression3;
			columnExpression4.ColumnName = "FKLabID";
			columnExpression4.Table = table;
			column4.Expression = columnExpression4;
			columnExpression5.ColumnName = "IsLocked";
			columnExpression5.Table = table;
			column5.Expression = columnExpression5;
			columnExpression6.ColumnName = "LabName";
			table2.MetaSerializable = "185|30|125|140";
			table2.Name = "LabsList";
			columnExpression6.Table = table2;
			column6.Expression = columnExpression6;
			selectQuery.Columns.Add(column);
			selectQuery.Columns.Add(column2);
			selectQuery.Columns.Add(column3);
			selectQuery.Columns.Add(column4);
			selectQuery.Columns.Add(column5);
			selectQuery.Columns.Add(column6);
			selectQuery.Name = "ValidityList";
			relationColumnInfo.NestedKeyColumn = "LabID";
			relationColumnInfo.ParentKeyColumn = "FKLabID";
			join.KeyColumns.Add(relationColumnInfo);
			join.Nested = table2;
			join.Parent = table;
			selectQuery.Relations.Add(join);
			selectQuery.Tables.Add(table);
			selectQuery.Tables.Add(table2);
			customSqlQuery.Name = "ValidityListDetails";
			customSqlQuery.Sql = resources.GetString("customSqlQuery1.Sql");
			this.sqlDataSource1.Queries.AddRange(new SqlQuery[]
			{
				selectQuery,
				customSqlQuery
			});
			masterDetailInfo.DetailQueryName = "ValidityListDetails";
			relationColumnInfo2.NestedKeyColumn = "FKValidityID";
			relationColumnInfo2.ParentKeyColumn = "ValidityID";
			masterDetailInfo.KeyColumns.Add(relationColumnInfo2);
			masterDetailInfo.MasterQueryName = "ValidityList";
			masterDetailInfo.Name = "FK_ValidityListDetails_ValidityList";
			this.sqlDataSource1.Relations.AddRange(new MasterDetailInfo[]
			{
				masterDetailInfo
			});
			this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
			this.Detail.Controls.AddRange(new XRControl[]
			{
				this.xrLabel10,
				this.xrLabel6,
				this.xrLabel5,
				this.xrLabel26
			});
			this.Detail.Dpi = 100f;
			this.Detail.HeightF = 108f;
			this.Detail.KeepTogether = true;
			this.Detail.KeepTogetherWithDetailReports = true;
			this.Detail.Name = "Detail";
			this.Detail.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
			this.Detail.PageBreak = PageBreak.BeforeBand;
			this.Detail.TextAlignment = TextAlignment.TopLeft;
			this.TopMargin.Dpi = 100f;
			this.TopMargin.HeightF = 23.75f;
			this.TopMargin.Name = "TopMargin";
			this.TopMargin.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
			this.TopMargin.TextAlignment = TextAlignment.TopLeft;
			this.BottomMargin.Dpi = 100f;
			this.BottomMargin.HeightF = 3.458405f;
			this.BottomMargin.Name = "BottomMargin";
			this.BottomMargin.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
			this.BottomMargin.TextAlignment = TextAlignment.TopLeft;
			this.pageFooterBand1.Dpi = 100f;
			this.pageFooterBand1.HeightF = 0.8749326f;
			this.pageFooterBand1.Name = "pageFooterBand1";
			this.reportHeaderBand1.Dpi = 100f;
			this.reportHeaderBand1.HeightF = 2.541669f;
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
			this.DetailReport.DataMember = "ValidityList.FK_ValidityListDetails_ValidityList";
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
			this.xrTable1.Font = new Font("Times New Roman", 10f);
			this.xrTable1.LocationFloat = new PointFloat(0f, 0f);
			this.xrTable1.Name = "xrTable1";
			this.xrTable1.Padding = new PaddingInfo(0, 0, 3, 0, 100f);
			this.xrTable1.Rows.AddRange(new XRTableRow[]
			{
				this.xrTableRow1
			});
			this.xrTable1.SizeF = new SizeF(1088f, 25f);
			this.xrTable1.StylePriority.UseBorders = false;
			this.xrTable1.StylePriority.UseFont = false;
			this.xrTable1.StylePriority.UsePadding = false;
			this.xrTable1.StylePriority.UseTextAlignment = false;
			this.xrTable1.TextAlignment = TextAlignment.TopCenter;
			this.xrTableRow1.Cells.AddRange(new XRTableCell[]
			{
				this.xrTableCell1,
				this.xrTableCell2,
				this.xrTableCell3,
				this.xrTableCell4,
				this.xrTableCell5,
				this.xrTableCell6,
				this.xrTableCell7,
				this.xrTableCell9,
				this.xrTableCell12,
				this.xrTableCell13
			});
			this.xrTableRow1.Dpi = 100f;
			this.xrTableRow1.Name = "xrTableRow1";
			this.xrTableRow1.Weight = 11.5;
			this.xrTableCell1.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "ValidityList.FK_ValidityListDetails_ValidityList.CertificateName")
			});
			this.xrTableCell1.Dpi = 100f;
			this.xrTableCell1.Name = "xrTableCell1";
			this.xrTableCell1.Text = "xrTableCell1";
			this.xrTableCell1.Weight = 0.3596744337124881;
			this.xrTableCell2.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "ValidityList.FK_ValidityListDetails_ValidityList.CertificateSerialNumber")
			});
			this.xrTableCell2.Dpi = 100f;
			this.xrTableCell2.Name = "xrTableCell2";
			this.xrTableCell2.Text = "xrTableCell2";
			this.xrTableCell2.Weight = 0.17226404013485533;
			this.xrTableCell3.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "ValidityList.FK_ValidityListDetails_ValidityList.IDNumber")
			});
			this.xrTableCell3.Dpi = 100f;
			this.xrTableCell3.Name = "xrTableCell3";
			this.xrTableCell3.Weight = 0.15370800881791746;
			this.xrTableCell4.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "ValidityList.FK_ValidityListDetails_ValidityList.EnteredBy")
			});
			this.xrTableCell4.Dpi = 100f;
			this.xrTableCell4.Name = "xrTableCell4";
			this.xrTableCell4.Weight = 0.1289916966309982;
			this.xrTableCell5.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "ValidityList.FK_ValidityListDetails_ValidityList.EntryDate", "{0:dd/MM/yyyy}")
			});
			this.xrTableCell5.Dpi = 100f;
			this.xrTableCell5.Name = "xrTableCell5";
			this.xrTableCell5.Weight = 0.13126928467681004;
			this.xrTableCell6.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "ValidityList.FK_ValidityListDetails_ValidityList.ExpiryDate", "{0:dd/MM/yyyy}")
			});
			this.xrTableCell6.Dpi = 100f;
			this.xrTableCell6.Name = "xrTableCell6";
			this.xrTableCell6.Weight = 0.1510591091211691;
			this.xrTableCell7.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "ValidityList.FK_ValidityListDetails_ValidityList.Responsible")
			});
			this.xrTableCell7.Dpi = 100f;
			this.xrTableCell7.Name = "xrTableCell7";
			this.xrTableCell7.Text = "xrTableCell7";
			this.xrTableCell7.Weight = 0.1809211268752949;
			this.xrTableCell9.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "ValidityList.FK_ValidityListDetails_ValidityList.CalibratedBy")
			});
			this.xrTableCell9.Dpi = 100f;
			this.xrTableCell9.Name = "xrTableCell9";
			this.xrTableCell9.Weight = 0.14869005937926982;
			this.xrTableCell12.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "ValidityList.FK_ValidityListDetails_ValidityList.Status")
			});
			this.xrTableCell12.Dpi = 100f;
			this.xrTableCell12.Name = "xrTableCell12";
			this.xrTableCell12.Weight = 0.09220432116154983;
			this.xrTableCell13.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "ValidityList.FK_ValidityListDetails_ValidityList.Remarks")
			});
			this.xrTableCell13.Dpi = 100f;
			this.xrTableCell13.Name = "xrTableCell13";
			this.xrTableCell13.Weight = 0.32130863486397876;
			this.GroupHeader1.Controls.AddRange(new XRControl[]
			{
				this.xrTable4
			});
			this.GroupHeader1.Dpi = 100f;
			this.GroupHeader1.HeightF = 25f;
			this.GroupHeader1.Name = "GroupHeader1";
			this.GroupHeader1.RepeatEveryPage = true;
			this.xrTable4.BackColor = Color.LightGray;
			this.xrTable4.Borders = BorderSide.All;
			this.xrTable4.Dpi = 100f;
			this.xrTable4.Font = new Font("Times New Roman", 9f, FontStyle.Bold);
			this.xrTable4.LocationFloat = new PointFloat(0f, 0f);
			this.xrTable4.Name = "xrTable4";
			this.xrTable4.Rows.AddRange(new XRTableRow[]
			{
				this.xrTableRow4
			});
			this.xrTable4.SizeF = new SizeF(1088f, 25f);
			this.xrTable4.StylePriority.UseBackColor = false;
			this.xrTable4.StylePriority.UseBorders = false;
			this.xrTable4.StylePriority.UseFont = false;
			this.xrTable4.StylePriority.UseTextAlignment = false;
			this.xrTable4.TextAlignment = TextAlignment.TopCenter;
			this.xrTableRow4.Cells.AddRange(new XRTableCell[]
			{
				this.xrTableCell8,
				this.xrTableCell18,
				this.xrTableCell19,
				this.xrTableCell20,
				this.xrTableCell21,
				this.xrTableCell22,
				this.xrTableCell23,
				this.xrTableCell25,
				this.xrTableCell10,
				this.xrTableCell11
			});
			this.xrTableRow4.Dpi = 100f;
			this.xrTableRow4.Name = "xrTableRow4";
			this.xrTableRow4.Weight = 11.5;
			this.xrTableCell8.Dpi = 100f;
			this.xrTableCell8.Name = "xrTableCell8";
			this.xrTableCell8.Text = "Certificate Name";
			this.xrTableCell8.Weight = 0.39859314892039543;
			this.xrTableCell18.Dpi = 100f;
			this.xrTableCell18.Name = "xrTableCell18";
			this.xrTableCell18.Text = "Certificate Sr no";
			this.xrTableCell18.Weight = 0.19090391583606733;
			this.xrTableCell19.Dpi = 100f;
			this.xrTableCell19.Name = "xrTableCell19";
			this.xrTableCell19.Text = "Equiment Sr no";
			this.xrTableCell19.Weight = 0.1703398952230073;
			this.xrTableCell20.Dpi = 100f;
			this.xrTableCell20.Name = "xrTableCell20";
			this.xrTableCell20.Text = "Entered By";
			this.xrTableCell20.Weight = 0.14294939877928317;
			this.xrTableCell21.Dpi = 100f;
			this.xrTableCell21.Name = "xrTableCell21";
			this.xrTableCell21.Text = "Entry Date";
			this.xrTableCell21.Weight = 0.14547330677602308;
			this.xrTableCell22.Dpi = 100f;
			this.xrTableCell22.Name = "xrTableCell22";
			this.xrTableCell22.Text = "Expiry Date";
			this.xrTableCell22.Weight = 0.16740450540049445;
			this.xrTableCell23.Dpi = 100f;
			this.xrTableCell23.Name = "xrTableCell23";
			this.xrTableCell23.Text = "Responsible";
			this.xrTableCell23.Weight = 0.2004977564081386;
			this.xrTableCell25.Dpi = 100f;
			this.xrTableCell25.Name = "xrTableCell25";
			this.xrTableCell25.Text = "Calibrated By";
			this.xrTableCell25.Weight = 0.16477911728780725;
			this.xrTableCell10.Dpi = 100f;
			this.xrTableCell10.Name = "xrTableCell10";
			this.xrTableCell10.Text = "Status";
			this.xrTableCell10.Weight = 0.10218131251183545;
			this.xrTableCell11.Dpi = 100f;
			this.xrTableCell11.Name = "xrTableCell11";
			this.xrTableCell11.Text = "Remarks";
			this.xrTableCell11.Weight = 0.3560758567941192;
			this.xrLabel26.Dpi = 100f;
			this.xrLabel26.LocationFloat = new PointFloat(185.2082f, 10.00001f);
			this.xrLabel26.Name = "xrLabel26";
			this.xrLabel26.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel26.SizeF = new SizeF(638f, 33f);
			this.xrLabel26.StyleName = "Title";
			this.xrLabel26.StylePriority.UseTextAlignment = false;
			this.xrLabel26.Text = "Validity List Details";
			this.xrLabel26.TextAlignment = TextAlignment.TopCenter;
			this.PageHeader.Dpi = 100f;
			this.PageHeader.HeightF = 1.749992f;
			this.PageHeader.Name = "PageHeader";
			this.ValidityID.Description = "ValidityID";
			dynamicListLookUpSettings.DataAdapter = null;
			dynamicListLookUpSettings.DataMember = "ValidityList";
			dynamicListLookUpSettings.DataSource = this.sqlDataSource1;
			dynamicListLookUpSettings.DisplayMember = "ValidityName";
			dynamicListLookUpSettings.FilterString = null;
			dynamicListLookUpSettings.ValueMember = "ValidityID";
			this.ValidityID.LookUpSettings = dynamicListLookUpSettings;
			this.ValidityID.Name = "ValidityID";
			this.ValidityID.Type = typeof(int);
			this.ValidityID.ValueInfo = "0";
			this.FilterExpression.Description = "FilterExpression";
			this.FilterExpression.Name = "FilterExpression";
			this.xrLabel10.Dpi = 100f;
			this.xrLabel10.ForeColor = Color.FromArgb(0, 0, 0);
			this.xrLabel10.LocationFloat = new PointFloat(333.6316f, 64.99999f);
			this.xrLabel10.Name = "xrLabel10";
			this.xrLabel10.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel10.SizeF = new SizeF(29.70132f, 33f);
			this.xrLabel10.StyleName = "Title";
			this.xrLabel10.StylePriority.UseForeColor = false;
			this.xrLabel10.StylePriority.UseTextAlignment = false;
			this.xrLabel10.Text = "-";
			this.xrLabel10.TextAlignment = TextAlignment.TopCenter;
			this.xrLabel6.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "ValidityList.ValidityName")
			});
			this.xrLabel6.Dpi = 100f;
			this.xrLabel6.ForeColor = Color.FromArgb(0, 0, 0);
			this.xrLabel6.LocationFloat = new PointFloat(358.7705f, 64.99999f);
			this.xrLabel6.Name = "xrLabel6";
			this.xrLabel6.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel6.SizeF = new SizeF(464.4378f, 33.00001f);
			this.xrLabel6.StyleName = "Title";
			this.xrLabel6.StylePriority.UseForeColor = false;
			this.xrLabel6.StylePriority.UseTextAlignment = false;
			this.xrLabel6.TextAlignment = TextAlignment.TopLeft;
			this.xrLabel5.DataBindings.AddRange(new XRBinding[]
			{
				new XRBinding("Text", null, "ValidityList.ValidityCode")
			});
			this.xrLabel5.Dpi = 100f;
			this.xrLabel5.ForeColor = Color.FromArgb(0, 0, 0);
			this.xrLabel5.LocationFloat = new PointFloat(291.4584f, 65.00002f);
			this.xrLabel5.Name = "xrLabel5";
			this.xrLabel5.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
			this.xrLabel5.SizeF = new SizeF(42.17325f, 32.99998f);
			this.xrLabel5.StyleName = "Title";
			this.xrLabel5.StylePriority.UseForeColor = false;
			this.xrLabel5.StylePriority.UseTextAlignment = false;
			this.xrLabel5.TextAlignment = TextAlignment.TopRight;
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
			base.DataMember = "ValidityList";
			base.DataSource = this.sqlDataSource1;
			this.FilterString = "[ValidityID] = ?ValidityID";
			base.Landscape = true;
			base.Margins = new Margins(0, 2, 24, 3);
			base.PageHeight = 850;
			base.PageWidth = 1100;
			base.Parameters.AddRange(new Parameter[]
			{
				this.ValidityID,
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
			((ISupportInitialize)this.xrTable1).EndInit();
			((ISupportInitialize)this.xrTable4).EndInit();
			((ISupportInitialize)this).EndInit();
		}

		// Token: 0x04000C58 RID: 3160
		private IContainer components;

		// Token: 0x04000C59 RID: 3161
		private DetailBand Detail;

		// Token: 0x04000C5A RID: 3162
		private TopMarginBand TopMargin;

		// Token: 0x04000C5B RID: 3163
		private BottomMarginBand BottomMargin;

		// Token: 0x04000C5C RID: 3164
		private SqlDataSource sqlDataSource1;

		// Token: 0x04000C5D RID: 3165
		private PageFooterBand pageFooterBand1;

		// Token: 0x04000C5E RID: 3166
		private ReportHeaderBand reportHeaderBand1;

		// Token: 0x04000C5F RID: 3167
		private XRControlStyle Title;

		// Token: 0x04000C60 RID: 3168
		private XRControlStyle FieldCaption;

		// Token: 0x04000C61 RID: 3169
		private XRControlStyle PageInfo;

		// Token: 0x04000C62 RID: 3170
		private XRControlStyle DataField;

		// Token: 0x04000C63 RID: 3171
		private DetailReportBand DetailReport;

		// Token: 0x04000C64 RID: 3172
		private DetailBand Detail1;

		// Token: 0x04000C65 RID: 3173
		private XRTable xrTable1;

		// Token: 0x04000C66 RID: 3174
		private XRTableRow xrTableRow1;

		// Token: 0x04000C67 RID: 3175
		private XRTableCell xrTableCell1;

		// Token: 0x04000C68 RID: 3176
		private XRTableCell xrTableCell2;

		// Token: 0x04000C69 RID: 3177
		private XRTableCell xrTableCell3;

		// Token: 0x04000C6A RID: 3178
		private XRTableCell xrTableCell4;

		// Token: 0x04000C6B RID: 3179
		private XRTableCell xrTableCell5;

		// Token: 0x04000C6C RID: 3180
		private XRTableCell xrTableCell6;

		// Token: 0x04000C6D RID: 3181
		private XRTableCell xrTableCell7;

		// Token: 0x04000C6E RID: 3182
		private GroupHeaderBand GroupHeader1;

		// Token: 0x04000C6F RID: 3183
		private XRTableCell xrTableCell9;

		// Token: 0x04000C70 RID: 3184
		private XRTable xrTable4;

		// Token: 0x04000C71 RID: 3185
		private XRTableRow xrTableRow4;

		// Token: 0x04000C72 RID: 3186
		private XRTableCell xrTableCell8;

		// Token: 0x04000C73 RID: 3187
		private XRTableCell xrTableCell18;

		// Token: 0x04000C74 RID: 3188
		private XRTableCell xrTableCell19;

		// Token: 0x04000C75 RID: 3189
		private XRTableCell xrTableCell20;

		// Token: 0x04000C76 RID: 3190
		private XRTableCell xrTableCell21;

		// Token: 0x04000C77 RID: 3191
		private XRTableCell xrTableCell22;

		// Token: 0x04000C78 RID: 3192
		private XRTableCell xrTableCell23;

		// Token: 0x04000C79 RID: 3193
		private XRTableCell xrTableCell25;

		// Token: 0x04000C7A RID: 3194
		private XRLabel xrLabel26;

		// Token: 0x04000C7B RID: 3195
		private PageHeaderBand PageHeader;

		// Token: 0x04000C7C RID: 3196
		private Parameter ValidityID;

		// Token: 0x04000C7D RID: 3197
		private Parameter FilterExpression;

		// Token: 0x04000C7E RID: 3198
		private XRTableCell xrTableCell12;

		// Token: 0x04000C7F RID: 3199
		private XRTableCell xrTableCell13;

		// Token: 0x04000C80 RID: 3200
		private XRTableCell xrTableCell10;

		// Token: 0x04000C81 RID: 3201
		private XRTableCell xrTableCell11;

		// Token: 0x04000C82 RID: 3202
		private XRLabel xrLabel10;

		// Token: 0x04000C83 RID: 3203
		private XRLabel xrLabel6;

		// Token: 0x04000C84 RID: 3204
		private XRLabel xrLabel5;
	}
}
