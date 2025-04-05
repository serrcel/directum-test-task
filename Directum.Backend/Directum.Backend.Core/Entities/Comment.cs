using Directum.Backend.Core.Common;

namespace Directum.Backend.Core.Entities;

public class Comment: BaseEntity
{
    public string Author { get; private set; }
    public string Content { get; private set; }

    public Comment(string author, string content)
    {
        Author = author;
        Content = content;
    }

    public int DaysAgo() => (DateTime.UtcNow - CreatedAt).Days;
}