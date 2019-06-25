using AutoMapper;
using Belatrix.Exam.WebApi.Filters;
using Belatrix.Exam.WebApi.Models;
using Belatrix.Exam.WebApi.Repository;
using Belatrix.Exam.WebApi.ViewModels.MediaType.Requests;
using Belatrix.Exam.WebApi.ViewModels.MediaType.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Belatrix.Exam.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [CustomResultFilterAttribute]
    public class MediaTypeController : ControllerBase
    {
        private readonly IRepository<MediaType> _repository;
        private readonly IMapper _mapper;

        public MediaTypeController(IRepository<MediaType> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MediaTypeResponse>>> GetMediaType()
        {
            return Ok(_mapper.Map<List<MediaTypeResponse>>(await _repository.Read()));
        }

        [HttpPost]
        public async Task<ActionResult<MediaTypeResponse>> PostMediaType(MediaTypePostRequest request)
        {
            var MediaType = _mapper.Map<MediaType>(request);
            await _repository.Create(MediaType);
            return Ok(MediaType.MediaTypeId);
        }

        [HttpPut]
        public async Task<ActionResult<bool>> PutMediaType(MediaTypePutRequest request)
        {
            return Ok(await _repository.Update(_mapper.Map<MediaType>(request)));
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteMediaType(int id)
        {
            return Ok(await _repository.Delete(new MediaType { MediaTypeId = id }));
        }
    }
}
