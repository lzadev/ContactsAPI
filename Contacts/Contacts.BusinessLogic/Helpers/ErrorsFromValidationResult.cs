namespace Contacts.BusinessLogic.Helpers
{
    using Contacts.BusinessLogic.ApiResponse;
    using FluentValidation.Results;
    public static class ErrorsFromValidationResult
    {
        public static List<ErrorDetails> GetErrorsDetails(ValidationResult validationResult)
        {
            var errorsDetails = new List<ErrorDetails>();
            if (validationResult.Errors.Any())
            {
                foreach (var error in validationResult.Errors)
                {
                    errorsDetails.Add(new ErrorDetails { ErrorMessage = error.ErrorMessage });
                }
            }

            return errorsDetails;
        }
    }
}
