using DocumentFormat.OpenXml.Spreadsheet;
using FSH.WebApi.Application.Catalog.Books;
using FSH.WebApi.Application.Catalog.Brands;
using FSH.WebApi.Domain.Catalog;

namespace FSH.WebApi.Host.Controllers.Catalog;

public class BooksController : VersionedApiController
{
    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Books)]
    [OpenApiOperation("Create a new book.", "")]
    public Task<Guid> CreateAsync(CreateBookRequest request)
    {
        return Mediator.Send(request);
    }


    [HttpGet]
    [MustHavePermission(FSHAction.Search, FSHResource.Books)]
    [OpenApiOperation("Get list of books by id", "")]
    public Task<List<BookDto>> GetAllAsync([FromQuery] Guid userId)
    {
        var request = new GetAllBooksByIdRequest { UserId = userId };
        return Mediator.Send(request);
    }

    [HttpPut]
    [MustHavePermission(FSHAction.Update, FSHResource.Books)]
    [OpenApiOperation("Update a book.", "")]
    public Task<bool> UpdateAsync(UpdateBookIndexRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHAction.Search, FSHResource.Books)]
    [OpenApiOperation("Get book by id", "")]
    public Task<Book> GetByBookId(Guid id)
    {
        var request = new GetBookByIdRequest { Id = id};
        return Mediator.Send(request);
    }
    [HttpDelete]
    [MustHavePermission(FSHAction.Delete, FSHResource.Books)]
    [OpenApiOperation("delete book by id", "")]
    public Task<bool> DeleteByBookId([FromQuery] Guid id)
    {
        var request = new DeleteBookByIdRequest { Id = id };
        return Mediator.Send(request);
    }
}
