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
    
    public partial class SampleReceiveMaterialCustomField
    {
        public long SampleReceiveCFLinkID { get; set; }
        public long FkSampleID { get; set; }
        public int FkCustomFieldID { get; set; }
        public string Value { get; set; }
    
        public virtual MaterialTypesCustomFields MaterialTypesCustomFields { get; set; }
        public virtual SampleReceiveList SampleReceiveList { get; set; }
    }
}
