using Data.Models;
using Data.Paging;
using Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCattleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CattlesController : ControllerBase
    {
        private CattleRepository _cattleRepository;
        public CattlesController(CattleRepository cattleRepository)
        {
            _cattleRepository = cattleRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<cattle>>> GetCattles([FromQuery] PagingParameters pagingParametrs)
        {
            return await _cattleRepository.GetCattles(pagingParametrs);
        }
        
        [HttpPost]
        public ActionResult CreateCattle([FromBody] cattle cattle)
        {
            if (cattle == null)
                return BadRequest("Objeto é nulo");

            if (!ModelState.IsValid)
                return BadRequest("Objeto não é valido");

            _cattleRepository.Create(cattle);

            return NoContent();
        }
    }
}
