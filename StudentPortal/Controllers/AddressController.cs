using Microsoft.AspNetCore.Mvc;
using StudentPortal.Interfaces;
using StudentPortal.Models;
using StudentPortal.Mappers;
using StudentPortal.Repository;
using StudentPortal.Dto;

namespace StudentPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : Controller
    {
        private readonly IAddressRepository _addressRepository;

        public AddressController(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Address>))]
        public IActionResult GetAddresses()
        {
            var addresses = _addressRepository.GetAddresses();

            var addressesDto = addresses.Select(x => x.ToAddressDto());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(addressesDto);

        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Address>))]
        [ProducesResponseType(400)]
        public IActionResult GetAddress(int id)
        {
            var address = _addressRepository.GetAddressById(id);

            if (address == null)
            {
                return NotFound();
            }

            var addressDto = address.ToAddressDto();


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(addressDto);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateAddress([FromBody] AddressDto addressCreate)
        {
            if (addressCreate == null)
            {
                return BadRequest(ModelState);
            }

            //check if the address name is already registered
            var address = _addressRepository.GetAddresses()
                .Where(x => (x.Street.ToLower() == addressCreate.Street.ToLower()))
                .FirstOrDefault();

            //check if the address already exists 
            if (address != null)
            {
                ModelState.AddModelError("", "Address already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //check if the course object has been created and saved in the database
            if (!_addressRepository.CreateAddress(addressCreate.ToAddressObject()))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("successfully created");
        }


        [HttpPut("{addressId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateAddress(int addressId, [FromBody] AddressDto addressDto)
        {
            //check if addressDto is null
            if (addressDto == null)
            {
                return BadRequest(ModelState);
            }

            //if addressId doesn't exist return
            if (!_addressRepository.AddressExists(addressId))
            {
                return BadRequest(ModelState);
            }

            //if addressId doesn't match the id of the user object to be updated
            if (addressId != addressDto.Id)
            {
                return BadRequest(ModelState);
            }

            var address = addressDto.ToAddressObject();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //check if the address object has been updated
            if (!_addressRepository.UpdateAddress(address))
            {
                ModelState.AddModelError("", "Something went wrong while updating address");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }

        [HttpDelete("{addressId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteAddress(int addressId)
        {
            //check if addressId isn't null and it exists
            if (addressId == null)
            {
                return BadRequest(ModelState);
            }

            if (!_addressRepository.AddressExists(addressId))
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var address = _addressRepository.GetAddressById(addressId);

            //check if course object is removed sucessfully
            if (!_addressRepository.DeleteAddress(address))
            {
                ModelState.AddModelError("", "Something went wrong while deleting address");
                return StatusCode(500, ModelState);
            }

            return Ok("Deleted address succesfully");
        }
    }
}
