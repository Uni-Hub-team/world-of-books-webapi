using Microsoft.AspNetCore.Http;

namespace WorldOfBooks.Service.Interfaces.Common;

public interface IFileService
{
    public Task<string> UploadImageAsync(IFormFile image, string rootPath);
    public Task<bool> DeleteImageAsync(string subPath);

    public Task<string> UploadBookAsync(IFormFile book, string rootPath);
    public Task<bool> DeleteBookAsync(string subPath);

    public Task<string> UploadAudioAsync(IFormFile audio, string rootPath);
    public Task<bool> DeleteAudioAsync(string subPath);
}
