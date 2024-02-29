using Microsoft.AspNetCore.Mvc;
using StudentPortal.Dto;
using StudentPortal.Interfaces;
using StudentPortal.Mappers;
using StudentPortal.Models;

namespace StudentPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository) 
        {
            this._userRepository = userRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
        public IActionResult GetUsers()
        {
            var users =  _userRepository.GetUsers();

            var usersDto = users.Select(x => x.ToUserDto());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(usersDto);
        }
    }
}
