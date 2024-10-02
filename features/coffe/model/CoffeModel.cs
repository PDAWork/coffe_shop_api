namespace WebApplication1.model;

public class CoffeModel
{
    public long id { get; set; }
    public string name { get; set; } = String.Empty;
    public float price { get; set; } = 0.0f;
    public string path { get; set; } = String.Empty;
    public DateTime createAt { get; set; } = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
    public DateTime updateAt { get; set; } = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
}