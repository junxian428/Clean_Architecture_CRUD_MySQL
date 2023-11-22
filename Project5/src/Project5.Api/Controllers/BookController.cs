using System.Diagnostics.CodeAnalysis;
using Project5.Api.Extensions;
using Project5.Application.Endpoints.Books.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project5.Application.Endpoints.Books.Commands;
using Project5.Application.Endpoints.Books.Updates;
using Project5.Application.Endpoints.Books.Delete;

namespace Project5.Api.Controllers
{
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Route("api/v{version:apiVersion}/books")]
    [ApiVersion("1.0")]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetBooksAsync([FromQuery] BookQuery request) =>
            (await _mediator.Send(request)).ToActionResult();

        [HttpPost]
        public async Task<ActionResult> AddBookAsync([FromBody] AddBookCommand command) =>
            (await _mediator.Send(command)).ToActionResult();

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBookAsync(int id, [FromBody] UpdateBookCommand command)
        {
            command.Id = id;
            return (await _mediator.Send(command)).ToActionResult();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBookAsync(int id)
        {
            var command = new DeleteBookCommand { Id = id };
            return (await _mediator.Send(command)).ToActionResult();
        }


    }
}
