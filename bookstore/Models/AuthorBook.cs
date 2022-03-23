using System.ComponentModel.DataAnnotations;

namespace bookstore.Models
{
    public class AuthorBook
    {
        [Key]
        public int author_id { get; set; }
        [Key]
        public int book_id { get; set; }

        // parent/ relationship
        public virtual Author author { get; set; }
        public virtual Book book { get; set; }
    }
}
