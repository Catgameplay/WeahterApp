using Microsoft.EntityFrameworkCore;
using WeatherApp.Server.Interfaces;
using WeatherApplication.Server.Data;
using WeatherApplication.Server.Interfaces;

namespace WeatherApp.Server.Services
{
    public class TenantFinderServices : ITenantFinderInterface
    {
        public async Task<Guid> GetTennantId(string userEmail, ApplicationDbContext dbContext)
        {
            Guid tenantId = Guid.Empty;
            if(string.IsNullOrEmpty(userEmail))
            {
                return tenantId;
            }
            var user = await dbContext.Users.FirstOrDefaultAsync(x => x.Email == userEmail);
            if (user == null || user.TenantId == default)
            {
                return tenantId;
            }
            return user.TenantId;

        }
    }
}