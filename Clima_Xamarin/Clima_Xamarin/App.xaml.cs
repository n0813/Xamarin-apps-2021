using System;
using Clima_Xamarin.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Clima_Xamarin
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new WeatherPage();  //MainPage();
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
