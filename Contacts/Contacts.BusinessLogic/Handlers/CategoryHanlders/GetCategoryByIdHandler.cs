namespace Contacts.BusinessLogic.Handlers.CategoryHanlders
{
    using AutoMapper;
    using Contacts.BusinessLogic.ApiResponse;
    using Contacts.BusinessLogic.DTOs.CategoryDTOs;
    using Contacts.BusinessLogic.Exceptions;
    using Contacts.BusinessLogic.Queries.CategoryQueries;
    using Contacts.DataAccess.Repositories.Abstract;
    using MediatR;

    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, Response<CategoryDto>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoryByIdHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<Response<CategoryDto>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var category = await _categoryRepository.GetById(request.id);
                if (category == null || category.IsDeleted == true || !category.IsActive) throw new NotFoundException($"A category with id {request.id} does not exist");
                var categoryToReturn = _mapper.Map<CategoryDto>(category);

                return Response.Ok(categoryToReturn);
            }
            catch(NotFoundException ex)
            {
                throw ex;
            }
            catch(Exception ex)
            {
                throw new InternalErrorException("Something went wrong, try it again");
            }

        }
    }
}
