using WebApplication1.features.coffe_size.entity;
using WebApplication1.model;

namespace WebApplication1.features.coffe_size.Mapper;

public static class CoffeSizeMapper
{
    public static CoffeSizeModel ToCoffeSizeFromCreateDTO(this CoffeSizeCreateEntity coffeSize)
    {
        return new CoffeSizeModel()
        {
            name = coffeSize.name,
            createAt = coffeSize.createAt,
            updateAt = coffeSize.updateAt
        };
    }

    public static CoffeSizeEntity ToCoffeSizeDto(this CoffeSizeModel coffeSize)
    {
        return new CoffeSizeEntity
        {
            id = coffeSize.id,
            name = coffeSize.name,
            createAt = coffeSize.createAt,
            updateAt = coffeSize.updateAt,
        };
    }
}