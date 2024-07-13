using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Application.Catalog.Books;
public class DeleteBookByIdRequest : IRequest<bool>
{
    public Guid Id { get; set; }
}
public class DeleteBookByIdRequestHandler : IRequestHandler<DeleteBookByIdRequest, bool>
{
    private readonly IRepositoryWithEvents<Book> _repository;
    public DeleteBookByIdRequestHandler(IRepositoryWithEvents<Book> repository) => _repository = repository;

    public async Task<bool> Handle(DeleteBookByIdRequest request, CancellationToken cancellationToken)
    {
        Book? book = await _repository.GetByIdAsync(request.Id, cancellationToken);
        await _repository.DeleteAsync(book!, cancellationToken);
        return true;
    }
}
