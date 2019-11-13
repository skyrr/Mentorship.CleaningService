using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mentorship.CleaningService.DataAccess;
using Mentorship.CleaningService.Models;

namespace Mentorship.CleaningService.Repository
{
    class PersonRepository : IRepository<Person>
    {
        private readonly IPersonDbContext _dbContext;
        public PersonRepository(IPersonDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Person GetById(int id)
        {
            return _dbContext.Persons.FirstOrDefault(c => c.Id.Equals(id));
        }

        public IQueryable<Person> GetAll()
        {
            throw new NotImplementedException();
        }

        public Person Create(Person entity)
        {
            throw new NotImplementedException();
        }

        public Person Update(Person entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Person entity)
        {
            throw new NotImplementedException();
        }
    }
}
