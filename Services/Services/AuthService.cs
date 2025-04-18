
using Services.IServices;

namespace Services.Services
{
    public class AuthService : IAuthService
    {
        public Task<bool> Authenticate(string user)
        {
            if (string.IsNullOrEmpty(user)) return Task.FromResult(false);

            return Task.FromResult(true);

        }
    }
}
