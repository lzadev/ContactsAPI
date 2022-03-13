namespace Contacts.BusinessLogic.Commands.CategoryCommands
{
    using Contacts.BusinessLogic.ApiResponse;
    using Contacts.BusinessLogic.DTOs.CategoryDTOs;
    using MediatR;

    public record UpdateCategoryCommand(int id, UpdateCategoryDto model) : IRequest<Response<CategoryDto>>;
}
