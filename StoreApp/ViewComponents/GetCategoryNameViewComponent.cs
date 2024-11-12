using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.ViewComponents
{
    public class GetCategoryNameViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;

        public GetCategoryNameViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }

        public string Invoke(Guid id)
        {
            var categoryName = _manager.CategoryService.GetOneCategory(id);

            return categoryName.CategoryName;

        }
    }
}
