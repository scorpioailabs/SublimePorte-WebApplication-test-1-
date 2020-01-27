using SublimePorteApplication.Domain;
using SublimePorteApplication.Services.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SublimePorteApplication.Services.Interfaces
{
    public interface IAccountRepository : IBaseRepository<User>
    {
        User GetAsync(string Id);
    }
}
