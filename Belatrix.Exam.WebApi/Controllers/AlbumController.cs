using AutoMapper;
using Belatrix.Exam.WebApi.Filters;
using Belatrix.Exam.WebApi.Models;
using Belatrix.Exam.WebApi.Repository;
using Belatrix.Exam.WebApi.Requests;
using Belatrix.Exam.WebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Belatrix.Exam.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [CustomResultFilterAttribute]
    public class AlbumController : ControllerBase
    {
        private readonly IRepository<Album> _repository;
        private readonly IMapper _mapper;

        public AlbumController(IRepository<Album> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlbumResponse>>> GetAlbums()
        {
            return Ok(_mapper.Map<List<AlbumResponse>>(await _repository.Read()));
        }

        [HttpPost]
        public async Task<ActionResult<AlbumResponse>> PostAlbum(AlbumRequest album)
        {
            await _repository.Create(_mapper.Map<Album>(album));
            return Ok(album.AlbumId);
        }

        [HttpPut]
        public async Task<ActionResult<bool>> PutCustomer(AlbumRequest album)
        {
            return Ok(await _repository.Update(_mapper.Map<Album>(album)));
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteCustomer(int id)
        {
            return Ok(await _repository.Delete(new Album { AlbumId = id }));
        }
    }
}
