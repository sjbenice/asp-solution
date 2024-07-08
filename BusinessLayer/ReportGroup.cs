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
    
    public partial class ReportGroup
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ReportGroup()
        {
            this.ReportGroupExcelMappings = new HashSet<ReportGroupExcelMapping>();
            this.MaterialsDetailsTests = new HashSet<MaterialsDetailsTests>();
            this.TestsLists = new HashSet<TestsList>();
        }
    
        public int GroupID { get; set; }
        public string GroupName { get; set; }
        public string GroupNumber { get; set; }
        public string GroupDescription { get; set; }
        public Nullable<int> FKMaterialTypeID { get; set; }
        public string WorkFormFileName { get; set; }
        public string WorkFormWorksheet { get; set; }
        public string ReportFileName { get; set; }
        public string ReportWorksheet { get; set; }
    
        public virtual MaterialsTypes MaterialsType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReportGroupExcelMapping> ReportGroupExcelMappings { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MaterialsDetailsTests> MaterialsDetailsTests { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TestsList> TestsLists { get; set; }
    }
}
