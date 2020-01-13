using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mentorship.CleaningService.DataAccess;
using Mentorship.CleaningService.Models;
using Microsoft.EntityFrameworkCore;

namespace Mentorship.CleaningService.Repository
{
    public class ApplicationUserRepository
    {
        private readonly ApplicationUserDbContext _dbContext;
        public ApplicationUserRepository(ApplicationUserDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ApplicationUser GetById(int id)
        {
            return  _dbContext.ApplicationUsers.FirstOrDefault(c => c.Id.Equals(id) && !c.IsDeleted);
        }

        public IQueryable<ApplicationUser> GetAll()
        {
            return _dbContext.ApplicationUsers.Where(a => !a.IsDeleted);
        }

        public ApplicationUser Create(ApplicationUser entity)
        {
            _dbContext.Entry(entity).State = EntityState.Added;
            _dbContext.SaveChanges();
            return entity;
        }

        public ApplicationUser Update(ApplicationUser entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return entity;
        }

        public bool Delete(ApplicationUser entity)
        {
            entity.IsDeleted = true;
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
