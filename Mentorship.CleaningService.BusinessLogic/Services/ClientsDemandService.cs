﻿using Mentorship.CleaningService.Models;
using Mentorship.CleaningService.Repository;
using System;
using System.Linq;
using AutoMapper;
using Mentorship.CleaningService.DTO;
using System.Collections.Generic;
using System.Collections;
using System.Data.SqlClient;

namespace Mentorship.CleaningService.BusinessLogic
{
    public class ClientsDemandService : ICleaningServiceService<ClientsDemandDTO>
    {
        public IRepositoryFactory _factory;
        public IMapper _mapper;
        public ClientsDemandService(IRepositoryFactory factory, IMapper mapper) {
            _factory = factory;
            _mapper = mapper;
        }

        public ClientsDemandDTO Create(ClientsDemandDTO entity)
        {
            throw new NotImplementedException();
        }

        public ClientsDemandDTO CreateClientsDemand()
        {
            throw new NotImplementedException();
        }

        public bool Delete(ClientsDemandDTO entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public IEnumerable<ClientsDemandDTO> GetAll()
        {
            try
            {
                var clientsDemand = _factory.GetRepository<ClientsDemand>().GetAll();
                IEnumerable<ClientsDemandDTO> cDTO = _mapper.Map<IEnumerable<ClientsDemand>, IEnumerable<ClientsDemandDTO>>(clientsDemand);
                return cDTO;
            }
            catch (SqlException ex)
            {
                //TODO: Logging an exception
                return new List<ClientsDemandDTO> { new ClientsDemandDTO { ErrorMessage = ex.Message } };
            }
            catch (Exception ex)
            {
                //TODO: Logging an exception
                return new List<ClientsDemandDTO> { new ClientsDemandDTO { ErrorMessage = ex.Message } };
            }
        }

        public ClientsDemandDTO GetById(int id)
        {
            var clientsDemand = _factory.GetRepository<ClientsDemand>().GetById(id);
            return _mapper.Map<ClientsDemandDTO>(clientsDemand);
        }

        //public ClientsDemandDTO GetClientsDemandById(int id)
        //{
        //    var clientsDemand = _factory.GetRepository<ClientsDemand>().GetById(id);
        //    return _mapper.Map<ClientsDemandDTO>(clientsDemand);
        //}

        public ClientsDemandDTO Update(ClientsDemandDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
