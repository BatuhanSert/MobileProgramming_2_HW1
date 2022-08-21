using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
//ben ekledim...
using Xamarin.Essentials;


namespace Ilk_Odev
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        string email_adresi = Preferences.Get("email", "null");
        string sifre = Preferences.Get("password", "null");
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Login_Clicked(object sender, EventArgs e)
        {
            if ((Email.Text == "admin" && Password.Text == "1234") 
                || (Email.Text == email_adresi && Password.Text == sifre))
            {
                //if (Kaydet_Switch.IsToggled)
                //{
                    Hata_Durumu.Text = "Successfully logged in!";
                    Preferences.Set("email", Email.Text);
                    Preferences.Set("password", Password.Text);
                //}
                //else
                //{
                    //Preferences.Clear();
                    //Hata_Durumu.Text = "Deleting preferences!";
                //}
                Application.Current.MainPage = new MainPage();
            }
            else
            {
                Hata_Durumu.Text = "Username or Password is wrong!!";

            }
        }


        private void Register_Clicked(object sender, EventArgs e)
        {
            Preferences.Clear();
            Application.Current.MainPage = new RegisterPage();
        }
    }
}