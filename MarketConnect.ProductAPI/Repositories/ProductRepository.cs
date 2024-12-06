using MarketConnect.ProductAPI.Context;
using MarketConnect.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MarketConnect.ProductAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            var value = await _context.Products.ToListAsync();

            return value;
        }

        public async Task<IEnumerable<Product>> GetProductsByPrice(decimal price)
        {
            var value = await _context.Products.Where(p => p.Price == price).ToListAsync();

            return value;
        }

        public async Task<Product> GetProductById(int id)
        {
            var value = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();

            return value;
        }

        public async Task<Product> GetProductByName(string name)
        {
            var value = await _context.Products.Where(p => p.Name == name).FirstOrDefaultAsync();

            return value;
        }

        public async Task<Product> Create(Product product)
        {
            //Usando forma diferente para fazer um insert
            _context.Entry(product).State = EntityState.Added;
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<Product> Update(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<Product> Delete(int id)
        {
            var product = await GetProductById(id);

            _context.Entry(product).State = EntityState.Deleted;
            await _context.SaveChangesAsync();

            return product;
        }

    }
}
