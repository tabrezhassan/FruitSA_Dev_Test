using FruitSA_Dev_Test.DAL.Models;
using FruitSA_Dev_Test.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitSA_Dev_Test.BLL.Services
{
    public class CategoryService
    {
        public readonly CategoryRepository _repository;

        public CategoryService(CategoryRepository repository)
        {
            _repository = repository;
        }

        //Create Method
        public async Task<Category> CreateCategory(Category category)
        {
            try
            {
                if(category == null)
                {
                    throw new ArgumentNullException(nameof(category));
                }
                else
                {
                    return await _repository.Create(category);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Update Method
        public void UpdateCategory(Category category)
        {
            try
            {
                if (category != null)
                {
                    _repository.Update(category);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Get List of Catgories
        public IEnumerable<Category> GetAll()
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

        //Get Category By ID
        public Category GetCategory(string id)
        {
            try
            {
                var category = _repository.GetAll().Where(category => category.CategoryId == id).FirstOrDefault();
                if (category != null)
                {
                    return (Category)category;
                }

                return new Category();
            }
            catch (Exception)
            {
                throw;
            }
            }
        }
}
