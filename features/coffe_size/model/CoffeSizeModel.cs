using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.model;

public class CoffeSizeModel
{
    // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }
    public string name { get; set; } = string.Empty;
    public DateTime createAt { get; set; } = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
    public DateTime updateAt { get; set; } = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
}