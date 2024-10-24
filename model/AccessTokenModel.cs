namespace WebApplication1.features.auth.model;

public class AccessTokenModel
{
    public int Id { get; set; }
    public string Token { get; set; }
    public DateTime Expiration { get; set; }
    public bool IsRevoked { get; set; } = false;
    public string UserId { get; set; } // Связь с пользователем
   
    public UserModel User { get; set; }
}