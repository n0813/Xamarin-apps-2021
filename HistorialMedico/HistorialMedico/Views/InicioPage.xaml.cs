using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace HistorialMedico.Views
{
    public partial class InicioPage : TabbedPage
    {
        public InicioPage()
        {
            InitializeComponent();
            
        }

        void ToolbarItem_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
    }
}
