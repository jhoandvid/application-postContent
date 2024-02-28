namespace comment.microservice.Dtos
{
    public class CommentParents
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }

        public string? Content { get; set; }
        public bool IsActive { get; set; }
    }
}
