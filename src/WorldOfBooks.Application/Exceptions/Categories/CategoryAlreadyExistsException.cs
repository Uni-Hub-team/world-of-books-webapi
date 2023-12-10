namespace WorldOfBooks.Application.Exceptions.Categories;

public class CategoryAlreadyExistsException : AlreadyExistsException
{
    public CategoryAlreadyExistsException()
    {
        TitleMessage = "Category already exists";
    }
}
