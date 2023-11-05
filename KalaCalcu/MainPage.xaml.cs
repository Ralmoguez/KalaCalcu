using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace KalaCalcu
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void LoginClicked(object sender, EventArgs args)
        {
            if (usernameEntry.Text == null)
            {
                messageLabel.TextColor = Color.FromHex("#9C363A");
                messageLabel.Text = "Username entry is Empty!";
            }
            else if (usernameEntry.Text != null && usernameEntry.Text.Trim().Equals(""))
            {
                messageLabel.TextColor = Color.FromHex("#9C363A");
                messageLabel.Text = "Username entry is Empty!";
            }
            else if (passwordEntry.Text == null)
            {
                messageLabel.TextColor = Color.FromHex("#9C363A");
                messageLabel.Text = "Password entry is Empty!";
            }
            else if (passwordEntry.Text != null && passwordEntry.Text.Trim().Equals(""))
            {
                messageLabel.TextColor = Color.FromHex("#9C363A");
                messageLabel.Text = "Password entry is Empty!";
            }
            else if (passwordEntry.Text != null && passwordEntry.Text.Length < 6)
            {
                messageLabel.TextColor = Color.FromHex("#9C363A");
                messageLabel.Text = "Password is too short!";
            }
            else
            {
                CheckIfExisting();
            }
        }

        private async void CheckIfExisting()
        {
            User userGot = await App.Database.GetUser(usernameEntry.Text.Trim().ToLower());

            if (userGot != null)
            {
                LoginUser();
            }
            else
            {
                messageLabel.TextColor = Color.FromHex("#9C363A");
                messageLabel.Text = "Account does not exists!";
            }
        }

        private async void LoginUser()
        {
            User userGot = await App.Database.CheckIfCorrectUser(usernameEntry.Text.ToLower(), passwordEntry.Text);
            if (userGot != null)
            {
                App.Current.MainPage = new MainNav(userGot.Firstname, userGot.ContactNo);
            }
            else
            {
                messageLabel.TextColor = Color.FromHex("#9C363A");
                messageLabel.Text = "Wrong Password!";
            }
        }

        private void SignUpClicked(object sender, EventArgs args)
        {
            App.Current.MainPage = new Register();
        }

        protected override bool OnBackButtonPressed()
        {
            Device.BeginInvokeOnMainThread(async () => {
                var result = await DisplayAlert("Exit?", "Do you really want to exit?", "Yes", "No");
                if (result) Environment.Exit(0);
            });

            return true;
        }
    }
}
