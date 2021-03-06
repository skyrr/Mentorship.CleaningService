﻿using System;
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
            return  _dbContext.Addresses.FirstOrDefault(c => c.Id.Equals(id) && !c.IsDeleted);
        }

        public IEnumerable<Address> GetAll()
        {
            return _dbContext.Addresses.Where(a => !a.IsDeleted);
        }

        public Address Create(Address entity)
        {
            _dbContext.Entry(entity).State = EntityState.Added;
            _dbContext.SaveChanges();
            return entity;
        }

        public Address Update(Address entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return entity;
        }

        public bool Delete(Address entity)
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
