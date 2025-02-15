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
    
    public partial class JobOrderDetails
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public JobOrderDetails()
        {
            this.WorkOrderList = new HashSet<WorkOrderList>();
        }
    
        public long JobOrderDetailsID { get; set; }
        public long FKJobOrderMasterID { get; set; }
        public int FKTestID { get; set; }
        public int FKPriceUnitID { get; set; }
        public Nullable<long> FKQuotationDetailsID { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> MinQty { get; set; }
        public Nullable<System.DateTime> ExpiryDate { get; set; }
        public string Remarks { get; set; }
        public bool Inactive { get; set; }
        public Nullable<int> FKMaterialTypeID { get; set; }
        public Nullable<int> FKMaterialDetailsID { get; set; }
        public bool IsEnable { get; set; }
    
        public virtual JobOrderMaster JobOrderMaster { get; set; }
        public virtual MaterialsDetails MaterialsDetails { get; set; }
        public virtual MaterialsTypes MaterialsTypes { get; set; }
        public virtual PriceUnitList PriceUnitList { get; set; }
        public virtual QuotationDetails QuotationDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkOrderList> WorkOrderList { get; set; }
        public virtual TestsList TestsList { get; set; }
    }
}
