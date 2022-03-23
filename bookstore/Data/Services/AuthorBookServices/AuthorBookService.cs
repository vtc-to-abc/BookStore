using bookstore.Models;
using bookstore.Data.Repositories;
namespace bookstore.Data.Services.AuthorBookServices
{
    public interface IAuthorBookService
    {
        AuthorBook Add(int authid, int bookid);
        AuthorBook Delete(int authorid, int bookid);
        IEnumerable<Author> GetAllAuthor(int bookid);
    }
    public class AuthorBookService : IAuthorBookService
    {
        private readonly IAuthorBookRepository _repo;
        public AuthorBookService(IAuthorBookRepository repo)
        {
            _repo = repo;
        }

        public AuthorBook Add(int auid, int bid)
        {
            AuthorBook ab = new AuthorBook { author_id = auid, book_id= bid };
           return _repo.Add(ab);
            
        }

        public AuthorBook Delete(int authorid, int bookid)
        { 
            return  _repo.Delete(authorid);
      
        }

        public IEnumerable<Author> GetAllAuthor(int bookid)
        {
            /*var result = (from a in _repo
                          join ab in _repo on a.author_id equals ab.author_id
                          join b in _repo.book on ab.book_id equals b.book_id
                          where b.book_id == bookid
                          select (new Author
                          {
                              author_id = a.author_id,
                              pseudonym = a.pseudonym
                          })) ;
            return result.ToList();*/
            return null;

        }
    }
}
