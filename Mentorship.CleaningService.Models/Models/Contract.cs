using System;
using System.Collections.Generic;
using System.Text;

namespace Mentorship.CleaningService.Models
{
    public class Contract : IEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public Client Client { get; set; }
        public Company Company { get; set; }
        public ServicePlan ServicePlan { get; set; }
        public Address Address { get; set; }
        public ContractStatus ContractStatus { get; set; }
    }
}
