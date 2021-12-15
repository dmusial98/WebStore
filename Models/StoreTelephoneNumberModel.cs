using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Models
{
    public class StoreTelephoneNumberModel
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public string TelephoneNumberContent { get; set; }
    }
}
