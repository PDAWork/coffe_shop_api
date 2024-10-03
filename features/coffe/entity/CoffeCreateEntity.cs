using System.ComponentModel.DataAnnotations;

namespace WebApplication1.features.coffe.entity;

public class CoffeCreateEntity
{
    [Required] public String name { get; set; } = String.Empty;
    [Required] public float price { get; set; }
}