using Microsoft.AspNetCore.Mvc;
using OrderManagement.Models;
using System.Linq;

namespace OrderManagement.Controllers
{
    [Route("api/order")]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _db;

        public OrderController(IOrderRepository db)
        {
            this._db = db;
        }
        [HttpGet("GetOrders")]
        public IActionResult GetOrders()
        {
            var orders = _db.GetOrders().ToList();
            if (orders.Count > 0)
                return Ok(orders);
            else
                return Json(NoContent());
        }
        [HttpPost("AddOrderLink")]
        public IActionResult AddOrderLink([FromBody] OrderLink orderLink)
        {
            var orderLnk = _db.AddOrder(orderLink);
            if (orderLnk == null)
                return Json(BadRequest());
            return Json(orderLnk);
        }
    }
}
