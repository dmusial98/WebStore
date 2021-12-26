using System.Collections.Generic;

namespace WebStore.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Currency { get; set; }
        public int Amount { get; set; }
        public List<Opinion> Opinions { get; set; }
        public double AverageRating { get; set; }
    }
}
