namespace like.microservice.Model
{
    public class LikeModel
    {
        public int Id { get; set; } 
        public int UserId { get; set; }
        public int? PostId { get; set; }
        public int? CommentId { get; set; }
        public string ContentType { get; set; } 
        public DateTime CreatedAt{ get; set; }
    }
}
