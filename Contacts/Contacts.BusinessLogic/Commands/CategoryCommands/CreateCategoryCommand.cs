namespace Contacts.BusinessLogic.Commands.CategoryCommands
{
    using Contacts.BusinessLogic.ApiResponse;
    using Contacts.BusinessLogic.DTOs.CategoryDTOs;
    using MediatR;

    public record CreateCategoryCommand(CreateCategoryDto model) : IRequest<Response<CategoryDto>>;
}
