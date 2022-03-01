namespace Contacts.BusinessLogic.Helpers
{
    using Contacts.BusinessLogic.ApiResponse;
    using FluentValidation.Results;
    public static class ErrorsFromValidationResult
    {
        public static List<ErrorDetails> GetErrorsDetails(IEnumerable<ValidationFailure> errors)
        {
            var errorsDetails = new List<ErrorDetails>();
            if (errors.Any())
            {
                foreach (var error in errors)
                {
                    errorsDetails.Add(new ErrorDetails { ErrorMessage = error.ErrorMessage });
                }
            }

            return errorsDetails;
        }
    }
}
