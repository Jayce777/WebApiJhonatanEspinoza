namespace WebApiKnowlegde.DTO
{
    public class responseDTO
    {
        public bool success { get; set; }
        public string? message { get; set; }
        public object ? data { get; set; }
        public List<string> errors { get; set; }
        public responseDTO(bool success, string message, object data, List<string> errors)
        {
            this.success = success;
            this.message = message;
            this.data = data;
            this.errors = errors;
        }
    }
}
