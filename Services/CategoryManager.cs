using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class CategoryManager : ICategoryService
    {
        private readonly IRepositoryManager _repositoryManager;

        public CategoryManager(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public IEnumerable<Category> GetAllCategories(bool trackChanges)
        {
            return _repositoryManager.Category.FindAll(trackChanges);
        }

        public Category GetOneCategory(Guid id)
        {
            var category = _repositoryManager.Category.FindByCondition(c => c.Id.Equals(id), false);
            if (category is null)
                throw new Exception("Category is not found.");

            return category;
        }
    }
}
