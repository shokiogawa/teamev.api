using System;
using teamev.api.domain.value_object;
namespace teamev.api.domain.entity
{
  public class Objective
  {
    public int Id { get; set; }
    public Guid PublicObjectiveId { get; set; }
    public DateTime CreatedDate { get; set; }

    public ObjectiveInfo objectiveInfo { get; set; }
  }
}