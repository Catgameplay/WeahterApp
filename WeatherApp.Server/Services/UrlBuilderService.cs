using System.Text;
using WeatherApp.Server.DTO;
using WeatherApp.Server.Interfaces;

namespace WeatherApp.Server.Services
{
    public class UrlBuilderService : IUrlBuilderInterface
    {
        public string GetGeocodeUrl(OpenWeather openWeather, string city, int? stateCode, int? countryCode)
        {
            StringBuilder geoCode = new StringBuilder();
            string geocodeUrl = geoCode.Append(openWeather.Site + openWeather.GeoResponseType + openWeather.GeoVersion)
                .Append(openWeather.GeolocationTemplate.Replace("cityname", city)
                .Replace(",statecode", stateCode.HasValue ? stateCode.Value.ToString() : "")
                .Replace(",countrycode", countryCode.HasValue ? countryCode.Value.ToString() : "")
                .Replace("APIKey", openWeather.Key)).ToString();

            return geocodeUrl;
        }

        public string GetWeatherUrl(string template, GeoCodeDto geoCode, OpenWeather openWeather)
        {
            return "";
        }
    }
}
