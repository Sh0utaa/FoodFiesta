using AutoMapper;
using FoodFiestaApp.DTO;
using FoodFiestaApp.Models;

namespace FoodFiestaApp.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<Comment, CommentDto>();
            CreateMap<Cart, CartDto>();
            CreateMap<Food, FoodDto>();
            CreateMap<FoodIngredient, FoodIngredientDto>();
            CreateMap<Ingredient, IngredientDto>();
        }
    }
}
