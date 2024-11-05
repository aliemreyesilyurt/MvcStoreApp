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

        public UserController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var users = _manager.AuthService.GetAllUsers();
            return View(users);
        }

        public IActionResult Create()
        {
            ViewBag.Roles = GetRolesCheckbox();

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
                : View();
            }

            ViewBag.Roles = GetRolesCheckbox();
            return View();
        }

        private HashSet<string> GetRolesCheckbox()
        {
            return new HashSet<string>(_manager
                .AuthService
                .Roles
                .Select(r => r.Name)
                .ToList());
        }
    }
}
