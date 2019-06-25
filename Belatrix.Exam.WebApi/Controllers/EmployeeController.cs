using AutoMapper;
using Belatrix.Exam.WebApi.Filters;
using Belatrix.Exam.WebApi.Models;
using Belatrix.Exam.WebApi.Repository;
using Belatrix.Exam.WebApi.ViewModels.Employee.Requests;
using Belatrix.Exam.WebApi.ViewModels.Employee.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Belatrix.Exam.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [CustomResultFilterAttribute]
    public class EmployeeController : ControllerBase
    {
        private readonly IRepository<Employee> _repository;
        private readonly IMapper _mapper;

        public EmployeeController(IRepository<Employee> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeResponse>>> GetEmployee()
        {
            return Ok(_mapper.Map<List<EmployeeResponse>>(await _repository.Read()));
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeResponse>> PostEmployee(EmployeePostRequest request)
        {
            var Employee = _mapper.Map<Employee>(request);
            await _repository.Create(Employee);
            return Ok(Employee.EmployeeId);
        }

        [HttpPut]
        public async Task<ActionResult<bool>> PutEmployee(EmployeePutRequest request)
        {
            return Ok(await _repository.Update(_mapper.Map<Employee>(request)));
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteEmployee(int id)
        {
            return Ok(await _repository.Delete(new Employee { EmployeeId = id }));
        }
    }
}
