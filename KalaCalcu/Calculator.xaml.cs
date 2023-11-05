using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Xamarin.Essentials;

namespace KalaCalcu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Calculator : ContentPage
    {
        private int cans = 0, news = 0, plasticBottles = 0, glassBottles = 0, plasticBags = 0, tires = 0;
        private double total;
        private string accountName, contactNo;


        private SmsClass sms = new SmsClass();
        public Calculator()
        {
            InitializeComponent();
            junkshopPicker.SelectedIndex = 0; 
        }

        public void SetAccount(string accountName, string contactNo)
        {
            this.accountName = accountName;
            this.contactNo = contactNo;
        }

        private void SendClicked(object sender, EventArgs arg)
        {
            SendSMS();
        }
        
        private async void SendSMS()
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                string message = "Hi there! There is a request for the collection of junk at Barangay Maysantol.\nName: " + accountName+
                " & Contact: " + contactNo+
                ".\nThanks and be safe!";

                /*string no = "+639763330402";*/
                /*string no = "+639169220883";*/
                string no = "+639155470913";
                string receiver;
                switch (junkshopPicker.SelectedItem.ToString())
                {
                    case "Maysantol":
                        receiver = no;
                        break;
                    case "Poblacion":
                        receiver = no;
                        break;
                    case "Balite":
                        receiver = no;
                        break;
                    default:
                        receiver = no;
                        break;
                }

                bool status = sms.SendTextTwilio(receiver, "\n" + message);

                //bool status = sms.SendTextTwilio("+639174598166", "\n" + message); // for debug only, remove after

                string msgResult;
                string msgTitle;
                if (status)
                {
                    msgTitle = "Message Queued!";
                    msgResult = "Hi KalaCalcu warrior!\r\n\r\nThank you for using the KalaCalcu app! Please minutes until the collectors are right in front of your doorsteps.\r\n\r\nTogether, let's achieve a #ZeroWasteCommunity!";
                }
                else
                {
                    msgTitle = "Message Failed to be Queued!";
                    msgResult = "Something went wrong.\n\r\nPlease contact us.";
                }

                await DisplayAlert(msgTitle, msgResult, "OK");
            }
            else
            {
                await DisplayAlert("Message Failed to be Queued!", "There is no internet connection.", "Understood");
            }
            
        }

        private void AddClicked(object sender, EventArgs args)
        {
            string item = ((ImageButton)sender).ClassId;
            switch (item)
            {
                case "cans":
                    cans++;
                    cansLabel.Text = cans.ToString();
                    break;
                case "news":
                    news++;
                    newsLabel.Text = news.ToString();
                    break;
                case "plasticbottles":
                    plasticBottles++;
                    plasticbottlesLabel.Text = plasticBottles.ToString();
                    break;
                case "glassbottles":
                    glassBottles++;
                    glassbottlesLabel.Text = glassBottles.ToString();
                    break;
                case "plasticbag":
                    plasticBags++;
                    plasticbagLabel.Text = plasticBags.ToString();
                    break;
                case "tire":
                    tires++;
                    tireLabel.Text = tires.ToString();
                    break;
            }

            SetTotal();
        }

        private void SubtractClicked(object sender, EventArgs args)
        {
            string item = ((ImageButton)sender).ClassId;
            switch (item)
            {
                case "cans":
                    cans--;
                    if (cans < 0)
                    {
                        cans = 0;
                    }
                    cansLabel.Text = cans.ToString();
                    cansLabel.HorizontalTextAlignment = TextAlignment.Center;
                    break;
                case "news":
                    news--;
                    if (news < 0)
                    {
                        news = 0;
                    }
                    newsLabel.Text = news.ToString();
                    newsLabel.HorizontalTextAlignment = TextAlignment.Center;
                    break;
                case "plasticbottles":
                    plasticBottles--;
                    if (plasticBottles < 0)
                    {
                        plasticBottles = 0;
                    }
                    plasticbottlesLabel.Text = plasticBottles.ToString();
                    plasticbottlesLabel.HorizontalTextAlignment = TextAlignment.Center;
                    break;
                case "glassbottles":
                    glassBottles--;
                    if (glassBottles < 0)
                    {
                        glassBottles = 0;
                    }
                    glassbottlesLabel.Text = glassBottles.ToString();
                    glassbottlesLabel.HorizontalTextAlignment = TextAlignment.Center;
                    break;
                case "plasticbag":
                    plasticBags--;
                    if (plasticBags < 0)
                    {
                        plasticBags = 0;
                    }
                    plasticbagLabel.Text = plasticBags.ToString();
                    plasticbagLabel.HorizontalTextAlignment = TextAlignment.Center;
                    break;
                case "tire":
                    tires--;
                    if (tires < 0)
                    {
                        tires = 0;
                    }
                    tireLabel.Text = tires.ToString();
                    tireLabel.HorizontalTextAlignment = TextAlignment.Center;
                    break;
            }

            SetTotal();
        }

        private void SetTotal()
        {
            total = cans * 1 + news * .5 + plasticBottles * 1 + glassBottles * 5 + plasticBags * 2 + tires * 10;
            priceLabel.Text = total.ToString();
        }
    }
}