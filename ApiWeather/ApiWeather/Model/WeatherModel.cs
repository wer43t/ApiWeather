using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;

namespace ApiWeather.Model
{

    public class WeatherModel
    {
        public Coord Coord { get; set; }

        public Position Position
        {
            get
            {
                return new Position(Coord.Lat, Coord.Lon);
            }
        }

        public List<Weather> Weather { get; set; }
        public string _base { get; set; }
        public Main Main { get; set; }
        public int Visibility { get; set; }
        public Wind Wind { get; set; }
        public Clouds Clouds { get; set; }
        public int Dt { get; set; }
        public Sys Sys { get; set; }
        public int Timezone { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cod { get; set; }
    }
}