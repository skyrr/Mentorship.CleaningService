using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mentorship.CleaningService.DataAccess;
using Mentorship.CleaningService.Models;
using Microsoft.EntityFrameworkCore;

namespace Mentorship.CleaningService.Repository
{
    public class AddressRepository : IRepository<Address>
    {
        private readonly IAddressDbContext _dbContext;
        public AddressRepository(IAddressDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Address GetById(int id)
        {
            return new Address {Id = 1, City = "Lviv"};
            //return  _dbContext.Addresses.FirstOrDefault(c => c.Id.Equals(id) && !c.IsDeleted);}
        }

        public IQueryable<Address> GetAll()
        {
            return _dbContext.Addresses.Where(a => !a.IsDeleted);
        }

        public bool Create(Address entity)
        {
            _dbContext.Entry(entity).State = EntityState.Added;
            ;
            return true;
        }

        public bool Update(Address entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return true;
        }

        public bool Delete(Address entity)
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
