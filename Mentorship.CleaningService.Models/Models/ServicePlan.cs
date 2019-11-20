using System;
using System.Collections.Generic;
using System.Text;

namespace Mentorship.CleaningService.Models.Models
{
    public class ServicePlan : IEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string ServicePlanName { get; set; }
        public decimal ServicePlanValue { get; set; }
    }
}
