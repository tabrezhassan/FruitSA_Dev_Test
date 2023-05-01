using FruitSA_Dev_Test.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FruitSA_Dev_Test.PL.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Categories()
        {
            return View();
        }

        //[Authorize]
        public IActionResult CreateUpdateCategory(string id="")
        {
            var category = new Category
            {
                CategoryId = id
            };
            return View(category);
        }

    }

}

