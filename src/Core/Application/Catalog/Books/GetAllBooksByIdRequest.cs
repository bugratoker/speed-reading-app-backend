using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Application.Catalog.Books;
public class GetAllBooksByIdRequest : IRequest<List<BookDto>>
{
    public Guid UserId { get; set; }
}
public class GetAllBooksByIdRequestHandler : IRequestHandler<GetAllBooksByIdRequest, List<BookDto>>
{
    private readonly IReadRepository<Book> _repository;

    public GetAllBooksByIdRequestHandler(IReadRepository<Book> repository) => _repository = repository;

    public async Task<List<BookDto>> Handle(GetAllBooksByIdRequest request, CancellationToken cancellationToken)
    {
        var spec = new BooksByUserIdSpec(request.UserId);
        return await _repository.ListAsync(spec, cancellationToken);
    }
}