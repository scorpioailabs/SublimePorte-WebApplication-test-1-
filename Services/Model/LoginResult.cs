using SublimePorteApplication.Domain;
using SublimePorteApplication.Services.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SublimePorteApplication.Services.Model
{
    public class LoginResult
    {
        public bool Success { get; set; }
        public User User { get; set; }
        public List<LoginValidationError> Errors { get; set; }
    }
}
