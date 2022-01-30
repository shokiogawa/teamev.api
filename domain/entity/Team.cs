using System;
namespace teamev.api.domain.entity
{
  public class Team
  {
    public int Id { get; set; }
    public Guid PublicTeamId { get; set; }
    public string Name { get; set; }
    public int Number { get; set; }

    public Team(string name, int number)
    {
      PublicTeamId = Guid.NewGuid();
      Name = name;
      Number = number;
    }
  }
}