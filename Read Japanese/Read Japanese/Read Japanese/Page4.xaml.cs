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
    public partial class Page4 : ContentPage
    {
        void cambiar()
        {
            string page = "page" + index + ".png";
            Pagina.Source = page;
            tabla1.IsVisible = false;
            tabla2.IsVisible = false;
            tabla3.IsVisible = false;
            tabla4.IsVisible = false;
            if (index == 1)
            {
                tabla1.IsVisible = true;
                FrameSalva.IsVisible = false; 
            }
            if (index == 2)
            {
                tabla2.IsVisible = true;
                FrameSalva.IsVisible = true;
                FrameSalva.Padding = new Thickness(0, 0, 0, 298);
            }
            if (index == 3)
            {
                tabla3.IsVisible = true;
                FrameSalva.IsVisible = true;
                FrameSalva.Padding = new Thickness(0, 0, 0, 200);
            }
            if (index == 4)
            {
                tabla4.IsVisible = true;
                FrameSalva.IsVisible = true;
                FrameSalva.Padding = new Thickness(0, 0, 0, 300);
            }

        }
        public Page4()
        {
            InitializeComponent();
            
        }
        int index = 1;
        private void Button_Clicked(object sender, EventArgs e)
        {
            if (index != 1)
            {
                index -= 1;
            }
            cambiar();
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            if (index != 4)
            {
                index += 1;
            }
            cambiar();
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new Hiragana());
        }
    }
}