using AutoMapper;
using Belatrix.Exam.WebApi.Filters;
using Belatrix.Exam.WebApi.Models;
using Belatrix.Exam.WebApi.Repository;
using Belatrix.Exam.WebApi.ViewModels.PlaylistTrack.Requests;
using Belatrix.Exam.WebApi.ViewModels.PlaylistTrack.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Belatrix.Exam.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [CustomResultFilterAttribute]
    public class PlaylistTrackController : ControllerBase
    {
        private readonly IRepository<PlaylistTrack> _repository;
        private readonly IMapper _mapper;

        public PlaylistTrackController(IRepository<PlaylistTrack> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlaylistTrackResponse>>> GetPlaylistTrack()
        {
            return Ok(_mapper.Map<List<PlaylistTrackResponse>>(await _repository.Read()));
        }

        [HttpPost]
        public async Task<ActionResult<PlaylistTrackResponse>> PostPlaylistTrack(PlaylistTrackPostRequest request)
        {
            var playlistTrack = _mapper.Map<PlaylistTrack>(request);
            await _repository.Create(playlistTrack);
            return Ok(_mapper.Map<PlaylistTrackResponse>(playlistTrack));
        }

        [HttpPut]
        public async Task<ActionResult<bool>> PutPlaylistTrack(PlaylistTrackPutRequest request)
        {
            return Ok(await _repository.Update(_mapper.Map<PlaylistTrack>(request)));
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeletePlaylistTrack(int playlistId, int trackId)
        {
            return Ok(await _repository.Delete(new PlaylistTrack { PlaylistId = playlistId, TrackId = trackId }));
        }
    }
}
