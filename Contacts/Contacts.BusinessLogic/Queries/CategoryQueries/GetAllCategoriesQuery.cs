namespace Contacts.BusinessLogic.Queries.CategoryQueries
{
    using Contacts.BusinessLogic.DTOs.CategoryDTOs;
    using MediatR;
    public record GetAllCategoriesQuery : IRequest<IEnumerable<CategoryDto>>;
}
