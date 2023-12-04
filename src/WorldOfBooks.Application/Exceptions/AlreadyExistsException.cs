using System.Net;

namespace WorldOfBooks.Application.Exceptions;

public class AlreadyExistsException : ClientException
{
    public override HttpStatusCode StatusCode { get; } = HttpStatusCode.Conflict;
    public override string TitleMessage { get; protected set; } = String.Empty;
}
