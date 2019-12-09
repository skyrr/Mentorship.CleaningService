using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mentorship.CleaningService.DataAccess;
using Mentorship.CleaningService.Models;
using Microsoft.EntityFrameworkCore;

namespace Mentorship.CleaningService.Repository
{
    public class ClientAddressRepository : IRepository<ClientAddress>
    {
        private readonly IClientAddressDbContext _dbContext;
        public ClientAddressRepository(IClientAddressDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ClientAddress GetById(int id)
        {
            return _dbContext.ClientAddresses.FirstOrDefault(c => c.Id.Equals(id) && !c.IsDeleted);
        }

        public IQueryable<ClientAddress> GetAll()
        {
            return _dbContext.ClientAddresses.Where(a => !a.IsDeleted); ;
        }

        public bool Create(ClientAddress entity)
        {
            _dbContext.Entry(entity).State = EntityState.Added;
            _dbContext.Entry(entity).Context.SaveChanges();
            return true;
        }

        public bool Update(ClientAddress entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.Entry(entity).Context.SaveChanges();

            return true;
        }

        public bool Delete(ClientAddress entity)
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
