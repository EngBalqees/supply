using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using supply.Models.Repositorie;
using supply.Models;
using supply.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace supply.Controllers
{
    public class SaleController : Controller
    {
        public IRepositorie<Sale> saleRep;
        IRepositorie<Customer> customerRep;
        IRepositorie<Employee> employeeRepo;
        IRepositorie<InvoiceItem> invoiceItemRepo;

        public SaleController(IRepositorie<Sale> repositorie
            ,IRepositorie<Customer> customerRepositorie
            , IRepositorie<Employee> employeeRepositorie
            , IRepositorie<InvoiceItem> invoiceItemRepositorie)
        {
            saleRep = repositorie;
            customerRep = customerRepositorie;
            employeeRepo = employeeRepositorie;
            invoiceItemRepo = invoiceItemRepositorie;
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
            var obj = new VmSaleProCusInvo
            {
                ListCustomer = customerRep.View().ToList(),
                ListEmployee = employeeRepo.View().ToList(),
                ListInvoiceItem = invoiceItemRepo.View().ToList()

            };
            return View(obj);
        }

        // POST: SaleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Sale collection)
        {
            try
            {
                saleRep.Add(collection);
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();

            }
        }

        // GET: SaleController/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null) return NotFound();
            var data = saleRep.Find(id);
            if (id == null) return NotFound();
            var vm = new VmSaleProCusInvo
            {
                SaleId = data.SaleId,
                Date = data.Date,
                Amount = data.Amount,
                ListCustomer = customerRep.View().ToList(),
                ListEmployee  = employeeRepo.View().ToList(),
                ListInvoiceItem = invoiceItemRepo.View().ToList()
            };
            return View(vm);


        }

        // POST: SaleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Sale collection)
        {
            try
            {
                saleRep.Update(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();

            }
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
