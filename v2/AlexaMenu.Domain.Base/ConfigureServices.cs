using AlexaMenu.Domain.Base.Api.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AlexaMenu.DependencyInjection
{
    public static class ConfigureServices
    {
        public static IApplicationBuilder AddAlexaMenuApiBaseSettings(this IApplicationBuilder app, IConfiguration config)
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseMiddleware<ExceptionHandler>();
            app.UseHttpLogging();
            app.UseStaticFiles();

            return app;
        }
        public static ILoggingBuilder AddLogginServices(this ILoggingBuilder loggin)
        {
            loggin.ClearProviders();
            loggin.AddConsole();

            return loggin;
        }
        public static IServiceCollection AddAlexaMenuApiBaseServices(this IServiceCollection services)
        {

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }
        
    }
}
