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
    public partial class Page3 : ContentPage
    {
        void ver(string[] permisos, string[,,] letras, int messi)
        {
            Random random = new Random();
            int index;
            messi = random.Next(0, permisos.Length);
            if (permisos[messi] == "False")
            {
                ver(permisos, letras, messi);
            }
            else
            {
                if (messi > 14)
                {
                    index = random.Next(0, 3);
                    Hiragana.FontSize = 150;
                }
                else
                {
                    index = random.Next(0, permisos[messi].Length + 1);
                    Hiragana.FontSize = 200;
                }
                Hiragana.Text = letras[messi, index, 0];
                Application.Current.Properties["respuesta"] = letras[messi, index, 1];
            }

        }
        string[,,] letras = { { { "あ", "a" }, { "い", "i" }, { "う", "u" }, { "え", "e" }, { "お", "o" } }, { { "か", "ka" }, { "き", "ki" }, { "く", "ku" }, { "け", "ke" }, { "こ", "ko" } }, { { "さ", "sa" }, { "し", "shi" }, { "す", "su" }, { "せ", "se" }, { "そ", "so" } }, { { "た", "ta" }, { "ち", "chi" }, { "つ", "tsu" }, { "て", "te" }, { "と", "to" } }, { { "な", "na" }, { "に", "ni" }, { "ぬ", "nu" }, { "ね", "ne" }, { "の", "no" } }, { { "は", "ha" }, { "ひ", "hi" }, { "ふ", "fu" }, { "へ", "he" }, { "ほ", "ho" } }, { { "ま", "ma" }, { "み", "mi" }, { "む", "mu" }, { "め", "me" }, { "も", "mo" } }, { { "ら", "ra" }, { "り", "ri" }, { "る", "ru" }, { "れ", "re" }, { "ろ", "ro" } }, { { "が", "ga" }, { "ぎ", "gi" }, { "ぐ", "gu" }, { "げ", "ge" }, { "ご", "go" } }, { { "ざ", "za" }, { "じ", "ji" }, { "ず", "zu" }, { "ぜ", "ze" }, { "ぞ", "zo" } }, { { "だ", "da" }, { "ぢ", "ji" }, { "づ", "zu" }, { "で", "de" }, { "ど", "do" } }, { { "ば", "ba" }, { "び", "bi" }, { "ぶ", "bu" }, { "べ", "be" }, { "ぼ", "bo" } }, { { "ぱ", "pa" }, { "ぴ", "pi" }, { "ぷ", "pu" }, { "ぺ", "pe" }, { "ぽ", "po" } }, { { "わ", "wa" }, { "を", "wo" }, { "ん", "n" }, { "", "" }, { "", "" } }, { { "や", "ya" }, { "ゆ", "yu" }, { "よ", "yo" }, { "", "" }, { "", "" } }, { { "きや", "kya" }, { "きゆ", "kyu" }, { "きよ", "kyo" }, { "", "" }, { "", "" } }, { { "ぎや", "gya" }, { "ぎゆ", "gyu" }, { "ぎよ", "gyo" }, { "", "" }, { "", "" } }, { { "しや", "sha" }, { "しゆ", "shu" }, { "しよ", "sho" }, { "", "" }, { "", "" } }, { { "じや", "ja" }, { "じゆ", "ju" }, { "じよ", "jo" }, { "", "" }, { "", "" } }, { { "ちや", "cha" }, { "ちゆ", "chu" }, { "ちよ", "cho" }, { "", "" }, { "", "" } }, { { "にや", "nya" }, { "にゆ", "nyu" }, { "によ", "nyo" }, { "", "" }, { "", "" } }, { { "ひや", "hya" }, { "ひゆ", "hyu" }, { "ひよ", "hyo" }, { "", "" }, { "", "" } }, { { "びや", "bya" }, { "びゆ", "byu" }, { "びよ", "byo" }, { "", "" }, { "", "" } }, { { "みや", "mya" }, { "みゆ", "myu" }, { "よ", "myo" }, { "", "" }, { "", "" } }, { { "りや", "rya" }, { "りゆ", "ryu" }, { "りよ", "ryo" }, { "", "" }, { "", "" } }, { { "ぴや", "pya" }, { "ぴゆ", "pyu" }, { "ぴよ", "pyo" }, { "", "" }, { "", "" } } };

        int messi = 0;

        public Page3()
        {
            InitializeComponent();
            int IDs = Int32.Parse(Application.Current.Properties["PermisosID"] as string);
            string[] permisos;
            permisos = new string[IDs];
            for (int i = 0; i < IDs; i++)
            {
                permisos[i] = Application.Current.Properties["permisos" + i] as string;
            }
            ver(permisos, letras, messi);
        }

        int Incorrectas = 0;
        int Correctas = 0;

        private async void Button_Clicked(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(RespuestaHi.Text))
            {
                int IDs = Int32.Parse(Application.Current.Properties["PermisosID"] as string);
                string[] permisos;
                permisos = new string[IDs];
                for (int i = 0; i < IDs; i++)
                {
                    permisos[i] = Application.Current.Properties["permisos" + i] as string;
                }
                string total = RespuestaHi.Text.ToLower();
                if (total == Application.Current.Properties["respuesta"] as string)
                {
                    await PopupNavigation.Instance.PushAsync(new Correcta());
                    RespuestaHi.Text = "";
                    ver(permisos, letras, messi);
                    Correctas = Correctas + 1;
                    Buena.Text = " " + Correctas;
                }
                else
                {
                    await PopupNavigation.Instance.PushAsync(new Incorrecta());
                    RespuestaHi.Text = "";
                    ver(permisos, letras, messi);
                    Incorrectas = Incorrectas + 1;
                    Mala.Text = " " + Incorrectas;
                }
            }
        }

        private async void RespuestaHi_Completed(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(RespuestaHi.Text))
            {
                int IDs = Int32.Parse(Application.Current.Properties["PermisosID"] as string);
                string[] permisos;
                permisos = new string[IDs];
                for (int i = 0; i < IDs; i++)
                {
                    permisos[i] = Application.Current.Properties["permisos" + i] as string;
                }
                string total = RespuestaHi.Text.ToLower();
                if (total == Application.Current.Properties["respuesta"] as string)
                {
                    await PopupNavigation.Instance.PushAsync(new Correcta());
                    RespuestaHi.Text = "";
                    ver(permisos, letras, messi);
                    Correctas = Correctas + 1;
                    Buena.Text = " " + Correctas;
                }
                else
                {
                    await PopupNavigation.Instance.PushAsync(new Incorrecta());
                    RespuestaHi.Text = "";
                    ver(permisos, letras, messi);
                    Incorrectas = Incorrectas + 1;
                    Mala.Text = " " + Incorrectas;
                }
            }
        }

    }
}