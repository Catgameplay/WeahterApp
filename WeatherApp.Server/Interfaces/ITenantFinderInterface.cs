using WeatherApp.Server.DTO;
using WeatherApplication.Server.Data;
using WeatherApplication.Server.Interfaces;

namespace WeatherApp.Server.Interfaces
{
    public interface ITenantFinderInterface
    {
        Task<Guid> GetTennantId(string userEmail, ApplicationDbContext dbContext);
    }
}
