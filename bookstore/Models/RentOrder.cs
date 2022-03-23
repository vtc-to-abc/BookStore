using System.ComponentModel.DataAnnotations;

namespace bookstore.Models
{
    public class RentOrder
    {
        [Key]
        public int order_id { get; set; }
        public int renter_id { get; set; }
        public int book_id { get; set; }
        public DateTime rent_date { get; set; }
        public DateTime return_date { get; set; }
        public int rent_status { get; set; }

        // parent/ relationship
        public virtual Renter renter { get; set; }
        public virtual Book book { get; set; }

    }
}
