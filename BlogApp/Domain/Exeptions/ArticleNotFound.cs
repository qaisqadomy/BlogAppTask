namespace Domain.Exeptions;

/// <summary>
/// Represents an exception that is thrown when an article cannot be found.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="ArticleNotFound"/> class with a specified error message.
/// </remarks>
/// <param name="msg">The message that describes the error.</param>
public class ArticleNotFound(string msg) : NotFound(msg)
{
}
