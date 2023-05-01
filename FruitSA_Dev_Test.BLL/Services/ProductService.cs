using FruitSA_Dev_Test.DAL.Models;
using FruitSA_Dev_Test.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitSA_Dev_Test.BLL.Services
{
    public class ProductService
    {
        public readonly ProductRepository _repository;

        public ProductService(ProductRepository repository)
        {
            _repository = repository;
        }

        //Create Method
        public async Task<Product> CreateCategory(Product product)
        {
            try
            {
                if (product == null)
                {
                    throw new ArgumentNullException(nameof(product));
                }
                else
                {
                    return await _repository.Create(product);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Update Method
        public void UpdateCategory(Product product)
        {
            try
            {
                if (product != null)
                {
                    _repository.Update(product);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Get List of Catgories
        public IEnumerable<Product> GetAll()
        {
            try
            {
                return _repository.GetAll().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string GetLastId()
        {
            try

            {
                if (_repository.GetAll().Any())
                {
                    var productCode =  _repository.GetAll().ToList().OrderByDescending(p => p.ProductCode).FirstOrDefault().ProductCode;
                    return productCode.Substring(7, productCode.Length - 7);
                }
                return "000";
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string CheckProductCode()
        {
            try

            {
                if (_repository.GetAll().Any())
                {
                    var productCode = _repository.GetAll().ToList().OrderByDescending(p => p.ProductCode).FirstOrDefault().ProductCode;
                    return productCode.Substring(7, productCode.Length - 7);
                }
                return "";
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Get Category By ID
        public Product GetProduct(string id)
        {
            try
            {
                var product = _repository.GetAll().Where(product => product.ProductId == id).FirstOrDefault();
                if (product != null)
                {
                    return (Product)product;
                }

                return new Product();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
