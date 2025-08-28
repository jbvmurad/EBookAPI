namespace EBook.Application.Interfaces;

public interface IJwtService
{
    string GenerateToken(string username);
    string GetUsernameFromToken(string token);
    bool ValidateToken(string token);
    bool ValidateAdminCredentials(string username, string password);
}
