using like.microservice.Data;
using like.microservice.Model;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;

namespace like.microservice.Repository
{
    public class LikeRepository : ILikeRepository
    {
        private readonly LikeContext _context;

        public LikeRepository(LikeContext context)
        {
            _context = context;
        }
        public async Task<int> CountLikeByComment(int commentId)
        {
           return await _context.Likes.Where(l => l.CommentId == commentId && l.ContentType == "comment").CountAsync();
        }

        public async Task<int> CountLikeByPost(int postId)
        {
            return await _context.Likes.Where(l => l.PostId ==postId  && l.ContentType == "post").CountAsync();
        }

        public async Task CreateLike(LikeModel likeModel)
        {
            _context.Add(likeModel);
            await _context.SaveChangesAsync();  
        }

        public async Task DeleteLikeComment(int commentId, int userId)
        {
            var likeModel = this.FindLikeById(commentId, "comment", userId);
            
            _context.Remove(likeModel);
            await _context.SaveChangesAsync();  
        }

        public async Task<LikeModel?> FindLikeById(int id, string type, int userId)
        {

            if (type == "comment")
            {
                return await _context.Likes.Where(l=>l.CommentId==id && l.ContentType==type && l.UserId==userId).FirstOrDefaultAsync();
            }
            else
            {
                return await _context.Likes.Where(l => l.PostId == id && l.ContentType == type && l.UserId == userId).FirstOrDefaultAsync();
            }

        }

        public async Task DeleteLikePost(int postId, int userId)
        {
            var likeNodel = await this.FindLikeById(postId, "post", userId);
            if(likeNodel!=null)
            {
                _context.Remove(likeNodel);
                await _context.SaveChangesAsync();
            }
           
        }
    }
}
