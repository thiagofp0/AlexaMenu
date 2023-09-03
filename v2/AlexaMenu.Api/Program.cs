using AlexaMenu.Domain.Base.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

//Logs
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

//Configs
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dependency Injection

//Build
var app = builder.Build();

//Middlewares
app.UseMiddleware<ExceptionHandler>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
