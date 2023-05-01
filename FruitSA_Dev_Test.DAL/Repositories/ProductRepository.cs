using FruitSA_Dev_Test.DAL.Data;
using FruitSA_Dev_Test.DAL.Interfaces;
using FruitSA_Dev_Test.DAL.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitSA_Dev_Test.DAL.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly AppDbContext _appDbContext;

        public ProductRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public async Task<Product> Create(Product product)
        {
            try
            {
                if (product != null)
                {
                   
                    var newproduct = _appDbContext.Add<Product>(product);
                    await _appDbContext.SaveChangesAsync();
                    return newproduct.Entity;
                }
                else
                {
                    return new Product();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(Product product)
        {

            try
            {
                if (product != null)
                {
                    var currentcategory = _appDbContext.Remove<Product>(product);
                    if (currentcategory != null)
                    {
                        _appDbContext.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Product> GetAll()
        {
            try
            {
                var product = _appDbContext.Products.ToList();
                if (product != null)
                {
                    return product;
                }
                else
                {
                    return Enumerable.Empty<Product>();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Product GetById(string id)
        {
            throw new NotImplementedException();
        }

        //public Product GetById(string id)
        //{
        //    try
        //    {
        //        if(id != null)
        //        {
        //            var currentproduct = _appDbContext.Products.FirstOrDefault(product => product.ProductId == id);

        //            if (currentproduct != null)
        //            {
        //                return currentproduct;
        //            }
        //        }
        //    }
        //    catch(Exception)
        //    {
        //        throw;
        //    }
        //}

        public void Update(Product product)
        {
            try
            {
                if (product != null)
                {
                    var currentproduct = _appDbContext.Update(product);

                    if (currentproduct != null)
                    {
                        _appDbContext.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
