using WorldOfBooks.Persistence.Dtos;

namespace WorldOfBooks.Service.Interfaces.Notifications
{
    public interface IEmailsender
    {
        public Task<bool> SenderAsync(EmailSenderDto emailMessage);
    }
}
