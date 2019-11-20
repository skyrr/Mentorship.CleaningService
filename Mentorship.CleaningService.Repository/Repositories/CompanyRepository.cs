using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mentorship.CleaningService.DataAccess;
using Mentorship.CleaningService.Models;
using Microsoft.EntityFrameworkCore;

namespace Mentorship.CleaningService.Repository
{
    public class CompanyRepository : IRepository<Company>
    {
        private readonly ICompanyDbContext _dbContext;
        public CompanyRepository(ICompanyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Company GetById(int id)
        {
            return _dbContext.Companies.FirstOrDefault(c => c.Id.Equals(id) && !c.IsDeleted);
        }

        public IQueryable<Company> GetAll()
        {
            return _dbContext.Companies.Where(a => !a.IsDeleted); ;
        }

        public bool Create(Company entity)
        {
            _dbContext.Entry(entity).State = EntityState.Added;
            return true;
        }

        public bool Update(Company entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return true;
        }

        public bool Delete(Company entity)
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
