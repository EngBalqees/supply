using supply.Models;

namespace supply.ViewModels
{
    public class VmInvoiceProduct
    {
        public int InvoiceItemId { get; set; }
        public int InvoiceNumber { get; set; }
        public int Qty { get; set; }
        public decimal Vprice { get; set; }
        public decimal Tprice { get; set; }
        public int ProductId { get; set; }
        public  Product Product { get; set; }
        public List<Product> ListProduct { get; set; }

    }
}
