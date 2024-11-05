using Entities.Dtos.User;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System.Data;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IServiceManager _manager;
        public HashSet<string> Roles { get; set; }

        public UserController(IServiceManager manager)
        {
            _manager = manager;
            Roles = new HashSet<string>(_manager
                .AuthService
                .Roles
                .Select(r => r.Name)
                .ToList());
        }

        public IActionResult Index()
        {
            var users = _manager.AuthService.GetAllUsers();
            return View(users);
        }

        public IActionResult Create()
        {
            ViewBag.Roles = Roles;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] UserDtoForCreation userDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _manager.AuthService.CreateUser(userDto);
                return result.Succeeded
                ? RedirectToAction("Index")
                : View(userDto);
            }

            ViewBag.Roles = Roles;
            return View();
        }

        public async Task<IActionResult> Update([FromRoute(Name = "id")] string id)
        {
            ViewBag.Roles = Roles;
            var user = await _manager.AuthService.GetOneUserForUpdate(id);
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromRoute(Name = "id")] string id, [FromForm] UserDtoForUpdate userDto)
        {
            if (ModelState.IsValid)
            {
                await _manager.AuthService.UpdateOneUser(id, userDto);
                return RedirectToAction("Index");
            }

            ViewBag.Roles = Roles;
            return View(userDto);
        }
    }
}
