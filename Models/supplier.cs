using System.Diagnostics.CodeAnalysis;

namespace supply.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string ContactPerson { get; set; }
        public required string Address { get; set; }
        public required string phone { get; set; }
        public required string email { get; set; }
    }
}