﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mentorship.CleaningService.DataAccess;
using Mentorship.CleaningService.Models;
using Microsoft.EntityFrameworkCore;

namespace Mentorship.CleaningService.Repository
{
    public class RoleRepository : IRepository<Role>
    {
        private readonly IRoleDbContext _dbContext;
        public RoleRepository(IRoleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Role GetById(int id)
        {
            return _dbContext.Roles.FirstOrDefault(c => c.Id.Equals(id) && !c.IsDeleted);
        }

        public IEnumerable<Role> GetAll()
        {
            return _dbContext.Roles.Where(a => !a.IsDeleted);
        }

        public Role Create(Role entity)
        {
            _dbContext.Entry(entity).State = EntityState.Added;
            _dbContext.SaveChanges();
            return entity;
        }

        public Role Update(Role entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return entity;
        }

        public bool Delete(Role entity)
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
