namespace supply.Models
{
    public class InvoiceItem
    {
        public int InvoiceItemId { get; set; }
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
        public int ProductId { get; set; }
        public  Product Product { get; set; }

        public int Qty { get; set; }
        public decimal Vprice { get; set; }
        public decimal Tprice { get; set; }
      


    }

}
