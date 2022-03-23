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
    public interface ICategoryBookRepository : IRepository<BookCategory>, IDisposable
    {

    }
    public class CategoryBookRepository : ICategoryBookRepository
    {
        private readonly ApplicationDbContext _db;
  

        public CategoryBookRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public BookCategory Add(BookCategory entity)
        {
            var result = _db.category_book.Add(entity);
            Save();
            return result.Entity;
        }

        public BookCategory Delete(int id)
        {
            BookCategory a = GetById(id);
            var result = _db.category_book.Remove(a);
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

        public IEnumerable<BookCategory> GetAll()
        {
            return _db.category_book.ToList();
        }

        public BookCategory GetById(int id)
        {
            return _db.category_book.FirstOrDefault(a => a.category_id == id);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(BookCategory entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            Save();
             
        }
    }
}
