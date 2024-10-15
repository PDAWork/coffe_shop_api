namespace WebApplication1.features.basket.model;

public class StatusOrderModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
    public DateTime UpdatedAt { get; set; } = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);

    public ICollection<OrderModel> Orders { get; set; } = new List<OrderModel>();
}
