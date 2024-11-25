using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealTimeChat.ApplicationCore.Entities;
using RealTimeChat.ApplicationCore.Interfaces.Infrastructure;
using RealTimeChat.ApplicationCore.Interfaces.Services;
using RealTimeChat.ApplicationCore.Services;

namespace RealTimeChat.ApplicationCore
{
    public static class ApplicationCoreServicesExtensions
    {
        public static IServiceCollection AddApplicationCoreServicesExtensions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddSignalR().AddJsonProtocol();
            return services;
        }
    }
}
