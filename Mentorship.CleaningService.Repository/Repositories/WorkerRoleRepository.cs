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

        public IQueryable<WorkerRole> GetAll()
        {
            return _dbContext.WorkerRoles.Where(a => !a.IsDeleted); ;
        }

        public bool Create(WorkerRole entity)
        {
            _dbContext.Entry(entity).State = EntityState.Added;
            return true;
        }

        public bool Update(WorkerRole entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return true;
        }

        public bool Delete(WorkerRole entity)
        {
            entity.IsDeleted = true;
            _dbContext.Entry(entity).State = EntityState.Modified;
            return true;
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}
