namespace LynkerSocial_API.Models
{
    public class ApiResponse
    {
        public bool Succeded { get; set; } = false;
        public string Message { get; set; } = "";

        public static ApiResponse Failure(string message)
        {
            return new ApiResponse()
            {
                Message = message
            };
        }
    }
    public class ApiResponse<T> : ApiResponse
    {
        public T Data { get; set; }

        public static ApiResponse<T> Success(T data)
        {
            return new ApiResponse<T>()
            {
                Succeded = true,
                Data = data
            };
        }
    }
}