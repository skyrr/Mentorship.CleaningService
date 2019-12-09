using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mentorship.CleaningService.DataAccess;
using Mentorship.CleaningService.Models;
using Microsoft.EntityFrameworkCore;

namespace Mentorship.CleaningService.Repository
{
    public class DemandStatusRepository : IRepository<DemandStatus>
    {
        private readonly IDemandStatusDbContext _dbContext;
        public DemandStatusRepository(IDemandStatusDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DemandStatus GetById(int id)
        {
            return _dbContext.DemandStatuses.FirstOrDefault(c => c.Id.Equals(id) && !c.IsDeleted);
        }

        public IQueryable<DemandStatus> GetAll()
        {
            return _dbContext.DemandStatuses.Where(a => !a.IsDeleted); ;
        }

        public bool Create(DemandStatus entity)
        {
            _dbContext.Entry(entity).State = EntityState.Added;
            _dbContext.Entry(entity).Context.SaveChanges();
            return true;
        }

        public bool Update(DemandStatus entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.Entry(entity).Context.SaveChanges();

            return true;
        }

        public bool Delete(DemandStatus entity)
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
