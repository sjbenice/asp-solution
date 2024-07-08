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
    
    public partial class PaymentMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PaymentMaster()
        {
            this.PaymentDetails = new HashSet<PaymentDetails>();
        }
    
        public long PaymentID { get; set; }
        public System.DateTime PaymentDate { get; set; }
        public long ReferenceNumber { get; set; }
        public Nullable<int> FKCustomerID { get; set; }
        public int PaymentType { get; set; }
        public decimal PaymentAmount { get; set; }
        public string Remarks { get; set; }
        public bool IsRemoved { get; set; }
        public bool IsApproved { get; set; }
        public Nullable<long> FKJobOrderMasterID { get; set; }
        public string ReceivedBy { get; set; }
        public string ChequeNo { get; set; }
        public Nullable<System.DateTime> ChequeDate { get; set; }
        public string BankName { get; set; }
        public string BookCRVNumber { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public string ReasonForDelete { get; set; }
        public string ApprovedBy { get; set; }
    
        public virtual CustomersList CustomersList { get; set; }
        public virtual JobOrderMaster JobOrderMaster { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PaymentDetails> PaymentDetails { get; set; }
    }
}
