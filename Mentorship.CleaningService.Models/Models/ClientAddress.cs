using System;
using System.Collections.Generic;
using System.Text;

namespace Mentorship.CleaningService.Models.Models
{
    public class ClientAddress
    {
        public int ClientId { get; set; }
        public int AddressId { get; set; }

        public Client Client { get; set; }
        public Address Address { get; set; }
    }
}
