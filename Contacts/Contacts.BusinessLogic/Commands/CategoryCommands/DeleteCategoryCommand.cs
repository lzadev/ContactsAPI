using Contacts.BusinessLogic.ApiResponse;
using MediatR;

namespace Contacts.BusinessLogic.Commands.CategoryCommands
{
    public record DeleteCategoryCommand(int id) : IRequest<Response<string>>;
}
