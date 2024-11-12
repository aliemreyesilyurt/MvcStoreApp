using Entities.Dtos.Order;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IServiceManager _manager;
        private readonly UserManager<User> _userManager;
        private readonly Cart _cart;

        public OrderController(IServiceManager manager, Cart cartService, UserManager<User> userManager)
        {
            _manager = manager;
            _cart = cartService;
            _userManager = userManager;
        }

        [Authorize(Roles = "User")]
        public IActionResult Checkout() => View(new OrderDto());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Checkout([FromForm] OrderDto orderDto)
        {
            if (_cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("Error", "Sorry, your cart is empty.");
            }
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);

                orderDto.Lines = _cart.Lines.ToArray();
                _manager.OrderService.SaveOrder(orderDto, user.Id);
                _cart.Clear();
                return RedirectToPage("/Complete", new { OrderId = orderDto.Id });
            }
            else
            {
                return View(orderDto);
            }

        }

        [Authorize(Roles = "User")]
        public async Task<IActionResult> UserOrders()
        {
            var user = await _userManager.GetUserAsync(User);

            var userOrders = _manager.OrderService.GetUsersOrders(user.Id);

            return View(userOrders);
        }
    }
}
