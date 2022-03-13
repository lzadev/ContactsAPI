namespace Contacts.BusinessLogic.Handlers.CategoryHanlders
{
    using AutoMapper;
    using Contacts.BusinessLogic.ApiResponse;
    using Contacts.BusinessLogic.Commands.CategoryCommands;
    using Contacts.BusinessLogic.DTOs.CategoryDTOs;
    using Contacts.BusinessLogic.Exceptions;
    using Contacts.DataAccess.Repositories.Abstract;
    using MediatR;

    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, Response<CategoryDto>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public UpdateCategoryHandler(ICategoryRepository categoryRepository,IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<Response<CategoryDto>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var model = request.model;

                if (model.Id != request.id) throw new BadRequestException("The id you send in the query no match with the id in the body");

                var categoryToUpdate = await _categoryRepository.GetById(request.id);
                if (categoryToUpdate == null) throw new NotFoundException($"Category with id {request.id} not found");

                categoryToUpdate.ModifiedAt = DateTime.UtcNow;
                categoryToUpdate.Name = request.model.Name;

                await _categoryRepository.Update(categoryToUpdate);

                var categoryToReturn = _mapper.Map<CategoryDto>(categoryToUpdate);

                return Response.Ok(categoryToReturn, "Category updated");
            }
            catch(BadRequestException ex)
            {
                throw ex;
            }
            catch (NotFoundException ex)
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
