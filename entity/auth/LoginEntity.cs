using System.ComponentModel.DataAnnotations;

namespace WebApplication1.features.auth.entity;

public class LoginEntity
{
    [Required] 
    public string Login { get; set; }
    [Required] 
    public string Password { get; set; }
}