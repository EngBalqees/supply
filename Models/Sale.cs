namespace supply.Models
{
    public class Sale
    {
        public int SaleId { get; set; }
        public required DateTime Date { get; set; }
        public required int Amount { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public int InvoiceItemId { get; set; }
        public required Customer? Customer { get; set; }

        public required Employee? Employee { get; set; }

        public required InvoiceItem? InvoiceItem { get; set; }

    }
}
