using Mentorship.CleaningService.Models;

namespace Mentorship.CleaningService.BusinessLogic
{
    public interface IClientsDemandService
    {
        ClientsDemand CreateClientsDemand();
        ClientsDemand GetClientsDemandById(int id);
    }
}
