﻿using AutoMapper;
using FoodFiestaApp.DTO;
using FoodFiestaApp.Interfaces;
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
    }
}
