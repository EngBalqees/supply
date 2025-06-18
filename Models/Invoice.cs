namespace supply.Models
{
    public class Invoice
    {

        public int InvoiceId { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }

        public ICollection<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();
        public decimal TotalAmount { get; set; }

    }
}
