using System.ComponentModel.DataAnnotations;
namespace bookstore.Models
{
    public class Book
    {
        [Key]
        public int book_id { get; set; }
        public string book_title { get; set; }
        public int stored_copies { get; set; }
        public int current_rent { get; set; }

        //relationships
        public virtual ICollection<BookCategory> BookCategories { get; set; } = new List<BookCategory>();
        public virtual ICollection<AuthorBook> BookAuthors { get; set; } = new List<AuthorBook>();

        public virtual ICollection<RentOrder> BookOrders { get; set; } = new List<RentOrder>();

    }
}
