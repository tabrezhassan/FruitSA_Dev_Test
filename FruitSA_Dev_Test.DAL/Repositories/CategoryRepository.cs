using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FruitSA_Dev_Test.DAL.Interfaces;
using FruitSA_Dev_Test.DAL.Repositories;
using FruitSA_Dev_Test.DAL.Models;
using FruitSA_Dev_Test.DAL.Data;

namespace FruitSA_Dev_Test.DAL.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly AppDbContext _appDbContext;

        public CategoryRepository(AppDbContext appDbContext) 
        {
            this._appDbContext = appDbContext;
        }

        public async Task <Category> Create(Category category)
        {
            try
            {
                if (category != null)
                {
                    var newcategory = _appDbContext.Add<Category>(category);
                    await _appDbContext.SaveChangesAsync();
                    return newcategory.Entity;
                }
                else
                {
                    return new Category();
                }
            }
            catch(Exception)
            {
                throw;
            }
        }

        public void Delete(Category category)
        {
            try
            {
                if (category != null)
                {
                    var currentcategory = _appDbContext.Remove<Category>(category);
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

        public IEnumerable<Category> GetAll()
        {
            try
            {
                var category = _appDbContext.Categories.ToList();
                if (category != null)
                {
                    return category;
                }
                else
                {
                    return Enumerable.Empty<Category>();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

       

        public Category GetById(string id)
        {
            try
            {
                if (id != null)
                {
                    var currentcategory = _appDbContext.Categories.FirstOrDefault(category => category.CategoryId == id);
                    if (currentcategory != null)
                    {
                        return currentcategory;
                    }
                }
                    return new Category();
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(Category category)
        {
            try
            {
                if (category != null)
                {
                    var currentcategory = _appDbContext.Update(category);

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
    }
}
