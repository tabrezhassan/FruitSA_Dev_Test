using FruitSA_Dev_Test.API.Classes;
using FruitSA_Dev_Test.BLL.Services;
using FruitSA_Dev_Test.DAL.Interfaces;
using FruitSA_Dev_Test.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FruitSA_Dev_Test.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _categoryService;

        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [HttpGet]
        [Route("GetCategories")]
        public async Task<IActionResult> GetCategories()
        {
            var categories =  _categoryService.GetAll();
            return Ok (categories);

        }

        [HttpGet]
        [Route("GetCategories/{id}")]
        public async Task<IActionResult> GetCatgeory([FromRoute] string id)
        {
            var category = _categoryService.GetCategory(id);
            return Ok(category);
        }

        [HttpPut]
        [Route("CreateUpdateCategory")]
        public async Task<IActionResult> CreateUpdateCategory([FromBody] Category category)
        {
            if (category.CategoryCode.All(c => !Char.IsLetterOrDigit(c)))
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Incorrect format for Category Code. Category Code has to be Alpha Numeric (eg: ABC123)" });
            }

            var updatecategory = new Category
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
                CategoryCode = category.CategoryCode,
                IsActive = category.IsActive
            };

            if (category.CategoryId == "0")
            {
                await _categoryService.CreateCategory(category);
            }
            else
            {
                _categoryService.UpdateCategory(category);
            }
            return Ok();
        }
    }
}
