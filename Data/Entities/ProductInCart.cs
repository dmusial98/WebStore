namespace WebStore.Data.Entities
{
    public class ProductInCart
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int Count { get; set; }
        public bool IsPaid { get; set; }
    }
}
