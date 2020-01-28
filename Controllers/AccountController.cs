using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    [Route("accounts")]
    [ApiController]
    public class AccountController : Base.BaseController    
    {
        private Accounts _accounts;
        private IHttpContextAccessor HttpContextAccessor;
        private string userId;

        public AccountController(IAccountRepository repo, IMapper mapper, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor) : base(repo, mapper)
        {
            _accounts = new Accounts(repo, userManager);
            userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }

        [HttpGet, Route("{id}")]
        [Authorize]
        public async Task<IActionResult> GetAsync(string id)
        {
            var user = await _accounts.GetAsync(id);

            if (user is null)
                return NotFound();

            return Ok(_mapper.Map<UserProfileModel>(user));
        }

        [HttpPost, Route("register")]
        [AllowAnonymous]
        public async Task<IActionResult> PostAsync([FromBody]RegisterUserModel userDetails)
        {
            var result = await _accounts.CreateAsync(_mapper.Map<User>(userDetails), userDetails.password);

            if (!result.Success || result.Errors.Any())
                return BadRequest(result);

            await _repo.SaveChangesAsync();

            return Created($"/register/{result.User.Id}/", _mapper.Map<RegisterUserModel>(result.User));
        }

        [HttpGet, Route("profile/{id}")]
        [Authorize]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _accounts.GetAsync(userId);

            return Ok(_mapper.Map<UserProfileModel>(result));
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}