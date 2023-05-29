using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Services;
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
    public partial class FlashCard_Hira : ContentPage
    {
        async void invocar()
        {
            await Navigation.PopPopupAsync();
            await PopupNavigation.Instance.PushAsync(new Page1());
        }
        void cambiar()
        {
            Random random = new Random();
            Index1 = random.Next(0, 25);
            if(Index1 > 12)
            {
                Index2 = random.Next(0, 2);
            }
            else
            {
                Index2 = random.Next(0, 4);
            }
            
            letra = letras[Index1, Index2, 0];
            letraJp = letras[Index1, Index2, 1];
            int modo = random.Next(0, 2);
            if (modo == 1)
            {
                LetraJP.Text = "";
                PronunJP.Text = letraJp;
            }
            else
            {
                LetraJP.Text = letra;
                PronunJP.Text = "";
            }

        }
        string[,,] letras = { { { "あ", "a" }, { "い", "i" }, { "う", "u" }, { "え", "e" }, { "お", "o" } }, { { "か", "ka" }, { "き", "ki" }, { "く", "ku" }, { "け", "ke" }, { "こ", "ko" } }, { { "さ", "sa" }, { "し", "shi" }, { "す", "su" }, { "せ", "se" }, { "そ", "so" } }, { { "た", "ta" }, { "ち", "chi" }, { "つ", "tsu" }, { "て", "te" }, { "と", "to" } }, { { "な", "na" }, { "に", "ni" }, { "ぬ", "nu" }, { "ね", "ne" }, { "の", "no" } }, { { "は", "ha" }, { "ひ", "hi" }, { "ふ", "fu" }, { "へ", "he" }, { "ほ", "ho" } }, { { "ま", "ma" }, { "み", "mi" }, { "む", "mu" }, { "め", "me" }, { "も", "mo" } }, { { "ら", "ra" }, { "り", "ri" }, { "る", "ru" }, { "れ", "re" }, { "ろ", "ro" } }, { { "が", "ga" }, { "ぎ", "gi" }, { "ぐ", "gu" }, { "げ", "ge" }, { "ご", "go" } }, { { "ざ", "za" }, { "じ", "ji" }, { "ず", "zu" }, { "ぜ", "ze" }, { "ぞ", "zo" } }, { { "だ", "da" }, { "ぢ", "ji" }, { "づ", "zu" }, { "で", "de" }, { "ど", "do" } }, { { "ば", "ba" }, { "び", "bi" }, { "ぶ", "bu" }, { "べ", "be" }, { "ぼ", "bo" } }, { { "ぱ", "pa" }, { "ぴ", "pi" }, { "ぷ", "pu" }, { "ぺ", "pe" }, { "ぽ", "po" } }, { { "わ", "wa" }, { "を", "wo" }, { "ん", "n" }, { "", "" }, { "", "" } }, { { "や", "ya" }, { "ゆ", "yu" }, { "よ", "yo" }, { "", "" }, { "", "" } }, { { "きや", "kya" }, { "きゆ", "kyu" }, { "きよ", "kyo" }, { "", "" }, { "", "" } }, { { "ぎや", "gya" }, { "ぎゆ", "gyu" }, { "ぎよ", "gyo" }, { "", "" }, { "", "" } }, { { "しや", "sha" }, { "しゆ", "shu" }, { "しよ", "sho" }, { "", "" }, { "", "" } }, { { "じや", "ja" }, { "じゆ", "ju" }, { "じよ", "jo" }, { "", "" }, { "", "" } }, { { "ちや", "cha" }, { "ちゆ", "chu" }, { "ちよ", "cho" }, { "", "" }, { "", "" } }, { { "にや", "nya" }, { "にゆ", "nyu" }, { "によ", "nyo" }, { "", "" }, { "", "" } }, { { "ひや", "hya" }, { "ひゆ", "hyu" }, { "ひよ", "hyo" }, { "", "" }, { "", "" } }, { { "びや", "bya" }, { "びゆ", "byu" }, { "びよ", "byo" }, { "", "" }, { "", "" } }, { { "みや", "mya" }, { "みゆ", "myu" }, { "よ", "myo" }, { "", "" }, { "", "" } }, { { "りや", "rya" }, { "りゆ", "ryu" }, { "りよ", "ryo" }, { "", "" }, { "", "" } }, { { "ぴや", "pya" }, { "ぴゆ", "pyu" }, { "ぴよ", "pyo" }, { "", "" }, { "", "" } } };
        int Index1;
        int Index2;
        string letraJp;
        string letra;
        public FlashCard_Hira()
        {
            InitializeComponent();
            cambiar();
            invocar();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            LetraJP.Text = letra;
            PronunJP.Text = letraJp;
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            cambiar();
        }
    }
}