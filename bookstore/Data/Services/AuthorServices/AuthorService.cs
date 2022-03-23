using bookstore.Models;
using bookstore.Data.Repositories;
namespace bookstore.Data.Services.AuthorServices
{
    public interface IAuthorService
    {
        IEnumerable<Author> GetAll();
        Author GetById(int id);
        Author Add(Author auth);
        Author Update(int id, Author newauth);
        Author Delete(int id);
    }
    public class AuthorService: IAuthorService
    {
        private  IAuthorRepository _repo;

        public AuthorService(IAuthorRepository repo)
        {
            _repo = repo;
        }

        public Author Add(Author auth)
        {
            return _repo.Add(auth);
        }

        public Author Delete(int id)
        {
           return _repo.Delete(id);
        }

        public IEnumerable<Author> GetAll()
        {
            return _repo.GetAll();
        }

        public Author GetById(int id)
        {
            var result = _repo.GetById(id);
            return result;
        }

        public Author Update(int id, Author newauth)
        {
            newauth.author_id = id;
            _repo.Update(newauth);
            return newauth;
        }
    }
}
