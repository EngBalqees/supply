using Microsoft.AspNetCore.Mvc;
using supply.Models.Repositorie;
using supply.Models;
using supply.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace supply.Controllers
{
    public class SaleController : Controller
    {
        private readonly IRepositorie<Sale> saleRep;
        private readonly IRepositorie<Customer> customerRep;
        private readonly IRepositorie<Employee> employeeRepo;
        private readonly IRepositorie<Invoice> invoiceRepo;

        public SaleController(
            IRepositorie<Sale> saleRepositorie,
            IRepositorie<Customer> customerRepositorie,
            IRepositorie<Employee> employeeRepositorie,
            IRepositorie<Invoice> invoiceRepositorie)
        {
            saleRep = saleRepositorie;
            customerRep = customerRepositorie;
            employeeRepo = employeeRepositorie;
            invoiceRepo = invoiceRepositorie;
        }

        // GET: SaleController
        public ActionResult Index()
        {
            var data = saleRep.View().ToList();
            return View(data);
        }

        // GET: SaleController/Details/5
        public ActionResult Details(int? id)
        {
            var data = (saleRep as dbSaleRepos)?.GetDetails(id);
            if (data == null) return NotFound();
            return View(data);
        }

        // GET: SaleController/Create
        public ActionResult Create()
        {
            var viewModel = new VmSaleProCusInvo
            {
                ListCustomer = customerRep.View().ToList(),
                ListEmployee = employeeRepo.View().ToList(),
                ListInvoice = invoiceRepo.View().ToList()
            };
            return View(viewModel);
        }

        // POST: SaleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VmSaleProCusInvo vm)
        {
            if (!ModelState.IsValid)
            {
                vm.ListCustomer = customerRep.View().ToList();
                vm.ListEmployee = employeeRepo.View().ToList();
                vm.ListInvoice = invoiceRepo.View().ToList();
                return View(vm);
            }

            var sale = new Sale
            {
                Date = vm.Date,
                Amount = vm.Amount,
                CustomerId = vm.CustomerId,
                EmployeeId = vm.EmployeeId,
                InvoiceId = vm.InvoiceId
            };

            saleRep.Add(sale);
            return RedirectToAction(nameof(Index));
        }

        // GET: SaleController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = saleRep.Find(id);
            if (data == null) return NotFound();

            var vm = new VmSaleProCusInvo
            {
                SaleId = data.SaleId,
                Date = data.Date,
                Amount = data.Amount,
                CustomerId = data.CustomerId,
                EmployeeId = data.EmployeeId,
                InvoiceId = data.InvoiceId,
                ListCustomer = customerRep.View().ToList(),
                ListEmployee = employeeRepo.View().ToList(),
                ListInvoice = invoiceRepo.View().ToList()
            };

            return View(vm);
        }

        // POST: SaleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, VmSaleProCusInvo vm)
        {
            if (!ModelState.IsValid)
            {
                vm.ListCustomer = customerRep.View().ToList();
                vm.ListEmployee = employeeRepo.View().ToList();
                vm.ListInvoice = invoiceRepo.View().ToList();
                return View(vm);
            }

            var updatedSale = new Sale
            {
                SaleId = vm.SaleId,
                Date = vm.Date,
                Amount = vm.Amount,
                CustomerId = vm.CustomerId,
                EmployeeId = vm.EmployeeId,
                InvoiceId = vm.InvoiceId
            };

            saleRep.Update(id, updatedSale);
            return RedirectToAction(nameof(Index));
        }

        // GET: SaleController/Delete/5
        public ActionResult Delete(int? id)
        {
            var sale = (saleRep as dbSaleRepos)?.GetDetails(id);
            if (sale == null) return NotFound();
            return View(sale);
        }

        // POST: SaleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Sale collection)
        {
            try
            {
                saleRep.Delete(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
