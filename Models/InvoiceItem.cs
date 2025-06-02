namespace supply.Models
{
    public class InvoiceItem
    {
        public int InvoiceItemId { get; set; }
        public int InvoiceNumber{ get; set; }
        public int Qty { get; set; }
        public decimal Vprice { get; set; }
        public decimal Tprice { get; set; }
        public int ProductId { get; set; }
        public required Product Product { get; set; }


    }

}
