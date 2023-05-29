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
    public partial class mul_Hiragana : ContentPage
    {

        void ver(string[] permisos, string[,,] letras)
        {
            for (int i = 0; i < 3; i++)
            {
                Application.Current.Properties["respuestas" + i] = "";
            }
            
            

            Button[] opciones = { Opcion1, Opcion2, Opcion3, Opcion4};
            Random random = new Random();
            int Respuesta = random.Next(0, opciones.Length);
            randon = random.Next(0, 26);
            if (permisos[randon] == "False")
            {
                ver(permisos, letras);
            }
            else
            {
                if (randon > 12)
                {
                    randon2 = random.Next(0, 2);
                    Hiragana.FontSize = 140;
                }
                else
                {
                    randon2 = random.Next(0, 4);
                    Hiragana.FontSize = 200;
                }
                int escondite = random.Next(0, 3);
                string letra = letras[randon, randon2, 0];
                string respuesta = letras[randon, randon2, 1];

                Hiragana.Text = letra;

                for (int i = 0; i < 3; i++)
                {

                    if (i != escondite)
                    {
                        randon = random.Next(0, 26);
                        if (randon > 12)
                        {
                            randon2 = random.Next(0, 2);
                        }
                        else
                        {
                            randon2 = random.Next(0, 4);
                        }
                        opciones[i].Text = letras[randon, randon2, 1];
                        
                        Application.Current.Properties["respuestas"+i] = letras[randon, randon2, 1];
                    }
                    else
                    {
                        opciones[i].Text = respuesta;
                        Application.Current.Properties["index"] = i;
                        Application.Current.Properties["respuestas"+Application.Current.Properties["index"].ToString() ] = respuesta;
                    }
                }
            }
            
        }
            
        async void Comprobar(Button a)
        {
            if (a.Text == Application.Current.Properties["respuestas" + Application.Current.Properties["index"].ToString()].ToString())
            {
                Correctas = Correctas + 1;
                Buena.Text = " " + Correctas;
                await PopupNavigation.Instance.PushAsync(new Correcta());
            }
            else
            {
                Incorrectas = Incorrectas + 1;
                Mala.Text = " " + Incorrectas;
                Application.Current.Properties["respuesta"] = Application.Current.Properties["respuestas" + Application.Current.Properties["index"].ToString()].ToString();
                await PopupNavigation.Instance.PushAsync(new Incorrecta());
            }

            int IDs = Int32.Parse(Application.Current.Properties["PermisosID"] as string);
            string[] permisos;
            permisos = new string[IDs];
            for (int i = 0; i < IDs; i++)
            {
                permisos[i] = Application.Current.Properties["permisos" + i] as string;
            }
            ver(permisos, letras);

        }

            int randon;
            int randon2;
        


        string[,,] letras = { { { "あ", "a" }, { "い", "i" }, { "う", "u" }, { "え", "e" }, { "お", "o" } }, { { "か", "ka" }, { "き", "ki" }, { "く", "ku" }, { "け", "ke" }, { "こ", "ko" } }, { { "さ", "sa" }, { "し", "shi" }, { "す", "su" }, { "せ", "se" }, { "そ", "so" } }, { { "た", "ta" }, { "ち", "chi" }, { "つ", "tsu" }, { "て", "te" }, { "と", "to" } }, { { "な", "na" }, { "に", "ni" }, { "ぬ", "nu" }, { "ね", "ne" }, { "の", "no" } }, { { "は", "ha" }, { "ひ", "hi" }, { "ふ", "fu" }, { "へ", "he" }, { "ほ", "ho" } }, { { "ま", "ma" }, { "み", "mi" }, { "む", "mu" }, { "め", "me" }, { "も", "mo" } }, { { "ら", "ra" }, { "り", "ri" }, { "る", "ru" }, { "れ", "re" }, { "ろ", "ro" } }, { { "が", "ga" }, { "ぎ", "gi" }, { "ぐ", "gu" }, { "げ", "ge" }, { "ご", "go" } }, { { "ざ", "za" }, { "じ", "ji" }, { "ず", "zu" }, { "ぜ", "ze" }, { "ぞ", "zo" } }, { { "だ", "da" }, { "ぢ", "ji" }, { "づ", "zu" }, { "で", "de" }, { "ど", "do" } }, { { "ば", "ba" }, { "び", "bi" }, { "ぶ", "bu" }, { "べ", "be" }, { "ぼ", "bo" } }, { { "ぱ", "pa" }, { "ぴ", "pi" }, { "ぷ", "pu" }, { "ぺ", "pe" }, { "ぽ", "po" } }, { { "わ", "wa" }, { "を", "wo" }, { "ん", "n" }, { "", "" }, { "", "" } }, { { "や", "ya" }, { "ゆ", "yu" }, { "よ", "yo" }, { "", "" }, { "", "" } }, { { "きや", "kya" }, { "きゆ", "kyu" }, { "きよ", "kyo" }, { "", "" }, { "", "" } }, { { "ぎや", "gya" }, { "ぎゆ", "gyu" }, { "ぎよ", "gyo" }, { "", "" }, { "", "" } }, { { "しや", "sha" }, { "しゆ", "shu" }, { "しよ", "sho" }, { "", "" }, { "", "" } }, { { "じや", "ja" }, { "じゆ", "ju" }, { "じよ", "jo" }, { "", "" }, { "", "" } }, { { "ちや", "cha" }, { "ちゆ", "chu" }, { "ちよ", "cho" }, { "", "" }, { "", "" } }, { { "にや", "nya" }, { "にゆ", "nyu" }, { "によ", "nyo" }, { "", "" }, { "", "" } }, { { "ひや", "hya" }, { "ひゆ", "hyu" }, { "ひよ", "hyo" }, { "", "" }, { "", "" } }, { { "びや", "bya" }, { "びゆ", "byu" }, { "びよ", "byo" }, { "", "" }, { "", "" } }, { { "みや", "mya" }, { "みゆ", "myu" }, { "よ", "myo" }, { "", "" }, { "", "" } }, { { "りや", "rya" }, { "りゆ", "ryu" }, { "りよ", "ryo" }, { "", "" }, { "", "" } }, { { "ぴや", "pya" }, { "ぴゆ", "pyu" }, { "ぴよ", "pyo" }, { "", "" }, { "", "" } } };

        public mul_Hiragana()
        {
            InitializeComponent();
            int IDs = Int32.Parse(Application.Current.Properties["PermisosID"] as string);
            string[] permisos;
            permisos = new string[IDs];
            for (int i = 0; i < IDs; i++)
            {
                permisos[i] = Application.Current.Properties["permisos" + i] as string;
            }
            ver(permisos, letras);


        }
        int Incorrectas = 0;
        int Correctas = 0;
        private void Opcion1_Clicked(object sender, EventArgs e)
        {
            Comprobar(Opcion1);
        }

        private void Opcion3_Clicked(object sender, EventArgs e)
        {
            Comprobar(Opcion3);
        }

        private void Opcion4_Clicked(object sender, EventArgs e)
        {
            Comprobar(Opcion4);
        }

        private void Opcion2_Clicked(object sender, EventArgs e)
        {
            Comprobar(Opcion2);
        }
    }
}