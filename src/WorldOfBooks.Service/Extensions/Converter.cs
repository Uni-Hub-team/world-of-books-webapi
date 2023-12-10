using Microsoft.AspNetCore.Http;

namespace WorldOfBooks.Service.Service.Extensions;

public static class Converter
{
    public static byte[] ToByte(this IFormFile formFile)
    {
        using var memoryStream = new MemoryStream();
        formFile.CopyTo(memoryStream);
        return memoryStream.ToArray();
    }
}