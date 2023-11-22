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
            var updatedBook = await _updateBookDataService.ExecuteAsync(_mapper.Map<Book>(request));
            return new EndpointResult<BookViewModel>(_mapper.Map<BookViewModel>(updatedBook));
        }
    }

}
