using System;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Clima_Xamarin.Models;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Clima_Xamarin.ViewModels
{
    public class WeatherPageViewModel : INotifyPropertyChanged
    {
        private WeatherData data;


        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        public WeatherData Data
        {
            get => data; set
            {
                data = value;
                OnPropertyChanged();
            }
        }

        public ICommand SearchCommand { get; set; }


        public WeatherPageViewModel()
        {
            SearchCommand = new Command(async (seachTerm) =>
            {
                var temp = seachTerm as string;
                var datos = temp.Split(',');
                var lat = datos[0];
                var lon = datos[1];

                await GetData($"https://api.weatherbit.io/v2.0/current?lat={0}&lon={1}&lang=es&key=02ea48470d1b46f38b6731362c9d580d");
            });

            //Recibimos el comando

        }


        private async Task GetData(string url)
        {
            var client = new HttpClient();
            var response = await client.GetAsync(url);

            //errores
            response.EnsureSuccessStatusCode();
            //leer el archivo Json
            var jsonResul = await response.Content.ReadAsStringAsync();

            //serialización Json
            var result = JsonConvert.DeserializeObject<WeatherData>(jsonResul);

            //Finaliza la conversión
            Data = result;


        }


    }
}
