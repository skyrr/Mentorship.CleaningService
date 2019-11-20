using System;
using System.Collections.Generic;
using System.Text;

namespace Mentorship.CleaningService.Models.Models
{
    public class Demand : IEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DemandStatus DemandStatus { get; set; }
    }
}
