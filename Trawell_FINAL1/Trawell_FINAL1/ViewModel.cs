using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trawell_FINAL1.Models;

namespace Trawell_FINAL1
{
    public class ViewModel
    {
        
        public IEnumerable<About>  abouts { get; set; }
        public IEnumerable<Activity>  activities { get; set; }
        public IEnumerable<Activity_ActivityItems>  activity_activityitems { get; set; }
        public IEnumerable<Activity_Attract>  Activity_Attracts { get; set; }
        public IEnumerable<Activity_items>  Activity_itemss { get; set; }
        public IEnumerable<Activity_Nightlife>  Activity_Nightlifes { get; set; }
        public IEnumerable<Activity_photo>  Activity_photos { get; set; }
        public IEnumerable<Admin_Info>  Admin_Infos { get; set; }
        public IEnumerable<Amenty>  Amentys { get; set; }

        public IEnumerable<Attraction>  Attraction { get; set; }
        public IEnumerable<Bedroom> Bedrooms { get; set; }
        public IEnumerable<Car_pickup_Option> Car_pickup_Option { get; set; }
        public IEnumerable<Cars_DefEquip> Cars_DefEquips { get; set; }
        public IEnumerable<Cars_Equip> Cars_Equips { get; set; }
        public IEnumerable<Cars_Feat> Cars_Feats { get; set; }
        public IEnumerable<Cars_group> Cars_group { get; set; }
        public IEnumerable<Cars_PIckupFeat> Cars_PIckupFeats { get; set; }
        public IEnumerable<Cars_trans> Cars_transs { get; set; }

        public IEnumerable<Car> Cars { get; set; }
        public IEnumerable<Contact> Contacts { get; set; }
        public IEnumerable<Default_Equipment> Default_Equipments { get; set; }
        public IEnumerable<Engine> Enginess { get; set; }
        public IEnumerable<Equipment> Equipments { get; set; }
        public IEnumerable<Feature> Features { get; set; }
        public IEnumerable<Nightlife> Nightlifes { get; set; }
        public IEnumerable<PickUp_Features> PickUp_Featuress { get; set; }
        public IEnumerable<Rent_Ament> Rent_Aments { get; set; }

        public IEnumerable<Rent_Suit> Rent_Suits { get; set; }
        public IEnumerable<Rental_Photo> Rental_Photos { get; set; }
        public IEnumerable<Rental> Rentals { get; set; }
        public IEnumerable<Site_settings> Site_settingss { get; set; }
        public IEnumerable<Slider> Sliders { get; set; }
        public IEnumerable<Slogan> Slogans { get; set; }
        public IEnumerable<Subscriber> Subscribers { get; set; }
        public IEnumerable<Suitability> Suitabilitys { get; set; }
      


    }
}