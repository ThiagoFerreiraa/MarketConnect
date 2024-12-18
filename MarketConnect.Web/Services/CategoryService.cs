using MarketConnect.Web.Models;
using MarketConnect.Web.Services.Contracts;
using System.Text;
using System.Text.Json;

namespace MarketConnect.Web.Services;

public class CategoryService : ICategoryService
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly JsonSerializerOptions _options;
    private const string apiEndpoint = "api/categories";
    private HttpClient client; 
    private CategoryViewModel categoryVM;
    private IEnumerable<CategoryViewModel> categoriesVM;

    public CategoryService(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
        _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        client = _clientFactory.CreateClient("ProductApi");
    }
    public async Task<IEnumerable<CategoryViewModel>> GetAllCategories()
    {

        using (var response = await client.GetAsync(apiEndpoint))
        {
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStreamAsync();

                categoriesVM = await JsonSerializer.DeserializeAsync<IEnumerable<CategoryViewModel>>(result, _options);
            }
            else
            {
                return null;
            }

            return categoriesVM;
        }
    }
    public async Task<IEnumerable<CategoryViewModel>> GetAllCategoriesProducts()
    {
        var client = _clientFactory.CreateClient("ProductApi");

        using (var response = await client.GetAsync(apiEndpoint + "products"))
        {

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStreamAsync();

                categoriesVM = await JsonSerializer.DeserializeAsync<IEnumerable<CategoryViewModel>>(result, _options);
            }
            else
            {
                return null;
            }

        }

        return categoriesVM;
    }
    public async Task<CategoryViewModel> FindCategoryById(int id)
    {
        var client = _clientFactory.CreateClient("ProductApi");

        using (var response = await client.GetAsync(apiEndpoint + id))
        {
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStreamAsync();

                categoryVM = await JsonSerializer.DeserializeAsync<CategoryViewModel>(result, _options);
            }
            else
            {
                return null;
            }
        }

        return categoryVM;
    }
    public async Task<CategoryViewModel> CreateCategory(CategoryViewModel pCategoryVM)
    {
        var client = _clientFactory.CreateClient("ProductApi");

        StringContent categoryVmPost = new StringContent(JsonSerializer.Serialize(pCategoryVM), Encoding.UTF8,"application/json");

        using (var response = await client.PostAsync(apiEndpoint, categoryVmPost))
        {
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStreamAsync();

                categoryVM = await JsonSerializer.DeserializeAsync<CategoryViewModel>(result, _options);
            }
            else
            {
                return null;
            }
        }

        return categoryVM;
    }
    public async Task<CategoryViewModel> UpdateCategory(CategoryViewModel pCategoryVM)
    {
        var client = _clientFactory.CreateClient("ProductApi");

        StringContent categoryVmPut = new StringContent(JsonSerializer.Serialize(pCategoryVM), Encoding.UTF8, "application/json");

        using (var response = await client.PutAsync(apiEndpoint, categoryVmPut))
        {
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStreamAsync();

                categoryVM = await JsonSerializer.DeserializeAsync<CategoryViewModel>(result, _options);
            }
            else
            {
                return null;
            }
        }

        return categoryVM;
    }
    public async Task<bool> RemoveCategory(int id)
    {
        var client = _clientFactory.CreateClient("ProductApi");

        using (var response = await client.DeleteAsync(apiEndpoint + id))
        {
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
        }

        return false;
    }
}
