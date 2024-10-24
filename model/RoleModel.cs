using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace WebApplication1.features.auth.model;

public class RoleModel : IdentityRole
{
    public DateTime CreateAt { get; set; } = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
    public DateTime UpdateAt { get; set; } = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
}