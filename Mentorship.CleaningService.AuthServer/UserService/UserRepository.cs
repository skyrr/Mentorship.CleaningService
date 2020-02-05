using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Validation;
using Mentorship.CleaningService.DataAccess;
using Microsoft.AspNetCore.Identity;

namespace Mentorship.CleaningService.AuthServer.UserService
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public UserRepository(ApplicationDbContext dbContext) {
            _dbContext = dbContext;
        }
        public IdentityUser FindAsync(string UserName)
        {
            return _dbContext.Users.FirstOrDefault(u => u.UserName.Equals(UserName));
        }
    }
}
