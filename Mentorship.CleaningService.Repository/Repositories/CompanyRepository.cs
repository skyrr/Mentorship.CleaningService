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

        public IEnumerable<Company> GetAll()
        {
            return _dbContext.Companies.Where(a => !a.IsDeleted);
        }

        public Company Create(Company entity)
        {
            _dbContext.Entry(entity).State = EntityState.Added;
            _dbContext.SaveChanges();
            return entity;
        }

        public Company Update(Company entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return entity;
        }

        public bool Delete(Company entity)
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
