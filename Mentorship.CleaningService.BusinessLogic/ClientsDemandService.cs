﻿using Mentorship.CleaningService.Models;
using Mentorship.CleaningService.Repository;
using System;

namespace Mentorship.CleaningService.BusinessLogic
{
    public class ClientsDemandService : IClientsDemandService
    {
        public IRepositoryFactory _factory;
        public ClientsDemandService(IRepositoryFactory factory) {
            _factory = factory;
        }

        public ClientsDemand CreateClientsDemand()
        {
            throw new NotImplementedException();
        }

        public ClientsDemand GetClientsDemandById(int id)
        {
            return _factory.GetRepository<ClientsDemand>().GetById(id);
        }
    }
}
