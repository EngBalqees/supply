using supply.Models;

namespace supply.ViewModels
{
    public class VmSaleProCusInvo
    {
        public int SaleId { get; set; }
        public  DateTime Date { get; set; }
        public  int Amount { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public int InvoiceItemId { get; set; }
        public  Customer Customer { get; set; }
        public List<Customer> ListCustomer { get; set; }
        public  Employee Employee { get; set; }
        public List<Employee> ListEmployee { get; set; }

        public  InvoiceItem InvoiceItem { get; set; }
        public List<InvoiceItem> ListInvoiceItem { get; set; }

    }
}
