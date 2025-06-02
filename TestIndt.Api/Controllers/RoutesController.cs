using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestIndt.Application.Commands.RouteModule.Command;
using TestIndt.Application.Queries.RouteModule.Query;

namespace TestIndt.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoutesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoutesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoute([FromBody] CreateRouteCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(command);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRouteById(int id)
        {
            var query = new GetRouteByIdQuery { Id = id };
            var result = await _mediator.Send(query);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetPaginated([FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string? search = null)
        {
            var query = new GetRoutesPaginateQuery(page, pageSize, search);
            var result = await _mediator.Send(query);
            return Ok(result);  
        }

        [HttpGet("active")]
        public async Task<IActionResult> GetActiveRoutes()
        {
            var result = await _mediator.Send(new GetActiveRoutesQuery());
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoute(int id, [FromBody] UpdateRouteCommand command)
        {
            if (id != command.Id)
                return BadRequest("Id na URL não corresponde ao body.");

            var result = await _mediator.Send(command);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);        
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoute(int id)
        {
            var command = new DeleteRouteCommand { Id = id };
            var result = await _mediator.Send(command);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
