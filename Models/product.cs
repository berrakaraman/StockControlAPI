namespace EnvarterTakip.Models;

public class Product{
    public int id{get;set;}
    public required string Name{get;set;}
    public decimal Price { get; set; }
    public int Stock { get; set; }
}