using EBook.Application.DTOs.AuthDTOs;

namespace EBook.Application.Interfaces;

public interface IAuthService
{
    Task<LoginResponse> LoginAsync(LoginRequest request);
    Task<bool> ValidateTokenAsync(string token);
    Task<string> GetUsernameFromTokenAsync(string token);
    Task<bool> ValidateCredentialsAsync(string username, string password);
}
