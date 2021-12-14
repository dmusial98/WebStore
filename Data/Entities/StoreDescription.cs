using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Data.Entities
{
    public class StoreDescription
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public string DescriptionText { get; set; }
    }
}
