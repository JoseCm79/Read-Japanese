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
    public partial class Incorrecta : Rg.Plugins.Popup.Pages.PopupPage
    {
        public Incorrecta()
        {
            InitializeComponent();
            label.Text = "La respuesta correcta es: " + Application.Current.Properties["respuesta"].ToString().ToUpper();
        }
    }
}