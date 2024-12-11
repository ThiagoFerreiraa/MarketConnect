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

        /*
            Explicando o Include em GetAll e em GetProductsByPrice:
        
            Bem, como eu acabei mudando o mapeamento no MappingProfile, possibilitando agora que insira no atributo CategoryName o valor de Category.Name, eu preciso mudar nos metodos de busca, para que realize o Join no select (Include) que assim o retorno da consulta vai trazer o nome da categoria
         
        */

        public async Task<IEnumerable<Product>> GetAll()
        {
            var value = await _context.Products.Include(c => c.Category).ToListAsync();

            return value;
        }

        public async Task<IEnumerable<Product>> GetProductsByPrice(decimal price)
        {
            var value = await _context.Products.Include(c => c.Category).Where(p => p.Price == price).ToListAsync();

            return value;
        }

        public async Task<Product> GetProductById(int id)
        {
            var value = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();

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
