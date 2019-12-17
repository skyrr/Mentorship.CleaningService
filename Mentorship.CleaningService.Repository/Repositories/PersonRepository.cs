using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mentorship.CleaningService.DataAccess;
using Mentorship.CleaningService.Models;
using Microsoft.EntityFrameworkCore;

namespace Mentorship.CleaningService.Repository
{
    public class PersonRepository : IRepository<Person>
    {
        private readonly IPersonDbContext _dbContext;
        public PersonRepository(IPersonDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Person GetById(int id)
        {
            return _dbContext.Persons.FirstOrDefault(c => c.Id.Equals(id) && !c.IsDeleted);
        }

        public IQueryable<Person> GetAll()
        {
            return _dbContext.Persons.Where(a => !a.IsDeleted);
        }

        public Person Create(Person entity)
        {
            _dbContext.Entry(entity).State = EntityState.Added;
            _dbContext.SaveChanges();
            return entity;
        }

        public Person Update(Person entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return entity;
        }

        public bool Delete(Person entity)
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
