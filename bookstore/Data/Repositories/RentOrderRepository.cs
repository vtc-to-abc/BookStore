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
    public interface IRentOrderRepository : IRepository<RentOrder>, IDisposable
    {

    }
    public class RentOrderRepository : IRentOrderRepository
    {
        private readonly ApplicationDbContext _db;
  

        public RentOrderRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public RentOrder Add(RentOrder entity)
        {
            var result = _db.rentorder.Add(entity);
            Save();
            return result.Entity;
        }

        public RentOrder Delete(int id)
        {
            RentOrder a = GetById(id);
            var result = _db.rentorder.Remove(a);
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

        public IEnumerable<RentOrder> GetAll()
        {
            return _db.rentorder.ToList();
        }

        public RentOrder GetById(int id)
        {
            return _db.rentorder.FirstOrDefault(a => a.order_id == id);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(RentOrder entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            Save();
             
        }
    }
}
