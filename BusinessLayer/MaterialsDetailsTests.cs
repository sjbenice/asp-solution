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
    
    public partial class MaterialsDetailsTests
    {
        public int MaterialTestID { get; set; }
        public int FKMaterialDetailsID { get; set; }
        public int FKTestID { get; set; }
        public Nullable<int> FKGroupID { get; set; }
    
        public virtual MaterialsDetails MaterialsDetails { get; set; }
        public virtual ReportGroup ReportGroup { get; set; }
        public virtual TestsList TestsList { get; set; }
    }
}
