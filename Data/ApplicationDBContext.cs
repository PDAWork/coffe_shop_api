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

      
        
        // Create Relation OneToMany User -> Role
        // builder.Entity<UserModel>()
        //     .HasOne(u => u.Role) // Один пользователь имеет одну роль
        //     .WithMany(r => r.Users) // У одной роли много пользователей
        //     .HasForeignKey(u => u.RoleId);


        List<RoleModel> listRole =
        [
            new RoleModel
            {
                Id = Guid.NewGuid().ToString(),
                Name = "ADMIN",
                NormalizedName = "Admin"
            },

            new RoleModel
            {
                Id = Guid.NewGuid().ToString(),
                Name = "USER",
                NormalizedName = "User"
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
    }

    public DbSet<CoffeSizeModel> CoffeSizes { get; set; }
    public DbSet<CoffeModel> Coffes { get; set; }

    public DbSet<RoleModel> Roles { get; set; }
    public DbSet<UserModel> Users { get; set; }
}