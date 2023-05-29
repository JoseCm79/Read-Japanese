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
    public partial class mul_kata : ContentPage
    {
        void ver(string[] permisos, string[,,] letras)
        {
            for (int i = 0; i < 3; i++)
            {
                Application.Current.Properties["respuestas" + i] = "";
            }



            Button[] opciones = { Opcion1, Opcion2, Opcion3, Opcion4 };
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
                    Hiragana.FontSize = 170;
                }
                else
                {
                    randon2 = random.Next(0, 4);
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

                        Application.Current.Properties["respuestas" + i] = letras[randon, randon2, 1];
                    }
                    else
                    {
                        opciones[i].Text = respuesta;
                        Application.Current.Properties["index"] = i;
                        Application.Current.Properties["respuestas" + Application.Current.Properties["index"].ToString()] = respuesta;
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

        string[,,] letras = { { { "ア", "a" }, { "イ", "i" }, { "ウ", "u" }, { "エ", "e" }, { "オ", "o" } }, { { "カ", "ka" }, { "キ", "ki" }, { "ク", "ku" }, { "ケ", "ke" }, { "コ", "ko" } }, { { "サ", "sa" }, { "シ", "shi" }, { "ス", "su" }, { "セ", "se" }, { "ソ", "so" } }, { { "タ", "ta" }, { "チ", "chi" }, { "ツ", "tsu" }, { "テ", "te" }, { "ト", "to" } }, { { "ナ", "na" }, { "ニ", "ni" }, { "ヌ", "nu" }, { "ネ", "ne" }, { "ノ", "no" } }, { { "ハ", "ha" }, { "ヒ", "hi" }, { "フ", "fu" }, { "ヘ", "he" }, { "ホ", "ho" } }, { { "マ", "ma" }, { "ミ", "mi" }, { "ム", "mu" }, { "メ", "me" }, { "モ", "mo" } }, { { "ラ", "ra" }, { "リ", "ri" }, { "ル", "ru" }, { "レ", "re" }, { "ロ", "ro" } }, { { "ガ", "ga" }, { "ギ", "gi" }, { "グ", "gu" }, { "ゲ", "ge" }, { "ゴ", "go" } }, { { "ザ", "za" }, { "ジ", "ji" }, { "ズ", "zu" }, { "ゼ", "ze" }, { "ゾ", "zo" } }, { { "ダ", "da" }, { "ヂ", "ji" }, { "ヅ", "zu" }, { "デ", "de" }, { "ド", "do" } }, { { "バ", "ba" }, { "ビ", "bi" }, { "ブ", "bu" }, { "ベ", "be" }, { "ボ", "bo" } }, { { "パ", "pa" }, { "ピ", "pi" }, { "プ", "pu" }, { "ペ", "pe" }, { "ポ", "po" } }, { { "ワ", "wa" }, { "ヲ", "wo" }, { "ン", "n" }, { "", "" }, { "", "" } }, { { "ヤ", "ya" }, { "ユ", "yu" }, { "ヨ", "yo" }, { "", "" }, { "", "" } }, { { "キヤ", "kya" }, { "キユ", "kyu" }, { "キヨ", "kyo" }, { "", "" }, { "", "" } }, { { "ギヤ", "gya" }, { "ギユ", "gyu" }, { "ギヨ", "gyo" }, { "", "" }, { "", "" } }, { { "シヤ", "sha" }, { "シユ", "shu" }, { "シヨ", "sho" }, { "", "" }, { "", "" } }, { { "ジヤ", "ja" }, { "ジユ", "ju" }, { "ジヨ", "jo" }, { "", "" }, { "", "" } }, { { "ヂヤ", "cha" }, { "ヂユ", "chu" }, { "ヂヨ", "cho" }, { "", "" }, { "", "" } }, { { "ニヤ", "nya" }, { "ニユ", "nyu" }, { "ニヨ", "nyo" }, { "", "" }, { "", "" } }, { { "ヒヤ", "hya" }, { "ヒユ", "hyu" }, { "ヒヨ", "hyo" }, { "", "" }, { "", "" } }, { { "ビヤ", "bya" }, { "ビユ", "byu" }, { "ビヨ", "byo" }, { "", "" }, { "", "" } }, { { "ミヤ", "mya" }, { "ミユ", "myu" }, { "ミヨ", "myo" }, { "", "" }, { "", "" } }, { { "リヤ", "rya" }, { "リユ", "ryu" }, { "リヨ", "ryo" }, { "", "" }, { "", "" } }, { { "ピヤ", "pya" }, { "ピユ", "pyu" }, { "ピヨ", "pyo" }, { "", "" }, { "", "" } } };


        public mul_kata()
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