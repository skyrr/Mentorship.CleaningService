using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mentorship.CleaningService.DataAccess;
using Mentorship.CleaningService.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Mentorship.CleaningService.DTO;

namespace Mentorship.CleaningService.Repository
{
    public class ClientsDemandRepository : IRepository<ClientsDemand>
    {
        private readonly IClientsDemandDbContext _dbContext;
        private readonly IMapper _mapper;
        public ClientsDemandRepository(IClientsDemandDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public ClientsDemand GetById(int id)
        {
            return _dbContext.ClientsDemands.FromSql($"sps_ClientsDemand {id}").FirstOrDefault(c => c.Id.Equals(id) && !c.IsDeleted);
        }

        public ClientsDemandDTO GetByIdDTO(int id)
        {
            var cl = _dbContext.ClientsDemands.FromSql($"sps_ClientsDemand {id}").FirstOrDefault(c => c.Id.Equals(id) && !c.IsDeleted);
            var mp = _mapper.Map<ClientsDemandDTO>(cl);
            return mp;
        }


        public IEnumerable<ClientsDemand> GetAll()
        {
            return _dbContext.ClientsDemands.FromSql("sps_ClientsDemand NULL").Where(a => !a.IsDeleted);
        }

        public ClientsDemand Create(ClientsDemand entity)
        {
            _dbContext.Entry(entity).State = EntityState.Added;
            _dbContext.SaveChanges();
            return entity;
        }

        public ClientsDemand Update(ClientsDemand entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return entity;
        }

        public bool Delete(ClientsDemand entity)
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
