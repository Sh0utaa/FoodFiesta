using FoodFiestaApp.DTO;
using FoodFiestaApp.Models;

namespace FoodFiestaApp.Interfaces
{
    public interface ICommentRepository
    {
        ICollection<Comment> GetComments();
        Comment GetComment(int Id);
        void CreateComment(CommentDto commentDto);
    }
}
