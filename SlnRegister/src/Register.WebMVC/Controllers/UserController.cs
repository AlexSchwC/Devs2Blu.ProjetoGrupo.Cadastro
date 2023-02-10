using Microsoft.AspNetCore.Mvc;

namespace Register.WebMVC.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
