using AutoMapper;
using FoodFiestaApp.DTO;
using FoodFiestaApp.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodFiestaApp.Controllers
{
    [Route("api/history")]
    [ApiController]
    public class HistoryController : Controller
    {
        private readonly IHistoryRepository _historyRepository;
        private readonly IMapper _mapper;
        public HistoryController(IHistoryRepository historyRepository, IMapper mapper)
        {
            _historyRepository = historyRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<HistoryDto>))]
        public IActionResult GetHistories()
        {
            var allHistories = _mapper.Map<List<HistoryDto>>(_historyRepository.GetHistories());
            if (allHistories is null) return NotFound();
            if (!ModelState.IsValid) return BadRequest();

            return Ok(allHistories);
        }
    }
}
