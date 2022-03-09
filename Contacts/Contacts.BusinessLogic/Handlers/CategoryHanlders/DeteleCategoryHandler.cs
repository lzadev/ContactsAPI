namespace Contacts.BusinessLogic.Handlers.CategoryHanlders
{
    using Contacts.BusinessLogic.ApiResponse;
    using Contacts.BusinessLogic.Commands.CategoryCommands;
    using Contacts.BusinessLogic.Exceptions;
    using Contacts.DataAccess.Repositories.Abstract;
    using MediatR;

    public class DeteleCategoryHandler : IRequestHandler<DeleteCategoryCommand, Response<string>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public DeteleCategoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Response<string>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetById(request.id);
            if (category == null) throw new NotFoundException($"A category with id {request.id} does not exist");

            var result = await _categoryRepository.Delete(category);
            if (result > 0) return Response.Ok<string>(null, "Category deleted successful.");
            throw new InternalErrorException("Something went wrong, try it again");
        }
    }
}
