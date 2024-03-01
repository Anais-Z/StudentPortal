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


        [HttpGet("{firstName}/{lastName}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
        [ProducesResponseType(400)]
        public IActionResult GetUser(string firstName, string lastName)
        {
            var user = _userRepository.GetUser(firstName, lastName);

            if (user == null)
            {
                return NotFound();
            }

            var userDto = user.ToUserDto();


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(userDto);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateUser([FromBody] UserDto userCreate) 
        {
            if(userCreate == null)
            {
                return BadRequest(ModelState);
            }

            //check if the firstname and lastname is already registered
            var user = _userRepository.GetUsers()
                .Where(x => (x.FirstName.ToLower() == userCreate.FirstName.ToLower()) && (x.LastName.ToLower() == userCreate.LastName.ToLower()))
                .FirstOrDefault();

            if (user != null)
            {
                ModelState.AddModelError("", "User already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!_userRepository.CreateUser(userCreate.ToUserObject()))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("successfully created");
        }
    }
}
