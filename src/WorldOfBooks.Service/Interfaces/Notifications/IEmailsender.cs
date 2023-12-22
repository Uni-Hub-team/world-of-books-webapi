using WorldOfBooks.Persistence.Dtos;

namespace WorldOfBooks.Service.Interfaces.Notifications
{
    public interface IEmailSender
    {
        public Task<bool> SenderAsync(EmailSenderDto emailMessage);
    }
}
