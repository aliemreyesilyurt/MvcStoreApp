using Entities.Dtos.Product;
using Entities.RequestParameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Contracts;
using StoreApp.Models;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly IServiceManager _manager;

        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }

        // Get
        public IActionResult Index([FromQuery] ProductRequestParameters p)
        {
            var products = _manager.ProductService.GetAllProductsWithDetails(p);
            var pagination = new Pagination()
            {
                CurrentPage = p.PageNumber,
                ItemsPerPage = p.PageSize,
                TotalItems = _manager.ProductService.GetAllProducts(false).Count()
            };

            return View(new ProductListViewModel()
            {
                Products = products,
                Pagination = pagination
            });
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
        public async Task<IActionResult> Create([FromForm] ProductDtoForInsertion productDto, IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                ModelState.AddModelError("file", "Please select an image.");
            }

            if (ModelState.IsValid)
            {
                // file operation
                string path = Path.Combine(Directory.GetCurrentDirectory(),
                   "wwwroot", "images", file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                productDto.ImageUrl = String.Concat("/images/", file.FileName);

                _manager.ProductService.CreateProduct(productDto);
                TempData["success"] = $"{productDto.ProductName} has been created.";
                return RedirectToAction("Index");
            }
            ViewBag.Categories = GetCategoreiesSelectList();
            return View();
        }

        // Get Update
        public IActionResult Update([FromRoute(Name = "id")] Guid id)
        {
            ViewBag.Categories = GetCategoreiesSelectList();

            var model = _manager.ProductService.GetOneProductForUpdate(id, false);
            return View(model);
        }

        // Post Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromForm] ProductDtoForUpdate productDto, IFormFile file)
        {
            var currentImageUrl = _manager.ProductService.GetOneProduct(productDto.Id, false).ImageUrl;
            if (ModelState.IsValid)
            {
                // file operation
                if (file is null)
                {
                    productDto.ImageUrl = currentImageUrl;
                }
                else
                {
                    string path = Path.Combine(Directory.GetCurrentDirectory(),
                   "wwwroot", "images", file.FileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    productDto.ImageUrl = String.Concat("/images/", file.FileName);
                }
                _manager.ProductService.UpdateOneProduct(productDto);
                return RedirectToAction("Index");
            }

            ViewBag.Categories = GetCategoreiesSelectList();
            productDto.ImageUrl = currentImageUrl;
            return View(productDto);
        }

        // Get Delete
        public IActionResult Delete([FromRoute(Name = "id")] Guid id)
        {
            var model = _manager.ProductService.GetOneProduct(id, false);
            return View(model);
        }

        // Post Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteProduct(Guid id)
        {
            _manager.ProductService.DeleteOneProduct(id);
            return RedirectToAction("Index");
        }

        // Methods
        private SelectList GetCategoreiesSelectList()
        {
            return new SelectList(_manager.CategoryService.GetAllCategories(false),
                "Id",
                "CategoryName",
                "1");
        }
    }
}
