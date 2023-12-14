using WorldOfBooks.Domain.Commons;

namespace WorldOfBooks.Persistence.ViewModels.Books;

public class BookSourceResult : Auditable
{
    public string SourcePath { get; set; } = string.Empty;
}
