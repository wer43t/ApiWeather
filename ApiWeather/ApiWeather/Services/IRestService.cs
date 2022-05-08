using ApiWeather.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiWeather.Services
{
    public interface IRestService
    {
        Task<WeatherModel> GetWeather(string cityName);
        Task<CityInfo> GetCity();
    }
}
