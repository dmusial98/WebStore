using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Data.Entities
{
    public class StoreEMail
    {
        public int Id { get; set; }
        //public Store Store { get; set; }
        public int StoreId { get; set; }
        public string EmailContent { get; set; }
    }
}
