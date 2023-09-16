using AlexaMenu.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddLogginServices();
builder.Services.AddAlexaMenuApiBaseServices();
builder.Services.AddMongoDBServices();

var app = builder.Build();

app.AddAlexaMenuApiBaseSettings(builder.Configuration);
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
