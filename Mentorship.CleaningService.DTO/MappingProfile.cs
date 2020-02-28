using AutoMapper;
using Mentorship.CleaningService.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mentorship.CleaningService.DTO
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<ClientsDemand, ClientsDemandDTO>();
        }
    }
}
