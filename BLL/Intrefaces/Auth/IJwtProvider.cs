namespace BLL.Intrefaces.Auth;

public interface IJwtProvider
{
    string GenerateToken(Guid userId, string role, string email);
}