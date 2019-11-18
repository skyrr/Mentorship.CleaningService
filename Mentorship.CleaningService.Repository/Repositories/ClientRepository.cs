using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mentorship.CleaningService.DataAccess;
using Mentorship.CleaningService.Models;
using Microsoft.EntityFrameworkCore;

namespace Mentorship.CleaningService.Repository
{
    public class ClientRepository : IRepository<Client>
    {
        private readonly IClientDbContext _dbContext;
        public ClientRepository(IClientDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Client GetById(int id)
        {
            return _dbContext.Clients.FirstOrDefault(c => c.Id.Equals(id) && !c.IsDeleted);
        }

        public IQueryable<Client> GetAll()
        {
            return _dbContext.Clients.Where(a => !a.IsDeleted); ;
        }

        public bool Create(Client entity)
        {
            _dbContext.Entry(entity).State = EntityState.Added;
            return true;
        }

        public bool Update(Client entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return true;
        }

        public bool Delete(Client entity)
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
