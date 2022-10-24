namespace OTP_Application.Twilio
{
    public class AuthMessangerSender
    {
        public Task SendSmsAsync(string number, string message)
        {
            ASPSMS.SMS SMSSender = new ASPSMS.SMS();

            SMSSender.Userkey = "";
            SMSSender.Password = "";
            SMSSender.Originator = "";

            SMSSender.AddRecipient(number);
            SMSSender.MessageData = message;

            SMSSender.SendTextSMS();

            return Task.FromResult(0);
        }
    }
}
