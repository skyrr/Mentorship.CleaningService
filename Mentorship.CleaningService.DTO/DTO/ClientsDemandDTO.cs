using System;
using System.Collections.Generic;
using System.Text;

namespace Mentorship.CleaningService.DTO
{
    public class ClientsDemandDTO : IEntityDTO
    {
        public int ClientId { get; set; }
        public string DemandStatusName { get; set; }
    }
}
