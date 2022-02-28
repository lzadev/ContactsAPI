using Contacts.BusinessLogic.DTOs.CategoryDTOs;
using MediatR;

namespace Contacts.BusinessLogic.Commands.CategoryCommands
{
    public record CreateCategoryCommand(CreateCategoryDto model) : IRequest<CategoryDto>;
}
