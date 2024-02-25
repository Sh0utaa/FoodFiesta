using AutoMapper;
using FoodFiestaApp.DTO;
using FoodFiestaApp.Interfaces;
using FoodFiestaApp.Models;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet, Authorize]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Comment>))]
        public IActionResult GetComments()
        {

            var allComments = _mapper.Map<List<CommentDto>>(_commentRepository.GetComments());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(allComments);
        }

        [HttpGet("{Id}"), Authorize]
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

        [HttpPost, Authorize]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateComment([FromBody] CommentDto commentDto)
        {
            if (commentDto == null)
            {
                return BadRequest("Comment object is null");
            }

            _commentRepository.CreateComment(commentDto);

            return Ok(commentDto);
        }

        [HttpPut("{commentId}"), Authorize]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateComment([FromBody] CommentDto commentDto, int commentId)
        {
            if (commentDto == null || commentId != commentDto.Id)
                return BadRequest(ModelState);

            if (!_commentRepository.CommentExists(commentId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var commentMap = _mapper.Map<Comment>(commentDto);

            try
            {
                _commentRepository.UpdateComment(commentMap);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Something wet wrong updating Comment");
                throw ex;
            }
            return NoContent();
        }

        [HttpDelete("{commentId}"), Authorize]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        public IActionResult DeleteComment(int commentId)
        {
            if (!_commentRepository.CommentExists(commentId))
            {
                return NotFound();
            }

            var singleComment = _commentRepository.GetComment(commentId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _commentRepository.DeleteComment(singleComment);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Something Went Wrong deleting Comment");
                throw ex;
            }

            return NoContent();
        }
    }
}
