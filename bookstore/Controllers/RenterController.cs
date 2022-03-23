using Microsoft.AspNetCore.Mvc;
using bookstore.Models;
using bookstore.Data;
using bookstore.Data.Services.RenterServices;
using bookstore.Data.Services.RentOrderServices;
using bookstore.Data.Services.BookServices;

namespace bookstore.Controllers
{
    public class RenterController : Controller
    {
        private readonly IRenterService _service;
        private readonly IRentOrderService _orderservice;
        private readonly IBookService _bservice;
        public RenterController(IRenterService service, IRentOrderService orderservice, IBookService bservice)
        {
            _service = service;
            _orderservice = orderservice;
            _bservice = bservice;
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
        public IActionResult Create([Bind("renter_name","renter_phone","renter_email")] Renter renter)
        {

            if (!ModelState.IsValid)
                return View(renter);
            _service.Add(renter);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult MakeOrder(int id)
        {
            var r = _service.GetById(id);
            ViewBag.Books = _bservice.GetAll();
            return View(r);
        }

        [HttpPost]
        public IActionResult MakeOrder(int id, int book_id)
        {

            _orderservice.Add(id, book_id);
            return RedirectToAction(nameof(Index));
        }

        // Get: Category/Detail
        public IActionResult Details(int id)
        {
            var renterDetails = _service.GetById(id);
            if (renterDetails == null) return View("NotFound");
            return View(renterDetails);
        }

        // Get: Category/Edit
        public IActionResult Edit(int id)
        {
            var renterDetails = _service.GetById(id);
            if (renterDetails == null) return View("NotFound");
            return View(renterDetails);
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind("renter_name", "renter_phone", "renter_email")] Renter rent)
        {

            if (!ModelState.IsValid)
                return View(rent);
            _service.Update(id, rent);
            return RedirectToAction(nameof(Index));
        }

        // Get: Category/Delete
        public IActionResult Delete(int id)
        {
            var renterDetails = _service.GetById(id);
            if (renterDetails == null) return View("NotFound");
            return View(renterDetails);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var rent = _service.GetById(id);
            if (rent == null) return View("NotFound");

            _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
