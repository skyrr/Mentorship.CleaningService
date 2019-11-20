using System;
using System.Collections.Generic;
using System.Text;

namespace Mentorship.CleaningService.Models
{
    public class ClientAddress : IEntity
    {
        public int ClientId { get; set; }
        public int AddressId { get; set; }

        public Client Client { get; set; }
        public Address Address { get; set; }
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
