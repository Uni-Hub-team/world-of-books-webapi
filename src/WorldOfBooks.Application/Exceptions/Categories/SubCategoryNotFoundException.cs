namespace WorldOfBooks.Application.Exceptions.Categories;

public class SubCategoryNotFoundException : NotFoundException
{
    public SubCategoryNotFoundException()
    {
        this.TitleMessage = "Sub Category not found";
    }
}