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
    public class UsersController : ControllerBase
    {
        private IUserRepository _userRepository;
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<user>>> GetUsers([FromQuery] PagingParameters pagingParametrs)
        {
            return await _userRepository.GetUsers(pagingParametrs);
        }

        [HttpGet("{id}")]
        public ActionResult<user> GetUserById(string id)
        {
            var user = _userRepository.GetUser(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public ActionResult<user> CreateUser([FromBody] user user)
        {
            if(user == null)
            {
                return BadRequest("Objeto Usuario é nulo");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest("Objeto Usurio inválido");
            }

            _userRepository.CreateUser(user);
            return Ok(CreatedAtRoute("UserId", new { id = user.id }, user));
        }

        [HttpPut("{id}")]
        public ActionResult UpdateUser(string id, [FromBody] user user)
        {
            if(user == null)
            {
                return BadRequest("O objeto Usuario é nulo");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest("Objeto Usuario invalido");
            }

            _userRepository.Update(user);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(string id)
        {
            var del = _userRepository.GetUser(id);
            if (!del.id.Equals(id))
            {
                return NotFound();
            }

            _userRepository.Delete(del);

            return NoContent();
        }
    }
}
