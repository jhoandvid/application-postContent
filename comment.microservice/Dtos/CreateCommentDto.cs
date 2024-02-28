using comment.microservice.Model;

namespace comment.microservice.Dtos
{
    public class CreateCommentDto
    {
 
        public int? UserId { get; set; }
        public int PostId { get; set; }
        public string Content { get; set; }
        public int? ContentParentId { get; set; }=null;
    }
}
