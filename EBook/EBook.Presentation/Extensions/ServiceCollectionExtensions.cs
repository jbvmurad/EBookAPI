using EBook.Application.DTOs.AuthDTOs;
using EBook.Application.DTOs.JwtDTOs;
using EBook.Application.DTOs.MongoDbDTO;
using EBook.Application.Interfaces;
using EBook.Infrastructure.Services;
using EBook.Persistance.Context;
using EBook.Persistance.Mapping;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace EBook.Presentation.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddSwaggerGen();
        services.AddConfigurationSettings(configuration);
        services.AddDatabaseServices(configuration);
        services.AddBusinessServices();
        services.AddMappingServices();
        services.AddJwtAuthentication(configuration);
        return services;
    }

    private static IServiceCollection AddConfigurationSettings(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
        services.Configure<AdminCredentials>(configuration.GetSection("AdminCredentials"));
        services.Configure<MongoDbSettings>(configuration.GetSection("MongoDbSettings"));
        return services;
    }

    private static IServiceCollection AddDatabaseServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<EBookContext>();
        return services;
    }

    private static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        services.AddScoped<IJwtService, JwtService>();

        services.AddScoped<IAuthService, AuthService>();

        services.AddScoped(typeof(IGenericService<>), typeof(MongoGenericService<>));

        return services;
    }

    private static IServiceCollection AddMappingServices(this IServiceCollection services)
    {
        services.AddAutoMapper(configmap =>
        {
            configmap.AddProfile<UniversalMapping>();
        });
        return services;
    }

    private static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                var jwtSettings = configuration.GetSection("JwtSettings").Get<JwtSettings>();
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey)),
                    ValidateIssuer = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidateAudience = true,
                    ValidAudience = jwtSettings.Audience,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(5)
                };
            });
        return services;
    }
}