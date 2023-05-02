using FruitSA_Dev_Test.API.Classes;
using FruitSA_Dev_Test.BLL.Services;
using FruitSA_Dev_Test.DAL.Interfaces;
using FruitSA_Dev_Test.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace FruitSA_Dev_Test.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("GetProducts")]
        public async Task<IActionResult> GetProducts()
        {
            var categories = _productService.GetAll();
            return Ok(categories);

        }

        [HttpGet]
        [Route("GetProduct/{id}")]
        public async Task<IActionResult> GetCatgeory([FromRoute] string id)
        {
            var product = _productService.GetProduct(id);
            return Ok(product);
        }

        [HttpPost]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateUpdateProduct(Product product)
        {
            if (product.ProductCode.All(c => !Char.IsLetterOrDigit(c)))
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Incorrect format for Product Code. Product Code has to be Alph Numeric (eg: ABC123)" });
            }

            var productCode = int.Parse(_productService.CheckProductCode()).ToString("0##");

            if (productCode == product.ProductCode.Substring(7, product.ProductCode.Length - 7))
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Duplicate Product Code. Product Code has to be unique" });
            }

            var code = (int.Parse(_productService.GetLastId())+1).ToString("0##");

            var productcode = DateTime.Now.ToString("yyyy") + DateTime.Now.ToString("MM") + "-" + code;



            var newproduct = new Product
            {
                ProductId = product.ProductId,
                ProductCode = productcode,
                Name = product.Name,
                Description = product.Description,
                CategoryName = product.CategoryName,
                Price = product.Price,
                Image = product.Image
        };
            await _productService.CreateCategory(newproduct);
            return Ok(newproduct);
        }




        [HttpPut]
        [Route("UpdateProduct")]
        public async Task<IActionResult> UpdateCategory([FromBody] Product product)
        {
            if (product.ProductCode.All(c => !Char.IsLetterOrDigit(c)))
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Incorrect format for Product Code. Product Code has to be Alpha Numeric (eg: ABC123)" });
            }

            var updatecategory = new Product
            {
                ProductId = product.ProductId,
                ProductCode = product.ProductCode,
                Name = product.Name,
                Description = product.Description,
                CategoryName = product.CategoryName,
                Price = product.Price,
                Image = product.Image
            };

            _productService.UpdateCategory(product);
            return Ok();
        }
    }
}
