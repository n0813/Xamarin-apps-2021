using System;
using System.Collections.Generic;
using Entry = Microcharts.ChartEntry;

using Xamarin.Forms;
using SkiaSharp;
using Microcharts;
using SQLite;
using HistorialMedico.Models;
using System.Linq;
using System.Globalization;

namespace HistorialMedico.Views
{
    public partial class GraficasPage : ContentPage
    {
        //variables
        float FtamañoFuente = 35f;

        public GraficasPage()
        {
            InitializeComponent();
            fechaInicio.Date = DateTime.Now.Date.AddDays(-7);
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("es-ES");
            System.Threading.Thread.CurrentThread.CurrentCulture = culture; System.Threading.Thread.CurrentThread.CurrentUICulture = culture;
        }

        public string informacionGlucosa(string stGlucosa)
        {
            string stColor = "";

            int inGlucosa = Convert.ToInt32(stGlucosa);

            if (inGlucosa >= 215)
            { stColor = "#be0027"; } //Rojo

            else if (inGlucosa >= 150 & inGlucosa <= 180)
            { stColor = "#ffc845"; } //amarillo

            else if (inGlucosa >= 80 & inGlucosa <= 115)
            { stColor = "#34bf49"; } //Verde

            else if (inGlucosa >= 0 & inGlucosa <= 70)
            { stColor = "#fbb034"; } //Naranja



            return stColor;
        }

