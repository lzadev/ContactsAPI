namespace Contacts.BusinessLogic.Validators
{
    using Contacts.BusinessLogic.DTOs.CategoryDTOs;
    using FluentValidation;
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryDto>
    {
        public CreateCategoryValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("Category name is required")
                .MaximumLength(100)
                .WithMessage("Category name is exceding the maximun caracters allowed");
        }
    }
}
