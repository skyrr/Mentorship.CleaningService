using System;
using System.Collections.Generic;
using System.Text;

namespace Mentorship.CleaningService.Models
{
    public class ContractStatus : IEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string StatusName { get; set; }
    }
}
