using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Application.Catalog.Books;
public class GetBookByIdRequest : IRequest<Book>
{
    public Guid Id { get; set; }
}
public class GetBookByIdRequestHandler : IRequestHandler<GetBookByIdRequest, Book>
{
    private readonly IReadRepository <Book> _repository;
    public GetBookByIdRequestHandler(IReadRepository<Book> repository) => _repository = repository;

    public async Task<Book> Handle(GetBookByIdRequest request, CancellationToken cancellationToken)
    {
        return await _repository.GetByIdAsync(request.Id) ?? throw new ConflictException("Book not found.");
    }
}
