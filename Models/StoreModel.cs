using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Data.Entities;

namespace WebStore.Models
{
    public class StoreModel
    {
        public int Id { get; set; }
        public StoreDescriptionModel StoreDescription { get; set; }
        public List<StoreTelephoneNumberModel> TelephoneNumbers { get; set; }
        public string Address { get; set; }
        public List<StoreHoursModel> StoreOpenedHours { get; set; }
        public List<StoreEMailModel> EMails { get; set; }
    }
}
