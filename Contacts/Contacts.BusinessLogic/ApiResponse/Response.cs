namespace Contacts.BusinessLogic.ApiResponse
{
    public static class Response
    {
        public static Response<T> Fail<T>(List<ErrorDetails> errorsDetails, T data = default)
            => new Response<T>(data, errorsDetails, true);

        public static Response<T> Ok<T>(T data)
                => new Response<T>(data, null, false);
    }

    public class Response<T>
    {
        public Response(T data, List<ErrorDetails> errorsDetails, bool errors)
        {
            Data = data;
            ErrorsDetails = errorsDetails;
            Errors = errors;
        }

        public T Data { get; set; }
        public bool Errors { get; set; }
        public List<ErrorDetails> ErrorsDetails { get; set; }
    }
}
