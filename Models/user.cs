namespace EnvarterTakip.Models;

public class User{
    public int id { get; set; }  // Birincil anahtar
    public required string userName{get; set;}
    public required string surname{get; set;}
    public required string email{get; set;}
    public required string password{get;set;}
}