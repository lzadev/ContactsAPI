namespace Contacts.BusinessLogic.ApiResponse
{
    public static class Response
    {
        public static Response<T> Fail<T>(List<ErrorDetails> errorsDetails, string message = "", T data = default)
            => new Response<T>(data, errorsDetails, true,message);

        public static Response<T> Ok<T>(T data, string message = "")
                => new Response<T>(data, null, false,message);
    }

    public class Response<T>
    {
        public Response(T data, List<ErrorDetails> errorsDetails, bool errors, string message)
        {
            Data = data;
            ErrorsDetails = errorsDetails;
            Errors = errors;
            Message = message;
        }

        public T Data { get; set; }
        public bool Errors { get; set; }
        public List<ErrorDetails> ErrorsDetails { get; set; }
        public string Message { get; set; }
    }
}
