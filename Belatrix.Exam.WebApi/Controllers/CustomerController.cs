using AutoMapper;
using Belatrix.Exam.WebApi.Filters;
using Belatrix.Exam.WebApi.Models;
using Belatrix.Exam.WebApi.Repository;
using Belatrix.Exam.WebApi.Requests.Customer;
using Belatrix.Exam.WebApi.Responses.Customer;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Belatrix.Exam.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [CustomResultFilterAttribute]
    public class CustomerController : ControllerBase
    {
        private readonly IRepository<Customer> _repository;
        private readonly IMapper _mapper;

        public CustomerController(IRepository<Customer> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerResponse>>> GetCustomer()
        {
            return Ok(_mapper.Map<List<CustomerResponse>>(await _repository.Read()));
        }

        [HttpPost]
        public async Task<ActionResult<CustomerResponse>> PostCustomer(CustomerPostRequest request)
        {
            var Customer = _mapper.Map<Customer>(request);
            await _repository.Create(Customer);
            return Ok(Customer.CustomerId);
        }

        [HttpPut]
        public async Task<ActionResult<bool>> PutCustomer(CustomerPutRequest request)
        {
            return Ok(await _repository.Update(_mapper.Map<Customer>(request)));
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteCustomer(int id)
        {
            return Ok(await _repository.Delete(new Customer { CustomerId = id }));
        }
    }
}
