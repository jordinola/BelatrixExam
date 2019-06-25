using AutoMapper;
using Belatrix.Exam.WebApi.Filters;
using Belatrix.Exam.WebApi.Models;
using Belatrix.Exam.WebApi.Repository;
using Belatrix.Exam.WebApi.ViewModels.Genre.Requests;
using Belatrix.Exam.WebApi.ViewModels.Genre.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Belatrix.Exam.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [CustomResultFilterAttribute]
    public class GenreController : ControllerBase
    {
        private readonly IRepository<Genre> _repository;
        private readonly IMapper _mapper;

        public GenreController(IRepository<Genre> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenreResponse>>> GetGenre()
        {
            return Ok(_mapper.Map<List<GenreResponse>>(await _repository.Read()));
        }

        [HttpPost]
        public async Task<ActionResult<GenreResponse>> PostGenre(GenrePostRequest request)
        {
            var Genre = _mapper.Map<Genre>(request);
            await _repository.Create(Genre);
            return Ok(Genre.GenreId);
        }

        [HttpPut]
        public async Task<ActionResult<bool>> PutGenre(GenrePutRequest request)
        {
            return Ok(await _repository.Update(_mapper.Map<Genre>(request)));
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteGenre(int id)
        {
            return Ok(await _repository.Delete(new Genre { GenreId = id }));
        }
    }
}
