namespace WebApplication1.features.coffe_size.entity;

public class CoffeeSizeUpdateEntity
{
    public string name { get; set; } = String.Empty;
    public short Percent { get; set; }
    public DateTime updateAt { get; } = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
}