//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Trawell_FINAL1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Activity_Nightlife
    {
        public int id { get; set; }
        public int activ_id { get; set; }
        public int nightlife_id { get; set; }
    
        public virtual Activity Activity { get; set; }
        public virtual Nightlife Nightlife { get; set; }
    }
}
