using MarketConnect.Web.Models;

namespace MarketConnect.Web.Services.Contracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewModel>> GetAllCategories();
        Task<IEnumerable<CategoryViewModel>> GetAllCategoriesProducts();
        Task<CategoryViewModel> FindCategoryById(int id);
        Task<CategoryViewModel> CreateCategory(CategoryViewModel categoryVM);
        Task<CategoryViewModel> UpdateCategory(CategoryViewModel categoryVM);
        Task<bool> RemoveCategory(int id);
    }
}
