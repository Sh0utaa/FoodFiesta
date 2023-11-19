﻿using FoodFiestaApp.Data;
using FoodFiestaApp.DTO;
using FoodFiestaApp.Interfaces;
using FoodFiestaApp.Models;

namespace FoodFiestaApp.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly DataContext _contexet;
        public CartRepository(DataContext context)
        {
            _contexet = context;   
        }
        public ICollection<Cart> GetAllCarts()
        {
            return _contexet.Carts.OrderBy(c => c.Id).ToList();
        }
    }
}
