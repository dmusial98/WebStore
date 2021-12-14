namespace WebStore.Data.Entities
{
    public class Opinion
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int Value { get; set; }
        public User Critic { get; set; }
    }
}
