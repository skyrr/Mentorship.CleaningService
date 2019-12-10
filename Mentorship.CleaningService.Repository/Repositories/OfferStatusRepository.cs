using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mentorship.CleaningService.DataAccess;
using Mentorship.CleaningService.Models;
using Microsoft.EntityFrameworkCore;

namespace Mentorship.CleaningService.Repository
{
    public class OfferStatusRepository : IRepository<OfferStatus>
    {
        private readonly IOfferStatusDbContext _dbContext;
        public OfferStatusRepository(IOfferStatusDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public OfferStatus GetById(int id)
        {
            return _dbContext.OfferStatuses.FirstOrDefault(c => c.Id.Equals(id) && !c.IsDeleted);
        }

        public IQueryable<OfferStatus> GetAll()
        {
            return _dbContext.OfferStatuses.Where(a => !a.IsDeleted);
        }

        public bool Create(OfferStatus entity)
        {
            _dbContext.Entry(entity).State = EntityState.Added;
            _dbContext.SaveChanges();
            return true;
        }

        public bool Update(OfferStatus entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return true;
        }

        public bool Delete(OfferStatus entity)
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
