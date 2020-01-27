using AutoMapper;
using SublimePorteApplication.Core.EntityFramework.Repositories.Base;
using SublimePorteApplication.Data;
using SublimePorteApplication.Domain;
using SublimePorteApplication.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SublimePorteApplication.Core.EntityFramework.Repositories
{
    public class AccountRepository : EntityBaseRepsitory<User>, IAccountRepository
    {
        public AccountRepository(ApplicationDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public User GetAsync(string Id)
        {
            var data = _context.Set<User>()
                .FindAsync(Id);

            return _mapper.Map<User>(data);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
