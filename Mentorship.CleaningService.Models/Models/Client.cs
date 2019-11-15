using System;
using System.Collections.Generic;
using System.Text;
using Mentorship.CleaningService.Models.Models;

namespace Mentorship.CleaningService.Models
{
    public class Client : IEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public Person Person { get; set; }
        public virtual ICollection<ClientAddress> ClientAddresses { get; set; }
    }
}
