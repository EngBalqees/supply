using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using supply.Models;

namespace supply.ViewModels
{
    public class VmSaleProCusInvo
    {
        public int SaleId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Amount must be greater than zero")]
        public int Amount { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public int InvoiceId { get; set; }


        public List<Customer> ListCustomer { get; set; } = new();


        public List<Employee> ListEmployee { get; set; } = new();

 
        public List<Invoice> ListInvoice { get; set; } = new(); 
    }
}
