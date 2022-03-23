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
    public interface IAuthorRepository : IRepository<Author>, IDisposable
    {

    }
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationDbContext _db;
  

        public AuthorRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public Author Add(Author entity)
        {
            var result = _db.author.Add(entity);
            Save();
            return result.Entity;
        }

        public Author Delete(int id)
        {
            Author a = GetById(id);
            var result = _db.author.Remove(a);
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

        public IEnumerable<Author> GetAll()
        {
            return _db.author.ToList();
        }

        public Author GetById(int id)
        {
            return _db.author.FirstOrDefault(a => a.author_id == id);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Author entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            Save();
             
        }
    }
}
