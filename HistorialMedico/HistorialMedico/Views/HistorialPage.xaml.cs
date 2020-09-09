using System;
using System.Collections.Generic;
using HistorialMedico.Models;
using SQLite;
using Xamarin.Forms;

namespace HistorialMedico.Views
{
    public partial class HistorialPage : ContentPage
    {
        public HistorialPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLiteConnection db = new SQLiteConnection(App.FilePath))
            {

                db.CreateTable<Historial>();

               //var historial = db.Table<Historial>().OrderByDescending(x => x.Fecha).ToList();

                DateTime mes = DateTime.Now.Date;

                DateTime oPrimerDiaDelMes = DateTime.Now.Date.AddMonths(-1);


                var historial = db.Table<Historial>().OrderByDescending(x => x.Fecha)
                          .Where(y => y.Fecha >= oPrimerDiaDelMes & y.Fecha <= mes).ToList();

                collectionDatos.ItemsSource = historial;
                // listaDatos.ItemsSource = historial;
            }
        }


        void collectionDatos_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            var DatosSQL = collectionDatos.SelectedItem as Historial;
            if (DatosSQL != null)
            {

                Navigation.PushAsync(new DetallePage(DatosSQL));
            }
        }

    }
}
