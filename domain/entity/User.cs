using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace teamev.api.domain.entity
{
  public enum STATUS
  {
    Leader,
    Member,
  }
  public class User
  {
    [Key]
    public int Id { get; set; }
    [Column(TypeName = "char(36)")]
    public Guid PublicUserId { get; set; }

    [Required(ErrorMessage = "name is required")]
    [EmailAddress(ErrorMessage = "this email is invalid")]
    public string Email { get; set; }

    [Required(ErrorMessage = "password is required")]
    public string Password { get; set; }

    [Required(ErrorMessage = "name is required")]
    public string Name { get; set; }

    [Required(ErrorMessage = "status is required")]
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