using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.model;

namespace WebApplication1.features.basket.model;

public class BasketModel
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    [Range(0, 3)] public short CountSugar { get; set; } = 0;
    [Range(1, 5)] public short Quantity { get; set; } = 1;
    

    public DateTime CreatedAt { get; set; } = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
    public DateTime UpdatedAt { get; set; } = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);

    public string OrderId { get; set; }
    public OrderModel Order { get; set; }
    
    public int CoffeeSizeId { get; set; }
    public CoffeeSizeModel CoffeeSize { get; set; }

    public long CoffeeId { get; set; }
    public CoffeeModel Coffee { get; set; }
}