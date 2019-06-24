using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Belatrix.Exam.WebApi.Models;
using Belatrix.Exam.WebApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Belatrix.Exam.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IRepository<Album> _repository;

        public AlbumController(IRepository<Album> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Album>>> GetAlbums()
        {
            return Ok(await _repository.Read());
        }
    }
}
