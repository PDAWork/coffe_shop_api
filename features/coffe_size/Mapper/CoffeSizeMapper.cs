using WebApplication1.features.coffe_size.entity;
using WebApplication1.model;

namespace WebApplication1.features.coffe_size.Mapper;

public static class CoffeSizeMapper
{
    public static CoffeeSizeModel ToCoffeSizeFromCreateDTO(this CoffeSizeCreateEntity coffeeSize)
    {
        return new CoffeeSizeModel()
        {
            Name = coffeeSize.name,
            Percent = coffeeSize.Percent,
            CreateAt = coffeeSize.createAt,
            UpdateAt = coffeeSize.updateAt
        };
    }

    public static CoffeeSizeEntity ToCoffeSizeDto(this CoffeeSizeModel coffeeSize)
    {
        return new CoffeeSizeEntity
        {
            Id = coffeeSize.Id,
            Name = coffeeSize.Name,
            CreateAt = coffeeSize.CreateAt,
            UpdateAt = coffeeSize.UpdateAt,
        };
    }
}
