namespace BasicShop.Api.Models;

public class Cart
{
    public int Id { get; set; }
    public List<Item>? Items { get; set; }
}
