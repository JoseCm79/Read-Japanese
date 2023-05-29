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
    public partial class FlashCard_Kata : ContentPage
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
            if (Index1 > 12)
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
        string[,,] letras = { { { "ア", "a" }, { "イ", "i" }, { "ウ", "u" }, { "エ", "e" }, { "オ", "o" } }, { { "カ", "ka" }, { "キ", "ki" }, { "ク", "ku" }, { "ケ", "ke" }, { "コ", "ko" } }, { { "サ", "sa" }, { "シ", "shi" }, { "ス", "su" }, { "セ", "se" }, { "ソ", "so" } }, { { "タ", "ta" }, { "チ", "chi" }, { "ツ", "tsu" }, { "テ", "te" }, { "ト", "to" } }, { { "ナ", "na" }, { "ニ", "ni" }, { "ヌ", "nu" }, { "ネ", "ne" }, { "ノ", "no" } }, { { "ハ", "ha" }, { "ヒ", "hi" }, { "フ", "fu" }, { "ヘ", "he" }, { "ホ", "ho" } }, { { "マ", "ma" }, { "ミ", "mi" }, { "ム", "mu" }, { "メ", "me" }, { "モ", "mo" } }, { { "ラ", "ra" }, { "リ", "ri" }, { "ル", "ru" }, { "レ", "re" }, { "ロ", "ro" } }, { { "ガ", "ga" }, { "ギ", "gi" }, { "グ", "gu" }, { "ゲ", "ge" }, { "ゴ", "go" } }, { { "ザ", "za" }, { "ジ", "ji" }, { "ズ", "zu" }, { "ゼ", "ze" }, { "ゾ", "zo" } }, { { "ダ", "da" }, { "ヂ", "ji" }, { "ヅ", "zu" }, { "デ", "de" }, { "ド", "do" } }, { { "バ", "ba" }, { "ビ", "bi" }, { "ブ", "bu" }, { "ベ", "be" }, { "ボ", "bo" } }, { { "パ", "pa" }, { "ピ", "pi" }, { "プ", "pu" }, { "ペ", "pe" }, { "ポ", "po" } }, { { "ワ", "wa" }, { "ヲ", "wo" }, { "ン", "n" }, { "", "" }, { "", "" } }, { { "ヤ", "ya" }, { "ユ", "yu" }, { "ヨ", "yo" }, { "", "" }, { "", "" } }, { { "キヤ", "kya" }, { "キユ", "kyu" }, { "キヨ", "kyo" }, { "", "" }, { "", "" } }, { { "ギヤ", "gya" }, { "ギユ", "gyu" }, { "ギヨ", "gyo" }, { "", "" }, { "", "" } }, { { "シヤ", "sha" }, { "シユ", "shu" }, { "シヨ", "sho" }, { "", "" }, { "", "" } }, { { "ジヤ", "ja" }, { "ジユ", "ju" }, { "ジヨ", "jo" }, { "", "" }, { "", "" } }, { { "ヂヤ", "cha" }, { "ヂユ", "chu" }, { "ヂヨ", "cho" }, { "", "" }, { "", "" } }, { { "ニヤ", "nya" }, { "ニユ", "nyu" }, { "ニヨ", "nyo" }, { "", "" }, { "", "" } }, { { "ヒヤ", "hya" }, { "ヒユ", "hyu" }, { "ヒヨ", "hyo" }, { "", "" }, { "", "" } }, { { "ビヤ", "bya" }, { "ビユ", "byu" }, { "ビヨ", "byo" }, { "", "" }, { "", "" } }, { { "ミヤ", "mya" }, { "ミユ", "myu" }, { "ミヨ", "myo" }, { "", "" }, { "", "" } }, { { "リヤ", "rya" }, { "リユ", "ryu" }, { "リヨ", "ryo" }, { "", "" }, { "", "" } }, { { "ピヤ", "pya" }, { "ピユ", "pyu" }, { "ピヨ", "pyo" }, { "", "" }, { "", "" } } };
        int Index1;
        int Index2;
        string letraJp;
        string letra;
        public FlashCard_Kata()
        {
            InitializeComponent();
            cambiar();
            invocar();
        }

        private  void Button_Clicked(object sender, EventArgs e)
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