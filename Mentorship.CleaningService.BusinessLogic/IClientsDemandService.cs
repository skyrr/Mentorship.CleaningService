using Mentorship.CleaningService.Models;
using System.Linq;

namespace Mentorship.CleaningService.BusinessLogic
{
    public interface IClientsDemandService
    {
        ClientsDemand CreateClientsDemand();
        ClientsDemand GetClientsDemandById(int id);
        IQueryable<ClientsDemand> GetAll();

    }
}
