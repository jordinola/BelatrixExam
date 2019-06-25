using AutoMapper;
using Belatrix.Exam.WebApi.Filters;
using Belatrix.Exam.WebApi.Models;
using Belatrix.Exam.WebApi.Repository;
using Belatrix.Exam.WebApi.ViewModels.Artist.Requests;
using Belatrix.Exam.WebApi.ViewModels.Artist.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Belatrix.Exam.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [CustomResultFilterAttribute]
    public class ArtistController : ControllerBase
    {
        private readonly IRepository<Artist> _repository;
        private readonly IMapper _mapper;

        public ArtistController(IRepository<Artist> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArtistResponse>>> GetArtist()
        {
            return Ok(_mapper.Map<List<ArtistResponse>>(await _repository.Read()));
        }

        [HttpPost]
        public async Task<ActionResult<ArtistResponse>> PostArtist(ArtistPostRequest request)
        {
            var artist = _mapper.Map<Artist>(request);
            await _repository.Create(artist);
            return Ok(artist.ArtistId);
        }

        [HttpPut]
        public async Task<ActionResult<bool>> PutArtist(ArtistPutRequest request)
        {
            return Ok(await _repository.Update(_mapper.Map<Artist>(request)));
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteArtist(int id)
        {
            return Ok(await _repository.Delete(new Artist { ArtistId = id }));
        }
    }
}
