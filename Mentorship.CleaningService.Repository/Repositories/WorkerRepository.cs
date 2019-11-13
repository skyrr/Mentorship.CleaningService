using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mentorship.CleaningService.DataAccess;
using Mentorship.CleaningService.Models;

namespace Mentorship.CleaningService.Repository
{
    public class WorkerRepository : IRepository<Worker>
    {
        private readonly IWorkerDbContext _dbContext;
        public WorkerRepository(IWorkerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Worker GetById(int id)
        {
            return _dbContext.Workers.FirstOrDefault(c => c.Id.Equals(id));
        }

        public IQueryable<Worker> GetAll()
        {
            throw new NotImplementedException();
        }

        public Worker Create(Worker entity)
        {
            throw new NotImplementedException();
        }

        public Worker Update(Worker entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Worker entity)
        {
            throw new NotImplementedException();
        }
    }
}
