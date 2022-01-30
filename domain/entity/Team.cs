using System;
using teamev.api.domain.value_object;
namespace teamev.api.domain.entity
{
  public class Team
  {
    public int Id { get; set; }
    public Guid PublicTeamId { get; set; }
    public TeamInfo TeamInfo { get; set; }
  }
}