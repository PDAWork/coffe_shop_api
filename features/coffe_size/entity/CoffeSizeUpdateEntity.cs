namespace WebApplication1.features.coffe_size.entity;

public class CoffeSizeUpdateEntity
{
    public string name { get; set; } = String.Empty;
    public DateTime updateAt { get; } = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
}