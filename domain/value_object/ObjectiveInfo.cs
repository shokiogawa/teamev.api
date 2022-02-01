using System;
using System.ComponentModel.DataAnnotations;
namespace teamev.api.domain.value_object
{
  public class ObjectiveInfo
  {
    [Required(ErrorMessage = "title is required")]
    [StringLength(100, ErrorMessage = "Max length of title is 100")]
    public string Title { get; private set; }

    [Required(ErrorMessage = "content is required")]
    [StringLength(500, ErrorMessage = "Max length of content is 500")]
    public string Content { get; private set; }

    [Required(ErrorMessage = "auther is required")]
    public string Author { get; private set; }

    public ObjectiveInfo(string title, string content, string author)
    {
      Title = title;
      Content = content;
      Author = author;
    }
  }
}