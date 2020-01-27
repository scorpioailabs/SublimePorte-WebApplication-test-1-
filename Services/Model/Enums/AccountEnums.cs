using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SublimePorteApplication.Services.Model.Enums
{
    public enum AccountValidationError
    {
        USERNAME_ALREADY_EXISTS,
        USERNAME_MISSING,
        USERNAME_TOO_LONG,
        PASSWORD_MISSING,
        PASSWORD_INVALID,
        PASSWORD_TOO_LONG,
        PASSWORD_MISMATCH,
        EMAIL_ADDRESS_INVALID,
        EMAIL_ADDRESS_MISSING,
        EMAIL_ADDRESS_TOO_LONG,
        EMAIL_ADDRESS_ALREADY_EXISTS,
        ACCOUNT_INVALID
    }
}
