using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
namespace Ilk_Odev
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            if (check_email_password())
            {
                MainPage = new MainPage();
            }
            else
            {
                MainPage = new LoginPage();
            }
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        private bool check_email_password()
        {
            string email = Preferences.Get("email", string.Empty);
            string sifre = Preferences.Get("password", string.Empty);
            if(email != string.Empty && sifre != string.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
