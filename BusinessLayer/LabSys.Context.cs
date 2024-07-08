﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BusinessLayer
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class LabSysEntities : DbContext
    {
        public LabSysEntities()
            : base("name=LabSysEntities")
        {
        }
        public LabSysEntities(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AccreditionList> AccreditionList { get; set; }
        public virtual DbSet<AttachedFiles> AttachedFiles { get; set; }
        public virtual DbSet<AttachFileTransTypes> AttachFileTransTypes { get; set; }
        public virtual DbSet<ContractorsList> ContractorsList { get; set; }
        public virtual DbSet<CustomersList> CustomersList { get; set; }
        public virtual DbSet<EmployeesList> EmployeesList { get; set; }
        public virtual DbSet<EnquiryDetails> EnquiryDetails { get; set; }
        public virtual DbSet<EnquiryMaster> EnquiryMaster { get; set; }
        public virtual DbSet<EquipmentsList> EquipmentsList { get; set; }
        public virtual DbSet<ExcelMappingFieldList> ExcelMappingFieldList { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<ItemsList> ItemsList { get; set; }
        public virtual DbSet<JobOrderMaster> JobOrderMaster { get; set; }
        public virtual DbSet<LabsList> LabsList { get; set; }
        public virtual DbSet<MaterialsDetails> MaterialsDetails { get; set; }
        public virtual DbSet<MaterialsDetailsTests> MaterialsDetailsTests { get; set; }
        public virtual DbSet<MaterialsTypes> MaterialsTypes { get; set; }
        public virtual DbSet<MaterialTypesCustomFields> MaterialTypesCustomFields { get; set; }
        public virtual DbSet<PaymentDetails> PaymentDetails { get; set; }
        public virtual DbSet<PaymentMaster> PaymentMaster { get; set; }
        public virtual DbSet<PriceUnitList> PriceUnitList { get; set; }
        public virtual DbSet<ProjectsList> ProjectsList { get; set; }
        public virtual DbSet<ProjectsTypes> ProjectsTypes { get; set; }
        public virtual DbSet<QuotationDetails> QuotationDetails { get; set; }
        public virtual DbSet<QuotationMaster> QuotationMaster { get; set; }
        public virtual DbSet<QuotationWorkOrderList> QuotationWorkOrderList { get; set; }
        public virtual DbSet<ReportGroup> ReportGroup { get; set; }
        public virtual DbSet<RSSDetails> RSSDetails { get; set; }
        public virtual DbSet<RSSMaster> RSSMaster { get; set; }
        public virtual DbSet<SampleReceiveList> SampleReceiveList { get; set; }
        public virtual DbSet<SampleReceiveMaterialCustomField> SampleReceiveMaterialCustomField { get; set; }
        public virtual DbSet<SampleReceiveMaterialTableCustomField> SampleReceiveMaterialTableCustomField { get; set; }
        public virtual DbSet<SampleReceiveTestInvoice> SampleReceiveTestInvoice { get; set; }
        public virtual DbSet<SampleReceiveTestList> SampleReceiveTestList { get; set; }
        public virtual DbSet<SubcontractorsList> SubcontractorsList { get; set; }
        public virtual DbSet<TermsConditionList> TermsConditionList { get; set; }
        public virtual DbSet<TestContractors> TestContractors { get; set; }
        public virtual DbSet<TestEquipments> TestEquipments { get; set; }
        public virtual DbSet<TestExcelMapping> TestExcelMapping { get; set; }
        public virtual DbSet<TestItems> TestItems { get; set; }
        public virtual DbSet<TestPrices> TestPrices { get; set; }
        public virtual DbSet<TimesheetPaySlip> TimesheetPaySlip { get; set; }
        public virtual DbSet<ValidityList> ValidityList { get; set; }
        public virtual DbSet<ValidityListDetails> ValidityListDetails { get; set; }
        public virtual DbSet<WorkOrderInvoice> WorkOrderInvoice { get; set; }
        public virtual DbSet<WorkOrderList> WorkOrderList { get; set; }
        public virtual DbSet<WorkOrderTimeSheet> WorkOrderTimeSheet { get; set; }
        public virtual DbSet<ViewBendingEnquiryMaster> ViewBendingEnquiryMaster { get; set; }
        public virtual DbSet<ViewEnquiryMaster> ViewEnquiryMaster { get; set; }
        public virtual DbSet<ViewExcelCellFieldMapping> ViewExcelCellFieldMapping { get; set; }
        public virtual DbSet<ViewGelAllInvoice> ViewGelAllInvoice { get; set; }
        public virtual DbSet<ViewGetAllQuotationMasterHistory> ViewGetAllQuotationMasterHistory { get; set; }
        public virtual DbSet<ViewIdelJobOrder> ViewIdelJobOrder { get; set; }
        public virtual DbSet<ViewInvoicesBalance> ViewInvoicesBalance { get; set; }
        public virtual DbSet<ViewJobOrderList> ViewJobOrderList { get; set; }
        public virtual DbSet<ViewJobOrderMaster> ViewJobOrderMaster { get; set; }
        public virtual DbSet<ViewJobOrderPendingToInvoicer> ViewJobOrderPendingToInvoicer { get; set; }
        public virtual DbSet<ViewJobOrderTestList> ViewJobOrderTestList { get; set; }
        public virtual DbSet<ViewN_OFUnPaidBills> ViewN_OFUnPaidBills { get; set; }
        public virtual DbSet<ViewNewJobOrderMaster> ViewNewJobOrderMaster { get; set; }
        public virtual DbSet<ViewNewQuotationMaster> ViewNewQuotationMaster { get; set; }
        public virtual DbSet<ViewPendingPayment> ViewPendingPayment { get; set; }
        public virtual DbSet<ViewQuotationDetails> ViewQuotationDetails { get; set; }
        public virtual DbSet<ViewRSS> ViewRSS { get; set; }
        public virtual DbSet<ViewSampleReceiveMaterialCustomField> ViewSampleReceiveMaterialCustomField { get; set; }
        public virtual DbSet<ViewSampleReceiveTests> ViewSampleReceiveTests { get; set; }
        public virtual DbSet<ViewTestPrices> ViewTestPrices { get; set; }
        public virtual DbSet<ViewTestUnits> ViewTestUnits { get; set; }
        public virtual DbSet<ViewWorkOrderList> ViewWorkOrderList { get; set; }
        public virtual DbSet<JobOrderDetails> JobOrderDetails { get; set; }
        public virtual DbSet<TestReporting> TestReportings { get; set; }
        public virtual DbSet<ReportGroupExcelMapping> ReportGroupExcelMappings { get; set; }
        public virtual DbSet<ViewReportGroupExcelCellFieldMapping> ViewReportGroupExcelCellFieldMappings { get; set; }
        public virtual DbSet<TestsList> TestsList { get; set; }

        public virtual DbSet<PaymentAttachedFile> PaymentAttachedFiles { get; set; }
        public virtual DbSet<ViewLateReport> ViewLateReports { get; set; }
    
        [DbFunction("LabSysEntities", "fnSplit")]
        public virtual IQueryable<fnSplit_Result> fnSplit(string sInputList, string sDelimiter)
        {
            var sInputListParameter = sInputList != null ?
                new ObjectParameter("sInputList", sInputList) :
                new ObjectParameter("sInputList", typeof(string));
    
            var sDelimiterParameter = sDelimiter != null ?
                new ObjectParameter("sDelimiter", sDelimiter) :
                new ObjectParameter("sDelimiter", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<fnSplit_Result>("[LabSysEntities].[fnSplit](@sInputList, @sDelimiter)", sInputListParameter, sDelimiterParameter);
        }
    
        public virtual ObjectResult<GetSampleFieldsByID_Result> GetSampleFieldsByID(Nullable<long> sampleID)
        {
            var sampleIDParameter = sampleID.HasValue ?
                new ObjectParameter("SampleID", sampleID) :
                new ObjectParameter("SampleID", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetSampleFieldsByID_Result>("GetSampleFieldsByID", sampleIDParameter);
        }
    
        public virtual ObjectResult<SpGetAllQuotationMasterHistory_Result> SpGetAllQuotationMasterHistory(Nullable<int> userID)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SpGetAllQuotationMasterHistory_Result>("SpGetAllQuotationMasterHistory", userIDParameter);
        }
    
        public virtual ObjectResult<SPGetWorkOrderToInvoice_Result> SPGetWorkOrderToInvoice(Nullable<System.DateTime> fromDate, Nullable<System.DateTime> toDate, Nullable<long> joborderId)
        {
            var fromDateParameter = fromDate.HasValue ?
                new ObjectParameter("fromDate", fromDate) :
                new ObjectParameter("fromDate", typeof(System.DateTime));
    
            var toDateParameter = toDate.HasValue ?
                new ObjectParameter("toDate", toDate) :
                new ObjectParameter("toDate", typeof(System.DateTime));
    
            var joborderIdParameter = joborderId.HasValue ?
                new ObjectParameter("JoborderId", joborderId) :
                new ObjectParameter("JoborderId", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SPGetWorkOrderToInvoice_Result>("SPGetWorkOrderToInvoice", fromDateParameter, toDateParameter, joborderIdParameter);
        }
    
        public virtual ObjectResult<SPPendingAdvancedPayment_Result> SPPendingAdvancedPayment(Nullable<long> jobOrderMasterID)
        {
            var jobOrderMasterIDParameter = jobOrderMasterID.HasValue ?
                new ObjectParameter("JobOrderMasterID", jobOrderMasterID) :
                new ObjectParameter("JobOrderMasterID", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SPPendingAdvancedPayment_Result>("SPPendingAdvancedPayment", jobOrderMasterIDParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> SPValidateExistWorkOrderInJo(Nullable<long> fKQuotationMasterID)
        {
            var fKQuotationMasterIDParameter = fKQuotationMasterID.HasValue ?
                new ObjectParameter("FKQuotationMasterID", fKQuotationMasterID) :
                new ObjectParameter("FKQuotationMasterID", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("SPValidateExistWorkOrderInJo", fKQuotationMasterIDParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> SPValidateUnitPriceExist(Nullable<long> unitPriceID, Nullable<long> fkTestID)
        {
            var unitPriceIDParameter = unitPriceID.HasValue ?
                new ObjectParameter("UnitPriceID", unitPriceID) :
                new ObjectParameter("UnitPriceID", typeof(long));
    
            var fkTestIDParameter = fkTestID.HasValue ?
                new ObjectParameter("FkTestID", fkTestID) :
                new ObjectParameter("FkTestID", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("SPValidateUnitPriceExist", unitPriceIDParameter, fkTestIDParameter);
        }
    }
}
