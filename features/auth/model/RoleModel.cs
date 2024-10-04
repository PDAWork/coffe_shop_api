using Microsoft.AspNetCore.Identity;

namespace WebApplication1.features.auth.model;

public class RoleModel : IdentityRole
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreateAt { get; set; } = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
    public DateTime UpdateAt { get; set; } = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);

    public ICollection<UserModel> Users { get; set; } = new List<UserModel>();

    public static RoleModel RoleUser()
    {
        return new RoleModel
        {
            Name = "USER"
        };
    }
}