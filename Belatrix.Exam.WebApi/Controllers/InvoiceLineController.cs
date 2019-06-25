using AutoMapper;
using Belatrix.Exam.WebApi.Filters;
using Belatrix.Exam.WebApi.Models;
using Belatrix.Exam.WebApi.Repository;
using Belatrix.Exam.WebApi.ViewModels.InvoiceLine.Requests;
using Belatrix.Exam.WebApi.ViewModels.InvoiceLine.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Belatrix.Exam.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [CustomResultFilterAttribute]
    public class InvoiceLineController : ControllerBase
    {
        private readonly IRepository<InvoiceLine> _repository;
        private readonly IMapper _mapper;

        public InvoiceLineController(IRepository<InvoiceLine> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceLineResponse>>> GetInvoiceLine()
        {
            return Ok(_mapper.Map<List<InvoiceLineResponse>>(await _repository.Read()));
        }

        [HttpPost]
        public async Task<ActionResult<InvoiceLineResponse>> PostInvoiceLine(InvoiceLinePostRequest request)
        {
            var InvoiceLine = _mapper.Map<InvoiceLine>(request);
            await _repository.Create(InvoiceLine);
            return Ok(InvoiceLine.InvoiceLineId);
        }

        [HttpPut]
        public async Task<ActionResult<bool>> PutInvoiceLine(InvoiceLinePutRequest request)
        {
            return Ok(await _repository.Update(_mapper.Map<InvoiceLine>(request)));
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteInvoiceLine(int id)
        {
            return Ok(await _repository.Delete(new InvoiceLine { InvoiceLineId = id }));
        }
    }
}
