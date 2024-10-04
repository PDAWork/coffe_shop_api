using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.features.auth.entity;
using WebApplication1.features.auth.model;

namespace WebApplication1.features.auth.controller;


[Route("api/[controller]")]
[ApiController]
public class AuthController: ControllerBase
{
    private readonly UserManager<UserModel> _userManager;

    public AuthController(UserManager<UserModel> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IActionResult> Register([FromBody] RegisterEntity registerEntity)
    {
        
    }
}