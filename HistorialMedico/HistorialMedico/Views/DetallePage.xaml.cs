using System;
using System.Collections.Generic;
using HistorialMedico.Models;
using SQLite;
using Xamarin.Forms;

namespace HistorialMedico.Views
{
    public partial class DetallePage : ContentPage
    {
        Historial seleccionado;

        public DetallePage(Historial oHistorial)
        {
            InitializeComponent();
            this.seleccionado = oHistorial;

            fechaPicker.Date = oHistorial.Fecha.Date;
            glucosaEntry.Text = oHistorial.Glucosa.ToString();
            presionEntry.Text = oHistorial.Presion;
            comentarioEntry.Text = oHistorial.Comentarios;

            //experienciaLabel.Text = select.Experiencie;
        }

        void Eliminar_Clicked(System.Object sender, System.EventArgs e)
        {

            try
            {
                this.seleccionado.Fecha = fechaPicker.Date;
                this.seleccionado.Presion = presionEntry.Text;
                this.seleccionado.Glucosa = Convert.ToInt32(glucosaEntry.Text);
                this.seleccionado.Comentarios = comentarioEntry.Text;
               

                using (SQLiteConnection db = new SQLiteConnection(App.FilePath))
                {
                    db.CreateTable<Historial>();
                    int rows = db.Delete(seleccionado);

                    if (rows > 0)
                    {
                        DisplayAlert("Aviso!", "Eliminado correctamente con fecha: " + fechaPicker.Date.ToShortDateString(), "Ok");
                        Navigation.PopAsync();
                    }
                    else
                    {
                        DisplayAlert("Error!", "No se elimino el registro con fecha: " + fechaPicker.Date.ToShortDateString(), "Ok");
                        return;
                    }

                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Error!", "Error al Eliminar con fecha: " + fechaPicker.Date.ToShortDateString(), "Ok");
                return;
            }
        }

        void actualizar_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                this.seleccionado.Fecha = fechaPicker.Date;
                this.seleccionado.Presion = presionEntry.Text;
                this.seleccionado.Glucosa = Convert.ToInt32(glucosaEntry.Text);
                this.seleccionado.Comentarios = comentarioEntry.Text;
                using (SQLiteConnection db = new SQLiteConnection(App.FilePath))
                {
                    db.CreateTable<Historial>();
                    int rows = db.Update(seleccionado);

                    if (rows > 0)
                    {
                        DisplayAlert("Aviso!", "Actualizado correctamente con fecha: " + fechaPicker.Date.ToShortDateString(), "Ok") ;
                        Navigation.PopAsync();
                    }
                    else
                    {
                        DisplayAlert("Error!", "No se actualizo el registro con fecha: " + fechaPicker.Date.ToShortDateString(), "Ok");
                        return;
                    }

                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Error!", "Error al Eliminar con fecha: " + fechaPicker.Date.ToShortDateString(), "Ok");
                return;
            }

        }
    }
}
