using AlexaMenu.DataCapture.Mapping;
using AlexaMenu.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices(services =>
    {
        services.AddMongoDBServices();
        services.AddAutoMapper(typeof(MapProfile));
    })
    .Build();

host.Run();
