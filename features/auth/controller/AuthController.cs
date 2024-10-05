using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.features.auth.entity;
using WebApplication1.features.auth.model;

namespace WebApplication1.features.auth.controller;

[Route("api/[controller]")]
[ApiController]
public class AuthController(UserManager<UserModel> userManager, ApplicationDbContext context) : ControllerBase
{
    private readonly UserManager<UserModel> _userManager = userManager;
    private ApplicationDbContext Context = context;
    
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterEntity registerEntity)
    {
        context.Roles.FindAsync();
        context.Users.FindAsync();
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new UserModel
            {
                UserName = registerEntity.Name,
                Login = registerEntity.Login,
            };

            var createUser = await _userManager.CreateAsync(user, registerEntity.Password);

            if (!createUser.Succeeded)
                return StatusCode(500, createUser.Errors);

            var roleResult = await _userManager.AddToRoleAsync(user, "USER");

            if (!createUser.Succeeded)
                return StatusCode(500, roleResult.Errors);


            Ok("User created");
        }
        catch (Exception e)
        {
            return StatusCode(500, e);
        }

        return StatusCode(500);
    }
}