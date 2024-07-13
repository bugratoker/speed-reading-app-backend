using System.ComponentModel.DataAnnotations.Schema;

namespace FSH.WebApi.Domain.Catalog;
public class Book : AuditableEntity, IAggregateRoot
{
    public string Name { get; set; }
    public int CurrentChunkIndex { get; set; }
    public int? TotalChunkCount { get; set; }
    public int WordIndex { get; set; }
    public Guid UserId { get; set; }
    [Column(TypeName = "bytea")]
    public byte[]? PdfContent { get; set; }

    public Book(string name, int currentChunkIndex, int wordIndex, DefaultIdType userId, byte[]? pdfContent, int? totalChunkCount)
    {
        Name = name;
        CurrentChunkIndex = currentChunkIndex;
        WordIndex = wordIndex;
        UserId = userId;
        PdfContent = pdfContent;
        TotalChunkCount = totalChunkCount;
    }
}
