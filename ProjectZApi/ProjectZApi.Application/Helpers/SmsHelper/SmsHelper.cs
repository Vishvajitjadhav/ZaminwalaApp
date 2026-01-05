using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace ProjectZApi.Helpers.SmsHelper
{
    public class SmsHelper
    {
        public static void SendOTPViaSMS(string phone, string otp)
        {
            string accountSid = "your_twilio_account_sid";
            string authToken = "your_twilio_auth_token";
            string twilioPhoneNumber = "+1234567890"; // Twilio phone number

            TwilioClient.Init(accountSid, authToken);

            try
            {
                var message = MessageResource.Create(
                    body: $"Your OTP is {otp}. It expires in 5 minutes.",
                    from: new Twilio.Types.PhoneNumber(twilioPhoneNumber),
                    to: new Twilio.Types.PhoneNumber(phone)
                );

                Console.WriteLine($"OTP Sent Successfully: {message.Sid}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending OTP: {ex.Message}");
            }
        }
    }
}
