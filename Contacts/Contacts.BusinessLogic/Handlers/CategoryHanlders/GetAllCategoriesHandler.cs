namespace Contacts.BusinessLogic.Handlers.CategoryHanlders
{
    using AutoMapper;
    using Contacts.BusinessLogic.ApiResponse;
    using Contacts.BusinessLogic.DTOs.CategoryDTOs;
    using Contacts.BusinessLogic.Exceptions;
    using Contacts.BusinessLogic.Queries.CategoryQueries;
    using Contacts.DataAccess.Repositories.Abstract;
    using MediatR;

    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, Response<IEnumerable<CategoryDto>>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetAllCategoriesHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<Response<IEnumerable<CategoryDto>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var categories = await _categoryRepository.GetAll();
                var categoriesToReturn = _mapper.Map<IEnumerable<CategoryDto>>(categories);

                return Response.Ok(categoriesToReturn);
            }
            catch (Exception ex)
            {
                throw new InternalErrorException(ex.Message);
            }
        }
    }
}
