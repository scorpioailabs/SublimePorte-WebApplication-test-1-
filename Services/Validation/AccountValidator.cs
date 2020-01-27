using SublimePorteApplication.Domain;
using SublimePorteApplication.Services.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SublimePorteApplication.Services.Validation
{
    public static class AccountValidator
    {
        private const int EMAIL_ADDRESS_MAX_LENGTH = 256;
        private const int USERNAME_MAX_LENGTH = 128;

        public static async Task<List<AccountValidationError>> IsValidAccountAsync(User user, Accounts accounts)
        {
            var errors = new List<AccountValidationError>();

            if (String.IsNullOrEmpty(user.SublimeName))
            {
                errors.Add(new AccountValidationError
                {
                    ErrorCode = Model.Enums.AccountValidationError.USERNAME_MISSING,
                    Message = "Please key in your username."
                });
            }
            else if (user.Email?.Length > EMAIL_ADDRESS_MAX_LENGTH)
            {
                errors.Add(new AccountValidationError
                {
                    ErrorCode = Model.Enums.AccountValidationError.EMAIL_ADDRESS_TOO_LONG,
                    Message = "Your email address is too long."
                });
            }

            return errors;
        }

    }
}
