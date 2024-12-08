using MarketConnect.ProductAPI.DTOs;

namespace MarketConnect.ProductAPI.Services;

public interface IProductService
{
    Task<IEnumerable<ProductDTO>> GetProducts();
    Task<IEnumerable<ProductDTO>> GetProductsByPrice(decimal price);
    Task<ProductDTO> GetProductById(int id);
    Task AddProduct(ProductDTO product);
    Task UpdateProduct(ProductDTO product);
    Task RemoveProduct(int id);
}
