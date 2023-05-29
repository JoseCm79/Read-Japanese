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
    public partial class Page7 : ContentPage
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

        string[,,] letras = { { { "ア", "a" }, { "イ", "i" }, { "ウ", "u" }, { "エ", "e" }, { "オ", "o" } }, { { "カ", "ka" }, { "キ", "ki" }, { "ク", "ku" }, { "ケ", "ke" }, { "コ", "ko" } }, { { "サ", "sa" }, { "シ", "shi" }, { "ス", "su" }, { "セ", "se" }, { "ソ", "so" } }, { { "タ", "ta" }, { "チ", "chi" }, { "ツ", "tsu" }, { "テ", "te" }, { "ト", "to" } }, { { "ナ", "na" }, { "ニ", "ni" }, { "ヌ", "nu" }, { "ネ", "ne" }, { "ノ", "no" } }, { { "ハ", "ha" }, { "ヒ", "hi" }, { "フ", "fu" }, { "ヘ", "he" }, { "ホ", "ho" } }, { { "マ", "ma" }, { "ミ", "mi" }, { "ム", "mu" }, { "メ", "me" }, { "モ", "mo" } }, { { "ラ", "ra" }, { "リ", "ri" }, { "ル", "ru" }, { "レ", "re" }, { "ロ", "ro" } }, { { "ガ", "ga" }, { "ギ", "gi" }, { "グ", "gu" }, { "ゲ", "ge" }, { "ゴ", "go" } }, { { "ザ", "za" }, { "ジ", "ji" }, { "ズ", "zu" }, { "ゼ", "ze" }, { "ゾ", "zo" } }, { { "ダ", "da" }, { "ヂ", "ji" }, { "ヅ", "zu" }, { "デ", "de" }, { "ド", "do" } }, { { "バ", "ba" }, { "ビ", "bi" }, { "ブ", "bu" }, { "ベ", "be" }, { "ボ", "bo" } }, { { "パ", "pa" }, { "ピ", "pi" }, { "プ", "pu" }, { "ペ", "pe" }, { "ポ", "po" } }, { { "ワ", "wa" }, { "ヲ", "wo" }, { "ン", "n" }, { "", "" }, { "", "" } }, { { "ヤ", "ya" }, { "ユ", "yu" }, { "ヨ", "yo" }, { "", "" }, { "", "" } }, { { "キヤ", "kya" }, { "キユ", "kyu" }, { "キヨ", "kyo" }, { "", "" }, { "", "" } }, { { "ギヤ", "gya" }, { "ギユ", "gyu" }, { "ギヨ", "gyo" }, { "", "" }, { "", "" } }, { { "シヤ", "sha" }, { "シユ", "shu" }, { "シヨ", "sho" }, { "", "" }, { "", "" } }, { { "ジヤ", "ja" }, { "ジユ", "ju" }, { "ジヨ", "jo" }, { "", "" }, { "", "" } }, { { "ヂヤ", "cha" }, { "ヂユ", "chu" }, { "ヂヨ", "cho" }, { "", "" }, { "", "" } }, { { "ニヤ", "nya" }, { "ニユ", "nyu" }, { "ニヨ", "nyo" }, { "", "" }, { "", "" } }, { { "ヒヤ", "hya" }, { "ヒユ", "hyu" }, { "ヒヨ", "hyo" }, { "", "" }, { "", "" } }, { { "ビヤ", "bya" }, { "ビユ", "byu" }, { "ビヨ", "byo" }, { "", "" }, { "", "" } }, { { "ミヤ", "mya" }, { "ミユ", "myu" }, { "ミヨ", "myo" }, { "", "" }, { "", "" } }, { { "リヤ", "rya" }, { "リユ", "ryu" }, { "リヨ", "ryo" }, { "", "" }, { "", "" } }, { { "ピヤ", "pya" }, { "ピユ", "pyu" }, { "ピヨ", "pyo" }, { "", "" }, { "", "" } } };
        int messi = 0;

        public Page7()
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

        int Correctas = 0;
        int Incorrectas = 0;


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
               if(Hiragana.Text == "フ")
                {
                    if( total == "fu" || total == "hu")
                    {
                        total = "fu/hu";
                    }
                }
                if (Hiragana.Text == "ハ")
                {
                    if (total == "ha" || total == "wa")
                    {
                        total = "ha/wa";
                    }
                }
                if (Hiragana.Text == "フ")
                {
                    if (total == "he" || total == "e")
                    {
                        total = "he/e";
                    }
                }
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