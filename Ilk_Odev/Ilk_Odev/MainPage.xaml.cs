using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
namespace Ilk_Odev
{
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Preferences.Clear();
            Application.Current.MainPage = new LoginPage();
        }

        private void Dial_Clicked(object sender, EventArgs e)
        {
            try
            {
                PhoneDialer.Open(EntryNumber_for_dial.Text);
            }
            catch (Exception)
            {
                DisplayAlert("Unable to make call", "Please enter a number", "OK");
            }
            
        }

        private async void Send_ClickedAsync(object sender, EventArgs e)
        {
            try
            {
                await Sms.ComposeAsync(new SmsMessage(EntrySms.Text, EntryNumber_for_sms.Text));
            }
            catch (Exception)
            {
                DisplayAlert("Unable to send sms", "Please enter a number and text", "OK");
            }
        }

        private async void Send_Email(object sender, EventArgs e)
        {
            var message = new EmailMessage(EntrySubject.Text, "", EntryEmail.Text);
            try
            {
                await Email.ComposeAsync(message);
            }
            catch (Exception)
            {
                DisplayAlert("Unable to send email", "Please enter a email and text", "OK");
            }


        }

        private async void Open_Website(object sender, EventArgs e)
        {
            try
            {
                await Browser.OpenAsync(EntryUrl.Text, BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception)
            {
                DisplayAlert("Unable to open website", "Please enter a valid url", "OK");
            }
        }

        private async void Open_Map(object sender, EventArgs e)
        {
            var options = new MapLaunchOptions { NavigationMode = NavigationMode.None };
            var placeMark = new Placemark
            {
                Locality = EntryLocation.Text
            };

            try
            {
                await Map.OpenAsync(placeMark, options);
            }
            catch (Exception)
            {
                DisplayAlert("Unable to open map", "Please enter a location or maybe you dont have map", "OK");
            }
        }
    }
}
