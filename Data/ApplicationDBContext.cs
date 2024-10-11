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


        List<CoffeModel> listCoffe = new List<CoffeModel>
        {
            new CoffeModel
            {
                id = 1,
                name = "Американо",
                price = 275,
                path = "85539d89-23ab-41bc-9267-0f86e35957f4.svg",
                createAt = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc),
                updateAt = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc)
            },
            new CoffeModel
            {
                id = 2,
                name = "Латте",
                price = 330,
                path = "5d5dc247-eba6-44d4-a87d-24475f7f40bf.svg",
                createAt = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc),
                updateAt = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc)
            },
            new CoffeModel
            {
                id = 3,
                name = "Эспрессо",
                price = 150,
                path = "635a7237-552b-459c-a304-6c32e6ba29fa.svg",
                createAt = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc),
                updateAt = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc)
            },

            new CoffeModel
            {
                id = 4,
                name = "Макиато",
                price = 365,
                path = "5779c99f-1228-42e7-ad32-b447d3f750a2.svg",
                createAt = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc),
                updateAt = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc)
            },
            new CoffeModel
            {
                id = 5,
                name = "Лунго",
                price = 350,
                path = "e80b89f0-09c2-4f31-85e7-c1ab61cb4cab.svg",
                createAt = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc),
                updateAt = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc)
            },
            new CoffeModel
            {
                id = 6,
                name = "Корретто",
                price = 365,
                path = "9760acfa-75a3-4b2a-b599-c6dc811c939c.svg",
                createAt = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc),
                updateAt = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc)
            },
            new CoffeModel
            {
                id = 7,
                name = "Эспрессо Романо",
                price = 200,
                path = "e0f2d3d9-17fc-4c90-bf76-49fa22d059e2.svg",
                createAt = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc),
                updateAt = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc)
            },
            new CoffeModel
            {
                id = 8,
                name = "Галан",
                price = 330,
                path = "b3355c87-de26-4c93-9673-dd725ea7757c.svg",
                createAt = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc),
                updateAt = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc)
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