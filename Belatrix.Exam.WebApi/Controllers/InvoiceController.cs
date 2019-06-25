using AutoMapper;
using Belatrix.Exam.WebApi.Filters;
using Belatrix.Exam.WebApi.Models;
using Belatrix.Exam.WebApi.Repository;
using Belatrix.Exam.WebApi.ViewModels.Invoice.Requests;
using Belatrix.Exam.WebApi.ViewModels.Invoice.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Belatrix.Exam.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [CustomResultFilterAttribute]
    public class InvoiceController : ControllerBase
    {
        private readonly IRepository<Invoice> _repository;
        private readonly IMapper _mapper;

        public InvoiceController(IRepository<Invoice> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceResponse>>> GetInvoice()
        {
            return Ok(_mapper.Map<List<InvoiceResponse>>(await _repository.Read()));
        }

        [HttpPost]
        public async Task<ActionResult<InvoiceResponse>> PostInvoice(InvoicePostRequest request)
        {
            var Invoice = _mapper.Map<Invoice>(request);
            await _repository.Create(Invoice);
            return Ok(Invoice.InvoiceId);
        }

        [HttpPut]
        public async Task<ActionResult<bool>> PutInvoice(InvoicePutRequest request)
        {
            return Ok(await _repository.Update(_mapper.Map<Invoice>(request)));
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteInvoice(int id)
        {
            return Ok(await _repository.Delete(new Invoice { InvoiceId = id }));
        }
    }
}
