using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.features.coffe_size.entity;
using WebApplication1.features.coffe_size.Mapper;
using WebApplication1.model;

namespace WebApplication1.features.coffe_size.Controller;

[Route("api/[controller]")]
[ApiController]
public class CoffeSizeController(ApplicationDbContext context) : ControllerBase
{
    [HttpGet("index")]
    public IActionResult index()
    {
        return Ok("CoffeSizeController");
    }

    [HttpGet]
    public IActionResult GetAllCoffeSize()
    {
        var result = context.CoffeSizes.Select(s => s.ToCoffeSizeDto()).ToList();
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetCoffeSizeById([FromRoute] int id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await context.CoffeSizes.FindAsync(id);
        if (result == null)
        {
            return NotFound();
        }

        return Ok(result.ToCoffeSizeDto());
    }

    [HttpPost]
    public async Task<IActionResult> CreateCoffeSize([FromBody] CoffeSizeCreateEntity request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        

        var model = request.ToCoffeSizeFromCreateDTO();
        await context.CoffeSizes.AddAsync(model);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetCoffeSizeById), new { id = model.id }, model.ToCoffeSizeDto());
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> UpdateCoffeSize([FromRoute] int id, [FromBody] CoffeSizeUpdateEntity request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var model = await context.CoffeSizes.FirstOrDefaultAsync(element => element.id == id);

        if (model == null)
        {
            return NotFound();
        }

        model.name = request.name;
        model.updateAt = request.updateAt;

        await context.SaveChangesAsync();

        return Ok(model.ToCoffeSizeDto());
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> DeleteCoffeSize([FromRoute] int id)
    {
        var result = await context.CoffeSizes.FirstOrDefaultAsync(element => element.id == id);
        if (result == null)
            return NotFound();

        context.CoffeSizes.Remove(result);
        await context.SaveChangesAsync();
        return NoContent();
    }
}