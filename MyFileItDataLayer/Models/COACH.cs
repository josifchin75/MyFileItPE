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
    
    public partial class COACH
    {
        public int ID { get; set; }
        public Nullable<int> APPUSERID { get; set; }
        public string ADDRESS1 { get; set; }
        public string ADDRESS2 { get; set; }
        public string CITY { get; set; }
        public string STATECODE { get; set; }
        public string ZIPCODE { get; set; }
        public string PHONE { get; set; }
        public string EMAILADDRESS { get; set; }
        public string SEX { get; set; }
        public Nullable<int> YEARCODE { get; set; }
        public Nullable<int> SPORTTYPEID { get; set; }
        public Nullable<int> RELATIONSHIPTYPEID { get; set; }
        public Nullable<int> COACHSTATUSID { get; set; }
        public Nullable<System.DateTime> DATECREATED { get; set; }
        public string FIRSTNAME { get; set; }
        public string LASTNAME { get; set; }
        public Nullable<int> ORGANIZATIONID { get; set; }
        public Nullable<int> TEAMEVENTID { get; set; }
    
        public virtual SPORTTYPE SPORTTYPE { get; set; }
        public virtual RELATIONSHIPTYPE RELATIONSHIPTYPE { get; set; }
        public virtual ORGANIZATION ORGANIZATION { get; set; }
        public virtual COACHSTATU COACHSTATU { get; set; }
        public virtual COACHSTATU COACHSTATU1 { get; set; }
        public virtual COACHSTATU COACHSTATU2 { get; set; }
        public virtual TEAMEVENT TEAMEVENT { get; set; }
    }
}
