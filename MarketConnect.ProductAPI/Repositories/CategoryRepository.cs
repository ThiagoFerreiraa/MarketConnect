using MarketConnect.ProductAPI.Context;
using MarketConnect.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MarketConnect.ProductAPI.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            var value = await _context.Categories.ToListAsync();

            return value;
        }

        public async Task<Category> GetCategoryById(int id)
        {
            var value = await _context.Categories.Where(c => c.CategoryId == id).FirstOrDefaultAsync();

            return value;
        }

        public async Task<IEnumerable<Category>> GetCategoriesProducts()
        {
            var value = await _context.Categories.Include(c => c.Products).ToListAsync();

            return value;
        }

        public async Task<Category> Create(Category category)
        {
            _context.Categories.Add(category); 
            await _context.SaveChangesAsync();

            return category;
        }
        public async Task<Category> Update(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return category;
        }

        public async Task<Category> Delete(int id)
        {
            var category = await GetCategoryById(id);
            _context.Categories.Remove(category);

            return category;
        }  
    }
}
