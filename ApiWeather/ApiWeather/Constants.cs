using System;
using System.Collections.Generic;
using System.Text;

namespace ApiWeather
{
    public class Constants
    {
        public static string RestUrl = "https://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}&units=metric";

        public static string GeoURL = "https://api.ipgeolocation.io/ipgeo?apiKey={0}&fields=city";
    }
}
