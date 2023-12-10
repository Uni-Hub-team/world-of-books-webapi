namespace WorldOfBooks.Application.Exceptions.Categories;

public class SubCategoryAlreadyExistsException : AlreadyExistsException
{
    public SubCategoryAlreadyExistsException()
    {
        TitleMessage = "Sub Category already exists";
    }
}