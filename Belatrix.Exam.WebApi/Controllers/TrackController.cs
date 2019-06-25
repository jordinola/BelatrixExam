using AutoMapper;
using Belatrix.Exam.WebApi.Filters;
using Belatrix.Exam.WebApi.Models;
using Belatrix.Exam.WebApi.Repository;
using Belatrix.Exam.WebApi.ViewModels.Track.Requests;
using Belatrix.Exam.WebApi.ViewModels.Track.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Belatrix.Exam.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [CustomResultFilterAttribute]
    public class TrackController : ControllerBase
    {
        private readonly IRepository<Track> _repository;
        private readonly IMapper _mapper;

        public TrackController(IRepository<Track> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrackResponse>>> GetTrack()
        {
            return Ok(_mapper.Map<List<TrackResponse>>(await _repository.Read()));
        }

        [HttpPost]
        public async Task<ActionResult<TrackResponse>> PostTrack(TrackPostRequest request)
        {
            var Track = _mapper.Map<Track>(request);
            await _repository.Create(Track);
            return Ok(Track.TrackId);
        }

        [HttpPut]
        public async Task<ActionResult<bool>> PutTrack(TrackPutRequest request)
        {
            return Ok(await _repository.Update(_mapper.Map<Track>(request)));
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteTrack(int id)
        {
            return Ok(await _repository.Delete(new Track { TrackId = id }));
        }
    }
}
