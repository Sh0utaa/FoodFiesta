using AutoMapper;
using FoodFiestaApp.DTO;
using FoodFiestaApp.Interfaces;
using FoodFiestaApp.Models;
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
    }
}
