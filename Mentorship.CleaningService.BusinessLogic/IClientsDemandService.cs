using Mentorship.CleaningService.DTO;
using Mentorship.CleaningService.Models;
using System.Collections.Generic;
using System.Linq;

namespace Mentorship.CleaningService.BusinessLogic
{
    public interface IClientsDemandService
    {
        ClientsDemandDTO CreateClientsDemand();
        ClientsDemandDTO GetClientsDemandById(int id);
        IEnumerable<ClientsDemandDTO> GetAll();

    }
}
