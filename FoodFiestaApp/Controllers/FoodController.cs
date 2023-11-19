using AutoMapper;
using FoodFiestaApp.DTO;
using FoodFiestaApp.Interfaces;
using FoodFiestaApp.Models;
using FoodFiestaApp.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodFiestaApp.Controllers
{
    [Route("api/Foods")]
    [ApiController]
    public class FoodController : Controller
    {
        private readonly IFoodRepository _foodRepository;
        private readonly IMapper _mapper;
        public FoodController(IFoodRepository foodRepository, IMapper mapper)
        {
            _foodRepository = foodRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(FoodDto))]
        public IActionResult GetFood()
        {
            var allFood =  _mapper.Map<List<FoodDto>>(_foodRepository.GetFood());
            if(!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(allFood);
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(200, Type = typeof(FoodDto))]
        [ProducesResponseType(400)]
        public IActionResult GetFoodById(int Id)
        {
            if (_foodRepository.GetFoodById(Id) is null)   return NotFound();

            var singleFood = _mapper.Map<FoodDto>(_foodRepository.GetFoodById(Id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(singleFood);
        }

        [HttpGet("byName/{foodName}")]
        [ProducesResponseType(200, Type = typeof(FoodDto))]
        [ProducesResponseType(400)]
        public IActionResult GetFood(string foodName)
        {
            if (_foodRepository.GetFood(foodName) is null) return NotFound();

            var singleFood = _mapper.Map<FoodDto>(_foodRepository.GetFood(foodName));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(singleFood);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateFood([FromBody] FoodDto food)
        {
            if (food == null)
            {
                return BadRequest("Food object is null");
            }

            _foodRepository.CreateFood(food);

            return Ok(food);
        }

    }
}
