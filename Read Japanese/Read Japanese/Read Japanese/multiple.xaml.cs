using Rg.Plugins.Popup.Extensions;
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
    public partial class multiple : Rg.Plugins.Popup.Pages.PopupPage
    {
        public multiple()
        {
            InitializeComponent();
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopPopupAsync();
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await this.Navigation.PushModalAsync(new mul_hira_Per());
        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            await this.Navigation.PushModalAsync(new Mul_Kata_Per());
        }
    }
}