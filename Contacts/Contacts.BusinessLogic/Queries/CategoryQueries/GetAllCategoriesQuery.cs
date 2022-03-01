namespace Contacts.BusinessLogic.Queries.CategoryQueries
{
    using Contacts.BusinessLogic.ApiResponse;
    using Contacts.BusinessLogic.DTOs.CategoryDTOs;
    using MediatR;
    public record GetAllCategoriesQuery : IRequest<Response<IEnumerable<CategoryDto>>>;
}
