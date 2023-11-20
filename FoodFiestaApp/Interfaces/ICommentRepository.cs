using FoodFiestaApp.DTO;
using FoodFiestaApp.Models;

namespace FoodFiestaApp.Interfaces
{
    public interface ICommentRepository
    {
        ICollection<Comment> GetComments();
        bool CommentExists(int id);
        Comment GetComment(int Id);
        void CreateComment(CommentDto commentDto);
        void UpdateComment(Comment comment);
        void DeleteComment(Comment commentObject)
    }
}
