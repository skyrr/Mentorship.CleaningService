using System;

namespace Mentorship.CleaningService.DTO
{
    public class AddressDTO : IEntityDTO
    {
        public bool IsDeleted { get; set; }
        public string StreetName { get; set; }
        public string BuildingNumber { get; set; }
        public string ApartmentNumber { get; set; }
        public string City { get; set; }
        public string ErrorMessage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
