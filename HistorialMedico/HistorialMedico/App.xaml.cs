using System;
using HistorialMedico.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HistorialMedico
{
    public partial class App : Application
    {

        public static string FilePath;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new InicioPage());
        }

        public App(string filePath)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new InicioPage());
            FilePath = filePath;
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
