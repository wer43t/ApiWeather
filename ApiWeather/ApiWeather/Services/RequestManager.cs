using ApiWeather.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiWeather.Services
{
    public class RequestManager
    {
        IRestService restService;
        public RequestManager(IRestService service)
        {
            restService = service;
        }

        public Task<WeatherModel> GetWeather(string cityName)
        {
            return restService.GetWeather(cityName);
        }

        public Task<CityInfo> GetCity()
        {
            return restService.GetCity();
        }
    }
}
