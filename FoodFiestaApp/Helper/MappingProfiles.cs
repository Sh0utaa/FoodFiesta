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
            CreateMap<CustomerDto, Customer>();
            CreateMap<Comment, CommentDto>();
            CreateMap<CommentDto, Comment>();
            CreateMap<Cart, CartDto>();
            CreateMap<CartDto, Cart>();
            CreateMap<Food, FoodDto>();
            CreateMap<FoodDto, Food>();
            CreateMap<FoodIngredient, FoodIngredientDto>();
            CreateMap<FoodIngredientDto, FoodIngredient>();
            CreateMap<Ingredient, IngredientDto>();
            CreateMap<IngredientDto, Ingredient>();
        }
    }
}
