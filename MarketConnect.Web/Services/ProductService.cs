using MarketConnect.Web.Models;
using MarketConnect.Web.Services.Contracts;
using System.Text;
using System.Text.Json;

namespace MarketConnect.Web.Services;

public class ProductService : IProductService
{
    private readonly IHttpClientFactory _clientFactory;
    private const string apiEndpoint = "api/products/";
    private readonly JsonSerializerOptions _jsonSerializerOptions;
    private ProductViewModel? productVM;
    private IEnumerable<ProductViewModel>? productsVM;

    public ProductService(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
        _jsonSerializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }

    public async Task<IEnumerable<ProductViewModel>> GetAllProducts()
    {
        var client = _clientFactory.CreateClient("ProductApi");

        using (var response = await client.GetAsync(apiEndpoint))
        {
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync();

                productsVM = await JsonSerializer.DeserializeAsync<IEnumerable<ProductViewModel>>(apiResponse, _jsonSerializerOptions);
            }
            else
            {
                return null;
            }
        }

        return productsVM;
    }
    public async Task<ProductViewModel> FindProductById(int id)
    {
        var client = _clientFactory.CreateClient("ProductApi");

        using (var response = await client.GetAsync(apiEndpoint + id))
        {
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync();

                productVM = await JsonSerializer.DeserializeAsync<ProductViewModel>(apiResponse, _jsonSerializerOptions);
            }
            else
            {
                return null;
            }
        }

        return productVM;
    }
    public async Task<ProductViewModel> CreateProduct(ProductViewModel pProductVM)
    {
        var client = _clientFactory.CreateClient("ProductApi");

        StringContent content = new StringContent(JsonSerializer.Serialize(pProductVM), Encoding.UTF8, "application/json");

        using (var response = await client.PostAsync(apiEndpoint, content))
        {
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync();

                productVM = await JsonSerializer.DeserializeAsync<ProductViewModel>(apiResponse, _jsonSerializerOptions);
            }
            else
            {
                return null;
            }
        }

        return productVM;
    }
    public async Task<ProductViewModel> UpdateProduct(ProductViewModel pProductVM)
    {
        var client = _clientFactory.CreateClient("ProductApi");

        ProductViewModel productUpdated = new ProductViewModel();

        using (var response = await client.PutAsJsonAsync(apiEndpoint, pProductVM))
        {
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync();

                productUpdated = await JsonSerializer.DeserializeAsync<ProductViewModel>(apiResponse, _jsonSerializerOptions);
            }
            else
            {
                return null;
            }
        }

        return productUpdated;
    }
    public async Task<bool> DeleteProduct(int id)
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
