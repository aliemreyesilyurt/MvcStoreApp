using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;

namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {
        //Dependency Injection
        private readonly IRepositoryManager _manager;

        public ProductController(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var products = _manager.Product.GetAllProducts(false);
            return View(products);
        }
        public IActionResult Get(int id)
        {
            var model = _manager.Product.GetOneProduct(id, false);
            return View(model);
        }
    }
}