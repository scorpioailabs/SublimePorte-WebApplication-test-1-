using Microsoft.AspNetCore.Identity;
using SublimePorteApplication.Data;
using SublimePorteApplication.Domain;
using SublimePorteApplication.Services.Interfaces;
using SublimePorteApplication.Services.Model;
using SublimePorteApplication.Services.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SublimePorteApplication.Services.UseCases
{
    public class Authorization
    {
        private IAccountRepository _repo;
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        public Authorization(IAccountRepository repo, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _repo = repo;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<LoginResult> LoginAsync(User user, string password)
        {
            var loginResult = new LoginResult();

            var appUser = await _userManager.FindByNameAsync(user.UserName);

            var validPassword = await _userManager.CheckPasswordAsync(appUser, password);

            var result = new SignInResult();

            if (validPassword)
            {
                result = await _signInManager.PasswordSignInAsync(user, password, false, false); ;
            }

            if (result.Succeeded)
            {
                loginResult.Success = true;
                return loginResult;
            }

            else
            {
                loginResult.Success = false;
                return loginResult;
            }
        }


    }
}
