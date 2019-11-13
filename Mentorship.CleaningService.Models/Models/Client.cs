using System;
using System.Collections.Generic;
using System.Text;

namespace Mentorship.CleaningService.Models
{
    public class Client : IEntity
    {
        public int Id { get; set; }
        public Person Person { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
