using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Application.Catalog.Books;
public class BookDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int? CurrentChunkIndex { get; set; }
    public int? WordIndex { get; set; }
    public int? TotalChunkCount { get; set; }
}
