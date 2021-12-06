using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Data.Entities
{
    public class Opinion
    {
        public int Id { get; set; }
        //public Product Product { get; set; }
        public string Content { get; set; }
        public int Value { get; set; }
        public User Critic { get; set; }
    }
}
