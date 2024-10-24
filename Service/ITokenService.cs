using Microsoft.AspNetCore.Mvc;
using WebApplication1.features.auth.model;

namespace WebApplication1.Service;

public interface ITokenService
{
    // Метод для создания токена Access
    string CreateRefreshToken(UserModel user, IList<String> roles);
    string CreateAccessToken(UserModel user);
}