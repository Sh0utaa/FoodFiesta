using AutoMapper;
using FoodFiestaApp.DTO;
using FoodFiestaApp.Interfaces;
using FoodFiestaApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FoodFiestaApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _customerRepository;
        private readonly IMapper _mapper;
        public UserController(IUserRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        [HttpGet, Authorize]
        [ProducesResponseType(200, Type = typeof(IEnumerable<UserDTO>))]
        public IActionResult GetUsers()
        {
            string userAuthenticationClaim = User.FindFirst(ClaimTypes.Authentication).Value;
            if (userAuthenticationClaim != "True")
            {
                return BadRequest("User is not authenticated.");
            }
            var allCustomers = _customerRepository.GetUsers();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(allCustomers);
        }

        [HttpGet("{Id}"), Authorize]
        [ProducesResponseType(200, Type = typeof(IEnumerable<UserDTO>))]
        [ProducesResponseType(400)]
        public IActionResult GetUser(int Id)
        {
            string userAuthenticationClaim = User.FindFirst(ClaimTypes.Authentication).Value;
            if (userAuthenticationClaim != "True")
            {
                return BadRequest("User is not authenticated.");
            }
            if (_customerRepository.GetUser(Id) is null)
                return NotFound();

            var customer = _customerRepository.GetUser(Id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(customer);
        }


        [HttpPut("{userId}"), Authorize]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateUser([FromBody] User user, int userId)
        {
            string userAuthenticationClaim = User.FindFirst(ClaimTypes.Authentication).Value;
            if (userAuthenticationClaim != "True")
            {
                return BadRequest("User is not authenticated.");
            }
            if (user == null || userId != user.Id)
                return BadRequest(ModelState);

            if (!_customerRepository.UserExists(userId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var customerMap = _mapper.Map<User>(user);

            try
            {
                _customerRepository.UpdateUser(customerMap);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Something wet wrong updating Customer");
                throw ex;
            }
            return NoContent();
        }

        [HttpDelete("{userId}"), Authorize]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        public IActionResult DeleteUser(int userId)
        {
            string userAuthenticationClaim = User.FindFirst(ClaimTypes.Authentication).Value;
            if (userAuthenticationClaim != "True")
            {
                return BadRequest("User is not authenticated.");
            }
            if (!_customerRepository.UserExists(userId))
            {
                return NotFound();
            }

            var singleCustomer = _customerRepository.GetUser(userId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _customerRepository.DeleteUser(singleCustomer);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Something Went Wrong deleting Customer");
                throw ex;
            }

            return NoContent();
        }
    }
}
