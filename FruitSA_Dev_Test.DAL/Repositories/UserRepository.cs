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
    public class UserRepository : IRepository<RegisterUserModel>
    {

        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public async Task<RegisterUserModel> Create(RegisterUserModel user)
        {
            try
            {
                if (user != null)
                {
                    var newuser = _appDbContext.Add<RegisterUserModel>(user);   
                    await _appDbContext.SaveChangesAsync();
                    return newuser.Entity;
                }
                else
                {
                    return new RegisterUserModel();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(RegisterUserModel user)
        {
            try
            {
                if (user != null)
                {
                    var currentuser = _appDbContext.Remove<RegisterUserModel>(user);
                    if (currentuser != null)
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

        public IEnumerable<RegisterUserModel> GetAll()
        {
            try
            {
                var users = _appDbContext.Users.ToList();
                if(users != null)
                {
                    return users;
                }
                else
                {
                    return Enumerable.Empty<RegisterUserModel>();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public RegisterUserModel GetById(string id)
        {
           throw new NotImplementedException();
        }

        public void Update(RegisterUserModel user)
        {
            try
            {
              if (user != null )
                {
                    var currentuser = _appDbContext.Update(user);

                    if (currentuser != null)
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
