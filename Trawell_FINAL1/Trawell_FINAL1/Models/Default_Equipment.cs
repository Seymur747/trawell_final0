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
    
    public partial class Default_Equipment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Default_Equipment()
        {
            this.Cars_DefEquip = new HashSet<Cars_DefEquip>();
        }
    
        public int id { get; set; }
        public string def_name { get; set; }
        public string def_icon { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cars_DefEquip> Cars_DefEquip { get; set; }
    }
}
