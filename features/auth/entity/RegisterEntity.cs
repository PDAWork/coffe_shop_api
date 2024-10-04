using System.ComponentModel.DataAnnotations;

namespace WebApplication1.features.auth.entity;

public class RegisterEntity
{
    [Required]
    public string Name { get; set; }
    [Required]
    [EmailAddress]
    public string Login { get; set; }
    [Required]
    public string Password { get; set; }
}