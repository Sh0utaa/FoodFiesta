using AutoMapper;
using FoodFiestaApp.DTO;
using FoodFiestaApp.Interfaces;
using FoodFiestaApp.Models;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet, Authorize]
        [ProducesResponseType(200, Type = typeof(CartDto))]
        public IActionResult GetCarts()
        {
            var allCarts = _mapper.Map<List<CartDto>>(_cartRepository.GetAllCarts());
            if (allCarts is null) return NotFound();
            if (!ModelState.IsValid) return BadRequest();

            return Ok(allCarts);
        }

        [HttpGet("{cartId}"), Authorize]
        [ProducesResponseType(200, Type = typeof(CartDto))]
        [ProducesResponseType(404)]
        public IActionResult GetCart(int cartId)
        {
            var cart = _cartRepository.GetCart(cartId);

            if (cart == null)
            {
                return NotFound(); 
            }

            var cartDto = _mapper.Map<CartDto>(cart);

            return Ok(cartDto);
        }


        [HttpPost, Authorize]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCart([FromBody] CartDto cartDto)
        {
            if (cartDto == null)
            {
                return BadRequest("Cart object is null");
            }

            _cartRepository.CreateCart(cartDto);
            return Ok(cartDto);
        }

        [HttpPut("{cartId}"), Authorize]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCart([FromBody] CartDto cartDto, int cartId)
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

        [HttpDelete("{cartId}"), Authorize]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        public IActionResult DeleteCart(int cartId)
        {
            if (!_cartRepository.CartExists(cartId))
            {
                return NotFound();
            }

            var singleCart = _cartRepository.GetCart(cartId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _cartRepository.DeleteCart(singleCart);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Something Went Wrong deleting Cart");
                throw ex;
            }

            return NoContent();
        }

    }
}
