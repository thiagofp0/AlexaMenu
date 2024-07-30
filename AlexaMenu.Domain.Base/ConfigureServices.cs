using AlexaMenu.Domain.Base.Api.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AlexaMenu.DependencyInjection
{
    public static class ConfigureServices
    {
        public static IApplicationBuilder AddAlexaMenuSwaggerSettings(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            return app;
        }
        public static IApplicationBuilder AddAlexaMenuHttpSettings(this IApplicationBuilder app)
        {
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
            services.AddHttpLogging(o => { });
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }
        
    }
}
