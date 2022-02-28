namespace Contacts.BusinessLogic.Handlers.CategoryHanlders
{
    using AutoMapper;
    using Contacts.BusinessLogic.Commands.CategoryCommands;
    using Contacts.BusinessLogic.DTOs.CategoryDTOs;
    using Contacts.DataAccess.Repositories.Abstract;
    using Contacts.Domain.Entities;
    using MediatR;
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, CategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CreateCategoryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<CategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(request.model);
            var categoryCreated = await _categoryRepository.Add(category);

            return _mapper.Map<CategoryDto>(categoryCreated); 
        }
    }
}
