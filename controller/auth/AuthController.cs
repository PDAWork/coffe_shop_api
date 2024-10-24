using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.features.auth.entity;
using WebApplication1.features.auth.model;
using WebApplication1.Service;

namespace WebApplication1.features.auth.controller;

[Route("api/[controller]")]
[ApiController]
public class AuthController(
    UserManager<UserModel> userManager,
    ITokenService tokenService,
    SignInManager<UserModel> signInManager,
    ApplicationDbContext context) : ControllerBase
{
    private readonly UserManager<UserModel> _userManager = userManager;
    private readonly ITokenService _tokenService = tokenService;
    private readonly SignInManager<UserModel> _signInManager = signInManager;
    private readonly ApplicationDbContext _context = context;


    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginEntity request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var user = _userManager.Users.FirstOrDefault(u => u.Email == request.Login);
        if (user == null) return Unauthorized("Invalid username!");

        var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);


        if (!result.Succeeded) return Unauthorized("Username not found and/or password incorrect");

        var roles = await _userManager.GetRolesAsync(user);

        string tokenRefreshToken = _tokenService.CreateRefreshToken(user, roles);
        string tokenAccessToken = _tokenService.CreateAccessToken(user);
        await GenerateRefreshToken(user, tokenAccessToken);
        await _context.SaveChangesAsync();

        return Ok(
            new UserEntity()
            {
                UserName = user.UserName,
                Email = user.Email,
                AccessToken = tokenAccessToken,
                RefreshToken = tokenRefreshToken
            }
        );
    }


    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterEntity registerEntity)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new UserModel
            {
                UserName = registerEntity.Name,
                Email = registerEntity.Login,
            };

            var createUser = await _userManager.CreateAsync(user, registerEntity.Password);

            if (!createUser.Succeeded)
                return StatusCode(500, createUser.Errors);

            var roleResult = await _userManager.AddToRoleAsync(user, "User");

            var roles = await _userManager.GetRolesAsync(user);

            if (!createUser.Succeeded)
                return StatusCode(500, roleResult.Errors);

            string tokenRefreshToken = _tokenService.CreateRefreshToken(user, roles);
            string tokenAccessToken = _tokenService.CreateAccessToken(user);
            await GenerateRefreshToken(user, tokenAccessToken);
            await _context.SaveChangesAsync();
            var response = new UserEntity
            {
                UserName = user.UserName,
                Email = user.Email,
                AccessToken = tokenAccessToken,
                RefreshToken = tokenRefreshToken
            };


            return Ok(response);
        }
        catch (Exception e)
        {
            return StatusCode(500, new { Message = e.Message, StackTrace = e.StackTrace });
        }
    }


    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken([FromBody] TokenEntity token)
    {
        var queryToken = _context.AccessTokens.FirstOrDefault(t => t.Token == token.AccessToken);

        if (queryToken == null)
        {
            return BadRequest("Invalid refresh token");
        }

        var queryUser = _context.Users.FirstOrDefault(u => u.Id == queryToken.UserId);
        var roles = await _userManager.GetRolesAsync(queryUser);

        _context.AccessTokens.Remove(queryToken);
        await _context.SaveChangesAsync();

        string tokenRefreshToken = _tokenService.CreateRefreshToken(queryUser, roles);
        string tokenAccessToken = _tokenService.CreateAccessToken(queryUser);
        await GenerateRefreshToken(queryUser, tokenAccessToken);
        await _context.SaveChangesAsync();

        var result = new RefreshTokenEntity
        {
            RefreshToken = tokenRefreshToken,
            AccessToken = tokenAccessToken
        };
        return Ok(result);
    }

    [Authorize]
    [HttpPost("logout")]
    public async Task<IActionResult> Logout([FromBody] TokenEntity request)
    {
        // Извлечение заголовка Authorization
        var authorizationHeader = HttpContext.Request.Headers["Authorization"].ToString();

        if (string.IsNullOrEmpty(authorizationHeader) || !authorizationHeader.StartsWith("Bearer "))
        {
            return BadRequest("Invalid or missing Authorization header");
        }

        // Извлечение токена из заголовка (убираем префикс "Bearer ")
        var token = authorizationHeader.Substring("Bearer ".Length).Trim();

        var tokenHandler = new JwtSecurityTokenHandler();

        // Чтение и парсинг токена
        var jwtToken = tokenHandler.ReadJwtToken(token);

        var isCheckToken = jwtToken.Claims.FirstOrDefault(options => options.Type == "role");
        if (isCheckToken == null)
            return Unauthorized("Invalid token");


        var queryRefreshTokenModel = _context.AccessTokens.FirstOrDefault(options => options.Token == token);

        if (queryRefreshTokenModel == null)
            return StatusCode(500, "Invalid token");


        _context.AccessTokens.Remove(queryRefreshTokenModel);

        await _context.SaveChangesAsync();

        return Ok();
    }


    private async Task<AccessTokenModel> GenerateRefreshToken(UserModel user, String token)
    {
        var refreshToken = new AccessTokenModel()
        {
            Token = token,
            Expiration = DateTime.SpecifyKind(DateTime.Now.AddDays(7), DateTimeKind.Utc), // Refresh токен на 7 дней
            UserId = user.Id
        };

        await _context.AccessTokens.AddAsync(refreshToken);
        return refreshToken;
    }
}