using WorldOfBooks.Persistence.Dtos;

namespace WorldOfBooks.Service.Interfaces.Notifications;

public interface ISmsSender
{
    public Task<bool> SendAsync(SmsSenderDto message);
}
