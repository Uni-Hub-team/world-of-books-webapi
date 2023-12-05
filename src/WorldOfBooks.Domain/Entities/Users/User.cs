using WorldOfBooks.Domain.Commons;
using WorldOfBooks.Domain.Enums;

namespace WorldOfBooks.Domain.Entities.Users;

public class User : Auditable
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string Salt { get; set; } = string.Empty;
    public string ImagePath { get; set; } = string.Empty;
    public Gender Gender { get; set; }
    public Role Role { get; set; }
}
