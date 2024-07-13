using FSH.WebApi.Application.Common.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Application.Catalog.Books;
public class UpdateBookIndexRequest : IRequest<bool>
{
    public Guid Id { get; set; }
    public int CurrentChunkIndex { get; set; }
    public int WordIndex { get; set; }
}
public class UpdateBookIndexRequestHandler : IRequestHandler<UpdateBookIndexRequest, bool>
{
    private readonly IRepositoryWithEvents<Book> _repository;
    public UpdateBookIndexRequestHandler(IRepositoryWithEvents<Book> repository) => _repository = repository;

    public async Task<bool> Handle(UpdateBookIndexRequest request, CancellationToken cancellationToken)
    {
        Book book = await _repository.GetByIdAsync(request.Id, cancellationToken) ?? throw new ConflictException("User not found");
        book.CurrentChunkIndex = request.CurrentChunkIndex;
        book.WordIndex = request.WordIndex;
        await _repository.UpdateAsync(book, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);
        return true;
    }
}