using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mentorship.CleaningService.DataAccess;
using Mentorship.CleaningService.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Mentorship.CleaningService.Repository
{
    public class ApplicationUserRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ApplicationUserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IdentityUser GetById(string id)
        {
            return  _dbContext.Users.FirstOrDefault(c => c.Id.Equals(id));
        }

        public IQueryable<IdentityUser> GetAll()
        {
            return _dbContext.Users;
        }

        public IdentityUser Create(IdentityUser entity)
        {
            _dbContext.Entry(entity).State = EntityState.Added;
            _dbContext.SaveChanges();
            return entity;
        }

        public IdentityUser Update(IdentityUser entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return entity;
        }

        public bool Delete(IdentityUser entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return true;
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}
