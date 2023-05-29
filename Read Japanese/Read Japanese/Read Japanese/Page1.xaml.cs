using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Read_Japanese
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        async void Iniciar()
        {
            try
            {
                if (Application.Current.Properties["InfoInicial"] as string == "si")
                {
                    await PopupNavigation.Instance.PushAsync(new PopUp());
                }
            }
            catch
            {

                await PopupNavigation.Instance.PushAsync(new PopUp());

            }
        }

        public Page1()
        {
            InitializeComponent();
            Iniciar();
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Page4());
        }

        private void Button_Clicked_3(object sender, EventArgs e)
        {
            this.Navigation.PushModalAsync(new Page5());
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushModalAsync(new juegosPage());
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new Page8());
        }
    }
}