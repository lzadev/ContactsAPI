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
            try
            {
                var categoryToDelete = await _categoryRepository.GetById(request.id);

                if (categoryToDelete == null || categoryToDelete.IsDeleted || !categoryToDelete.IsActive) 
                    throw new NotFoundException($"A category with id {request.id} does not exist");

                categoryToDelete.IsDeleted = true;
                categoryToDelete.IsActive = false;
                categoryToDelete.DeletedAt = DateTime.UtcNow;

                await _categoryRepository.Update(categoryToDelete);
                return Response.Ok<string>(null, "Category deleted successful.");
            }
            catch(NotFoundException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new InternalErrorException("Something went wrong, try it again");
            }
        }
    }
}
