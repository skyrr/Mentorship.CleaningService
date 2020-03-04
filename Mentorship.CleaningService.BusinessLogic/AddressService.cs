using AutoMapper;
using Mentorship.CleaningService.DTO;
using Mentorship.CleaningService.Models;
using Mentorship.CleaningService.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Mentorship.CleaningService.BusinessLogic
{
    public class AddressService
    {
        public IRepositoryFactory _factory;
        public IMapper _mapper;
        public AddressService(IRepositoryFactory factory, IMapper mapper)
        {
            _factory = factory;
            _mapper = mapper;
        }

        public AddressDTO CreateAdress() { return new AddressDTO(); }

        public IEnumerable<AddressDTO> GetAll() {
            try
            {
                var address = _factory.GetRepository<Address>().GetAll();
                IEnumerable<AddressDTO> cDTO = _mapper.Map<IEnumerable<Address>, IEnumerable<AddressDTO>>(address);
                return cDTO;
            }
            catch (SqlException ex)
            {
                //TODO: Logging an exception
                return new List<AddressDTO> { new AddressDTO { ErrorMessage = ex.Message } };
            }
            catch (Exception ex)
            {
                //TODO: Logging an exception
                return new List<AddressDTO> { new AddressDTO { ErrorMessage = ex.Message } };
            }
        }

        public AddressDTO GetAddressById(int id)
        {
            var clientsDemand = _factory.GetRepository<Address>().GetById(id);
            return _mapper.Map<AddressDTO>(clientsDemand);
        }

    }
}
