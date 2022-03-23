using System;
using System.Collections.Generic;
using System.Linq.Expressions;
namespace bookstore.Data.Repositories
{
    public interface IRepository<T>: IDisposable where T: class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        T Add(T entity);
        void Update(T entity);
        T Delete(int id);
        void Save();
    }
}
