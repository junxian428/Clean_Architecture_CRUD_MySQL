using System.Threading;
using System.Threading.Tasks;
using Project5.Application.Interfaces.Persistence;
using Project5.Application.Interfaces.Persistence.DataServices.Books.Delete;
using Project5.Domain.Entities;

namespace Project5.Infrastructure.Persistence.DataServices.Books.Commands
{
    public class DeleteBookDataService : IDeleteBookDataService
    {
        private readonly IApplicationDbContext _dbContext;

        public DeleteBookDataService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task ExecuteAsync(Book book, CancellationToken cancellationToken = default)
        {
            // Perform any additional logic or validation before deletion

            // Remove the book from the database
            _dbContext.Books.Remove(book);

            // Save changes to the database
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
