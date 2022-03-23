using bookstore.Models;
using bookstore.ViewModels;
using bookstore.Data.Services.RentOrderServices;
using bookstore.Data.Services.BookServices;
using bookstore.Data.Services.RenterServices;
using bookstore.Data.Repositories;
namespace bookstore.Data.Services.RentOrderServices
{
    public interface IRentOrderService
    {
        IEnumerable<RentOrderViewModel> GetAll();

        RentOrder GetById(int rid);
        RentOrder Add(int renterid, int bookid);

        RentOrder Update(int id, RentOrder neworder);

        RentOrder Delete(int id);

    }
    public class RentOrderService:IRentOrderService
    {
        private readonly IRentOrderRepository _repo;
        private readonly IBookService _bservice;
        private readonly IRenterService _rservice;
        public RentOrderService(IRentOrderRepository repo, IBookService bservice, IRenterService rservice)
        {
            _repo = repo;
            _bservice = bservice;
            _rservice = rservice;
        }
        public RentOrder Add(int renterid, int bookid)
        {
            var order = new RentOrder
            {
                renter_id = renterid,
                book_id = bookid,
            };
            Book b = _bservice.GetById(bookid);
            b.current_rent += 1;
            _bservice.Update(order.book_id, b);
            return _repo.Add(order);

        }
        public RentOrder Delete(int id)
        {
            var order = GetById(id);
            Book b = _bservice.GetById(order.book_id);
            b.current_rent -= 1;
            return _repo.Delete(id);
        }

        public IEnumerable<RentOrderViewModel> GetAll()
        {
            var result = (from a in _repo.GetAll()
                          select (new RentOrderViewModel
                          {
                              Id = a.order_id,
                              RentDate = a.rent_date,
                              ReturnDate = a.return_date,
                              RentStatus = a.rent_status,

                              Renter = _rservice.GetById(a.renter_id),
                              book = _bservice.GetById(a.book_id),
                          })) ;
            return result.ToList();
        }

        public RentOrder GetById(int rid)
        {
            return _repo.GetById(rid);
        }

        public RentOrder Update(int id, RentOrder neworder)
        {
            neworder.order_id = id;
            _repo.Update(neworder);
            return neworder;
        }

    }
}
