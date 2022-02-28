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
    public int Id { get; }

    [Required]
    public string UserUid { get; }


    [Column(TypeName = "char(36)")]
    public Guid PublicUserId { get; set; }

    [Required(ErrorMessage = "name is required")]
    [EmailAddress(ErrorMessage = "this email is invalid")]
    public string Email { get; }

    [Required(ErrorMessage = "name is required")]
    public string Name { get; }

    public STATUS Status { get; }

    public User(string userUid, string name, string email)
    {
      if (userUid == null || name == null || email == null)
      {
        throw new Exception("user parameter is required");
      }
      this.PublicUserId = Guid.NewGuid();
      this.UserUid = userUid;
      this.Email = email;
      this.Name = name;
    }
  }
}