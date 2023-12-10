namespace WorldOfBooks.Application.Exceptions.Categories;

public class CategoryNotFoundException : NotFoundException
{
    public CategoryNotFoundException()
    {
        this.TitleMessage = "User not found";
    }
}
