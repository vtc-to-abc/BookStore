using bookstore.Models;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace bookstore.Data.Repositories
{
    public interface ICategoryRepository : IRepository<Category>, IDisposable
    {

    }
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
  

        public CategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public Category Add(Category entity)
        {
            var result = _db.category.Add(entity);
            Save();
            return result.Entity;
        }

        public Category Delete(int id)
        {
            Category a = GetById(id);
            var result = _db.category.Remove(a);
            Save();
            return result.Entity;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Category> GetAll()
        {
            return _db.category.ToList();
        }

        public Category GetById(int id)
        {
            return _db.category.FirstOrDefault(a => a.category_id == id);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Category entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            Save();
             
        }
    }
}
