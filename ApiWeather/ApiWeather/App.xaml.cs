using ApiWeather.Services;
using ApiWeather.Model;
using ApiWeather.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ApiWeather
{
    public partial class App : Application
    {
        public static RequestManager RequestManager { get; private set; }
        public App()
        {
            InitializeComponent();

            RequestManager = new RequestManager(new RestService());
            MainPage = new NavigationPage(new WeatherInfoPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
