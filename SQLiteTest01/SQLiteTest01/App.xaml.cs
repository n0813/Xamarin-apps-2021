﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQLiteTest01
{
    public partial class App : Application
    {

        public static string FilePath;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ContactPage());
        }
        #region SQLite


        //SQLite
        public App(string filePath)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ContactPage());
            FilePath = filePath;
        }

        //sqlite

        #endregion
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
