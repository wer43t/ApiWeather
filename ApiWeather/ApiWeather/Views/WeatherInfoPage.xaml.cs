using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ApiWeather.Model;
using Xamarin.Forms.Maps;

namespace ApiWeather.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeatherInfoPage : ContentPage
    {
        public WeatherModel Weather { get; set; }
        public CityInfo CityInfo { get; set; }
        public WeatherInfoPage()
        {
            InitializeComponent();
            GetCity();
            this.BindingContext = Weather;
        }

        private async Task GetCity()
        {
            CityInfo = await App.RequestManager.GetCity();
            Weather = await App.RequestManager.GetWeather(CityInfo.City);
            this.BindingContext = Weather;
            MoveMap();
        }
        private async void SearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            var cityName = searchBar.Text;
            Weather = await App.RequestManager.GetWeather(cityName);

            MoveMap();
            this.BindingContext = Weather;
        }

        private void MoveMap()
        {
            map.MoveToRegion(MapSpan.FromCenterAndRadius(Weather.Position, Distance.FromKilometers(50)));

            map.ItemsSource = new List<WeatherModel>
            {
                new WeatherModel
                {
                    Name = Weather.Name,
                    Coord = new Coord
                    {
                        Lat = Weather.Coord.Lat,
                        Lon = Weather.Coord.Lon,
                    },
                    Sys = new Sys
                    {
                        Country = Weather.Sys.Country
                    }
                }
            };
            this.BindingContext = Weather;
        }
    }
}