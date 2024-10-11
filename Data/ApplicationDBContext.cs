using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.features.auth.model;
using WebApplication1.model;

namespace WebApplication1.Data;

public class ApplicationDbContext(DbContextOptions dbContextOptions)
    : IdentityDbContext<UserModel, RoleModel, string>(dbContextOptions)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        List<RoleModel> listRole =
        [
            new RoleModel
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Admin",
                NormalizedName = "ADMIN"
            },

            new RoleModel
            {
                Id = Guid.NewGuid().ToString(),
                Name = "User",
                NormalizedName = "USER"
            }
        ];

        List<CoffeSizeModel> listCoffeSize = new List<CoffeSizeModel>()
        {
            new CoffeSizeModel
            {
                id = 1,
                name = "S",
            },
            new CoffeSizeModel
            {
                id = 2,
                name = "M",
            },
            new CoffeSizeModel
            {
                id = 3,
                name = "L",
            }
        };
        builder.Entity<RoleModel>().HasData(
            listRole
        );
        builder.Entity<CoffeSizeModel>().HasData(
            listCoffeSize
        );
        
        // Настройка связи один ко многим между UserModel и RefreshTokenModel
        builder.Entity<UserModel>()
            .HasMany(u => u.AccessTokens)
            .WithOne(rt => rt.User)
            .HasForeignKey(rt => rt.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    public DbSet<CoffeSizeModel> CoffeSizes { get; set; }
    public DbSet<CoffeModel> Coffes { get; set; }

    public DbSet<RoleModel> Roles { get; set; }
    public DbSet<UserModel> Users { get; set; }
    public DbSet<AccessTokenModel> AccessTokens { get; set; }
}