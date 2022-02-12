using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace teamev.api.domain.entity
{
  public class Team
  {
    [Key]
    public int Id { get; set; }

    [Column(TypeName = "char(36)")]
    public Guid PublicTeamId { get; set; }

    [Required]
    public int UserId { get; set; }

    [Required(ErrorMessage = "team name is required")]
    public string Name { get; set; }

    [Required(ErrorMessage = "number is required")]
    public int Number { get; set; }

    public Team(int userId, string name, int number)
    {
      PublicTeamId = Guid.NewGuid();
      UserId = userId;
      Name = name;
      Number = number;
    }
  }
}