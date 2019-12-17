using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mentorship.CleaningService.DataAccess;
using Mentorship.CleaningService.Models;
using Microsoft.EntityFrameworkCore;

namespace Mentorship.CleaningService.Repository
{
    public class OfferRepository : IRepository<Offer>
    {
        private readonly IOfferDbContext _dbContext;
        public OfferRepository(IOfferDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Offer GetById(int id)
        {
            return _dbContext.Offers.FirstOrDefault(c => c.Id.Equals(id) && !c.IsDeleted);
        }

        public IQueryable<Offer> GetAll()
        {
            return _dbContext.Offers.Where(a => !a.IsDeleted);
        }

        public Offer Create(Offer entity)
        {
            _dbContext.Entry(entity).State = EntityState.Added;
            _dbContext.SaveChanges();
            return entity;
        }

        public Offer Update(Offer entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return entity;
        }

        public bool Delete(Offer entity)
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
