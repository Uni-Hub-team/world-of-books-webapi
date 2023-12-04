using System.Reflection;
using WorldOfBooks.Domain.Enums;

namespace WorldOfBooks.Persistence.Dtos.User;

public class UserUpdateDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public Gender Gender { get; set; }
}
