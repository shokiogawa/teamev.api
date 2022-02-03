using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace teamev.api.infrastructure.db.table
{
  public class users
  {
    [Key]
    public int id { get; set; }
    [Required]
    [Column(TypeName = "char(36)")]
    public Guid publicUserId { get; set; }
    [Required]
    public string email { get; set; }
    [Required]

    public string password { get; set; }
    [Required]

    public string name { get; set; }
    [Required]

    public STATUS status { get; set; }
  }

  public enum STATUS
  {
    Leader,
    Member,
  }
}