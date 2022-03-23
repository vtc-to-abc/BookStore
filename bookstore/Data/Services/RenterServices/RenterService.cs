using bookstore.Models;
using bookstore.Data.Repositories;
namespace bookstore.Data.Services.RenterServices
{
    public interface IRenterService
    {
        IEnumerable<Renter> GetAll();
        Renter GetById(int id);
        Renter Add(Renter renter);
        Renter Update(int id, Renter renter);
        Renter Delete(int id);
    }
    public class RenterService: IRenterService
    {
        private readonly IRenterRepository _repo;

        public RenterService(IRenterRepository repo)
        {
            _repo = repo;
        }

        public Renter Add(Renter renter)
        {
            return _repo.Add(renter);
            
        }

        public Renter Delete(int id)
        {
            return _repo.Delete(id);
            
        }

        public IEnumerable<Renter> GetAll()
        {
            return _repo.GetAll();
        }

        public Renter GetById(int id)
        {
            return _repo.GetById(id);
        }

        public Renter Update(int id, Renter newrenter)
        {
            newrenter.renter_id = id;
            _repo.Update(newrenter);
            return newrenter;
        }
    }
}
