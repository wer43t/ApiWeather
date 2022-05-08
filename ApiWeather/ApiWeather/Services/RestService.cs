using ApiWeather.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApiWeather.Services
{
    public class RestService : IRestService
    {
        HttpClient client;
        JsonSerializerOptions serializerOptions;
        WeatherModel Weather { get; set; }
        CityInfo CityInfo { get; set; }
        public RestService()
        {
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback =
            (message, cert, chain, errors) => { return true; };

            client = new HttpClient(httpClientHandler);

            serializerOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            };
        }

        public async Task<WeatherModel> GetWeather(string cityName)
        {
            Uri uri = new Uri(string.Format(Constants.RestUrl, cityName, ApiKeys.OpenWeatherMapToken));
            try
            {
                Debug.WriteLine("Start Requests");
                HttpResponseMessage responseMessage = await client.GetAsync(uri);
                Debug.WriteLine("End Request");

                if (responseMessage.IsSuccessStatusCode)
                {
                    string content = await responseMessage.Content.ReadAsStringAsync();
                    Weather = JsonSerializer.Deserialize<WeatherModel>(content, serializerOptions);
                }
                else
                {
                    Debug.WriteLine("Bad Requset");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return Weather;
        }

        public async Task<CityInfo> GetCity()
        {
            Uri uri = new Uri(string.Format(Constants.GeoURL, ApiKeys.IPGeolocationToken));
            try
            {
                Debug.WriteLine("Start Requests");
                HttpResponseMessage responseMessage = await client.GetAsync(uri);
                Debug.WriteLine("End Request");

                if (responseMessage.IsSuccessStatusCode)
                {
                    string content = await responseMessage.Content.ReadAsStringAsync();
                    CityInfo = JsonSerializer.Deserialize<CityInfo>(content, serializerOptions);
                }
                else
                {
                    Debug.WriteLine("Bad Requset");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return CityInfo;
        }
    }
}