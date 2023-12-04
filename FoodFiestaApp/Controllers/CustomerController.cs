using AutoMapper;
using FoodFiestaApp.DTO;
using FoodFiestaApp.Interfaces;
using FoodFiestaApp.Models;
using FoodFiestaApp.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace FoodFiestaApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly IUserRepository _customerRepository;
        private readonly IMapper _mapper;
        public CustomerController(IUserRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<UserDTO>))]
        public IActionResult GetUsers()
        
        {
            var allCustomers = _mapper.Map<List<UserDTO>>(_customerRepository.GetUsers());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(allCustomers);
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<UserDTO>))]
        [ProducesResponseType(400)]
        public IActionResult GetUser(int Id)
        {
            if (_customerRepository.GetUser(Id) is null)
                return NotFound();

            var customer = _mapper.Map<UserDTO>(_customerRepository.GetUser(Id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(customer);
        }


        [HttpPut("{customerId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateUser([FromBody] User customerDto, int customerId)
        {
            if (customerDto == null || customerId != customerDto.Id)
                return BadRequest(ModelState);

            if (!_customerRepository.UserExists(customerId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var customerMap = _mapper.Map<User>(customerDto);

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

        [HttpDelete("{customerId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        public IActionResult DeleteUser(int customerId)
        {
            if (!_customerRepository.UserExists(customerId))
            {
                return NotFound();
            }

            var singleCustomer = _customerRepository.GetUser(customerId);

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
