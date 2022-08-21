using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace Ilk_Odev
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Preferences.Clear();
            if (Email.Text != string.Empty &&
                Password.Text != string.Empty &&
                Name_Surname.Text != string.Empty &&
                Age.Text != string.Empty)
            {
                Preferences.Set("name_surname", Name_Surname.Text);
                Preferences.Set("age", Age.Text);
                Preferences.Set("email", Email.Text);
                Preferences.Set("password", Password.Text);
               
                Application.Current.MainPage = new LoginPage();
            }
            else
            {
                Hata_Durumu.Text = "Please do not leave blank space.";
            }
        }
    }
}