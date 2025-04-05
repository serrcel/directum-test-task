using Directum.Backend.Core.Common;

namespace Directum.Backend.Core.Entities;

public class Post: BaseEntity
{
    public string Author { get; private set; }
    public string Content { get; private set; }
    public string Preview { get; private set; }

    public Post(string author, string content, string preview)
    {
        Author = author;
        Content = content;
        Preview = preview;
    }

    public int DaysAgo() => (DateTime.UtcNow - CreatedAt).Days;
    public int DaysAgoRelativeTo(DateTime date) => (date - CreatedAt).Days;
}