using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mentorship.CleaningService.DataAccess;
using Mentorship.CleaningService.Models;
using Microsoft.EntityFrameworkCore;

namespace Mentorship.CleaningService.Repository
{
    public class WorkerRoleRepository : IRepository<WorkerRole>
    {
        private readonly IWorkerRoleDbContext _dbContext;
        public WorkerRoleRepository(IWorkerRoleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public WorkerRole GetById(int id)
        {
            return _dbContext.WorkerRoles.FirstOrDefault(c => c.Id.Equals(id) && !c.IsDeleted);
        }

        public IEnumerable<WorkerRole> GetAll()
        {
            return _dbContext.WorkerRoles.Where(a => !a.IsDeleted);
        }

        public WorkerRole Create(WorkerRole entity)
        {
            _dbContext.Entry(entity).State = EntityState.Added;
            _dbContext.SaveChanges();
            return entity;
        }

        public WorkerRole Update(WorkerRole entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return entity;
        }

        public bool Delete(WorkerRole entity)
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
