using System.ComponentModel.DataAnnotations;

namespace bookstore.Models
{
    public class Category
    {
        [Key]
        [Display(Name="Id")]
        public int category_id { get; set; }
        
        [Display(Name = "Name")]
        public string category_name { get; set; }

        // relationships
        public virtual ICollection<BookCategory> CategoryBooks { get; set; } = new List<BookCategory>();
    }
}
