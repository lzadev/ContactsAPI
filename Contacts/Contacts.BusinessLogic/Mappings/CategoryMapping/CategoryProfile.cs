namespace Contacts.BusinessLogic.Mappings.CategoryMapping
{
    using AutoMapper;
    using Contacts.BusinessLogic.DTOs.CategoryDTOs;
    using Contacts.Domain.Entities;
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
            CreateMap<CreateCategoryDto, Category>();
        }
    }
}
