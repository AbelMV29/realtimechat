using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.SignalR;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RealTimeChat.ApplicationCore;
using RealTimeChat.ApplicationCore.Configuration;
using RealTimeChat.ApplicationCore.Hub;
using RealTimeChat.Infrastructure;
using System.Reflection;
using System.Text;

namespace RealTimeChat.API;

public class Program : Hub
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddInfrastructureServicesExtensions(builder.Configuration);
        builder.Services.AddApplicationCoreServicesExtensions(builder.Configuration);
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "RealTimeChat API",

            });

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },new string[]{ }
                    }
                });

            //Configuración para añadir comentarios en XML
            //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            //c.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
        });

        // Add services to the container.
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddCors(corsOptions =>
        {
            corsOptions.AddDefaultPolicy(corsPolicy =>
            {
                corsPolicy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            });
        });

        builder.Services.Configure<RouteOptions>(options =>
        {
            options.LowercaseUrls = true;
        });

        builder.Services.AddAuthorization();
        

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(options=>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "RealTimeChat API");
            });
        }
        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseCors();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapHub<ChatHub>("/chatHub");

        app.MapControllers();
        app.Run();
    }
}
