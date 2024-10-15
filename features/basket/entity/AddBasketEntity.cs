using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApplication1.features.basket.entity;

public class AddBasketEntity
{
    [JsonIgnore] public string OrderId { get; set; } = "";
    [Required] [Range(1, int.MaxValue)] public long CoffeeId { get; set; }
    [Required] [Range(1, int.MaxValue)] public int CoffeeSize { get; set; }
    [Range(0, 10)] public short CountSugar { get; set; } = 0;
}