using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HistorialMedico.Models;
using SQLite;
using Xamarin.Forms;

namespace HistorialMedico
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        
        public MainPage()
        {
            InitializeComponent();
        }

        #region Metodos

        public string informacionGlucosa(string stGlucosa)
        {
            string mensaje = "";

            int inGlucosa = Convert.ToInt32(stGlucosa);

            if (inGlucosa >= 215)
            { mensaje = "Altamente elevado";  }

            else if (inGlucosa >= 150 & inGlucosa <= 180)
            { mensaje = "Nivel Elevado"; }

            else if (inGlucosa >= 80 & inGlucosa <= 115)
            { mensaje = "Niveles Normales"; }

            else if (inGlucosa >= 0 & inGlucosa <= 70)
            { mensaje = "Hipoglucemia"; }



            return mensaje;
        }

        public string informacionPresion(string stPresion)
        {
            string mensaje = "";
            List<string> lisPresion = new List<string>();
            lisPresion = stPresion.Split('.').ToList();

            int stRangoA, stRangoB;

            stRangoA = Convert.ToInt32(lisPresion[0]);
            stRangoB = Convert.ToInt32(lisPresion[1]);

            if (stRangoA  < 120 & stRangoB < 80)
            { mensaje = "Presión Normal"; }

            else if ((stRangoA >= 120 & stRangoA <=129) & stRangoB <= 80)
            { mensaje = "Presión Elevada"; }

            if ((stRangoA >= 130 & stRangoA <= 139) & (stRangoB >= 80 & stRangoB <= 89))
            { mensaje = "Presión arterial alta Nivel 1"; }


            if ((stRangoA >= 140 & stRangoA <= 179) & (stRangoB >= 90 & stRangoB <= 119))
            { mensaje = "Presión arterial alta Nivel 2"; }


            if (stRangoA >= 180  & stRangoB <= 120)
            { mensaje = "Crisis de hipertensión (Consulte a un médico de inmediato!)"; }

            return mensaje;
        }

        #endregion


        void ToolbarItem_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                int rows = 0;
                bool isGlucosaEmpty = string.IsNullOrEmpty(glucosaEntry.Text);
                bool isPresionEmtpty = string.IsNullOrEmpty(presionEntry.Text);

                if (isGlucosaEmpty || isGlucosaEmpty)
                {
                    DisplayAlert("Alerta", "El campo glucosa o presión no se han agregado, favor de agregarlos.", "Aceptar");
                }
                else
                {

                    if (!presionEntry.Text.Contains("."))
                    {
                        DisplayAlert("Error!", "Debe ingresar la Presión de la siguiente manera Ejemplo 120.80 = 120/80", "OK");
                        return;
                    }
                    if (glucosaEntry.Text.Contains("."))
                    {
                        DisplayAlert("Error!", "Debe ingresar la Glucosa de la siguiente manera Ejemplo 120", "OK");
                        return;
                    }

                  Historial historial = new Historial()
                    {
                        Fecha = fechaPicker.Date,
                        Presion = presionEntry.Text,
                        Glucosa = Convert.ToInt32(glucosaEntry.Text),
                        Comentarios = comentarioEntry.Text,

                        InfoGlucosa = informacionGlucosa(glucosaEntry.Text),
                        infoPresion = informacionPresion(presionEntry.Text)

                    };

                    using (SQLiteConnection db = new SQLiteConnection(App.FilePath))
                    {
                        db.CreateTable<Historial>();
                        rows = db.Insert(historial);

                        if (rows > 0)
                        {
                            DisplayAlert("Aviso", "Se agrego correctamente el registro", "Ok");
                            Navigation.PopAsync();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", "No se ha podido guardar el registro", "ok");

            }

        }
    }
}
