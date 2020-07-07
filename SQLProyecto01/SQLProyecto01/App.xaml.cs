using System;
using SQLProyecto01.Data;
using SQLProyecto01.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQLProyecto01
{
    public partial class App : Application
    {

        //Creamos al cargar la base de datos para inicializar
        private static FriendDatabase database;

        public static FriendDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new FriendDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("friendsdb.db3"));
                }

                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
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
