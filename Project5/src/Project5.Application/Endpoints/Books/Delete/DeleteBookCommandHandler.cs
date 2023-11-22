using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Project5.Application.Interfaces.Persistence;
using Project5.Application.Interfaces.Persistence.DataServices.Books.Commands;
using Project5.Application.Models;
using Project5.Application.Endpoints.Books.Delete;
using Project5.Application.Models.Enumerations;
using Project5.Application.Interfaces.Persistence.DataServices.Books.Delete;

namespace Project5.Application.Endpoints.Books.Commands
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, EndpointResult>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IDeleteBookDataService _deleteBookDataService;

        public DeleteBookCommandHandler(IApplicationDbContext dbContext, IDeleteBookDataService deleteBookDataService)
        {
            _dbContext = dbContext;
            _deleteBookDataService = deleteBookDataService;
        }

        public async Task<EndpointResult> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var bookToDelete = await _dbContext.Books.FindAsync(request.Id);

            if (bookToDelete == null)
            {
                return new EndpointResult(EndpointResultStatus.NotFound, $"Book with ID {request.Id} not found.");
            }

            // You can use IDeleteBookDataService here for additional logic if needed
            await _deleteBookDataService.ExecuteAsync(bookToDelete, cancellationToken);

            _dbContext.Books.Remove(bookToDelete);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return new EndpointResult(EndpointResultStatus.Success, $"Book with ID {request.Id} deleted successfully.");
        }
    }
}
