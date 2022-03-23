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
    public interface IBookRepository : IRepository<Book>, IDisposable
    {

    }
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _db;
  

        public BookRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public Book Add(Book entity)
        {
            var result = _db.book.Add(entity);
            Save();
            return result.Entity;
        }

        public Book Delete(int id)
        {
            Book a = GetById(id);
            var result = _db.book.Remove(a);
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

        public IEnumerable<Book> GetAll()
        {
            return _db.book.ToList();
        }

        public Book GetById(int id)
        {
            return _db.book.FirstOrDefault(a => a.book_id == id);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Book entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            Save();
             
        }
    }
}
