using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SublimePorteApplication.Data;
using SublimePorteApplication.Domain;
using SublimePorteApplication.Models;
using SublimePorteApplication.Services.Interfaces;
using SublimePorteApplication.Services.UseCases;

namespace SublimePorteApplication.Controllers
{
    [ApiVersion("1.0")]
    [Route("auth")]
    [ApiController]
    public class AuthController : Base.BaseController
    {

        private Authorization _auth;
        private Accounts _accounts;
        public AuthController(IAccountRepository repo, IMapper mapper, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager) : base(repo, mapper)
        {
            _auth = new Authorization(repo, userManager, signInManager);
            _accounts = new Accounts(repo, userManager);
        }

        [HttpPost, Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> PostAsync([FromBody]LoginUserModel loginDetails)
        {
            var user = await _accounts.GetByUsernameAsync(loginDetails.UserName);
            var result = await _auth.LoginAsync(user, loginDetails.password);
            var userId = user.Id;

            if (!result.Success || result.Errors.Any())
                return BadRequest(result);

            return Ok($"accounts/profile/{user.Id}/");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}