using AlexaMenu.AlexaInterface.Api.Interfaces;
using AlexaMenu.AlexaInterface.Api.Providers;
using AlexaMenu.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddLogginServices();
builder.Services.AddAlexaMenuApiBaseServices();
builder.Services.AddMongoDBServices();
builder.Services.AddScoped<IMenuProvider, MenuProvider>();

var app = builder.Build();

app.AddAlexaMenuSwaggerSettings();
app.AddAlexaMenuHttpSettings();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();