﻿using FoodFiestaApp.Data;
using FoodFiestaApp.DTO;
using FoodFiestaApp.Interfaces;
using FoodFiestaApp.Models;

namespace FoodFiestaApp.Repository
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly DataContext _context;
        public IngredientRepository(DataContext context)
        {
            _context = context;
        }

        public void CreateIngredient(IngredientDto ingredientDto)
        {
            try
            {
                var newIngredient = new Ingredient
                {
                    IngredientName = ingredientDto.IngredientName,
                };
                _context.Add(newIngredient);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Ingredient GetIngredient(string name)
        {
            var singleEngridient = _context.Ingredients.Where(i => i.IngredientName == name).FirstOrDefault();
            return singleEngridient;
        }

        public ICollection<Ingredient> GetIngredients()
        {
            return _context.Ingredients.OrderBy(i => i.Id).ToList();
        }

        public bool IngredientExists(int id)
        {
            return _context.Ingredients.Any(i => i.Id == id);
        }

        public void UpdateIngredient(Ingredient ingredientObject)
        {
            try
            {
                _context.Update(ingredientObject);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}