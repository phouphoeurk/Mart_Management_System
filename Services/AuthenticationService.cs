using Mart_Management_System.Models;
using Mart_Management_System.Repositories;

namespace Mart_Management_System.Services
{
    public sealed class AuthenticationService
    {
        private readonly IUser _userRepository;

        public AuthenticationService(IUser userRepository)
        {
            _userRepository = userRepository;
        }

        public User? Authenticate(
            string username,
            string password,
            out string errorMessage
        )
        {
            errorMessage = string.Empty;
            User? user = _userRepository.FindByUsername(username);

            if (user is null)
            {
                errorMessage = "Invalid username or password.";
                return null;
            }

            if (!user.IsActive)
            {
                errorMessage =
                    "This account is inactive. Please contact an administrator.";
                return null;
            }

            if (string.IsNullOrWhiteSpace(user.PasswordHash)
                || !global::BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                errorMessage = "Invalid username or password.";
                return null;
            }

            // The authenticated session does not need to retain the password hash.
            user.PasswordHash = string.Empty;
            return user;
        }
    }
}
