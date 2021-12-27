using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Data.Entities;

namespace WebStore.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public CategoryModel Category { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }
        [StringLength(2000)]
        public string Description { get; set; }
        [Required]
        [Range(0, 100_000)]
        public int Price { get; set; }
        [Required]
        [Range(0, 500)]
        public int Amount { get; set; }
        public List<OpinionModel> Opinions { get; set; }
        public double AverageRating { get; set; }
    }
}
