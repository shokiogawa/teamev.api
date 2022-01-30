using System;
namespace teamev.api.domain.entity
{
  public enum STATUS
  {
    Leader,
    Member,
  }
  public class User
  {
    public int Id { get; set; }
    public Guid PublicUserId { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public STATUS status { get; set; }
  }
}