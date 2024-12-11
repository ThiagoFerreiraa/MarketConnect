using AutoMapper;
using MarketConnect.ProductAPI.Models;

namespace MarketConnect.ProductAPI.DTOs.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<ProductDTO, Product>();
            CreateMap<Product, ProductDTO>().ForMember(x => x.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
        }

        /*
            Explicando o ForMember:
            
            Eu utilizo ele quando eu for criar um atributo a mais no DTO e o valor dele vai vir de um retorno de outro atributo, por exemplo eu tenho o retorno de Category no ProductDTO, e tenho um atributo dentro do ProductDTO chamado CategoryName, e com esse mapeamento eu passo para o sistema a seguinte mensagem.

            "quando trouxer os valores de Category, pegue o atribuito Name desse objeto (Category) e insira no atributo CategoryName presente no meu objeto (ProductDTO)"
         
        */
    }
}
