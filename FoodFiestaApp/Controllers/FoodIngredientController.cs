using AutoMapper;
using FoodFiestaApp.DTO;
using FoodFiestaApp.Interfaces;
using FoodFiestaApp.Models;
using FoodFiestaApp.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FoodFiestaApp.Controllers
{
    [Route("api/foodIngredients")]
    [ApiController]
    public class FoodIngredientController : Controller
    {
        private readonly IFoodIngredientRepository _foodIngredientRepository;
        private readonly IMapper _mapper;
        public FoodIngredientController(IFoodIngredientRepository foodIngredientRepository, IMapper mapper)
        {
            _foodIngredientRepository = foodIngredientRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<FoodIngredientDto>))]
        public IActionResult GetFoodIngredients()
        {
            var allFoodIngredients = _mapper.Map<List<FoodIngredientDto>>(_foodIngredientRepository.GetFoodIngredients());
            if(allFoodIngredients is null) return NotFound();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(allFoodIngredients);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateFoodIngredient([FromBody] FoodIngredientDto foodIngredientDto)
        {
            if (foodIngredientDto == null)
            {
                return BadRequest("foodIngredient object is null");
            }

            _foodIngredientRepository.CreateFoodIngredient(foodIngredientDto);

            return Ok(foodIngredientDto);
        }

        [HttpPut("{foodIngredientId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateFoodIngredient([FromBody] FoodIngredientDto updatedFoodIngredient, int foodIngredientId)
        {
            if (updatedFoodIngredient == null || foodIngredientId != updatedFoodIngredient.Id)
                return BadRequest(ModelState);

            if (!_foodIngredientRepository.FoodIngredeintExists(foodIngredientId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var foodIngredientMap = _mapper.Map<FoodIngredient>(updatedFoodIngredient);

            try
            {
                _foodIngredientRepository.UpdateFoodIngredient(foodIngredientMap);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Something wet wrong updating FoodIngredient");
                throw ex;
            }
            return NoContent();
        }
    }
}
