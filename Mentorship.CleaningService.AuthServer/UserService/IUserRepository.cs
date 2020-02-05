using IdentityServer4.Validation;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mentorship.CleaningService.AuthServer.UserService
{
    public interface IUserRepository
    {
        IdentityUser FindAsync(string UserName);
    }
}
