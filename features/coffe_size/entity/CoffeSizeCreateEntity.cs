using WebApplication1.model;

namespace WebApplication1.features.coffe_size.entity;

public class CoffeSizeCreateEntity
{
    public String name { get; set; } = String.Empty;
    public short Percent { get; set; }
    public DateTime createAt { get; } = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
    public DateTime updateAt { get; } = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
}