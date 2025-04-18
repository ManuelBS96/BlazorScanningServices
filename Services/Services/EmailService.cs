

using Services.IServices;

namespace Services.Services
{
    public class EmailService : IEmailService
    {
        public Task<string> SendEmail(string email)
        {
           
            Task.Delay(1000);
            return Task.FromResult($"Sending Email to {email}");
        }
    }
}
