using WorldOfBooks.Domain.Commons;

namespace WorldOfBooks.Persistence.ViewModels.Authors;

public class AuthorResult : Auditable
{
    public string FullName { get; set; } = string.Empty;
    public string Birthday { get; set; } = string.Empty;
    public string BirthdayCountry { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImagePath {  get; set; } = string.Empty;
}