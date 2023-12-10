﻿namespace WorldOfBooks.Application.Exceptions.Categories;

public class CategoryAlreadyExistsException : AlreadyExistsException
{
    public CategoryAlreadyExistsException()
    {
        TitleMessage = "User already exists";
    }
}
