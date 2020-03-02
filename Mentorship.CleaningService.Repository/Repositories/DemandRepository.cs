using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mentorship.CleaningService.DataAccess;
using Mentorship.CleaningService.Models;
using Microsoft.EntityFrameworkCore;

namespace Mentorship.CleaningService.Repository
{
    public class DemandRepository : IRepository<Demand>
    {
        private readonly IDemandDbContext _dbContext;
        public DemandRepository(IDemandDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Demand GetById(int id)
        {
            return _dbContext.Demands.FirstOrDefault(c => c.Id.Equals(id) && !c.IsDeleted);
        }

        public IEnumerable<Demand> GetAll()
        {
            return _dbContext.Demands.Where(a => !a.IsDeleted);
        }

        public Demand Create(Demand entity)
        {
            _dbContext.Entry(entity).State = EntityState.Added;
            _dbContext.SaveChanges();
            return entity;
        }

        public Demand Update(Demand entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return entity;
        }

        public bool Delete(Demand entity)
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
