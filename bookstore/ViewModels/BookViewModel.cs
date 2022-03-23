using bookstore.Models;
namespace bookstore.ViewModels
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Availible { get; set; }

        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
        public IEnumerable<Author> Authors { get; set; } = new List<Author>();
    }
}
