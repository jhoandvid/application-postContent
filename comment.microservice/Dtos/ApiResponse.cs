namespace comment.microservice.Dtos
{
    public class ApiResponse
    {
        public bool IsSuccess { get; set; }
        public string Messague { get; set; }
        public object? Result { get; set; }
    }
}
