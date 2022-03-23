using bookstore.Models;
namespace bookstore.Data.Services.CategoryBookServices
{
    public interface ICategoryBookService
    {
        IEnumerable<BookCategory> GetAll();
        //void Add(BookCategory bc);
        //Book Update(int id, Author newbook);
        //void Delete(int id);
    }
}
