using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SublimePorteApplication.Services.Validation
{
    public class AccountValidationError
    {
        public Model.Enums.AccountValidationError ErrorCode { get; set; }
        public string Message { get; set; }
    }
}
