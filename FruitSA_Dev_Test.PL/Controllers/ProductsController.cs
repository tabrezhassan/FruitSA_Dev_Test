using Microsoft.AspNetCore.Mvc;

namespace FruitSA_Dev_Test.PL.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Products()
        {
            return View();
        }

        public IActionResult CreateProduct()
        {
            return View();
        }

        public IActionResult EditProduct()
        {
            return View();
        }
    }
}
