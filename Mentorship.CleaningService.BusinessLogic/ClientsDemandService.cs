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
    }
}
