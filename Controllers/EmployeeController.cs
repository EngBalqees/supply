using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using supply.Models.Repositorie;
using supply.Models;

namespace supply.Controllers
{
    public class EmployeeController : Controller
    {
        public IRepositorie<Employee> empRep;
        public EmployeeController(IRepositorie<Employee> repositorie)
        {
            empRep = repositorie;
        }
        // GET: EmployeeController
        public ActionResult Index()
        {
            var data = empRep.View().ToList();
            return View(data);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            var data = empRep.Find(id);
            return View(data);
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee collection)
        {
            try
            {
                empRep.Add(collection);
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();

            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {

            var data = empRep.Find(id);
            return View(data);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employee collection)
        {
            try
            {
                empRep.Update(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();

            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = empRep.Find(id);
            return View(data);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Employee collection)
        {
            try
            {
                empRep.Delete(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();

            }
        }
    }
}
