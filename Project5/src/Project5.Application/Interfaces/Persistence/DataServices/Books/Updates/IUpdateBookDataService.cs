using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project5.Domain.Entities;

namespace Project5.Application.Interfaces.Persistence.DataServices.Books.Updates
{
    public interface IUpdateBookDataService
    {
        Task<Book> ExecuteAsync(Book book);
    }
}
