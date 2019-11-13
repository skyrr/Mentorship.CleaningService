using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mentorship.CleaningService.DataAccess;
using Mentorship.CleaningService.Models;

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
            return _dbContext.Clients.FirstOrDefault(c => c.Id.Equals(id));
        }

        public IQueryable<Client> GetAll()
        {
            throw new NotImplementedException();
        }

        public Client Create(Client entity)
        {
            throw new NotImplementedException();
        }

        public Client Update(Client entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Client entity)
        {
            throw new NotImplementedException();
        }
    }
}
