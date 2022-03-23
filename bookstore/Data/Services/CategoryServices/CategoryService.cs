using bookstore.Models;
using bookstore.Data.Repositories;
namespace bookstore.Data.Services.CategoryServices
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAll();
        Category GetById(int id);
        Category Add(Category cat);
        Category Update(int id, Category newcat);
        Category Delete(int id);
    }
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;

        public CategoryService(ICategoryRepository repo)
        {
            _repo = repo;
        }
        public Category Add(Category cat)
        {
            return _repo.Add(cat);

        }

        public Category Delete(int id)
        {
            return _repo.Delete(id);
        }

        public IEnumerable<Category> GetAll()
        {
            return _repo.GetAll();
        }

        public Category GetById(int id)
        {           
            return _repo.GetById(id);
        }

        public Category Update(int id, Category newcat)
        {
            newcat.category_id = id;
            _repo.Update(newcat);
            return newcat;
        }
    }
}
