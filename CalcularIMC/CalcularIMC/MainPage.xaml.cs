using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CalcularIMC
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

        void btnCalcular(System.Object sender, System.EventArgs e)
        {

            if (!string.IsNullOrEmpty(Altura.Text) && !string.IsNullOrEmpty(Peso.Text))
            {

                var altura = double.Parse(Altura.Text);
                var peso = double.Parse(Peso.Text);

                var imc = peso / (altura * altura);

                IMC.Text = Math.Round(imc, 2).ToString();;

                string resultado = "";

                if (imc < 18.5)
                {
                    resultado = "Tienes bajo peso";

                }
                else if (imc >= 18.5 && imc <= 24.9)
                {
                    resultado = "Tu peso es normal";
                }
                else if (imc >= 25 && imc <= 29.9)
                {
                    resultado = "Tienes sobrepeso";
                }
                else
                {
                    resultado = "Tienes obesisad !Cuidate¡";
                }

                DisplayAlert("Resultado", resultado, "OK");
            }
            else
            {
                DisplayAlert("Datos erróneos", "Ingrese la Altura y Peso", "OK");
            }
        }
    }
}
