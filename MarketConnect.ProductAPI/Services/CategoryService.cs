using AutoMapper;
using MarketConnect.ProductAPI.DTOs;
using MarketConnect.ProductAPI.Models;
using MarketConnect.ProductAPI.Repositories;

namespace MarketConnect.ProductAPI.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(IMapper mapper, ICategoryRepository categoryRepository)
    {
        _mapper = mapper;
        _categoryRepository = categoryRepository;
    }

    public async Task<IEnumerable<CategoryDTO>> GetCategories()
    {
        var categoriesEntity = await _categoryRepository.GetAll();

        return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
    }

    public async Task<IEnumerable<CategoryDTO>> GetCategoriesProducts()
    {
        var categoriesProductsEntity = await _categoryRepository.GetCategoriesProducts();

        return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesProductsEntity);
    }

    public async Task<CategoryDTO> GetCategoryById(int id)
    {
        var categoryById =  await _categoryRepository.GetCategoryById(id);

        return _mapper.Map<CategoryDTO>(categoryById);
    }

    public async Task AddCategory(CategoryDTO categoryDto)
    {
        var categoryEntity = _mapper.Map<Category>(categoryDto);

        await _categoryRepository.Create(categoryEntity);
        categoryDto.CategoryId = categoryEntity.CategoryId;
    }

    public async Task UpdateCategory(CategoryDTO categoryDto)
    {
        var categoryEntity = _mapper.Map<Category>(categoryDto);

        await _categoryRepository.Update(categoryEntity);
    }

    public async Task RemoveCategory(int id)
    {
        var categoryEntity = _categoryRepository.GetCategoryById(id);

        await _categoryRepository.Delete(categoryEntity.Id);
    }
}
