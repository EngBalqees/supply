using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using supply.Models.Repositorie;
using supply.Models;
using supply.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace supply.Controllers
{
    public class ProductController : Controller
    {
        IRepositorie<Product> productRep;
        IRepositorie<Category> categoryRep;
        IRepositorie<Supplier> supplierRepo;

        public ProductController(IRepositorie<Product> prorepositorie
            , IRepositorie<Category> categoryRepositorie,
             IRepositorie<Supplier> supplierRepositorie)
        {
            productRep = prorepositorie;
            categoryRep = categoryRepositorie;
            supplierRepo = supplierRepositorie;


        }
        // GET: ProductController
        public ActionResult Index()
        {
            var data = productRep.View().ToList();
            return View(data);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var data = (productRep as dbProductRepos)?.GetDetails(id);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            var obj = new VmProductCateSupp
            {
                ListCategory = categoryRep.View().ToList(),
                ListSupplier = supplierRepo.View().ToList()
            };
            return View(obj);
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product collection)
        {
            try
            {
                productRep.Add(collection);
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();

            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            
            
            var data = productRep.Find(id);
            if (data == null)
            {
                return NotFound();
            }
            ViewBag.CategoryList = new SelectList(categoryRep.View().ToList(), "CategoryId", "Name");
            ViewBag.SupplierList = new SelectList(supplierRepo.View().ToList(), "SupplierId", "Name");
            return View(data);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product collection)
        {
            try
            {
                productRep.Update(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();

            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int? id)
        {
            var data = productRep.Find(id.Value);
            if (data == null) return NotFound();
            return View(data);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Product collection)
        {
            try
            {
            
                productRep.Delete(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();

            }
        }
    }
}
