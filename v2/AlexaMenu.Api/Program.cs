using AlexaMenu.Api.Mapping;
using AlexaMenu.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddLogginServices();
builder.Services.AddAlexaMenuApiBaseServices();
builder.Services.AddMongoDBServices();
builder.Services.AddAutoMapper(typeof(MapProfile));

var app = builder.Build();

app.AddAlexaMenuApiBaseSettings(builder.Configuration);
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
