using API.Dtos;
using Domain.Model;
using MapperProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mappers
{
    public class CustomerDtoModelMapper : Mapper<CustomerDto, CustomerModel>
    {
        public override CustomerDto Map(CustomerModel t)
        {
            return new CustomerDto
            {
                CustomerId = t.CustomerId,
                CustomerName = t.CustomerName,
                CustomerAddress = t.CustomerAddress,
                CustomerContactNumner = t.CustomerContactNumner
            };
        }

        public override CustomerModel Map(CustomerDto t)
        {
            return new CustomerModel
            {
                CustomerId = t.CustomerId,
                CustomerName = t.CustomerName,
                CustomerAddress = t.CustomerAddress,
                CustomerContactNumner = t.CustomerContactNumner
            };
        }
    }
}
