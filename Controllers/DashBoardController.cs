using Microsoft.AspNetCore.Mvc;

namespace supply.Controllers
{
    public class DashBoardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
