using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FruitSA_Dev_Test.DAL.Interfaces;
using FruitSA_Dev_Test.DAL.Models;

namespace FruitSA_Dev_Test.BLL.Services
{
    public class UserService
    {
        public readonly IRepository<RegisterUserModel> _repository;

        public UserService(IRepository<RegisterUserModel> repository)
        {
            _repository = repository;
        }

        //Create Method
        public async Task <RegisterUserModel> CreateUser(RegisterUserModel user)
        {
            try
            {
                if(user == null)
                {
                    throw new ArgumentNullException(nameof(user));
                }
                else
                {
                    return await _repository.Create(user);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Update Method
        //public void UpdateUser(string id)
        //{
        //    try
        //    {
        //        if(id == null)
        //        {
        //            var user = _repository.GetAll().Where(user => user.Id == id).FirstOrDefault();
        //            if (user != null)
        //            {
        //                _repository.Update(user);
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //Get list of all Users
        public IEnumerable<RegisterUserModel> GetAll()
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
    }
}
