using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.features.coffe.controller;

[Route("api/[controller]")]
[ApiController]
public class CoffeController : ControllerBase
{
    [HttpGet("index")]
    public IActionResult index()
    {
        return Ok("CoffeController");
    }
}