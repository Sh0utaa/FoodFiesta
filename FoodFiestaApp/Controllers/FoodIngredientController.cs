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
    }
}
