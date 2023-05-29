using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Read_Japanese.Flashcard
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlashCardsMenu : Rg.Plugins.Popup.Pages.PopupPage
    {
        public FlashCardsMenu()
        {
            InitializeComponent();
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopPopupAsync();
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await this.Navigation.PushModalAsync(new Flashcard.FlashCard_Hira());

        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            await this.Navigation.PushModalAsync(new Flashcard.FlashCard_Kata());
        }

    }
}