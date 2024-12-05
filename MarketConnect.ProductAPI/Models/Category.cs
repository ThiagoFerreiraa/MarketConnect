namespace MarketConnect.ProductAPI.Models;

public class Category
{
    public int CategoryId { get; set; }
    public string? Name { get; set; }

    //Propriedades de navegação
    public ICollection<Product>? Products { get; set; }
}
