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
    
    public partial class RSSDetails
    {
        public long RSSDteailsId { get; set; }
        public long FkRSSMasterId { get; set; }
        public Nullable<int> FkTestId { get; set; }
    
        public virtual RSSMaster RSSMaster { get; set; }
        public virtual TestsList TestsList { get; set; }
    }
}
