using System;
using System.Collections.Generic;
using Clima_Xamarin.ViewModels;
using Xamarin.Forms;

namespace Clima_Xamarin.Views
{
    public partial class WeatherPage : ContentPage
    {
        public WeatherPage()
        {
            InitializeComponent();
            BindingContext = new WeatherPageViewModel();
            
        }
    }
}
