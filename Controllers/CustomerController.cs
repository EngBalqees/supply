using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using supply.Models.Repositorie;
using supply.Models;

namespace supply.Controllers
{
    public class CustomerController : Controller
    {
        public IRepositorie<Customer> customerRep;
        public CustomerController(IRepositorie<Customer> repositorie)
        {
            customerRep = repositorie;
        }
        // GET: CustomerController
        public ActionResult Index()
        {
            var data = customerRep.View().ToList();
            return View(data);
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            var data = customerRep.Find(id);
            return View(data);
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer collection)
        {
            try
            {
                customerRep.Add(collection);
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();

            }
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = customerRep.Find(id);
            return View(data);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Customer collection)
        {
            try
            {
                customerRep.Update(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();

            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = customerRep.Find(id);
            return View(data);
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Customer collection)
        {
            try
            {
                customerRep.Delete(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();

            }
        }
    }
}
