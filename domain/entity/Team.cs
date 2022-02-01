using System;
using System.ComponentModel.DataAnnotations;
namespace teamev.api.domain.entity
{
  public class Team
  {
    public int Id { get; set; }
    public Guid PublicTeamId { get; set; }

    [Required(ErrorMessage = "team name is required")]
    public string Name { get; set; }

    [Required(ErrorMessage = "number is required")]
    public int Number { get; set; }

    public Team(string name, int number)
    {
      PublicTeamId = Guid.NewGuid();
      Name = name;
      Number = number;
    }
  }
}