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
    public STATUS Status { get; set; }

    public User(string email, string password, string name, STATUS status)
    {
      PublicUserId = Guid.NewGuid();
      Email = email;
      Password = password;
      Name = name;
      Status = status;
    }
  }
}