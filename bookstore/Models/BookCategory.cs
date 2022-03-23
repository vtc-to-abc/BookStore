using System.ComponentModel.DataAnnotations;

namespace bookstore.Models
{
    public class BookCategory
    {
        [Key]
        public int category_id { get; set; }
        [Key]
        public int book_id { get; set; }

        public virtual Book Book { get; set; }
        public virtual Category Category { get; set; }


    }
}
