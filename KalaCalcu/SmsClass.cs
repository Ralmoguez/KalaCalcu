using System.Net.Http;
using Xamarin.Forms;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace KalaCalcu
{
    public class SmsClass
    {
        public bool SendTextTwilio(string number, string message)
        {
            string accountSid = "AC792b77b233ddc50bc2e050d2aaf8776a";
            string authToken = "4c6806ce1d09da85c7d623730078b82b";

            TwilioClient.Init(accountSid, authToken);

            var mes = MessageResource.Create(
                body: message,
                from: new Twilio.Types.PhoneNumber("+19034857557"),
                to: new Twilio.Types.PhoneNumber(number)
            );

            return mes.Status.ToString().Equals("queued");
        }

    }
}
