using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
