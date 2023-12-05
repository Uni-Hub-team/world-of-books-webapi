﻿using WorldOfBooks.Domain.Commons;
using WorldOfBooks.Domain.Entities.Authors;
using WorldOfBooks.Domain.Entities.Categories;

namespace WorldOfBooks.Domain.Entities.Books;

public class Book : Auditable
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Path { get; set; } = string.Empty;
    public string AudioPath { get; set; } = string.Empty;

    public long CategoryId { get; set; }
    public Category? Category { get; set; }

    public long SubCategoryId { get; set; }
    public SubCategory? SubCategory {  get; set; }

    public long AuthorId { get; set; }
    public Author? Author {  get; set; }
}
