using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SublimePorteApplication.Domain;
using SublimePorteApplication.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SublimePorteApplication.Controllers.Base
{
    public class BaseController : Controller
    {
        protected IAccountRepository _repo;
        protected IMapper _mapper;

        protected User CurrentUser { get; set; }

        public BaseController(IAccountRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            LoadUser();
            base.OnActionExecuting(context);
        }

        private void LoadUser()
        {
            var user = HttpContext.User;

            if (!user.Identity.IsAuthenticated || user == null || !user.HasClaim(c => c.Type == ClaimTypes.NameIdentifier))
                return;

            if (Int32.TryParse(user.Claims.FirstOrDefault(c =>c.Type == ClaimTypes.NameIdentifier).Value, out int currentUserId))
            {
                CurrentUser.Id = currentUserId.ToString();
            }
        }
    }
}
