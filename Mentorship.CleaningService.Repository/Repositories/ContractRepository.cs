using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mentorship.CleaningService.DataAccess;
using Mentorship.CleaningService.Models;
using Microsoft.EntityFrameworkCore;

namespace Mentorship.CleaningService.Repository
{
    public class ContractRepository : IRepository<Contract>
    {
        private readonly IContractDbContext _dbContext;
        public ContractRepository(IContractDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Contract GetById(int id)
        {
            return _dbContext.Contracts.FirstOrDefault(c => c.Id.Equals(id) && !c.IsDeleted);
        }

        public IQueryable<Contract> GetAll()
        {
            return _dbContext.Contracts
                .Include(c => c.Address)
                .Include(c => c.Client)
                .Include(c => c.Company)
                .Where(a => !a.IsDeleted);
        }

        public bool Create(Contract entity)
        {
            _dbContext.Entry(entity).State = EntityState.Added;
            _dbContext.SaveChanges();
            return true;
        }

        public bool Update(Contract entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return true;
        }

        public bool Delete(Contract entity)
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
