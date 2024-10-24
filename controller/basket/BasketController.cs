using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebApplication1.Data;
using WebApplication1.features.auth.model;
using WebApplication1.features.basket.entity;
using WebApplication1.features.basket.enums;
using WebApplication1.features.basket.mapper;
using WebApplication1.features.basket.model;

namespace WebApplication1.features.basket.controller;

[Route("api/[controller]")]
[ApiController]
public class BasketController(ApplicationDbContext context) : ControllerBase
{
    private readonly ApplicationDbContext _context = context;


    private String getUserIdToken()
    {
        var authorizationHeader = HttpContext.Request.Headers["Authorization"].ToString();

        if (string.IsNullOrEmpty(authorizationHeader) || !authorizationHeader.StartsWith("Bearer "))
        {
            throw new Exception("Invalid Authorization Header");
        }

        var token = authorizationHeader.Substring("Bearer ".Length).Trim();

        var tokenHandler = new JwtSecurityTokenHandler();

        // Чтение и парсинг токена
        var jwtToken = tokenHandler.ReadJwtToken(token);

        var tokenUserId = jwtToken.Claims.FirstOrDefault(options => options.Type == JwtRegisteredClaimNames.Sid);
        if (tokenUserId == null)
            throw new UnauthorizedAccessException();

        return tokenUserId.Value;
    }

    [HttpGet("index")]
    public IActionResult index()
    {
        return Ok("BasketController");
    }


    [HttpGet]
    [Authorize(Roles = "User")]
    public async Task<IActionResult> GetAllBasketUser()
    {
        string userId;

        try
        {
            userId = getUserIdToken();
        }
        catch (UnauthorizedAccessException)
        {
            return Unauthorized(); // Возвращаем 401 Unauthorized
        }
        catch (Exception e)
        {
            return BadRequest(e.Message); // Возвращаем 400 Bad Request
        }

        var queryBasket =
            _context
                .Baskets
                .Include(basket => basket.Coffee)
                .Include(basket => basket.Order)
                .Include(basket => basket.CoffeeSize)
                .Where(x => x.Order.UserId == userId && x.Order.StatusOrderId == (int)StatusOrderEnum.InProgress)
                .Select(basket => basket.ToBasketDTO(HttpContext)
                );

        // var test = await _context.Orders
        //     .Include(order => order.Baskets)
        //     .ThenInclude(basket =>
        //         basket.Coffee
        //     )
        //     .Include(order => order.Baskets)
        //     .ThenInclude(basket =>
        //         basket.CoffeeSize
        //     )
        //     .Where(x => x.UserId == userId && x.StatusOrderId == (int)StatusOrderEnum.InProgress)
        //     .Select(order => new
        //     {
        //         OrderId = order.Id,
        //         basket = order.Baskets
        //             .Select(basket => basket.ToBasketDTO(HttpContext))
        //     }).FirstOrDefaultAsync();

        return Ok(queryBasket);
    }


    [HttpPost]
    public async Task<IActionResult> AddBasketElementUser([FromBody] AddBasketEntity request)
    {
        string userId;
        string orderId;
        string basketId;

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            userId = getUserIdToken();
        }
        catch (UnauthorizedAccessException)
        {
            return Unauthorized(); // Возвращаем 401 Unauthorized
        }
        catch (Exception e)
        {
            return BadRequest(e.Message); // Возвращаем 400 Bad Request
        }


        var queryOrder = await _context.Orders.FirstOrDefaultAsync(x =>
            x.UserId == userId && x.StatusOrderId == (int)StatusOrderEnum.InProgress);


        if (queryOrder == null)
        {
            var order = await _context.Orders.AddAsync(
                new OrderModel
                {
                    UserId = userId,
                    StatusOrderId = (int)StatusOrderEnum.InProgress
                }
            );
            orderId = order.Entity.Id;
            request.OrderId = orderId;
            var model = await _context.Baskets.AddAsync(request.ToBasketFromCreateDTO());
            basketId = model.Entity.Id;
        }
        else
        {
            orderId = queryOrder.Id;
            request.OrderId = orderId;
            var queryBasket = await _context.Baskets
                .FirstOrDefaultAsync(basket =>
                    basket.OrderId == orderId &&
                    basket.CoffeeId == request.CoffeeId &&
                    basket.CoffeeSizeId == request.CoffeeSize);

            if (queryBasket == null)
            {
                var model = await _context.Baskets.AddAsync(request.ToBasketFromCreateDTO());
                basketId = model.Entity.Id;
            }
            else
            {
                basketId = queryBasket.Id;
                queryBasket.Quantity++;
            }
        }


        await _context.SaveChangesAsync();
        var result = await _context.Baskets
            .Include(basket => basket.Order)
            .Include(basket => basket.Coffee)
            .Include(basket => basket.CoffeeSize)
            .FirstOrDefaultAsync(basket => basket.Id == basketId);

        return Ok(result.ToBasketDTO(HttpContext));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateBasketElementUser([FromBody] UpdateElementBasketEntity request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var queryBasket = await _context.Baskets
            .Include(basket => basket.Order)
            .Include(basket => basket.Coffee)
            .Include(basket => basket.CoffeeSize).FirstOrDefaultAsync(basket => basket.Id == request.BasketId);

        if (queryBasket == null)
        {
            return BadRequest();
        }

        queryBasket.CoffeeId = request.CoffeeId;
        queryBasket.CoffeeSizeId = request.CoffeeSizeId;
        queryBasket.CountSugar = request.CountSugar;

        await _context.SaveChangesAsync();
        var result =
            _context
                .Baskets
                .Include(basket => basket.Coffee)
                .Include(basket => basket.Order)
                .Include(basket => basket.CoffeeSize)
                .Where(x => x.Id == queryBasket.Id)
                .Select(basket => basket.ToBasketDTO(HttpContext)
                );

        return Ok(result);
    }


    [HttpPut("count")]
    public async Task<IActionResult> UpdateCountBasketElementUser([FromBody] UpdateCountBasketEntity request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var queryBasket = await _context.Baskets
            .Include(basket => basket.Order)
            .Include(basket => basket.Coffee)
            .Include(basket => basket.CoffeeSize).FirstOrDefaultAsync(basket => basket.Id == request.BasketId);

        if (queryBasket == null)
        {
            return BadRequest();
        }

        queryBasket.Quantity = request.isCheckUpOrDown ? ++queryBasket.Quantity : --queryBasket.Quantity;

        if (queryBasket.Quantity == 0)
        {
            _context.Baskets.Remove(queryBasket);
        }

        await _context.SaveChangesAsync();

        return Ok(queryBasket.ToBasketDTO(HttpContext));
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteBasketElementUser(string id)
    {
        var queryBasket = await _context.Baskets.FirstOrDefaultAsync(basket => basket.Id == id);

        if (queryBasket == null)
        {
            return BadRequest();
        }

        _context.Remove(queryBasket);
        await _context.SaveChangesAsync();

        return Ok();
    }
}