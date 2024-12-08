using AutoMapper;
using MarketConnect.ProductAPI.DTOs;
using MarketConnect.ProductAPI.Models;
using MarketConnect.ProductAPI.Repositories;

namespace MarketConnect.ProductAPI.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IMapper mapper, IProductRepository productRepository)
    {
        _productRepository = productRepository;  
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductDTO>> GetProducts()
    {
        var productEntity = await _productRepository.GetAll();

        return _mapper.Map<IEnumerable<ProductDTO>>(productEntity);
    }
    public async Task<IEnumerable<ProductDTO>> GetProductsByPrice(decimal price)
    {
        var productEntity = await _productRepository.GetProductsByPrice(price);

        return _mapper.Map<IEnumerable<ProductDTO>>(productEntity);
    }
    public async Task<ProductDTO> GetProductById(int id)
    {
        var productEntity =  await _productRepository.GetProductById(id);

        return _mapper.Map<ProductDTO>(productEntity);
    }
    
    public async Task AddProduct(ProductDTO productDto)
    {
        var productEntity = _mapper.Map<Product>(productDto);

        await _productRepository.Create(productEntity);
        productDto.Id = productEntity.Id;
    }
    public async Task UpdateProduct(ProductDTO productDto)
    {
        var productEntity = _mapper.Map<Product>(productDto);

        await _productRepository.Update(productEntity);
    }
    public async Task RemoveProduct(int id)
    {
        var productEntity = _productRepository.GetProductById(id);

        await _productRepository.Delete(productEntity.Id);
    }
}
