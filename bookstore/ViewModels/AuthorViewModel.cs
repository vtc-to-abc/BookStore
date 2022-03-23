using bookstore.Models;
namespace bookstore.ViewModels
{
    public class AuthorViewModel
    {
        public int Id { get; set; }
        public string Pseudonym { get; set; }
        public IEnumerable<Book> Books { get; set; } = new List<Book>();
    }
}
