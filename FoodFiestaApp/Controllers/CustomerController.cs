using AutoMapper;
using FoodFiestaApp.DTO;
using FoodFiestaApp.Interfaces;
using FoodFiestaApp.Models;
using FoodFiestaApp.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FoodFiestaApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public CustomerController(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CustomerDto>))]
        public IActionResult GetCustomers()
        {
            var allCustomers = _mapper.Map<List<CustomerDto>>(_customerRepository.GetCustomers());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(allCustomers);
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CustomerDto>))]
        [ProducesResponseType(400)]
        public IActionResult GetCustomer(string Id)
        {
            if (_customerRepository.GetCustomer(Id) is null)
                return NotFound();

            var customer = _mapper.Map<CustomerDto>(_customerRepository.GetCustomer(Id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(customer);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCustomer([FromBody] CustomerDto newCustomer)
        {
            if (newCustomer == null)
            {
                return BadRequest("Customer object is null");
            }

            _customerRepository.CreateCustomer(newCustomer);

            return Ok(newCustomer);
        }

        [HttpPut("{customerId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCustomer([FromBody] CustomerDto customerDto, string customerId)
        {
            if (customerDto == null || customerId != customerDto.Id)
                return BadRequest(ModelState);

            if (!_customerRepository.CustomerExists(customerId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var customerMap = _mapper.Map<Customer>(customerDto);

            try
            {
                _customerRepository.UpdateCustomer(customerMap);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Something wet wrong updating Customer");
                throw ex;
            }
            return NoContent();
        }
    }
}
