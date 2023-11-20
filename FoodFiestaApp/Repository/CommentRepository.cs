using FoodFiestaApp.Data;
using FoodFiestaApp.DTO;
using FoodFiestaApp.Interfaces;
using FoodFiestaApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodFiestaApp.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly DataContext _context;
        public CommentRepository(DataContext context)
        {
            _context = context;
        }
        public ICollection<Comment> GetComments()
        {
            return _context.Comments.OrderBy(p => p.Id).ToList();
        }
        public Comment GetComment(int Id)
        {
            var singleComment = _context.Comments.Where(c => c.Id == Id).FirstOrDefault();
            return singleComment;
        }

        public void CreateComment(CommentDto commentDto)
        {
            try
            {
                var newComment = new Comment
                {
                    CustomerId = commentDto.CustomerId,
                    Text = commentDto.Text,
                    Rating = commentDto.Rating,
                };

                _context.Add(newComment);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool CommentExists(int id)
        {
            return _context.Comments.Any(c => c.Id == id);
        }

        public void UpdateComment(Comment comment)
        {
            try
            {
                _context.Update(comment);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
