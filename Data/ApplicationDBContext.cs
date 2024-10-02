using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplication1.model;

namespace WebApplication1.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : DbContext(dbContextOptions)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
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
        builder.Entity<CoffeSizeModel>().HasData(
            listCoffeSize
        );
    }

    public DbSet<CoffeSizeModel> CoffeSizes { get; set; }
    public DbSet<CoffeModel> Coffes { get; set; }
}