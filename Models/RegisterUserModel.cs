using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SublimePorteApplication.Models
{
    public class RegisterUserModel
    {
        [Required]
        public string sublimeName { get; set; }
        [Required]
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string address { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
        //[Required]
        //[DataType(DataType.Password)]
        //[Compare("Password", ErrorMessage = "The passwords do not match.")]
        //public string confirmPassword { get; set; }
    }
}
