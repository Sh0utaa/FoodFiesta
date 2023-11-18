using AutoMapper;
using FoodFiestaApp.DTO;
using FoodFiestaApp.Interfaces;
using FoodFiestaApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodFiestaApp.Controllers
{
    [Route("api/ingredients")]
    [ApiController]
    public class IngredientController : Controller
    {
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IMapper _mapper;
        public IngredientController(IIngredientRepository ingredientRepository, IMapper mapper)
        {
            _ingredientRepository = ingredientRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<IngredientDto>))]
        public IActionResult GetIngredients()
        {
            var allIngredients = _mapper.Map<List<IngredientDto>>(_ingredientRepository.GetIngredients());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(allIngredients);
        }
        [HttpGet("{ingredientName}")]
        [ProducesResponseType(200, Type = typeof(IngredientDto))]
        public IActionResult GetIngredient(string ingredientName)
        {
            var singleEngridient = _mapper.Map<IngredientDto>(_ingredientRepository.GetIngredient(ingredientName));

            if (singleEngridient is null) return NotFound();
            if (!ModelState.IsValid) return BadRequest();

            return Ok(singleEngridient);
        }
    }
}
