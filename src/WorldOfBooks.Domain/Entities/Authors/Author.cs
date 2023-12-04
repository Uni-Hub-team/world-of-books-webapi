using WorldOfBooks.Domain.Commons;

namespace WorldOfBooks.Domain.Entities.Authors;

public class Author : Auditable
{
    public string FullName { get; set; } = string.Empty;
    public string Birthday { get; set; } = string.Empty;
    public string BirthdayCountry {  get; set; } = string.Empty;
    public string Description {  get; set; } = string.Empty;
    public string ImagePath {  get; set; } = string.Empty;
}
