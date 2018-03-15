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
    
    public partial class Car
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Car()
        {
            this.Cars_DefEquip = new HashSet<Cars_DefEquip>();
            this.Cars_Equip = new HashSet<Cars_Equip>();
            this.Cars_Feat = new HashSet<Cars_Feat>();
            this.Cars_PIckupFeat = new HashSet<Cars_PIckupFeat>();
        }
    
        public int id { get; set; }
        public string car_Name { get; set; }
        public int car_Price { get; set; }
        public string car_Location { get; set; }
        public string owner_Email { get; set; }
        public int owner_Number { get; set; }
        public System.DateTime car_PickUpTime { get; set; }
        public System.DateTime car_DropOffTime { get; set; }
        public string car_PickUpPlace { get; set; }
        public string car_DropOffPlace { get; set; }
        public string car_Description { get; set; }
        public int car_grop_id { get; set; }
        public int car_pickup_id { get; set; }
        public int car_trans_id { get; set; }
        public int car_engine_id { get; set; }
        public int passabgers_num { get; set; }
        public int car_door_num { get; set; }
        public int car_baggage_quantity { get; set; }
        public string car_photo { get; set; }
    
        public virtual Car_pickup_Option Car_pickup_Option { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cars_DefEquip> Cars_DefEquip { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cars_Equip> Cars_Equip { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cars_Feat> Cars_Feat { get; set; }
        public virtual Cars_group Cars_group { get; set; }
        public virtual Cars_trans Cars_trans { get; set; }
        public virtual Engine Engine { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cars_PIckupFeat> Cars_PIckupFeat { get; set; }
    }
}
