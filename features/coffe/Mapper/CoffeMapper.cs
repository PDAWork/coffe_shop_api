using WebApplication1.features.coffe.entity;
using WebApplication1.model;

namespace WebApplication1.features.coffe.Mapper;

public static class CoffeMapper
{
    public static CoffeEntity ToCoffeEntity(this CoffeModel model,HttpContext httpContext)
    {
        return new CoffeEntity
        {
            id = model.id,
            name = model.name,
            path =$"{httpContext.Request.Scheme}://{httpContext.Request.Host}/images/{model.path}",
            price =model.price ,
            createAt = model.createAt,
            updateAt = model.updateAt
        };
    }

    public static CoffeModel ToCoffeFromCreateEntity(this CoffeCreateEntity entity ,String pathImage)
    {
        return new CoffeModel
        {
            name = entity.name,
            price = entity.price,
            path = pathImage,
        };
    }
}