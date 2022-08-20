using AlexaMenu.Interfaces;
using AlexaMenu.Providers;
using AlexaMenu.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using IMenuRepository = AlexaMenu.Interfaces.IMenuRepository;

var builder = WebApplication.CreateBuilder(args);
IMenuRepository menuRepository = new MenuRepository();

// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<MenuProvider>(new MenuProvider(menuRepository));
var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();