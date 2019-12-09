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

        public IQueryable<ServicePlan> GetAll()
        {
            return _dbContext.ServicePlans.Where(a => !a.IsDeleted);
        }

        public bool Create(ServicePlan entity)
        {
            _dbContext.Entry(entity).State = EntityState.Added;
            _dbContext.Entry(entity).Context.SaveChanges();
            return true;
        }

        public bool Update(ServicePlan entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.Entry(entity).Context.SaveChanges();

            return true;
        }

        public bool Delete(ServicePlan entity)
        {
            entity.IsDeleted = true;
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.Entry(entity).Context.SaveChanges();

            return true;
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}
