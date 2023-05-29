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
    public partial class Page6 : ContentPage
    {
        async void invocar()
        {
            await Navigation.PopPopupAsync();
            await PopupNavigation.Instance.PushAsync( new Escribe_la_letra_info());
        }
        public Page6()
        {
            InitializeComponent();
            talvez.Text = "Dakuten y" + "\n\r" + "Handakuten";
            invocar();
            
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            string[] permisos = { checkBoxV.IsChecked.ToString(), checkBoxK.IsChecked.ToString(), checkBoxS.IsChecked.ToString(), checkBoxT.IsChecked.ToString(), checkBoxN.IsChecked.ToString(), checkBoxH.IsChecked.ToString(), checkBoxM.IsChecked.ToString(), checkBoxR.IsChecked.ToString(), checkBoxKr.IsChecked.ToString(), checkBoxSr.IsChecked.ToString(), checkBoxTy.IsChecked.ToString(), checkBoxNy.IsChecked.ToString(), checkBoxHr.IsChecked.ToString(), checkBoxW.IsChecked.ToString(), checkBoxY.IsChecked.ToString(), checkBoxKy.IsChecked.ToString(), checkBoxKry.IsChecked.ToString(), checkBoxSy.IsChecked.ToString(), checkBoxSry.IsChecked.ToString(), checkBoxTy.IsChecked.ToString(), checkBoxNy.IsChecked.ToString(), checkBoxHy.IsChecked.ToString(), checkBoxHRry.IsChecked.ToString(), checkBoxMy.IsChecked.ToString(), checkBoxRy.IsChecked.ToString(), checkBoxHry.IsChecked.ToString() };
            string permisoStr = checkBoxV.IsChecked.ToString() + checkBoxK.IsChecked.ToString() + checkBoxS.IsChecked.ToString() + checkBoxT.IsChecked.ToString() + checkBoxN.IsChecked.ToString() + checkBoxH.IsChecked.ToString() + checkBoxM.IsChecked.ToString() + checkBoxR.IsChecked.ToString() + checkBoxKr.IsChecked.ToString() + checkBoxSr.IsChecked.ToString() + checkBoxTy.IsChecked.ToString() + checkBoxNy.IsChecked.ToString() + checkBoxHr.IsChecked.ToString() + checkBoxW.IsChecked.ToString() + checkBoxY.IsChecked.ToString() + checkBoxKy.IsChecked.ToString() + checkBoxKry.IsChecked.ToString() + checkBoxSy.IsChecked.ToString() + checkBoxSry.IsChecked.ToString() + checkBoxTy.IsChecked.ToString() + checkBoxNy.IsChecked.ToString() + checkBoxHy.IsChecked.ToString() + checkBoxHRry.IsChecked.ToString() + checkBoxMy.IsChecked.ToString() + checkBoxRy.IsChecked.ToString() + checkBoxHry.IsChecked.ToString();
            if (permisoStr != "FalseFalseFalseFalseFalseFalseFalseFalseFalseFalseFalseFalseFalseFalseFalseFalseFalseFalseFalseFalseFalseFalseFalseFalseFalse")
            {
                for (int i = 0; i < permisos.Length; i++)
                {
                    Application.Current.Properties["permisos" + i] = permisos[i];
                }
                Application.Current.Properties["PermisosID"] = permisos.Length.ToString();
                this.Navigation.PushModalAsync(new Page7());
            }
        }
    }
}