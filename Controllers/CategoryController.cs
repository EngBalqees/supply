using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using supply.Models.Repositorie;
using supply.Models;

namespace supply.Controllers
{
    public class CategoryController : Controller
    {
        public IRepositorie<Category> categoryRep;
        public CategoryController(IRepositorie<Category> repositorie)
        {
            categoryRep = repositorie;
        }
        // GET: CategoryController
        public ActionResult Index()
        {
            var data = categoryRep.View().ToList();
            return View(data);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            var data = categoryRep.Find(id);
            return View(data);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category collection)
        {
            try
            {
                categoryRep.Add(collection);
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();

            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = categoryRep.Find(id);
            return View(data);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Category collection)
        {
            try
            {
                categoryRep.Update(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();

            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = categoryRep.Find(id);
            return View(data);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Category collection)
        {
            try
            {
                categoryRep.Delete(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();

            }
        }
    }
}
