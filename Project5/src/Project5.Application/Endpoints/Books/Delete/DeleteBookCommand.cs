using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Project5.Application.Models;


namespace Project5.Application.Endpoints.Books.Delete
{
    public class DeleteBookCommand : IRequest<EndpointResult>
    {
        public int Id { get; set; }
    }
}
