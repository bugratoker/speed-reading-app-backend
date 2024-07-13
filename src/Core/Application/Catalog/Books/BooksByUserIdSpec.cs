using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Application.Catalog.Books;
public class BooksByUserIdSpec : Specification<Book, BookDto>
{
    public BooksByUserIdSpec(Guid UserId)
    {
        Query.Where(b => b.UserId == UserId);

    }
}
