using WebApplication1.features.basket.model;

namespace WebApplication1.model;

public class CoffeeModel
{
    public long Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public float Price { get; set; } = 0.0f;
    public string Path { get; set; } = String.Empty;
    public DateTime CreateAt { get; set; } = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
    public DateTime UpdateAt { get; set; } = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);

    public ICollection<BasketModel> Baskets { get; set; } = new List<BasketModel>();
}