using SublimePorteApplication.Domain;
using SublimePorteApplication.Services.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SublimePorteApplication.Services.Model
{
    public class UserCreationUpdateResult
    {
        public bool Success { get; set; }
        public User User { get; set; }
        public List<AccountValidationError> Errors { get; set; }
    }
}
