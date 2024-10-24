using WebApplication1.features.auth.model;

namespace WebApplication1.features.basket.model;

public class OrderModel
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public DateTime CreatedAt { get; set; } = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
    public DateTime UpdatedAt { get; set; } = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);

    public string UserId { get; set; }
    public UserModel User { get; set; }

    public int StatusOrderId { get; set; }
    public StatusOrderModel Status { get; set; }

    public ICollection<BasketModel> Baskets { get; set; } = new List<BasketModel>();
}