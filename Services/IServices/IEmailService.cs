

using Microsoft.Extensions.DependencyInjection;

namespace Services.IServices
{
    [ServiceLifetime(ServiceLifetime.Transient)]
    public interface IEmailService
    {
        /// <summary>
        /// Simulated a send Email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<string> SendEmail(string email);
    }
}
