using System;
namespace teamev.api.domain.value_object
{
  public class ObjectiveInfo : ValueObject
  {
    public string Title { get; private set; }
    public string Content { get; private set; }
    public string Author { get; private set; }

    public ObjectiveInfo(string title, string content, string author)
    {
      if (title.Length < 100)
      {
        throw new ArgumentOutOfRangeException(nameof(title));
      }
      if (content.Length < 500)
      {
        throw new ArgumentOutOfRangeException(nameof(content));
      }
      if (author.Length == null)
      {
        throw new ArgumentOutOfRangeException(nameof(author));
      }
      Title = title;
      Content = content;
      Author = author;
    }
  }
}