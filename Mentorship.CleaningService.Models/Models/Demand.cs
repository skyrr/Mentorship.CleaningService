using System;
using System.Collections.Generic;
using System.Text;
using Mentorship.CleaningService.Models;

namespace Mentorship.CleaningService.Models
{ 
    public class Demand : IEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DemandStatus DemandStatus { get; set; }
        public Client Client { get; set; }
    }
}
