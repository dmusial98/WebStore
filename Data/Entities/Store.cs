using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace WebStore.Data.Entities
{
    public class Store
    {
        public int Id { get; set; }
        public StoreDescription StoreDescription { get; set; }
        public List<StoreTelephoneNumber> TelephoneNumbers { get; set; }
        public string Address { get; set; }
        public List<StoreHours> StoreOpenedHours { get; set; }
        public List<StoreEMail> EMails { get; set; }
    }
}
