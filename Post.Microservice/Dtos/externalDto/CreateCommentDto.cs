

namespace Post.Microservice.Dtos.externalDto
{
    public class CreateCommentDto
    {
 
        public int UserId { get; set; }
        public int PostId { get; set; }
        public string Content { get; set; }
        public int? ContentParentId { get; set; }
    }
}
