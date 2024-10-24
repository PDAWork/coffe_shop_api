using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.features.basket.enums;
using WebApplication1.features.basket.mapper;
using WebApplication1.Service;

namespace WebApplication1.controller.order;

[Route("api/[controller]")]
[ApiController]
public class OrderController(ITokenService tokenService, ApplicationDbContext context) : ControllerBase
{
    private readonly ApplicationDbContext _context = context;
    private readonly ITokenService _tokenService = tokenService;

    [HttpGet("index")]
    public IActionResult index()
    {
        return Ok("OrderController");
    }


    [HttpGet("history")]
    [Authorize]
    public async Task<IActionResult> HistoryOrders()
    {
        if (!User.Identity.IsAuthenticated)
        {
            return Unauthorized();
        }

        string UserId = User.FindFirst(options => options.Type == JwtRegisteredClaimNames.Sid)?.Value;

        var queryOrders = _context.Orders
            .Include(order => order.Baskets)
            .ThenInclude(basket => basket.Coffee)
            .Include(order => order.Baskets)
            .ThenInclude(basket => basket.CoffeeSize)
            .Where(x => x.UserId == UserId && x.StatusOrderId == (int)StatusOrderEnum.Confirmed)
            .Select(order => new
            {
                OrderId = order.Id,
                CreatedAt = order.CreatedAt,
                Sum = order.Baskets
                    .Select(basket => basket.Coffee.Price + basket.CoffeeSize.Percent).Sum(),
                Basket = order.Baskets
                    .Select(basket => basket.ToBasketDTO(HttpContext))
            }).Skip(0).Take(10);

        return Ok(queryOrders);
    }
}