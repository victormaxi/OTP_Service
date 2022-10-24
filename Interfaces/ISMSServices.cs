using Twilio.Rest.Api.V2010.Account;

namespace OTP_Application.Interfaces
{
    public interface ISMSServices
    {
        MessageResource Send(string mobileNumber, string body);
    }
}
