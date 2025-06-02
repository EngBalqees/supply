namespace supply.Models
{
    public class Customer
    {

        public int CustomerId { get; set; }
        public required string Name { get; set; }
        public required string Address { get; set; }
        public required string phone { get; set; }
        public required string email { get; set; }
    }
}
