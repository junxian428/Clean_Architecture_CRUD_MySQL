using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Project5.Application.Interfaces.Persistence.DataServices.Books.Updates;
using Project5.Application.Models;
using Project5.Domain.Entities;
using Newtonsoft.Json;

namespace Project5.Application.Endpoints.Books.Updates
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, EndpointResult<BookViewModel>>
    {
        private readonly IUpdateBookDataService _updateBookDataService;
        private readonly IMapper _mapper;

        public UpdateBookCommandHandler(IUpdateBookDataService updateBookDataService, IMapper mapper)
        {
            _updateBookDataService = updateBookDataService;
            _mapper = mapper;
        }

        public async Task<EndpointResult<BookViewModel>> Handle(UpdateBookCommand request, CancellationToken cancellationToken = default)
        {
            Console.WriteLine($"Original Request: {JsonConvert.SerializeObject(request)}");
            var bookToUpdate = _mapper.Map<Book>(request);
            Console.WriteLine($"Mapped Book: {JsonConvert.SerializeObject(bookToUpdate)}");
            var updatedBook = await _updateBookDataService.ExecuteAsync(bookToUpdate);


            //var updatedBook = await _updateBookDataService.ExecuteAsync(_mapper.Map<Book>(request));

            if (updatedBook != null)
            {
                Console.WriteLine("Book updated successfully.");

                return new EndpointResult<BookViewModel>(_mapper.Map<BookViewModel>(updatedBook));
            }
            else
            {
                Console.WriteLine("Update did not result in changes.");

                // Optionally, log the failure or perform other error handling
                return null; // or a specific error response indicating the failure
            }
        }

    }

}
