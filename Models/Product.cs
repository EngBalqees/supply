namespace supply.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public required string Name { get; set; }
        public required int QtyStock { get; set; }
        public required decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }

        public required Category Category { get; set; }

        public required Supplier Supplier { get; set; }

    }
}
