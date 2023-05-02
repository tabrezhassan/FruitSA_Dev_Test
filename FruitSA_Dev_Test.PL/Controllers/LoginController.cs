using Microsoft.AspNetCore.Mvc;

namespace FruitSA_Dev_Test.PL.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
    }
}
