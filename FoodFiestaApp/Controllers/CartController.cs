using AutoMapper;
using FoodFiestaApp.DTO;
using FoodFiestaApp.Interfaces;
using FoodFiestaApp.Models;
using FoodFiestaApp.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FoodFiestaApp.Controllers
{
    [Route("api/carts")]
    [ApiController]
    public class CartController : Controller
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;
        public CartController(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(CartDto))]
        public IActionResult GetCarts()
        {
            var allCarts = _mapper.Map<List<CartDto>>(_cartRepository.GetAllCarts());
            if (allCarts is null) return NotFound();
            if (!ModelState.IsValid) return BadRequest();

            return Ok(allCarts);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateFood([FromBody] CartDto cartDto)
        {
            if (cartDto == null)
            {
                return BadRequest("Cart object is null");
            }

            _cartRepository.CreateCart(cartDto);
            return Ok(cartDto);
        }

        [HttpPut("{cartId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateFood([FromBody] CartDto cartDto, int cartId)
        {
            if (cartDto == null || cartId != cartDto.Id)
                return BadRequest(ModelState);

            if (!_cartRepository.CartExists(cartId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var cartMap = _mapper.Map<Cart>(cartDto);

            try
            {
                _cartRepository.UpdateCart(cartMap);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Something wet wrong updating Cart");
                throw ex;
            }
            return NoContent();
        }
    }
}
