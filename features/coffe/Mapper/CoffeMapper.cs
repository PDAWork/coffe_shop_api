using WebApplication1.features.coffe.entity;
using WebApplication1.model;

namespace WebApplication1.features.coffe.Mapper;

public static class CoffeMapper
{
    public static CoffeeEntity ToCoffeEntity(this CoffeeModel model,HttpContext httpContext)
    {
        return new CoffeeEntity
        {
            Id = model.Id,
            Name = model.Name,
            Path =$"{httpContext.Request.Scheme}://{httpContext.Request.Host}/images/{model.Path}",
            Price =model.Price ,
            CreateAt = model.CreateAt,
            UpdateAt = model.UpdateAt
        };
    }

    public static CoffeeModel ToCoffeFromCreateEntity(this CoffeCreateEntity entity ,String pathImage)
    {
        return new CoffeeModel
        {
            Name = entity.name,
            Price = entity.price,
            Path = pathImage,
        };
    }
}