namespace supply.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public required string Name { get; set; }
        public  int QtyStock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }

        public  Category? Category { get; set; }

        public  Supplier? Supplier { get; set; }
         public ICollection<InvoiceItem> invoiceItems { get; set; }
    }
}
