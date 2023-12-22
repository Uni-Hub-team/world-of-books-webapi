namespace WorldOfBooks.Persistence.Validations;

public class EmailValidator
{
    public static bool IsValid(string email)
    {
        try
        {
            if (!email.Contains('@')) return false;
            if (!email.Contains('.')) return false;

            return true;
        }
        catch
        {
            return false;
        }

    }
}
