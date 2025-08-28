using EBook.Application.DTOs.AuthDTOs;
using EBook.Application.DTOs.JwtDTOs;
using EBook.Application.Interfaces;
using Microsoft.Extensions.Options;

namespace EBook.Infrastructure.Services;

public class AuthService : IAuthService
{
    private readonly IJwtService _jwtService;
    private readonly JwtSettings _jwtSettings;
    private readonly AdminCredentials _adminCredentials;

    public AuthService(IJwtService jwtService, IOptions<JwtSettings> jwtSettings, IOptions<AdminCredentials> adminCredentials)
    {
        _jwtService = jwtService;
        _jwtSettings = jwtSettings.Value;
        _adminCredentials = adminCredentials.Value;
    }

    public async Task<LoginResponse> LoginAsync(LoginRequest request)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
            {
                return new LoginResponse
                {
                    Token = null,
                    ExpiresAt = DateTime.MinValue,
                    Message = "You must give Username and Password data"
                };
            }

            var isValidCredentials = await ValidateCredentialsAsync(request.Username, request.Password);
            if (!isValidCredentials)
            {
                return new LoginResponse
                {
                    Token = null,
                    ExpiresAt = DateTime.MinValue,
                    Message = "Username or Password incorrect"
                };
            }

            var token = _jwtService.GenerateToken(request.Username);
            var expiresAt = DateTime.Now.AddMinutes(_jwtSettings.ExpiryInMinutes);

            return new LoginResponse
            {
                Token = token,
                ExpiresAt = expiresAt,
                Message = "Login successfully"
            };
        }
        catch (Exception ex)
        {
            return new LoginResponse
            {
                Token = null,
                ExpiresAt = DateTime.MinValue,
                Message = $"Login failed: {ex.Message}"
            };
        }
    }

    public async Task<bool> ValidateTokenAsync(string token)
    {
        return await Task.FromResult(_jwtService.ValidateToken(token));
    }

    public async Task<string> GetUsernameFromTokenAsync(string token)
    {
        return await Task.FromResult(_jwtService.GetUsernameFromToken(token));
    }

    public async Task<bool> ValidateCredentialsAsync(string username, string password)
    {
        return await Task.FromResult(username == _adminCredentials.Username && password == _adminCredentials.Password);
    }
}
