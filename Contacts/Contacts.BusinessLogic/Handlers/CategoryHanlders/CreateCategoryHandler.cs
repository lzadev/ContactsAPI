namespace Contacts.BusinessLogic.Handlers.CategoryHanlders
{
    using AutoMapper;
    using Contacts.BusinessLogic.ApiResponse;
    using Contacts.BusinessLogic.Commands.CategoryCommands;
    using Contacts.BusinessLogic.DTOs.CategoryDTOs;
    using Contacts.BusinessLogic.Helpers;
    using Contacts.BusinessLogic.Validators;
    using Contacts.DataAccess.Repositories.Abstract;
    using Contacts.Domain.Entities;
    using MediatR;
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, Response<CategoryDto>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CreateCategoryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<Response<CategoryDto>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var createCategoryValidator = new CreateCategoryValidator();
            var resultValidator = createCategoryValidator.Validate(request.model);
            if (!resultValidator.IsValid)
            {
                var errorsDetails = ErrorsFromValidationResult.GetErrorsDetails(resultValidator);
                return Response.Fail<CategoryDto>(400, errorsDetails);
            }

            var category = _mapper.Map<Category>(request.model);
            var categoryCreated = _mapper.Map<CategoryDto>(await _categoryRepository.Add(category));

            return Response.Ok(categoryCreated, 200);
        }
    }
}
