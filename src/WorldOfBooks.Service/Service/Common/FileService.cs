using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using WorldOfBooks.Persistence.Helpers;
using WorldOfBooks.Service.Interfaces.Common;

namespace WorldOfBooks.Service.Service.Common;

public class FileService : IFileService
{
    private readonly string MEDIA = "Media";
    private readonly string BOOKS = "Books";
    private readonly string IMAGES = "Images";
    private readonly string ROOTPATH;

    public FileService(IWebHostEnvironment env)
    {
        ROOTPATH = env.WebRootPath;
    }
    public async Task<bool> DeleteAudioAsync(string subPath)
    {
        string path = Path.Combine(ROOTPATH, subPath);

        if (File.Exists(path))
        {
            await Task.Run(() =>
            {
                File.Delete(path);
            });

            return true;
        }

        return false;
    }

    public async Task<bool> DeleteBookAsync(string subPath)
    {
        string path = Path.Combine(ROOTPATH, subPath);

        if (File.Exists(path))
        {
            await Task.Run(() =>
            {
                File.Delete(path);
            });

            return true;
        }

        return false;
    }

    public async Task<bool> DeleteImageAsync(string subPath)
    {
        string path = Path.Combine(ROOTPATH, subPath);

        if (File.Exists(path))
        {
            await Task.Run(() =>
            {
                File.Delete(path);
            });

            return true;
        }

        return false;
    }

    public async Task<string> UploadAudioAsync(IFormFile audio, string rootPath)
    {
        string newAudioName = MediaHelper.MakeAudioName(audio.FileName);
        string subPath = Path.Combine(MEDIA, BOOKS, rootPath, newAudioName);
        string path = Path.Combine(ROOTPATH, subPath);
        var stream = new FileStream(path, FileMode.Create);
        await audio.CopyToAsync(stream);
        stream.Close();

        return subPath;
    }

    public async Task<string> UploadBookAsync(IFormFile book, string rootPath)
    {
        string newBookName = MediaHelper.MakeBookName(book.FileName);
        string subPath = Path.Combine(MEDIA, BOOKS, rootPath, newBookName);
        string path = Path.Combine(ROOTPATH, subPath);
        var stream = new FileStream(path, FileMode.CreateNew);
        await book.CopyToAsync(stream);
        stream.Close();

        return subPath;
    }

    public async Task<string> UploadImageAsync(IFormFile image, string rootPath)
    {
        string newImageName = MediaHelper.MakeImageName(image.FileName);
        string subPath = Path.Combine(MEDIA, IMAGES, rootPath, newImageName);
        string path = Path.Combine(ROOTPATH, subPath);
        var stream = new FileStream(path, FileMode.Create);
        await image.CopyToAsync(stream);
        stream.Close();

        return subPath;
    }
}
