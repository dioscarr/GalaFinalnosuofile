//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class FCRelation
    {
        public int Id { get; set; }
        public int FirmID { get; set; }
        public int CountryID { get; set; }
        public Nullable<System.DateTime> Created_ { get; set; }
        public Nullable<System.DateTime> Modified { get; set; }
        public Nullable<bool> isDeleted { get; set; }
    
        public virtual Country Country { get; set; }
        public virtual Firm Firm { get; set; }
    }
}
