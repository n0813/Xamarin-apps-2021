using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Curso01Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : TabbedPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        void ToolbarItem_Clicked(System.Object sender, System.EventArgs e)
        {

            Navigation.PushAsync(new NewTravelPage());

        }
    }
}
