using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.features.auth.model;
using WebApplication1.features.basket.model;
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

        List<CoffeeSizeModel> listCoffeSize = new List<CoffeeSizeModel>()
        {
            new CoffeeSizeModel
            {
                Id = 1,
                Name = "S",
                Percent = 0
            },
            new CoffeeSizeModel
            {
                Id = 2,
                Name = "M",
                Percent = 20
            },
            new CoffeeSizeModel
            {
                Id = 3,
                Name = "L",
                Percent = 30
            }
        };


        List<CoffeeModel> listCoffe = new List<CoffeeModel>
        {
            new CoffeeModel
            {
                Id = 1,
                Name = "Американо",
                Price = 275,
                Path = "85539d89-23ab-41bc-9267-0f86e35957f4.svg",
            },
            new CoffeeModel
            {
                Id = 2,
                Name = "Латте",
                Price = 330,
                Path = "5d5dc247-eba6-44d4-a87d-24475f7f40bf.svg",
            },
            new CoffeeModel
            {
                Id = 3,
                Name = "Эспрессо",
                Price = 150,
                Path = "635a7237-552b-459c-a304-6c32e6ba29fa.svg",
            },

            new CoffeeModel
            {
                Id = 4,
                Name = "Макиато",
                Price = 365,
                Path = "5779c99f-1228-42e7-ad32-b447d3f750a2.svg",
            },
            new CoffeeModel
            {
                Id = 5,
                Name = "Лунго",
                Price = 350,
                Path = "e80b89f0-09c2-4f31-85e7-c1ab61cb4cab.svg",
            },
            new CoffeeModel
            {
                Id = 6,
                Name = "Корретто",
                Price = 365,
                Path = "9760acfa-75a3-4b2a-b599-c6dc811c939c.svg",
            },
            new CoffeeModel
            {
                Id = 7,
                Name = "Эспрессо Романо",
                Price = 200,
                Path = "e0f2d3d9-17fc-4c90-bf76-49fa22d059e2.svg",
            },
            new CoffeeModel
            {
                Id = 8,
                Name = "Галан",
                Price = 330,
                Path = "b3355c87-de26-4c93-9673-dd725ea7757c.svg",
            }
        };

        List<StatusOrderModel> listStatus = new List<StatusOrderModel>
        {
            new StatusOrderModel
            {
                Id = 1,
                Name = "Pending"
            },
            new StatusOrderModel
            {
                Id = 2,
                Name = "Confirmed",
            }
        };


        builder.Entity<RoleModel>().HasData(listRole);
        builder.Entity<CoffeeSizeModel>().HasData(listCoffeSize);
        builder.Entity<CoffeeModel>().HasData(listCoffe);
        builder.Entity<StatusOrderModel>().HasData(listStatus);

        // Настройка связи один ко многим между UserModel и RefreshTokenModel
        builder.Entity<UserModel>()
            .HasMany(u => u.AccessTokens)
            .WithOne(rt => rt.User)
            .HasForeignKey(rt => rt.UserId)
            .OnDelete(DeleteBehavior.Cascade);


        builder.Entity<OrderModel>()
            .HasOne(order => order.Status)
            .WithMany(rt => rt.Orders)
            .HasForeignKey(rt => rt.StatusOrderId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<OrderModel>()
            .HasOne(order => order.User)
            .WithMany(rt => rt.Orders)
            .HasForeignKey(rt => rt.UserId)
            .OnDelete(DeleteBehavior.Cascade);


        builder.Entity<BasketModel>()
            .HasOne(order => order.Order)
            .WithMany(rt => rt.Baskets)
            .HasForeignKey(rt => rt.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<BasketModel>()
            .HasOne(order => order.CoffeeSize)
            .WithMany(rt => rt.Baskets)
            .HasForeignKey(rt => rt.CoffeeSizeId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<BasketModel>()
            .HasOne(order => order.Coffee)
            .WithMany(rt => rt.Baskets)
            .HasForeignKey(rt => rt.CoffeeId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    public DbSet<CoffeeSizeModel> CoffeSizes { get; set; }
    public DbSet<CoffeeModel> Coffes { get; set; }

    public DbSet<RoleModel> Roles { get; set; }
    public DbSet<UserModel> Users { get; set; }
    public DbSet<AccessTokenModel> AccessTokens { get; set; }

    public DbSet<StatusOrderModel> StatusOrders { get; set; }
    public DbSet<OrderModel> Orders { get; set; }
    public DbSet<BasketModel> Baskets { get; set; }
}