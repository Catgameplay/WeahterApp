using WeatherApp.Server.DTO;

namespace WeatherApp.Server.Interfaces
{
    public interface IUrlBuilderInterface
    {
        public string GetGeocodeUrl(OpenWeather openWeather, string city, int? stateCode, int? countryCode);
    }
}
