using FruitSA_Dev_Test.DAL.Models;
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
            var categoryList = new Category
            {

            };

            
            return View();
        }

        public IActionResult UpdateProduct(string id ="")
        {
            var product = new Product
            {
                ProductId = id
            };
            return View(product);
        }

       
    }
}
