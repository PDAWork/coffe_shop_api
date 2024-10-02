using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.features.coffe.entity;
using WebApplication1.features.coffe.Mapper;

namespace WebApplication1.features.coffe.controller;

[Route("api/[controller]")]
[ApiController]
public class CoffeController(ApplicationDbContext context) : ControllerBase
{
    [HttpGet("index")]
    public IActionResult index()
    {
        return Ok("CoffeController");
    }

    [HttpGet]
    public IActionResult GetAllCoffeeSize()
    {
        List<CoffeEntity> entity = context.Coffes.Select(s => s.ToCoffeEntity()).ToList();
        return Ok(entity);
    }
}