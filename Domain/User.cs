using SublimePorteApplication.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SublimePorteApplication.Domain
{
    public class User : ApplicationUser
    {
        public string SublimeName { get; set; }
        public string Address { get; set; }
        public DateTime? DoB { get; set; }
        public string ProfileDescription { get; set; } = "";
        public string Photo { get; set; } = ""; 
    }
}
