namespace Contacts.BusinessLogic.Filters
{
    using Contacts.BusinessLogic.ApiResponse;
    using Contacts.BusinessLogic.Exceptions;
    using Contacts.BusinessLogic.Helpers;
    using FluentValidation;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    public class GlobalExepctionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exceptionType = context.Exception.GetType();
            var errors = new List<ErrorDetails>();
            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = (int)StatusCodes.Status500InternalServerError;


            if (exceptionType == typeof(ValidationException))
            {
                var exception = (ValidationException)context.Exception;
                var errorsDetails = ErrorsFromValidationResult.GetErrorsDetails(exception.Errors);
                context.Result = new ObjectResult(Response.Fail<ErrorDetails>(errorsDetails));
                context.HttpContext.Response.StatusCode = (int)StatusCodes.Status400BadRequest;
                context.ExceptionHandled = true;
                return;
            }

            if (exceptionType == typeof(NotFoundException))
            {
                var exception = (NotFoundException)context.Exception;
                errors.Add(new ErrorDetails { ErrorMessage = exception.Message });
                context.Result = new ObjectResult(Response.Fail<ErrorDetails>(errors));
                context.HttpContext.Response.StatusCode = (int)StatusCodes.Status400BadRequest;
                context.ExceptionHandled = true;
                return;
            }

            if (exceptionType == typeof(BadRequestException))
            {
                var exception = (BadRequestException)context.Exception;
                errors.Add(new ErrorDetails { ErrorMessage = exception.Message });
                context.Result = new ObjectResult(Response.Fail<ErrorDetails>(errors));
                context.HttpContext.Response.StatusCode = (int)StatusCodes.Status400BadRequest;
                context.ExceptionHandled = true;
                return;
            }

            if (exceptionType == typeof(InternalErrorException))
            {
                var exception = (InternalErrorException)context.Exception;
                errors.Add(new ErrorDetails { ErrorMessage = exception.Message });
                context.Result = new ObjectResult(Response.Fail<ErrorDetails>(errors));
                context.ExceptionHandled = true;
                return;
            }


            //UnKnown Exception
            errors.Add(new ErrorDetails { ErrorMessage = context.Exception.Message });
            context.Result = new ObjectResult(Response.Fail<ErrorDetails>(errors));
            context.ExceptionHandled = true;

        }

    }
}
