using System;
using System.Collections.Generic;
using System.Text;
using Mentorship.CleaningService.Models.Models;

namespace Mentorship.CleaningService.Models
{
    public class Address : IEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string StreetName { get; set; }
        public string BuildingNumber { get; set; }
        public string ApartmentNumber { get; set; }
        public string City { get; set; }

        public virtual ICollection<ClientAddress> ClientAddresses { get; set; }
    }
}
