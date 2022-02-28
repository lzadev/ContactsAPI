namespace Contacts.BusinessLogic.Handlers.CategoryHanlders
{
    using AutoMapper;
    using Contacts.BusinessLogic.DTOs.CategoryDTOs;
    using Contacts.BusinessLogic.Queries.CategoryQueries;
    using Contacts.DataAccess.Repositories.Abstract;
    using MediatR;

    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<CategoryDto>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetAllCategoriesHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CategoryDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAll();

            return _mapper.Map<IEnumerable<CategoryDto>>(categories);
        }
    }
}
