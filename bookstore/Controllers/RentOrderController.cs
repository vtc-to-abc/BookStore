using Microsoft.AspNetCore.Mvc;
using bookstore.Models;
using bookstore.Data.Services.RentOrderServices;
using bookstore.ViewModels;

namespace bookstore.Controllers
{
    public class RentOrderController : Controller
    {
        private readonly IRentOrderService _service;
        public RentOrderController(IRentOrderService service)
        {
            _service = service;
        }
   
        public IActionResult Index()
        {
            var data = _service.GetAll();

            return View(data);
        }

        public IActionResult Delete(int id)
        {
            var orderDetails = _service.GetById(id);
            if (orderDetails == null) return View("NotFound");
            return View(orderDetails);
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
