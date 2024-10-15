using WebApplication1.features.basket.entity;
using WebApplication1.features.basket.model;

namespace WebApplication1.features.basket.mapper;

public static class BasketMapper
{
    public static BasketModel ToBasketFromCreateDTO(this AddBasketEntity entity)
    {
        return new BasketModel
        {
            OrderId = entity.OrderId,
            CoffeeId = entity.CoffeeId,
            CountSugar = entity.CountSugar,
            CoffeeSizeId = entity.CoffeeSize,
        };
    }

    public static BasketEntity ToBasketDTO(this BasketModel model, HttpContext httpContext)
    {
        return new BasketEntity
        {
            BasketId = model.Id,
            OrderId = model.OrderId,
            CoffeeName = model.Coffee.Name,
            CoffeeSizeName = model.CoffeeSize.Name,
            CountSugar = model.CountSugar,
            Quantity = model.Quantity,
            Price = model.Coffee.Price + model.CoffeeSize.Percent,
            Path = $"{httpContext.Request.Scheme}://{httpContext.Request.Host}/images/{model.Coffee.Path}",
        };
    }
}