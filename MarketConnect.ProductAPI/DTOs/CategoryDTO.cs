using MarketConnect.ProductAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace MarketConnect.ProductAPI.DTOs;

public class CategoryDTO
{
    public int CategoryId { get; set; }

    //Data Annotacions
    [Required(ErrorMessage = "The Name is Required")]
    [MinLength(2)]
    [MaxLength(100)]
    public string? Name { get; set; }

    //Propriedades de navegação
    public ICollection<Product>? Products { get; set; }
}
