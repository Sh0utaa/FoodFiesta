using AutoMapper;
using FoodFiestaApp.DTO;
using FoodFiestaApp.Interfaces;
using FoodFiestaApp.Models;
using FoodFiestaApp.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateIngredient([FromBody] IngredientDto ingredient)
        {
            if (ingredient == null)
            {
                return BadRequest("ingredient object is null");
            }

            _ingredientRepository.CreateIngredient(ingredient);

            return Ok(ingredient);
        }

        [HttpPut("{ingredientId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateIngredient([FromBody] IngredientDto updatedIngredient, int ingredientId)
        {
            if (updatedIngredient == null || ingredientId != updatedIngredient.Id)
                return BadRequest(ModelState);

            if (!_ingredientRepository.IngredientExists(ingredientId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ingredientMap = _mapper.Map<Ingredient>(updatedIngredient);

            try
            {
                _ingredientRepository.UpdateIngredient(ingredientMap);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Something wet wrong updating Ingredient");
                throw ex;
            }
            return NoContent();
        }

        [HttpDelete("{ingredientId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        public IActionResult DeleteIngredient(int ingredientId)
        {
            if (!_ingredientRepository.IngredientExists(ingredientId))
            {
                return NotFound();
            }

            var singleIngredient = _ingredientRepository.GetIngredientById(ingredientId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _ingredientRepository.DeleteIngredient(singleIngredient);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Something Went Wrong deleting Ingredient");
                throw ex;
            }

            return NoContent();
        }

    }
}
