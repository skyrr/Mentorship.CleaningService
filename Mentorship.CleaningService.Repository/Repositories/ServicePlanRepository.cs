using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mentorship.CleaningService.DataAccess;
using Mentorship.CleaningService.Models;
using Microsoft.EntityFrameworkCore;

namespace Mentorship.CleaningService.Repository
{
    public class ServicePlanRepository : IRepository<ServicePlan>
    {
        private readonly IServicePlanDbContext _dbContext;
        public ServicePlanRepository(IServicePlanDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ServicePlan GetById(int id)
        {
            return _dbContext.ServicePlans.FirstOrDefault(c => c.Id.Equals(id) && !c.IsDeleted);
        }

        public IEnumerable<ServicePlan> GetAll()
        {
            return _dbContext.ServicePlans.Where(a => !a.IsDeleted);
        }

        public ServicePlan Create(ServicePlan entity)
        {
            _dbContext.Entry(entity).State = EntityState.Added;
            _dbContext.SaveChanges();
            return entity;
        }

        public ServicePlan Update(ServicePlan entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return entity;
        }

        public bool Delete(ServicePlan entity)
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
