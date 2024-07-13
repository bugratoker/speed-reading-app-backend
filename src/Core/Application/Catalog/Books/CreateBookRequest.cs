namespace FSH.WebApi.Application.Catalog.Books;
public class CreateBookRequest : IRequest<Guid>
{
    public required string Name { get; set; }
    public int CurrentChunkIndex { get; set; }
    public int TotalChunkCount { get; set; }
    public int WordIndex { get; set; }
    public Guid UserId { get; set; }
    public String PdfContent { get; set; }

}

public class CreateBookRequestValidator : CustomValidator<CreateBookRequest>
{
    public CreateBookRequestValidator(IReadRepository<Book> repository, IStringLocalizer<CreateBookRequestValidator> T) =>
        RuleFor(p => p.Name)
            .NotEmpty();
}

public class CreateBookRequestHandler : IRequestHandler<CreateBookRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Book> _repository;

    public CreateBookRequestHandler(IRepositoryWithEvents<Book> repository) => _repository = repository;

    public async Task<Guid> Handle(CreateBookRequest request, CancellationToken cancellationToken)
    {
        var book = new Book(request.Name, request.CurrentChunkIndex, request.WordIndex, request.UserId, Convert.FromBase64String(request.PdfContent), request.TotalChunkCount);

        await _repository.AddAsync(book, cancellationToken);

        return book.Id;
    }
}