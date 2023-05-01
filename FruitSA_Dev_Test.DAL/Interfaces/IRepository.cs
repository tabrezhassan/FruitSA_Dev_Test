using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitSA_Dev_Test.DAL.Interfaces
{
    public interface IRepository <T>
    {
        public Task <T> Create(T entity);
        public void Update (T entity);
        public IEnumerable<T> GetAll ();
        public T GetById (string id);
        public void Delete (T entity);
    }
}
