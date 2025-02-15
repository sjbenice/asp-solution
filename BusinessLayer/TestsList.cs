//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class TestsList
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TestsList()
        {
            this.EnquiryDetails = new HashSet<EnquiryDetails>();
            this.JobOrderDetails = new HashSet<JobOrderDetails>();
            this.MaterialsDetailsTests = new HashSet<MaterialsDetailsTests>();
            this.QuotationDetails = new HashSet<QuotationDetails>();
            this.RSSDetails = new HashSet<RSSDetails>();
            this.SampleReceiveTestLists = new HashSet<SampleReceiveTestList>();
            this.TestContractors = new HashSet<TestContractors>();
            this.TestEquipments = new HashSet<TestEquipments>();
            this.TestExcelMappings = new HashSet<TestExcelMapping>();
            this.TestItems = new HashSet<TestItems>();
            this.TestPrices = new HashSet<TestPrices>();
        }
    
        public int TestID { get; set; }
        public string StandardNumber { get; set; }
        public string AshghalTestNumber { get; set; }
        public string TestName { get; set; }
        public string TestDescription { get; set; }
        public string ShortName { get; set; }
        public int FKAccreditionID { get; set; }
        public int FKLabID { get; set; }
        public string ResultUnit { get; set; }
        public string ResultSpecs { get; set; }
        public string SamplingMethod { get; set; }
        public string WorkFormFileName { get; set; }
        public string WorkFormWorksheet { get; set; }
        public string ReportFileName { get; set; }
        public string ReportWorksheet { get; set; }
        public Nullable<decimal> DefaultPrice { get; set; }
        public Nullable<decimal> MinimumPrice { get; set; }
        public bool IsLocked { get; set; }
        public bool IsSubcontractedTest { get; set; }
        public bool IsSiteTest { get; set; }
        public Nullable<int> FKTestID { get; set; }
        public bool IsUnavailable { get; set; }
        public Nullable<int> FkGroupId { get; set; }
        public string Image { get; set; }
        public Nullable<int> TestRequiredTime { get; set; }
        public Nullable<bool> IsReporting { get; set; }
        public string Remarks { get; set; }
    
        public virtual AccreditionList AccreditionList { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EnquiryDetails> EnquiryDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JobOrderDetails> JobOrderDetails { get; set; }
        public virtual LabsList LabsList { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MaterialsDetailsTests> MaterialsDetailsTests { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuotationDetails> QuotationDetails { get; set; }
        public virtual ReportGroup ReportGroup { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RSSDetails> RSSDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SampleReceiveTestList> SampleReceiveTestLists { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TestContractors> TestContractors { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TestEquipments> TestEquipments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TestExcelMapping> TestExcelMappings { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TestItems> TestItems { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TestPrices> TestPrices { get; set; }
    }
}
