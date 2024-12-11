using MarketConnect.Web.Models;
using MarketConnect.Web.Services.Contracts;
using System.Text.Json;

namespace MarketConnect.Web.Services;

public class CategoryService : ICategoryService
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly JsonSerializerOptions _options;
    private const string apiEndpoint = "api/categories";
    private CategoryViewModel categoryVM;
    private IEnumerable<CategoryViewModel> categoriesVM;

    public CategoryService(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
        _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }
    public Task<IEnumerable<CategoryViewModel>> GetAllCategories()
    {
        throw new NotImplementedException();
    }
    public Task<IEnumerable<CategoryViewModel>> GetAllCategoriesProducts()
    {
        throw new NotImplementedException();
    }
    public Task<CategoryViewModel> FindCategoryById(int id)
    {
        throw new NotImplementedException();
    }
    public Task<CategoryViewModel> CreateCategory(CategoryViewModel categoryVM)
    {
        throw new NotImplementedException();
    }
    public Task<CategoryViewModel> UpdateCategory(CategoryViewModel categoryVM)
    {
        throw new NotImplementedException();
    }
    public Task<bool> RemoveCategory(int id)
    {
        throw new NotImplementedException();
    }
}
