using Microsoft.AspNetCore.Mvc;
using bookstore.Models;
using bookstore.Data.Services.CategoryServices;
namespace bookstore.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }
        // get list for read only
        // to use services, first need dependency injection...
        // dependend because the controller use the method of the service
        public IActionResult Index()
        {
            var data = _service.GetAll();
            
            return View(data);
        }

        // Get: Category/create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("category_name")]Category cat)
        {

            if (!ModelState.IsValid)
               return View(cat);
            _service.Add(cat);
            return RedirectToAction(nameof(Index));
        }

        // Get: Category/Detail
        public IActionResult Details(int id)
        {
            var categoryDetails = _service.GetById(id);
            if (categoryDetails == null) return View("NotFound");
            return View(categoryDetails);
        }

        // Get: Category/Edit
        public IActionResult Edit(int id)
        {
            var categoryDetails = _service.GetById(id);
            if (categoryDetails == null) return View("NotFound");
            return View(categoryDetails);
        }

        [HttpPost]
        public IActionResult Edit(int id,[Bind("category_id","category_name")] Category cat)
        {

            if (!ModelState.IsValid)
                return View(cat);
            _service.Update(id, cat);
            return RedirectToAction(nameof(Index));
        }

        // Get: Category/Delete
        public IActionResult Delete(int id)
        {
            var categoryDetails = _service.GetById(id);
            if (categoryDetails == null) return View("NotFound");
            return View(categoryDetails);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var cat = _service.GetById(id);
            if (cat == null) return View("NotFound");

            _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
