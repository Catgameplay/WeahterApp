using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WeatherApp.Server.DTO;
using WeatherApp.Server.Interfaces;
using WeatherApp.Server.Services;
using WeatherApplication.Server.Data;


var builder = WebApplication.CreateBuilder(args);
// Add services to the containedr.
builder.Services.AddControllers();
builder.Services.AddHttpClient("OpenWeatherClient", client =>
{
    // Configure your HttpClient options here
    client.BaseAddress = new Uri("https://openweathermap.org/");
    // Additional configuration if needed...
});

builder.Services.AddTransient<IUrlBuilderInterface, UrlBuilderService>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("Database");
    var serverVersion = ServerVersion.AutoDetect(connectionString);
    options.UseMySql(connectionString, serverVersion);
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.CustomSchemaIds(type => type.FullName); // Use the type's full name as the schema ID
    // Other Swagger configuration...
});
builder.Services.Configure<OpenWeather>(builder.Configuration.GetSection("OpenWeather"));
var app = builder.Build();
app.UseDefaultFiles();
app.UseStaticFiles();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();