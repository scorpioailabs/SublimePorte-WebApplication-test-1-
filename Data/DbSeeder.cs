using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using SublimePorteApplication.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SublimePorteApplication.Data
{
    public class DbSeeder
    {
        public static void SeedDb
            (ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            context.Database.EnsureCreated();
            {
                User user1 = new User
                {
                    UserName = "sublime1@email.com",
                    FirstName = "Zak",
                    LastName = "Ali",
                    Email = "sublime1@email.com",
                    SublimeName = "sublime1",
                    Address = "1 Kayi Road, Istanbul, Turkey",
                    ProfileDescription = "Zak is a backend developer and is an avid history fan," +
                    " follow me to find out more!"
                };

                IdentityResult result = userManager.CreateAsync
                    (user1, "Password123!").Result;
            }
        }
    }
}
