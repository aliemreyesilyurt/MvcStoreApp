using Entities.Dtos.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IServiceManager _manager;

        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }

        // Get
        public IActionResult Index()
        {
            var model = _manager.ProductService.GetAllProducts(false);
            return View(model);
        }

        // Get Create
        public IActionResult Create()
        {
            ViewBag.Categories = GetCategoreiesSelectList();

            return View();
        }

        // Post Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] ProductDtoForInsertion productDto)
        {
            if (ModelState.IsValid)
            {
                _manager.ProductService.CreateProduct(productDto);
                return RedirectToAction("Index");
            }
            return View();
        }

        // Get Update
        public IActionResult Update([FromRoute(Name = "id")] int id)
        {
            ViewBag.Categories = GetCategoreiesSelectList();

            var model = _manager.ProductService.GetOneProductForUpdate(id, false);
            return View(model);
        }

        // Post Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([FromForm] ProductDtoForUpdate productDto)
        {
            if (ModelState.IsValid)
            {
                _manager.ProductService.UpdateOneProduct(productDto);
                return RedirectToAction("Index");
            }
            return View();
        }

        // Get Delete
        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {
            var model = _manager.ProductService.GetOneProduct(id, false);
            return View(model);
        }

        // Post Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteProduct(int id)
        {
            _manager.ProductService.DeleteOneProduct(id);
            return RedirectToAction("Index");
        }

        // Methods
        private SelectList GetCategoreiesSelectList()
        {
            return new SelectList(_manager.CategoryService.GetAllCategories(false),
                "CategoryId",
                "CategoryName",
                "1");
        }
    }
}
