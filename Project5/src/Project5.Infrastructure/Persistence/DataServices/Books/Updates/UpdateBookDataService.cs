using System.Threading;
using System.Threading.Tasks;
using Project5.Application.Interfaces.Persistence;
using Project5.Application.Interfaces.Persistence.DataServices.Books.Commands;
using Project5.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Project5.Application.Interfaces.Persistence.DataServices.Books.Updates;

namespace Project5.Infrastructure.Persistence.DataServices.Books.Commands
{
    public class UpdateBookDataService : IUpdateBookDataService
    {
        private readonly IApplicationDbContext _dbContext;

        public UpdateBookDataService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Book> ExecuteAsync(Book book)
        {
            var existingBook = await _dbContext.Books.FindAsync(book.Id);

            if (existingBook == null)
            {
                // Handle case where the book with the given ID is not found.
                // You might throw an exception or return null based on your requirements.
                return null;
            }

            // Update only non-null properties of the existing book with values from the provided book
            existingBook.Title = book.Title ?? existingBook.Title;
            existingBook.Author = book.Author ?? existingBook.Author;

            // Check for null or default value before updating Year
            if (book.Year != 0)
            {
                existingBook.Year = book.Year;
            }

            // Save changes to the database
            await _dbContext.SaveChangesAsync();

            return existingBook;
        }

    }
}
