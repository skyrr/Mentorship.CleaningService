﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mentorship.CleaningService.DataAccess;
using Mentorship.CleaningService.Models;
using Microsoft.EntityFrameworkCore;

namespace Mentorship.CleaningService.Repository
{
    public class WorkerRepository : IRepository<Worker>
    {
        private readonly IWorkerDbContext _dbContext;
        public WorkerRepository(IWorkerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Worker GetById(int id)
        {
            return _dbContext.Workers.FirstOrDefault(c => c.Id.Equals(id) && !c.IsDeleted);
        }

        public IEnumerable<Worker> GetAll()
        {
            return _dbContext.Workers.Where(a => !a.IsDeleted);
        }

        public Worker Create(Worker entity)
        {
            _dbContext.Entry(entity).State = EntityState.Added;
            _dbContext.SaveChanges();
            return entity;
        }

        public Worker Update(Worker entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return entity;
        }

        public bool Delete(Worker entity)
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
