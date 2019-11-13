using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mentorship.CleaningService.DataAccess;
using Mentorship.CleaningService.Models;

namespace Mentorship.CleaningService.Repository
{
    class AddressRepository : IRepository<Address>
    {
        private readonly IAddressDbContext _dbContext;
        public AddressRepository(IAddressDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Address GetById(int id)
        {
            return _dbContext.Addresses.FirstOrDefault(c => c.Id.Equals(id));
        }

        public IQueryable<Address> GetAll()
        {
            throw new NotImplementedException();
        }

        public Address Create(Address entity)
        {
            throw new NotImplementedException();
        }

        public Address Update(Address entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Address entity)
        {
            throw new NotImplementedException();
        }
    }
}
