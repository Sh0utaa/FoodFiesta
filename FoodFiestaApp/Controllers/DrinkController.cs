using AutoMapper;
using FoodFiestaApp.DTO;
using FoodFiestaApp.Interfaces;
using FoodFiestaApp.Models;
using FoodFiestaApp.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FoodFiestaApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrinkController : ControllerBase
    {
        private readonly IDrinkRepository _drinkRepository;
        private readonly IMapper _mapper;
        public DrinkController(IDrinkRepository drinkRepository, IMapper mapper)
        {
            _drinkRepository = drinkRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(DrinkDto))]
        public IActionResult GetDrink()
        {
            var allDrinks = _mapper.Map<List<DrinkDto>>(_drinkRepository.GetDrinks());
            if(!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(allDrinks);
        }

        [HttpGet("{id}", Name = "GetDrinkById")]
        [ProducesResponseType(200, Type = typeof(DrinkDto))]
        [ProducesResponseType(400)]
        public IActionResult GetDrinkById(int id)
        {
            var drink = _mapper.Map<DrinkDto>(_drinkRepository.GetDrinkById(id));
            if(!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(drink);
        }

        [HttpGet("byname/{drinkName}", Name = "GetDrinkByName")]
        [ProducesResponseType(200, Type = typeof(DrinkDto))]
        [ProducesResponseType(400)]
        public IActionResult GetDrinkByName(string drinkName)
        {
            var drink = _mapper.Map<DrinkDto>(_drinkRepository.GetDrinkByName(drinkName));
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(drink);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateDrink([FromBody] DrinkDto drink)
        {
            if (drink is null) return BadRequest("drink model is null");
            _drinkRepository.CreateDrink(drink);
            return Ok();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateDrink(int id, [FromBody] DrinkDto updatedDrink)
        {
            if (!_drinkRepository.DrinkExists(id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var drinkModel = _mapper.Map<Drink>(updatedDrink);

            try
            {
                _drinkRepository.UpdateDrink(drinkModel);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Something went wrong updating Drink");
                return BadRequest(ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        public IActionResult DeleteDrink(int id)
        {
            if (!_drinkRepository.DrinkExists(id))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _drinkRepository.DeleteDrink(id);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Something Went Wrong deleting Drink");
                throw ex;
            }

            return NoContent();
        }
    }
}
