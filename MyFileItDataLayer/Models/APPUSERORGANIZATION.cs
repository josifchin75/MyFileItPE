//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyFileItDataLayer.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class APPUSERORGANIZATION
    {
        public int ID { get; set; }
        public int ORGANIZATIONID { get; set; }
        public int APPUSERID { get; set; }
        public Nullable<System.DateTime> STARTDATE { get; set; }
        public Nullable<System.DateTime> EXPIRESDATE { get; set; }
        public Nullable<int> YEARCODE { get; set; }
        public int SPORTTYPEID { get; set; }
        public Nullable<System.DateTime> DATECREATED { get; set; }
        public Nullable<int> APPUSERTYPEID { get; set; }
    
        public virtual SPORTTYPE SPORTTYPE { get; set; }
        public virtual ORGANIZATION ORGANIZATION { get; set; }
        public virtual APPUSER APPUSER { get; set; }
        public virtual APPUSER APPUSER1 { get; set; }
    }
}
