using System.ComponentModel.DataAnnotations;

namespace bookstore.Models
{
    public class Author
    {
        [Key]
        public int author_id { get; set; }
        public string pseudonym { get; set; }

        // ienumerable là readonly, icollection có thể chỉnh sửa
        public virtual ICollection<AuthorBook> AuthorBooks { get; set; } = new List<AuthorBook>();
    }
}
