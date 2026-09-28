using Mart_Management_System.Enums;
using Mart_Management_System.Models;
using Mart_Management_System.Repositories;

namespace Mart_Management_System.Services
{
    public sealed class AuthenticationService
    {
        public const string PendingApprovalMessage =
            "Your account is waiting for admin approval.";

        private readonly IUser _userRepository;

        public AuthenticationService(IUser userRepository)
        {
            _userRepository = userRepository;
        }

        public User? Authenticate(
            string username,
            string password,
            out string errorMessage,
            out AuthenticationFailure failure
        )
        {
            errorMessage = string.Empty;
            failure = AuthenticationFailure.None;

            User? user = _userRepository.FindByUsername(username);

            if (user is null)
            {
                errorMessage = "Invalid username or password.";
                failure = AuthenticationFailure.InvalidCredentials;
                return null;
            }

            // The password is verified before the approval state is reported so
            // that "pending approval" is only shown to someone who already knows
            // the correct password. Reporting it earlier would let any caller
            // enumerate which usernames exist and are awaiting approval.
            if (string.IsNullOrWhiteSpace(user.PasswordHash)
                || !global::BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                errorMessage = "Invalid username or password.";
                failure = AuthenticationFailure.InvalidCredentials;
                return null;
            }

            if (!user.IsActive)
            {
                errorMessage = PendingApprovalMessage;
                failure = AuthenticationFailure.PendingApproval;
                return null;
            }

            // The authenticated session does not need to retain the password hash.
            user.PasswordHash = string.Empty;
            return user;
        }
    }
}
