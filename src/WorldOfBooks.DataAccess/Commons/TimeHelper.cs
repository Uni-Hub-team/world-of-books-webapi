using WorldOfBooks.Domain.Constants;

namespace WorldOfBooks.DataAccess.Commons;

public class TimeHelper
{
    public static DateTime GetDateTime()
    {
        var time = DateTime.UtcNow;
        return time.AddHours(TimeConstant.UTC);
    }
}
