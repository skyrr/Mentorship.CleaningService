using System;
using System.Collections.Generic;
using System.Text;

namespace Mentorship.CleaningService.Models
{
    public class ClientsDemand : IEntity
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int DemandStatusId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
