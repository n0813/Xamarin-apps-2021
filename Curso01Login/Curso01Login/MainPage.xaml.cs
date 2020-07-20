using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Curso01Login
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

        void btnAceptar_Clicked(System.Object sender, System.EventArgs e)
        {
            bool isEmailempty  = string.IsNullOrEmpty(correoEntry.Text);
            bool isPasswordEmtpty = string.IsNullOrEmpty(passEntry.Text);

            if (isEmailempty || isPasswordEmtpty)
            {

            }
            else
            {
                Navigation.PushAsync(new HomePage());
            }


        }
    }
}
