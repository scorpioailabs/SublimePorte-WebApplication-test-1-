using SublimePorteApplication.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SublimePorteApplication.Services.Validation
{
    public class LoginValidator
    {
        private const int USERNAME_MISSING = 0;
        private const int USERNAME_MAX_LENGTH = 128;

        public static async Task<List<LoginValidationError>> IsValidLoginAsync(User user)
        {
            var errors = new List<LoginValidationError>();

            if (String.IsNullOrEmpty(user.UserName))
            {
                errors.Add(new LoginValidationError
                {
                    ErrorCode = Model.Enums.LoginValidationError.USERNAME_MISSING,
                    Message = "Please key in your username."
                });
            }
            else if (user.UserName?.Length > USERNAME_MAX_LENGTH)
            {
                errors.Add(new LoginValidationError
                {
                    ErrorCode = Model.Enums.LoginValidationError.USERNAME_TOO_LONG,
                    Message = "Your email address is too long."
                });
            }

            return errors;
        }
    }
}
