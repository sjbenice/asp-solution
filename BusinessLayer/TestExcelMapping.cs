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
    
    public partial class TestExcelMapping
    {
        public int TestColMapID { get; set; }
        public int FKTestID { get; set; }
        public bool IsForReport { get; set; }
        public string FieldName { get; set; }
        public string ExcelCell { get; set; }
    
        public virtual TestsList TestsList { get; set; }
    }
}
