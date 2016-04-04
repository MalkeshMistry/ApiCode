using System;
using System.Net;
using System.Net.Http;
using System.Web;

using API.Interface;
using System.Web.Http;

using Domain.Model;
using API.Dtos;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    public class CustomerController : ApiController
    {
        private readonly IDomain _Domain;

        private readonly IMapper<CustomerDto, CustomerModel> _DtoMapper;

        public CustomerController(IDomain Domain,
            IMapper<CustomerDto, CustomerModel> DtoMapper)
        {
            if (Domain == null) throw new ArgumentNullException("domain");
            if (DtoMapper == null) throw new ArgumentNullException("DtoMapper");
            _Domain = Domain;
            _DtoMapper = DtoMapper;
        }

        [HttpGet]
        [Route("Customers/{customerId}")]
        public CustomerDto Get(int customerId)
        {
            return _DtoMapper.Map(_Domain.GetCustomer(customerId));
        }

        [HttpGet]
        [Route("Customers")]
        public IList<CustomerDto> GetAll()
        {
            return _DtoMapper.MapOrEmptyList(_Domain.GetCustomers());
        }

        [HttpPost]
        [Route("Customers/create")]
        public CustomerDto Post(CustomerDto customer)
        {
            return _DtoMapper.Map(_Domain.CreateCustomer(_DtoMapper.Map(customer)));

        }

        [HttpGet]
        [Route("Customers/GetByName/{CustomerName}")]
        public IHttpActionResult GetCustomerByName(string customerName)
        {
            return this.Ok<CustomerDto>(_DtoMapper.Map(_Domain.FindCustomerByName(customerName)));
        }

        [HttpDelete]
        [Route("Customers/{customerId}")]
        public void Delete(int customerId)
        {
             _Domain.DeleteCustomer(customerId);
        }
    }
}
