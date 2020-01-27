using Microsoft.AspNetCore.Identity;
using SublimePorteApplication.Data;
using SublimePorteApplication.Domain;
using SublimePorteApplication.Domain.Specifications;
using SublimePorteApplication.Services.Interfaces;
using SublimePorteApplication.Services.Model;
using SublimePorteApplication.Services.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SublimePorteApplication.Services.UseCases
{
    public class Accounts
    {
        private IAccountRepository _repo;
        private UserManager<ApplicationUser> _userManager;

        public Accounts(IAccountRepository repo, UserManager<ApplicationUser> userManager)
        {
            _repo = repo;
            _userManager = userManager;
        }

        public async Task<User> GetAsync(string id)
        {
            var users = await _repo.QueryAsync(new AccountQuerySpecification
            {
                WhereClause = u => u.Id == id
            });

            return users.FirstOrDefault();
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            var users = await _repo.QueryAsync(new AccountQuerySpecification
            {
                WhereClause = u => u.SublimeName == username
            });

            return users.FirstOrDefault();
        }

        public async Task<User> GetByEmailAddressAsync(string emailAddress)
        {
            var users = await _repo.QueryAsync(new AccountQuerySpecification
            {
                WhereClause = u => u.Email == emailAddress
            });

            return users.FirstOrDefault();
        }

        public async Task<List<User>> GetAll()
        {
            var users = await _repo.QueryAsync(new AccountQuerySpecification
            {
                WhereClause = u => !u.EmailConfirmed,
                OrderBy = u => u.SublimeName
            });

            return users;
        }

        public async Task<UserCreationUpdateResult> CreateAsync(User user, string password)
        {
            var errorResults = new AccountValidationError();
            var result = new UserCreationUpdateResult
            {
                Errors = await AccountValidator.IsValidAccountAsync(user, this)
            };

            if (result.Errors != null && result.Errors.Any())
                return result;

            _repo.Add(user);
            var createUser =  await _userManager.CreateAsync(user, password);

            if (createUser.Succeeded)
            {
                result.Success = true;
                result.User = user;
            }
            else
            {
                errorResults.ErrorCode = Model.Enums.AccountValidationError.USERNAME_ALREADY_EXISTS;
                errorResults.Message = createUser.Errors.FirstOrDefault().Description;
            }

            return result;
        }
    }
}
