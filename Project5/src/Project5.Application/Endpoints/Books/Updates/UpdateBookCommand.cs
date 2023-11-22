using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Project5.Application.Models;

namespace Project5.Application.Endpoints.Books.Updates
{
    public class UpdateBookCommand : IRequest<EndpointResult<BookViewModel>>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
    }

}
