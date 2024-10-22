using Entities.RequestParameters;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {
        //Dependency Injection
        private readonly IServiceManager _serviceManager;

        public ProductController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public IActionResult Index(ProductRequestParameters p)
        {
            var products = _serviceManager.ProductService.GetAllProductsWithDetails(p);
            return View(products);
        }
        public IActionResult Get([FromRoute(Name = "id")] int id)
        {
            var model = _serviceManager.ProductService.GetOneProduct(id, false);
            return View(model);
        }
    }
}