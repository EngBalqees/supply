using supply.Models;
using supply.ViewModels;

namespace supply.ViewModels
{
    public class VmInvoiceModel
    {
        public Invoice Invoice { get; set; } = new Invoice();
        public List<VmInvoiceProduct> InvoiceItems { get; set; } = new ();
        public List<Product> ProductList { get; set; } = new ();
    }
}
