namespace WorldOfBooks.Persistence.Helpers;

public class MediaHelper
{
    //Image
    public static string MakeImageName(string fileName)
    {
        FileInfo file = new FileInfo(fileName);
        string extension = file.Extension;
        string name = "IMG_" + Guid.NewGuid() + extension;

        return name;
    }

    public static string[] GetImageExtensions()
    {
        return new string[]
        {
            //Jpg files
            ".jpg", ".jpeg",
            //Png files
            ".png",
            //Bmo files 
            ".bmp",
            //svg files 
            ".svg"
        };
    }
    //Audio
    public static string MakeAudioName(string fileName)
    {
        FileInfo file = new FileInfo(fileName);
        string extension = file.Extension;
        string name = "Audio_" + Guid.NewGuid() + extension;

        return name;
    }

    public static string[] GetAudioExtensions()
    {
        return new string[]
        {
            //Jpg files
            ".mp3", ".wav",".aac",".ogg",".wma"
        };
    }
    //book
    public static string MakeBookName(string fileName)
    {
        FileInfo file = new FileInfo(fileName);
        string extension = file.Extension;
        string name = "BOOK_" + Guid.NewGuid() + extension;

        return name;
    }

    public static string[] GetBookExtensions()
    {
        return new string[]
        {
            ".pdf", 
            ".epub",
            ".doc",
            ".docx"
        };
    }
}
