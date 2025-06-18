using System.ComponentModel.DataAnnotations.Schema;

namespace supply.Models
{
    public class Sale
    {
        public int SaleId { get; set; }
        public required DateTime Date { get; set; }
        public required int Amount { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public int InvoiceId { get; set; }

        [ForeignKey("CustomerId")]
        public  Customer? Customer { get; set; }

        [ForeignKey("EmployeeId")]
        public  Employee? Employee { get; set; }

        [ForeignKey("InvoiceId")]
        public Invoice? Invoice { get; set; }

    }
}
