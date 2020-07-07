using System;
using System.IO;
using SQLProyecto02.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQLProyecto02
{
    public partial class App : Application
    {
        //SQLite
        static DatabaseQuery database;

        public static DatabaseQuery Database
        {
            get
            {
                if (database == null)
                {
                    database = new
                        DatabaseQuery(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"TestDB.db3"));

                }
                return database;
            }
        }

        //SQLite

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
