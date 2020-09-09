using System;
using System.Collections.Generic;
using HistorialMedico.Models;
using SQLite;
using Xamarin.Forms;

namespace HistorialMedico.Views
{
    public partial class DetalleMesPage : ContentPage
    {
        DateTime dateFecha;
        public DetalleMesPage(DateTime daFecha)
        {
            InitializeComponent();
            this.dateFecha = daFecha;
            this.Title = "Detalle del Mes de " + daFecha.ToString("MMMM");
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLiteConnection db = new SQLiteConnection(App.FilePath))
            {
                DateTime mes = dateFecha.Date;

                DateTime oPrimerDiaDelMes = new DateTime(mes.Year, mes.Month, 1);
                DateTime oUltimoDiaDelMes = oPrimerDiaDelMes.AddMonths(1).AddDays(-1);

                db.CreateTable<Historial>();

                var historial = db.Table<Historial>().OrderByDescending(x => x.Fecha)
                          .Where(y => y.Fecha >= oPrimerDiaDelMes & y.Fecha <= oUltimoDiaDelMes).ToList();

                collectionDatos.ItemsSource = historial;
                // listaDatos.ItemsSource = historial;
            }
        }

    }
}
