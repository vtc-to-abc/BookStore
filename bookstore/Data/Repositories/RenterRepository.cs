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
    public interface IRenterRepository : IRepository<Renter>, IDisposable
    {

    }
    public class RenterRepository : IRenterRepository
    {
        private readonly ApplicationDbContext _db;
  

        public RenterRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public Renter Add(Renter entity)
        {
            var result = _db.renter.Add(entity);
            Save();
            return result.Entity;
        }

        public Renter Delete(int id)
        {
            Renter a = GetById(id);
            var result = _db.renter.Remove(a);
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

        public IEnumerable<Renter> GetAll()
        {
            return _db.renter.ToList();
        }

        public Renter GetById(int id)
        {
            return _db.renter.FirstOrDefault(a => a.renter_id == id);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Renter entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            Save();
             
        }
    }
}
