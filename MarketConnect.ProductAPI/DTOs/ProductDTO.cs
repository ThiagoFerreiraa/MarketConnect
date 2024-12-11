using MarketConnect.ProductAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MarketConnect.ProductAPI.DTOs;

public class ProductDTO
{
    public int Id { get; set; }

    //Data Annotacions
    [Required(ErrorMessage = "The Name is Required")]
    [MinLength(2)]
    [MaxLength(100)]
    public string? Name { get; set; }

    [Required(ErrorMessage = "The Price is Required")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "The Description is Required")]
    [MinLength(2)]
    [MaxLength(200)]
    public string? Description { get; set; }

    [Required(ErrorMessage = "The Stock is Required")]
    [Range(1,9999)]
    public long Stock { get; set; }
    public string? ImageURL { get; set; }
    public string? CategoryName { get; set; }

    //Propriedades de navegação
    [JsonIgnore] //Fazer esse atributo em especifico ser ignorado na serialização
    public Category? Category { get; set; }
    public int CategoryID { get; set; }
}
