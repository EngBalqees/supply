using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using supply.Models.Repositorie;
using supply.Models;
using supply.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace supply.Controllers
{
    public class InvoiceItemController : Controller
    {
        IRepositorie<InvoiceItem> invoiceRep;
        IRepositorie<Product> productRepo;


        public InvoiceItemController(IRepositorie<InvoiceItem> repositorie,
            IRepositorie<Product> productRepositorie)
        {
            invoiceRep = repositorie;
            productRepo = productRepositorie;

        }
        // GET: InvoiceItemController
        public ActionResult Index()
        {
            var data = invoiceRep.View().ToList();
            return View(data);
        }

        // GET: InvoiceItemController/Details/5
        public ActionResult Details(int? id)
        {
            var data = (invoiceRep as dbInvoiceItemRepos)?.GetDetails(id);
            if (data == null) return NotFound();
            return View(data);
        }

        // GET: InvoiceItemController/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: InvoiceItemController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InvoiceItem collection)
        {
            try
            {
                invoiceRep.Add(collection);
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();

            }
        }

        // GET: InvoiceItemController/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null) return NotFound();

            var item = invoiceRep.Find(id);
            
            return View(id);
        }

        // POST: InvoiceItemController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, InvoiceItem collection)
        {
            try
            {
                invoiceRep.Update(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();

            }
        }

        // GET: InvoiceItemController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            var data = invoiceRep.Find(id.Value);
            return View(data);

        }

        // POST: InvoiceItemController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, InvoiceItem collection)
        {
            try
            {
                invoiceRep.Delete(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();

            }
        }
    }
}
