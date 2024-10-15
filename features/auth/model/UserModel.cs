using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using WebApplication1.features.basket.model;

namespace WebApplication1.features.auth.model;

public class UserModel() : IdentityUser
{
    public DateTime CreateAt { get; set; } = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
    public DateTime UpdateAt { get; set; } = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);

    public ICollection<AccessTokenModel> AccessTokens { get; set; } = new List<AccessTokenModel>();

    public ICollection<OrderModel> Orders { get; set; } = new List<OrderModel>();
}