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
    public interface IAuthorBookRepository : IRepository<AuthorBook>, IDisposable
    {

    }
    public class AuthorBookRepository : IAuthorBookRepository
    {
        private readonly ApplicationDbContext _db;
  

        public AuthorBookRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public AuthorBook Add(AuthorBook entity)
        {
            var result = _db.author_book.Add(entity);
            Save();
            return result.Entity;
        }

        public AuthorBook Delete(int id)
        {
            AuthorBook a = GetById(id);
            var result = _db.author_book.Remove(a);
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

        public IEnumerable<AuthorBook> GetAll()
        {
            return _db.author_book.ToList();
        }

        public AuthorBook GetById(int id)
        {
            return _db.author_book.FirstOrDefault(a => a.author_id == id);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(AuthorBook entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            Save();
             
        }
    }
}
