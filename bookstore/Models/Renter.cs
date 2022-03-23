using System.ComponentModel.DataAnnotations;

namespace bookstore.Models
{
    public class Renter
    {
        [Key]
        public int renter_id { get; set; }
        public string renter_name { get; set; }
        public string renter_phone { get; set; }
        public string renter_email { get; set; }

        public virtual ICollection<RentOrder> RenterOrders { get; set; } = new List<RentOrder>();
    }
}
