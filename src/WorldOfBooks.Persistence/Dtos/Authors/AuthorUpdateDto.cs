﻿namespace WorldOfBooks.Persistence.Dtos.Authors;

public class AuthorUpdateDto
{
    public string FullName { get; set; } = string.Empty;
    public string Birthday { get; set; } = string.Empty;
    public string BirthdayCountry { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
