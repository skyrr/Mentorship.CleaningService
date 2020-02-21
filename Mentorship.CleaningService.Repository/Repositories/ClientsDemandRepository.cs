using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mentorship.CleaningService.DataAccess;
using Mentorship.CleaningService.Models;
using Microsoft.EntityFrameworkCore;

namespace Mentorship.CleaningService.Repository
{
    public class ClientsDemandRepository : IRepository<ClientsDemand>
    {
        private readonly IClientsDemandDbContext _dbContext;
        public ClientsDemandRepository(IClientsDemandDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ClientsDemand GetById(int id)
        {
            return  _dbContext.ClientsDemands.FromSql($"sps_ClientsDemand {id}").FirstOrDefault(c => c.Id.Equals(id) && !c.IsDeleted);
        }

        public IQueryable<ClientsDemand> GetAll()
        {
            return _dbContext.ClientsDemands.FromSql("sps_ClientsDemand NULL").Where(a => !a.IsDeleted);
        }

        public ClientsDemand Create(ClientsDemand entity)
        {
            _dbContext.Entry(entity).State = EntityState.Added;
            _dbContext.SaveChanges();
            return entity;
        }

        public ClientsDemand Update(ClientsDemand entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return entity;
        }

        public bool Delete(ClientsDemand entity)
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
