using System;
using System.Collections.Generic;
using System.Text;
using Mentorship.CleaningService.Models;

namespace Mentorship.CleaningService.Models
{
    public class Company : IEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string CompanyName { get; set; }
        public virtual ICollection<Offer> Offers { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; }
        public virtual ICollection<Worker> Workers { get; set; }
    }
}
