using AutoMapper;
using FoodFiestaApp.DTO;
using FoodFiestaApp.Interfaces;
using FoodFiestaApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodFiestaApp.Controllers
{
    [Route("api/comments")]
    [ApiController]
    public class CommentController : Controller
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        public CommentController(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Comment>))]
        public IActionResult GetComments()
        {

            var allComments = _mapper.Map<List<CommentDto>>(_commentRepository.GetComments());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(allComments);
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(200, Type = typeof(Comment))]
        [ProducesResponseType(400)]
        public IActionResult GetComment(int Id)
        {
            var singleComment = _mapper.Map<CommentDto>(_commentRepository.GetComment(Id));
            
            if (singleComment is null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(singleComment);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateFood([FromBody] CommentDto commentDto)
        {
            if (commentDto == null)
            {
                return BadRequest("Comment object is null");
            }

            _commentRepository.CreateComment(commentDto);

            return Ok(commentDto);
        }
    }
}
