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
    
    public partial class RoleLinkOptionView
    {
        public int RoleID { get; set; }
        public string Code { get; set; }
        public string RoleAName { get; set; }
        public string RoleEName { get; set; }
        public int FKModuleID { get; set; }
        public int LinksID { get; set; }
        public string LinksAName { get; set; }
        public string LinksEName { get; set; }
        public string Url { get; set; }
        public string LinkIcon { get; set; }
        public bool ActiveLink { get; set; }
        public bool MenuLink { get; set; }
        public int FKLinkCategoryID { get; set; }
        public int Expr1 { get; set; }
        public int RoleLinkID { get; set; }
        public Nullable<int> Arrange { get; set; }
        public long RoleLinkOptionID { get; set; }
        public int OptionID { get; set; }
        public string OptionAName { get; set; }
        public string OptionEName { get; set; }
    }
}
