using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.features.basket.model;

namespace WebApplication1.model;

public class CoffeeSizeModel
{
    // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public short Percent { get; set; } = 0;
    public DateTime CreateAt { get; set; } = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
    public DateTime UpdateAt { get; set; } = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);


    public ICollection<BasketModel> Baskets { get; set; } = new List<BasketModel>();
}