namespace Contacts.Controllers
{
    using Contacts.BusinessLogic.Commands.CategoryCommands;
    using Contacts.BusinessLogic.DTOs.CategoryDTOs;
    using Contacts.BusinessLogic.Queries.CategoryQueries;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var categories = await _mediator.Send(new GetAllCategoriesQuery());
            return Ok(categories);
        }

        [HttpPost]
        public async Task<ActionResult> Add(CreateCategoryDto model)
        {
            var category = await _mediator.Send(new CreateCategoryCommand(model));
            return Ok(category);
        }
    }
}
