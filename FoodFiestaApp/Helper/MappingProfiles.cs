using AutoMapper;
using FoodFiestaApp.DTO;
using FoodFiestaApp.Models;

namespace FoodFiestaApp.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Comment, CommentDto>().ReverseMap();
            CreateMap<Cart, CartDto>().ReverseMap();
            CreateMap<Food, FoodDto>().ReverseMap();
            CreateMap<FoodIngredient, FoodIngredientDto>().ReverseMap();
            CreateMap<Ingredient, IngredientDto>().ReverseMap();
        }
    }
}
