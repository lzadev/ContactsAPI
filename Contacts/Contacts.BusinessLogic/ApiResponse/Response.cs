namespace Contacts.BusinessLogic.ApiResponse
{
    public static class Response
    {
        public static Response<T> Fail<T>(int statusCode, List<ErrorDetails> errorsDetails, T data = default)
            => new Response<T>(data, statusCode, errorsDetails, true);

        public static Response<T> Ok<T>(T data, int statusCode)
                => new Response<T>(data, statusCode, null, true);
    }

    public class Response<T>
    {
        public Response(T data, int statusCode, List<ErrorDetails> errorsDetails, bool error)
        {
            Data = data;
            StatusCode = statusCode;
            ErrorsDetails = errorsDetails;
            Error = error;
        }

        public T Data { get; set; }
        public int StatusCode { get; set; }
        public bool Error { get; set; }
        public List<ErrorDetails> ErrorsDetails { get; set; }
    }
}
