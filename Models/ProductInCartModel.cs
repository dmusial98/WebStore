using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Models
{
    public class ProductInCartModel
    {
        public int Id { get; set; }
        public ProductModel Product { get; set; }
        public int Count { get; set; }
        public bool IsPaid { get; set; }
    }
}
