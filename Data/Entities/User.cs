using System;
using System.Collections.Generic;

namespace WebStore.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public bool IsAdmin { get; set; }
        public string Login { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public List<ProductInCart> ProductsInCart { get; set; }
    }
}
