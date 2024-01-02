using Microsoft.Extensions.Configuration;
using WeatherApplication.Server.DTOs;
using WeatherApplication.Server.Interfaces;
using WeatherApplication.Server.Services;

var builder = WebApplication.CreateBuilder(args);

    client.BaseAddress = new Uri("https://openweathermap.org/");
    // Additional configuration if needed...
});

builder.Services.AddTransient<IUrlBuilderInterface, UrlBuilderService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
