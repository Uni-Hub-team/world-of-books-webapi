using WorldOfBooks.Domain.Commons;

namespace WorldOfBooks.Persistence.ViewModels.Books;

public class BookAudioResult : Auditable
{
    public string AudioPath { get; set; } = string.Empty;
}
