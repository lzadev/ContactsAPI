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

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var category = await _mediator.Send(new GetCategoryByIdQuery(id));
            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult> Add(CreateCategoryDto model)
        {
            var category = await _mediator.Send(new CreateCategoryCommand(model));
            return Ok(category);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteCategoryCommand(id));
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, UpdateCategoryDto model)
        {
            var result = await _mediator.Send(new UpdateCategoryCommand(id,model));
            return Ok(result);
        }
    }
}
