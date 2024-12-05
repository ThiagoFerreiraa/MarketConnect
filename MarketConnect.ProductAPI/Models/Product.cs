namespace MarketConnect.ProductAPI.Models;

public class Product
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public long Stock { get; set; }
    public string? ImageURL { get; set; }

    //Propriedades de navegação
    public Category? Category { get; set; }
    public int CategoryID { get; set; }
}
