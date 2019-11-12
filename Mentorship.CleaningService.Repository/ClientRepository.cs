using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mentorship.CleaningService.DataAccess;
using Mentorship.CleaningService.Models;

namespace Mentorship.CleaningService.Repository
{
    class ClientRepository : IRepository
    {
        private ClientDbContext clientDbContext;
        public ClientRepository()
        {
            clientDbContext = new ClientDbContext();
        }

        public IEntity GetById(int id)
        {
            IEntity client = clientDbContext.Clients.Where(x=>x.Id==id).SingleOrDefault();
            return client;
        }

        public IQueryable<IEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEntity Create(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEntity Update(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(IEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
