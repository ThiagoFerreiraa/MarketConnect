using MarketConnect.Web.Models;
using MarketConnect.Web.Services.Contracts;
using System.Text.Json;

namespace MarketConnect.Web.Services;

public class ProductService : IProductService
{
    private readonly IHttpClientFactory _clientFactory;
    private const string apiEndpoint = "api/products";
    private readonly JsonSerializerOptions _jsonSerializerOptions;
    private ProductViewModel productVM;
    private IEnumerable<ProductViewModel> productsVM;

    public ProductService(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
        _jsonSerializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }

    public Task<IEnumerable<ProductViewModel>> GetAllProducts()
    {
        throw new NotImplementedException();
    }
    public Task<ProductViewModel> FindProductById(int id)
    {
        throw new NotImplementedException();
    }
    public Task<ProductViewModel> CreateProduct(ProductViewModel productVM)
    {
        throw new NotImplementedException();
    }
    public Task<ProductViewModel> UpdateProduct(ProductViewModel productVM)
    {
        throw new NotImplementedException();
    }
    public Task<bool> DeleteProduct(int id)
    {
        throw new NotImplementedException();
    }
    
}
