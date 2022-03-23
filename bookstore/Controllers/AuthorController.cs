using Microsoft.AspNetCore.Mvc;
using bookstore.Models;
using bookstore.Data.Services.AuthorServices;
using bookstore.Data.Services.AuthorBookServices;

namespace bookstore.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService _service;
        //private readonly IAuthorBookService _abservice;
        public AuthorController(IAuthorService service, IAuthorBookService abservice)
        {
            _service = service;
            //_abservice = abservice;
        }
        // get list for read only
        // to use services, first need dependency injection...
        // dependend because the controller use the method of the service
        public IActionResult Index()
        {
            var data = _service.GetAll();

            return View(data);
        }

        public IActionResult AuthorListCheckBox()
        {
            ViewBag.Authors = _service.GetAll();
            return View("_AuthorListCheckBox");
        }

        // Get: Category/create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("pseudonym")] Author auth)
        {

            if (!ModelState.IsValid)
                return View(auth);
            _service.Add(auth);
            return RedirectToAction(nameof(Index));
        }

        // Get: Category/Detail
        public IActionResult Details(int id)
        {
            var authorDetails = _service.GetById(id);
            if (authorDetails == null) return View("NotFound");
            return View(authorDetails);
        }

        // Get: Category/Edit
        public IActionResult Edit(int id)
        {
            var authorDetails = _service.GetById(id);
            if (authorDetails == null) return View("NotFound");
            return View(authorDetails);
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind("pseudonym")] Author auth)
        {

            if (!ModelState.IsValid)
                return View(auth);
            _service.Update(id, auth);
            return RedirectToAction(nameof(Index));
        }

        // Get: Category/Delete
        public IActionResult Delete(int id)
        {
            var authorDetails = _service.GetById(id);
            if (authorDetails == null) return View("NotFound");
            return View(authorDetails);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var auth = _service.GetById(id);
            if (auth == null) return View("NotFound");

            _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
  

    }
}
