using Entities.Dtos.Order;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IServiceManager _manager;
        private readonly Cart _cart;

        public OrderController(IServiceManager manager, Cart cartService)
        {
            _manager = manager;
            _cart = cartService;
        }

        [Authorize(Roles = "User")]
        public IActionResult Checkout() => View(new OrderDto());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Checkout([FromForm] OrderDto orderDto)
        {
            if (_cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty.");
            }
            if (ModelState.IsValid)
            {
                orderDto.Lines = _cart.Lines.ToArray();
                _manager.OrderService.SaveOrder(orderDto);
                _cart.Clear();
                return RedirectToPage("/Complete", new { OrderId = orderDto.Id });
            }
            else
            {
                return View(orderDto);
            }

        }
    }
}
