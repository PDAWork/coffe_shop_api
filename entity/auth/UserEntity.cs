namespace WebApplication1.features.auth.entity;

public class UserEntity
{
    public string UserName { get; set; }
    public string Email { get; set; }
    //короткоживущий токен для доступа к API (обычно живет 15-60 минут).
    public string RefreshToken { get; set; } 
    //долговечный токен, который используется
    // для получения нового access token, когда срок действия старого истекает.
    public string AccessToken { get; set; }
}