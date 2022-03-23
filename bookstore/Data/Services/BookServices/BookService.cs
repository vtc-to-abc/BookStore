using bookstore.Models;
using bookstore.Data.Repositories;
namespace bookstore.Data.Services.BookServices
{
    public interface IBookService
    {
        IEnumerable<Book> GetAll();
        Book GetById(int id);
        Book Add(Book book);
        Book Update(int id, Book newbook);
        Book Delete(int id);
    }
    public class BookService : IBookService
    {
        private readonly IBookRepository _repo;

        public BookService(IBookRepository db)
        {
            _repo = db;
        }
        public Book Add(Book book)
        {
            return _repo.Add(book);
            
        }

        public Book Delete(int id)
        {
            return _repo.Delete(id);
        }

        public IEnumerable<Book> GetAll()
        {
            return _repo.GetAll();
        }

        public Book GetById(int id)
        {
            return _repo.GetById(id);
        }

        public Book Update(int id, Book newbook)
        {
            newbook.book_id = id;
            _repo.Update(newbook);
            return newbook;
        }

    }
}
