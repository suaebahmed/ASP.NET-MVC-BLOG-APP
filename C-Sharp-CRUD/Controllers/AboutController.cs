using Microsoft.AspNetCore.Mvc;

namespace C_Sharp_CRUD.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
