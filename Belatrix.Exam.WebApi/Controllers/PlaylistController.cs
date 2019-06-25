using AutoMapper;
using Belatrix.Exam.WebApi.Filters;
using Belatrix.Exam.WebApi.Models;
using Belatrix.Exam.WebApi.Repository;
using Belatrix.Exam.WebApi.ViewModels.Playlist.Requests;
using Belatrix.Exam.WebApi.ViewModels.Playlist.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Belatrix.Exam.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [CustomResultFilterAttribute]
    public class PlaylistController : ControllerBase
    {
        private readonly IRepository<Playlist> _repository;
        private readonly IMapper _mapper;

        public PlaylistController(IRepository<Playlist> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlaylistResponse>>> GetPlaylist()
        {
            return Ok(_mapper.Map<List<PlaylistResponse>>(await _repository.Read()));
        }

        [HttpPost]
        public async Task<ActionResult<PlaylistResponse>> PostPlaylist(PlaylistPostRequest request)
        {
            var Playlist = _mapper.Map<Playlist>(request);
            await _repository.Create(Playlist);
            return Ok(Playlist.PlaylistId);
        }

        [HttpPut]
        public async Task<ActionResult<bool>> PutPlaylist(PlaylistPutRequest request)
        {
            return Ok(await _repository.Update(_mapper.Map<Playlist>(request)));
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeletePlaylist(int id)
        {
            return Ok(await _repository.Delete(new Playlist { PlaylistId = id }));
        }
    }
}
