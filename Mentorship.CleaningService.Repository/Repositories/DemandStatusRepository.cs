﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mentorship.CleaningService.DataAccess;
using Mentorship.CleaningService.Models;
using Microsoft.EntityFrameworkCore;

namespace Mentorship.CleaningService.Repository
{
    public class DemandStatusRepository : IRepository<DemandStatus>
    {
        private readonly IDemandStatusDbContext _dbContext;
        public DemandStatusRepository(IDemandStatusDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DemandStatus GetById(int id)
        {
            return _dbContext.DemandStatuses.FirstOrDefault(c => c.Id.Equals(id) && !c.IsDeleted);
        }

        public IEnumerable<DemandStatus> GetAll()
        {
            return _dbContext.DemandStatuses.Where(a => !a.IsDeleted);
        }

        public DemandStatus Create(DemandStatus entity)
        {
            _dbContext.Entry(entity).State = EntityState.Added;
            _dbContext.SaveChanges();
            return entity;
        }

        public DemandStatus Update(DemandStatus entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return entity;
        }

        public bool Delete(DemandStatus entity)
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
