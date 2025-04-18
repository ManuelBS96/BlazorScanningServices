

using Microsoft.Extensions.DependencyInjection;

namespace Services.IServices
{
    [ServiceLifetime(ServiceLifetime.Singleton)]
    public interface IAuthService
    {
        /// <summary>
        /// Simulated a Task
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<bool> Authenticate(string user);
    }
}
