using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.ViewComponents
{
    public class ShowcaseViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;

        public ShowcaseViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }

        public IViewComponentResult Invoke()
        {
            var products = _manager.ProductService.GetShowcasesProducts(false);
            return View(products);
        }
    }
}
