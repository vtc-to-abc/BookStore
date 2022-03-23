using Microsoft.AspNetCore.Mvc;
using bookstore.Models;
using bookstore.Data.Services.BookServices;
using bookstore.Data.Services.AuthorBookServices;
using bookstore.Data.Services.AuthorServices;
using bookstore.Data.Services.CategoryBookServices;
using bookstore.Data.Services.RentOrderServices;
using bookstore.Controllers;
using bookstore.ViewModels;
namespace bookstore.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _service;
        private readonly IAuthorBookService _abservice;
        private readonly IAuthorService _aservice;
        public BookController(IBookService service, IAuthorBookService abservice, IAuthorService aservice)
        {
            _service = service;
            _abservice = abservice;
            _aservice = aservice;
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
        public IActionResult Create([Bind("book_title", "stored_copies", "current_rent")] Book b)
        {

            if (!ModelState.IsValid)
                return View(b);
            _service.Add(b);

            return RedirectToAction("CreateRelationship", "Book", new { bid = b.book_id });

        }

        // Get: book/createrealtion
        //[HttpGet("[controller]/[Action]/{bid}")]

        public IActionResult CreateRelationship(int bid)
        {
            var b = _service.GetById(bid);
            ViewBag.Authors = _aservice.GetAll();
            return View(b);

        }

        [HttpPost]
        public IActionResult CreateRelationship(int bid, IEnumerable<int> authid)
        {

            foreach (int id in authid)
            {
                _abservice.Add(id, bid);
            }

            return RedirectToAction(nameof(Index));

        }
        // Get: Category/Detail
        public IActionResult Details(int id)
        {
            var bookDetails = new BookViewModel
            {
                Id = _service.GetById(id).book_id,
                Title = _service.GetById(id).book_title,
                Availible =_service.GetById(id).stored_copies - _service.GetById(id).current_rent,
                
                Authors = _abservice.GetAllAuthor(id) 
            }; 
            if (bookDetails == null) return View("NotFound");
            return View(bookDetails);
        }

        // Get: Category/Edit
        public IActionResult Edit(int id)
        {
            var bookDetails = _service.GetById(id);
            if (bookDetails == null) return View("NotFound");
            return View(bookDetails);
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind("book_title", "stored_copies", "current_rent")] Book b)
        {

            if (!ModelState.IsValid)
                return View(b);
            _service.Update(id, b);
            return RedirectToAction(nameof(Index));
        }

        // Get: Category/Delete
        public IActionResult Delete(int id)
        {
            var bookDetails = _service.GetById(id);
            if (bookDetails == null) return View("NotFound");
            return View(bookDetails);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var b = _service.GetById(id);
            if (b == null) return View("NotFound");

            _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
