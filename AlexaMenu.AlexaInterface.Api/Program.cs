using AlexaMenu.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddLogginServices();
builder.Services.AddAlexaMenuApiBaseServices();
builder.Services.AddMongoDBServices();

var app = builder.Build();

app.AddAlexaMenuSwaggerSettings();
app.AddAlexaMenuHttpSettings();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();