using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mentorship.CleaningService.DataAccess;
using Mentorship.CleaningService.Models;
using Microsoft.EntityFrameworkCore;

namespace Mentorship.CleaningService.Repository
{
    public class ContractStatusRepository : IRepository<ContractStatus>
    {
        private readonly IContractStatusDbContext _dbContext;
        public ContractStatusRepository(IContractStatusDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ContractStatus GetById(int id)
        {
            return _dbContext.ContractStatuses.FirstOrDefault(c => c.Id.Equals(id) && !c.IsDeleted);
        }

        public IEnumerable<ContractStatus> GetAll()
        {
            return _dbContext.ContractStatuses.Where(a => !a.IsDeleted);
        }

        public ContractStatus Create(ContractStatus entity)
        {
            _dbContext.Entry(entity).State = EntityState.Added;
            _dbContext.SaveChanges();
            return entity;
        }

        public ContractStatus Update(ContractStatus entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return entity;
        }

        public bool Delete(ContractStatus entity)
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
