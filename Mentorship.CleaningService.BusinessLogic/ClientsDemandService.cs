using Mentorship.CleaningService.Models;
using Mentorship.CleaningService.Repository;
using System;
using System.Linq;
using AutoMapper;
using Mentorship.CleaningService.DTO;

namespace Mentorship.CleaningService.BusinessLogic
{
    public class ClientsDemandService // : IClientsDemandService
    {
        public IRepositoryFactory _factory;
        public IMapper _mapper;
        public ClientsDemandService(IRepositoryFactory factory, IMapper mapper) {
            _factory = factory;
            _mapper = mapper;
        }

        public ClientsDemand CreateClientsDemand()
        {
            throw new NotImplementedException();
        }

        public IQueryable<ClientsDemand> GetAll()
        {
            var clientsDemand = _factory.GetRepository<ClientsDemand>().GetAll();
            return clientsDemand;
            //return _mapper.Map<ClientsDemandDTO>(clientsDemand);
        }

        public ClientsDemandDTO GetClientsDemandById(int id)
        {
            var clientsDemand = _factory.GetRepository<ClientsDemand>().GetById(id);
            return _mapper.Map<ClientsDemandDTO>(clientsDemand);
        }

        //ClientsDemand IClientsDemandService.GetClientsDemandById(int id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
