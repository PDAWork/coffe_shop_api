using WebApplication1.features.coffe.entity;
using WebApplication1.model;

namespace WebApplication1.features.coffe.Mapper;

public static class CoffeMapper
{
    public static CoffeEntity ToCoffeEntity(this CoffeModel model)
    {
        return new CoffeEntity
        {
            id = model.id,
            name = model.name,
            path = model.path,
            price = model.price,
            createAt = model.createAt,
            updateAt = model.updateAt
        };
    }
}