using AlexaMenu.Domain.Interfaces;
using AlexaMenu.Infrastructure.Mapping;
using AlexaMenu.Infrastructure.Repository;
using AlexaMenu.Infrastructure.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(services =>
    {
        services.AddTransient<IUniversityService, UniversityService>();
        services.AddTransient<IMenuRepository, MenuRepository>();
        services.AddAutoMapper(typeof(MapProfile));
    })
    .Build();

host.Run();
