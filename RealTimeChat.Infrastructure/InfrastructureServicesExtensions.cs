using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RealTimeChat.ApplicationCore.Interfaces.Infrastructure;
using RealTimeChat.Infrastructure.Data;
using RealTimeChat.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using RealTimeChat.ApplicationCore.Entities;
using Microsoft.Extensions.DependencyInjection;
using RealTimeChat.Infrastructure.Identity;
using RealTimeChat.ApplicationCore.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace RealTimeChat.Infrastructure
{
    public static class InfrastructureServicesExtensions
    {
        public static IServiceCollection AddInfrastructureServicesExtensions(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddDbContext<ChatContext>(contextOptions =>
            {
                contextOptions.UseSqlServer(configuration.GetConnectionString("ChatConnectionString"));
            });
            services.AddIdentity<User, IdentityRole<int>>(identityOptions =>
            {
                identityOptions.Password.RequireNonAlphanumeric = false;
                identityOptions.Password.RequireDigit = false;
                identityOptions.Password.RequiredLength = 6;
            })
                .AddEntityFrameworkStores<ChatContext>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<INotificationRepository,NotificationRepository>();
            services.AddScoped<IMessageRepository,MessageRepository>();
            var jwtConfig = new JwtConfiguration();
            configuration.Bind("JwtConfiguration", jwtConfig);
            services.AddSingleton(jwtConfig);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                    .AddJwtBearer(config =>
                    {
                        config.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuerSigningKey = jwtConfig.ValidateIssuerSigningKey,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.Key)),
                            ValidateIssuer = jwtConfig.ValidateIssuer,
                            ValidateAudience = jwtConfig.ValidateAudience,
                            ValidateLifetime = jwtConfig.ValidateLifeTime,
                            ValidIssuer = jwtConfig.Issuer,
                            ValidAudience = jwtConfig.Audience

                        };
                    });

            services.AddAuthorization();
            return services;
        }
    }
}
