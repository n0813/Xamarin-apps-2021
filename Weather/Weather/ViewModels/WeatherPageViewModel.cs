using System;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtonsoft.Json;
using Weather.Models;
using Xamarin.Forms;

namespace Weather.ViewModels
{
    public class WeatherPageViewModel : INotifyPropertyChanged
    {
        private WeatherData _data;

        public WeatherData Data
        {
            get => _data; set
            {
                _data = value;
                OnPropertyChanged();
            }
        }
        public Command SearchCommand { get; set; }


        #region Implementación
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion



        public WeatherPageViewModel()
        {
            SearchCommand = new Command(async (textCP) =>
            {
                await GetData($"https://api.weatherbit.io/v2.0/current?postal_code={textCP}&country=Mx&lang=es&key=02ea48470d1b46f38b6731362c9d580d");
            });
        }


        private async Task GetData(string url)
        {

            var client = new HttpClient();

            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<WeatherData>(jsonResult);
            Data = result;


        }

    }
}
