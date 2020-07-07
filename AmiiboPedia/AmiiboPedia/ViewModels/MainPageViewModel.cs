using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using AmiiboPedia.Helpers;
using AmiiboPedia.Models;
using Xamarin.Forms;

namespace AmiiboPedia.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public ObservableCollection<Character> Characters { get; set; }
        public ICommand SearchCommand { get; set; }
        public ObservableCollection<Amiibo> Amiibos { get; set; }

        public MainPageViewModel()
        {
            SearchCommand = new Command(async (txtParam) =>
            {
                var url = $"https://www.amiiboapi.com/api/amiibo/?character={txtParam}";
                var service = new HttpHelper<Amiiboss>();
                var amiibos = await service.GetRestServiceDataAsync(url);
                Amiibos = new ObservableCollection<Amiibo>(amiibos.Amiibo);

            });
        }

        public async Task LoadCharacters()
        {
            var url = "https://www.amiiboapi.com/api/character";
            var service = new HttpHelper<Characters>();
            var characters = await service.GetRestServiceDataAsync(url);
            Characters = new ObservableCollection<Character>(characters.Amiibo);


        }

    }
}
