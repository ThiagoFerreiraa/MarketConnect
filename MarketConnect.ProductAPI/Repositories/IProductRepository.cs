using MarketConnect.ProductAPI.Models;

namespace MarketConnect.ProductAPI.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAll();
    Task<IEnumerable<Product>> GetProductsByPrice(decimal price);
    Task<Product> GetProductById(int id);
    Task<Product> GetProductByName(string name);
    Task<Product> Create(Product product);
    Task<Product> Update(Product product);
    Task<Product> Delete(int id);

}
