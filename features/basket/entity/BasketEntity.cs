namespace WebApplication1.features.basket.entity;

public class BasketEntity
{
    public string BasketId { get; set; }
    public string OrderId { get; set; }
    public string CoffeeName { get; set; }
    public string CoffeeSizeName { get; set; }
    public short CountSugar { get; set; }
    public short Quantity { get; set; }
    public string Path { get; set; }
    public float Price { get; set; }
}