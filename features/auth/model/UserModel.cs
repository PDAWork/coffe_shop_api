using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace WebApplication1.features.auth.model;

public class UserModel() : IdentityUser
{
    public long Id { get; set; }
    public string RefreshToken { get; set; } = String.Empty;
    public string SuccessToken { get; set; } = String.Empty;
    public DateTime CreateAt { get; set; } = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
    public DateTime UpdateAt { get; set; } = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);

}