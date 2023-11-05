using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KalaCalcu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Register : ContentPage
    {
        public Register()
        {
            InitializeComponent();
        }

        private void RegisterClicked(object sender, EventArgs args)
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
            else if (firstnameEntry.Text == null)
            {
                messageLabel.TextColor = Color.FromHex("#9C363A");
                messageLabel.Text = "Firstname entry is Empty!";
            }
            else if (firstnameEntry.Text != null && firstnameEntry.Text.Trim().Equals(""))
            {
                messageLabel.TextColor = Color.FromHex("#9C363A");
                messageLabel.Text = "Firstname entry is Empty!";
            }
            else if (lastnameEntry.Text == null)
            {
                messageLabel.TextColor = Color.FromHex("#9C363A");
                messageLabel.Text = "Lastname entry is Empty!";
            }
            else if (lastnameEntry.Text != null && lastnameEntry.Text.Trim().Equals(""))
            {
                messageLabel.TextColor = Color.FromHex("#9C363A");
                messageLabel.Text = "Lastname entry is Empty!";
            }
            else if (string.IsNullOrEmpty(contactEntry.Text))
            {
                messageLabel.TextColor = Color.FromHex("#9C363A");
                messageLabel.Text = "Contact Number entry is Empty!";
            }else if (contactEntry.Text != null && contactEntry.Text.Trim().Length < 10)
            {
                messageLabel.TextColor = Color.FromHex("#9C363A");
                messageLabel.Text = "Contact Number is too short!";
            }
            else if (contactEntry.Text != null && contactEntry.Text.Trim().Length > 11)
            {
                messageLabel.TextColor = Color.FromHex("#9C363A");
                messageLabel.Text = "Contact Number is too long!";
            }
            else
            {
                CheckIfExisting();
            }
        }

        private async void CheckIfExisting()
        {
            User userGot = await App.Database.GetUser(usernameEntry.Text);

            if (userGot == null)
            {
                RegisterUser();
            }
            else
            {
                messageLabel.TextColor = Color.FromHex("#9C363A");
                messageLabel.Text = "Account already exists!";
            }
        }

        private void RegisterUser()
        {
            User user = new User
            {
                Username = usernameEntry.Text.Trim().ToLower(),
                Password = passwordEntry.Text.Trim(),
                Firstname = firstnameEntry.Text.Trim().ToLower(),
                Lastname = lastnameEntry.Text.Trim().ToLower(),
                ContactNo = contactEntry.Text.Trim().ToLower()
            };
            
            App.Database.SaveUserAsync(user);
            messageLabel.TextColor = Color.FromHex("#00D100");
            messageLabel.Text = "Account registered!";
        }

        private void BackClicked(object sender, EventArgs args)
        {
            App.Current.MainPage = new MainPage();
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}