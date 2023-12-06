using AutoMapper;
using FoodFiestaApp.DTO;
using FoodFiestaApp.Interfaces;
using FoodFiestaApp.Models;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult CreateFood([FromBody] FoodDto food, [FromForm] IFormFile file)
        {
            if (food == null)
            {
                return BadRequest("Food object is null");
            }

            // Check if a file is actually uploaded
            if (file != null && file.Length > 0)
            {
                // Create a unique file name to avoid conflicts
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                // Create the path to the "Images" folder within the application's root directory
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Images", fileName);

                // Ensure the "Images" folder exists; create it if it doesn't
                if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Images")))
                {
                    Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "Images"));
                }

                // Save the file to the specified path
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                // Update the foodDto with the file path or other information
                food.FilePath = filePath;
            }

            _foodRepository.CreateFood(food);

            return Ok(food);
        }

        [HttpPut("{foodId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateFood([FromBody] FoodDto updatedFood,int foodId)
        {
            if (!_foodRepository.FoodExists(foodId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var foodMap = _mapper.Map<Food>(updatedFood);

            try
            {
                _foodRepository.UpdateFood(foodMap);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Something wet wrong updating Food");
                throw ex;
            }
            return NoContent();
        }

        [HttpDelete("{foodId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        public IActionResult DeleteFood(int foodId)
        {
            if (!_foodRepository.FoodExists(foodId))
            {
                return NotFound();
            }

            var singleFood = _foodRepository.GetFoodById(foodId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _foodRepository.DeleteFood(singleFood);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Something Went Wrong deleting Food");
                throw ex;
            }

            return NoContent();
        }
    }
}
