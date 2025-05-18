using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using supply.Models;
using supply.Models.Repositorie;

namespace supply.Controllers
{
    public class SupplierController : Controller
    {
        public IRepositorie<Supplier> supplierRep;
        public SupplierController(IRepositorie<Supplier> repositorie)
        {
            supplierRep = repositorie;
        }

        //GET: SupplierController
        public ActionResult Index()
        {
            var data = supplierRep.View().ToList();
            return View(data);
        }

        // GET : SupplierController/Details/id
        public ActionResult Details(int Id)
        {
            var data = supplierRep.Find(Id);
            return View(data);
        }

        //GET : SupplierController/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST : SupplierController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Supplier collection)
        {
            try
            {
                supplierRep.Add(collection);
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();

            }
        }

        //GET: SupplierController/Edit/id
        public ActionResult Edit(int Id)
        {
            var data = supplierRep.Find(Id);
            return View(data);
        }

        //POST : Supplier/Controller/Edit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int Id, Supplier collection)
        {
            try
            {
                supplierRep.Update(Id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();

            }
        }

        //GET : SupplierController/Delete/id
      public ActionResult Delete(int Id)
        {
            var data = supplierRep.Find(Id);
            return View(data);
        }

        //POST : SupplierController//Delete/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int Id, Supplier collection)
        {
            try
            {
                supplierRep.Delete(Id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();

            }
        }

    }
}