        public string informacionPresion(string stPresion)
        {
            string stColor = "";
            List<string> lisPresion = new List<string>();
            lisPresion = stPresion.Split('.').ToList();

            int stRangoA, stRangoB;

            stRangoA = Convert.ToInt32(lisPresion[0]);
            stRangoB = Convert.ToInt32(lisPresion[1]);

            if (stRangoA < 120 & stRangoB < 80)
            { stColor = "#34bf49"; } //Verde

            else if ((stRangoA >= 120 & stRangoA <= 129) & stRangoB <= 80)
            { stColor = "#fbb034"; } //Naranja

            if ((stRangoA >= 130 & stRangoA <= 139) & (stRangoB >= 80 & stRangoB <= 89))
            { stColor = "#ffc845"; } //Amarillo


            if ((stRangoA >= 140 & stRangoA <= 179) & (stRangoB >= 90 & stRangoB <= 119))
            { stColor = "#be0027"; } // rojo fuerte


            if (stRangoA >= 180 & stRangoB <= 120)
            { stColor = "#ff4c4c"; } //Rojo

            return stColor;
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            tituloGlucosa.Text = "Glucosa de " + fechaInicio.Date.ToString("MMMM", new CultureInfo("es-ES"));
            tituloPresion.Text = "Presion de " + fechaInicio.Date.ToString("MMMM", new CultureInfo("es-ES"));


            using (SQLiteConnection db = new SQLiteConnection(App.FilePath))
            {

                db.CreateTable<Historial>();

                var historial = db.Table<Historial>().OrderByDescending(x => x.Fecha)
                    .Where(y => y.Fecha >= fechaInicio.Date & y.Fecha <= fechaFin.Date).ToList();

                List<Entry> entriesGlucosa = new List<Entry>();
                List<Entry> entriesPresion = new List<Entry>();

                //Glucosa
                string stColorGlucosa = "";
                //Presion
                string[] stPresion;
                double doPresion = 0.0;
                string stColorPresion = "";
                for (int i = 0; i < historial.Count; i++)
                {
                    stColorGlucosa = informacionGlucosa(historial[i].Glucosa.ToString());

                    stColorGlucosa = (stColorGlucosa == "") ? "#0099e5" : stColorGlucosa;


                    //------------------------PRESION-------------------------------//
                    stPresion = historial[i].Presion.Split('.');
                    //doPresion = Convert.ToDouble(stPresion[0]) / Convert.ToDouble(stPresion[1]);
                    doPresion = Convert.ToDouble(stPresion[0]);
                    stColorPresion = informacionPresion(historial[i].Presion);

                    stColorPresion = (stColorPresion == "") ? "#0099e5" : stColorPresion;

                    //------------------------GLUCOSA-------------------------------//

                    entriesGlucosa.Add(new Entry(historial[i].Glucosa)
                    {
                        
                        Color = SKColor.Parse(stColorGlucosa),
                        Label = historial[i].Fecha.Day.ToString() + "-"+ historial[i].Fecha.ToString("dddd",new CultureInfo("es-ES")).Substring(0,3),
                        ValueLabel = historial[i].Glucosa.ToString()

                    });

                    //------------------------PRESION-------------------------------//
                    entriesPresion.Add(new Entry(Convert.ToInt32(doPresion))
                    {
                        Color = SKColor.Parse(stColorPresion),
                        Label = historial[i].Fecha.Day.ToString() + "-" + historial[i].Fecha.ToString("dddd", new CultureInfo("es-ES")).Substring(0, 3),
                        //Fecha.DayOfWeek.ToString().Substring(0, 3),
                        ValueLabel = historial[i].Presion.Replace('.', '/').ToString()

                    }); ; ;
                }

                Grafica.Chart = new BarChart {
                    LabelOrientation = Orientation.Horizontal,
                    ValueLabelOrientation = Orientation.Horizontal,
                    LabelTextSize = FtamañoFuente,
                    LabelColor = SKColor.Parse("000000"),
                    Entries = entriesGlucosa };
                
                Presion.Chart = new BarChart {
                    LabelOrientation = Orientation.Horizontal,
                    ValueLabelOrientation = Orientation.Horizontal,
                    LabelTextSize = FtamañoFuente,
                    LabelColor = SKColor.Parse("000000"),
                    Entries = entriesPresion };

            }
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            DateTime dateFechaFin = fechaFin.Date;

            dateFechaFin = dateFechaFin.Date.AddDays(-7);

            if (fechaInicio.Date < dateFechaFin.Date)
            {
                DisplayAlert("Aviso", "Solo se puede graficar de 7 dias atras a fecha final", "OK");
                fechaInicio.Date = DateTime.Now.Date.AddDays(-7);
                return;
            }

            using (SQLiteConnection db = new SQLiteConnection(App.FilePath))
            {

                db.CreateTable<Historial>();

                var historial = db.Table<Historial>().OrderByDescending(x => x.Fecha)
                    .Where(y => y.Fecha >= fechaInicio.Date & y.Fecha <= fechaFin.Date).ToList();

                List<Entry> entriesGlucosa = new List<Entry>();
                List<Entry> entriesPresion = new List<Entry>();

                //Glucosa
                string stColorGlucosa = "";
                //Presion
                string[] stPresion;
                double doPresion = 0.0;
                string stColorPresion = "";
                for (int i = 0; i < historial.Count; i++)
                {
                    stColorGlucosa = informacionGlucosa(historial[i].Glucosa.ToString());

                    stColorGlucosa = (stColorGlucosa == "") ? "#0099e5" : stColorGlucosa;


                    //------------------------PRESION-------------------------------//
                    stPresion = historial[i].Presion.Split('.');
                    //doPresion = Convert.ToDouble(stPresion[0]) / Convert.ToDouble(stPresion[1]);
                    doPresion = Convert.ToDouble(stPresion[0]);
                    stColorPresion = informacionPresion(historial[i].Presion);

                    stColorPresion = (stColorPresion == "") ? "#0099e5" : stColorPresion;

                    //------------------------GLUCOSA-------------------------------//

                    entriesGlucosa.Add(new Entry(historial[i].Glucosa)
                    {
                        Color = SKColor.Parse(stColorGlucosa),
                        Label = historial[i].Fecha.ToString("dddd", new CultureInfo("es-ES")).Substring(0, 3),
                        ValueLabel = historial[i].Glucosa.ToString()

                    });

                    //------------------------PRESION-------------------------------//
                    entriesPresion.Add(new Entry(Convert.ToInt32(doPresion))
                    {
                        Color = SKColor.Parse(stColorPresion),
                        Label = historial[i].Fecha.ToString("dddd", new CultureInfo("es-ES")).Substring(0, 3),
                        ValueLabel = historial[i].Presion.Replace('.', '/').ToString()

                    }); ;
                }

                Grafica.Chart = new BarChart {
                    LabelOrientation = Orientation.Horizontal,
                    ValueLabelOrientation = Orientation.Horizontal,
                    LabelTextSize = FtamañoFuente,
                    LabelColor = SKColor.Parse("000000"),
                    Entries = entriesGlucosa };

                Presion.Chart = new BarChart {
                    LabelOrientation = Orientation.Horizontal,
                    ValueLabelOrientation = Orientation.Horizontal,
                    LabelTextSize = FtamañoFuente,
                    LabelColor = SKColor.Parse("000000"),
                    Entries = entriesPresion };
            }


        }

        void fechaInicio_DateSelected(System.Object sender, Xamarin.Forms.DateChangedEventArgs e)
        {
            tituloGlucosa.Text = "Glucosa de " + fechaInicio.Date.ToString("MMMM", new CultureInfo("es-ES"));
            tituloPresion.Text = "Presion de " + fechaInicio.Date.ToString("MMMM", new CultureInfo("es-ES"));

            Grafica.Chart = new BarChart
            {
                LabelOrientation = Orientation.Horizontal,
                ValueLabelOrientation = Orientation.Horizontal,
                LabelTextSize = FtamañoFuente,
                LabelColor = SKColor.Parse("000000"),
                Entries = null
            };

            Presion.Chart = new BarChart
            {
                LabelOrientation = Orientation.Horizontal,
                ValueLabelOrientation = Orientation.Horizontal,
                LabelTextSize = FtamañoFuente,
                LabelColor = SKColor.Parse("000000"),
                Entries = null
            };
        }
    }
}
