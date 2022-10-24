using Microsoft.Extensions.Options;
using OTP_Application.Helpers;
using OTP_Application.Interfaces;
using Twilio;
using Twilio.Types;
using Twilio.Rest.Api.V2010.Account;


namespace OTP_Application.Twilio
{
    public class TwilioService : ISMSServices
    {
        private readonly TwilioSettings _twilio;

        public TwilioService(IOptions<TwilioSettings> twilio)
        {
            _twilio = twilio.Value;
        }
        //public string TwilioSender ()
        //{
        //    // Find your Account SID and Auth Token at twilio.com/console
        //    // and set the environment variables. See http://twil.io/secure
        //    string accountSid = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
        //    string authToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");

        //    TwilioClient.Init(accountSid, authToken);

        //    var message = MessageResource.Create(
        //        body: "This is the ship that made the kessel Run in fourteen parsecs?",
        //        from: new Twilio.Types.PhoneNumber(),
        //        to: new Twilio.Types.PhoneNumber()
        //        );

        //    return message.Sid;

        //}
        public MessageResource Send(string mobileNumber, string body)
        {
            TwilioClient.Init(_twilio.AccountSID, _twilio.AuthToken);

            var result = MessageResource.Create(
                body: body,
                from: new PhoneNumber(_twilio.TwilioPhoneNumber),
                to: mobileNumber);
            return result;
        }
    }
}
