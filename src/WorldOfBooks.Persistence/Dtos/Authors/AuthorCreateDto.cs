using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldOfBooks.Persistence.Dtos.Authors;

public class AuthorCreateDto
{
    public string FullName { get; set; } = string.Empty;
    public string Birthday { get; set; } = string.Empty;
    public string BirthdayCountry { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public IFormFile? Images { get; set; } = default;
}
