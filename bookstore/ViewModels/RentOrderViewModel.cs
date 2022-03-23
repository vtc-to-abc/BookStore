using bookstore.Models;

namespace bookstore.ViewModels
{
    public class RentOrderViewModel
    {
        public int Id { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int RentStatus { get; set; }

        public Renter Renter { get; set; }
        public Book book  { get; set; }
    }
}
