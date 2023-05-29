using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Read_Japanese
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopUp : Rg.Plugins.Popup.Pages.PopupPage
    {
        public PopUp()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Application.Current.Properties["InfoInicial"] = "no";
            Navigation.PopPopupAsync();
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            Application.Current.Properties["InfoInicial"] = "si";
            await Navigation.PopPopupAsync();

        }
    }
}