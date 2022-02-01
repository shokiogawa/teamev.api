using System;
using System.Globalization;
using System.ComponentModel.DataAnnotations;
using teamev.api.domain.value_object;
namespace teamev.api.domain.entity
{
  public class Objective
  {
    public int Id { get; set; }

    public Guid PublicObjectiveId { get; set; }

    [Required(ErrorMessage = "date time is required")]
    public DateTime CreatedDate { get; set; }
    [Required(ErrorMessage = "objective info is required")]
    public ObjectiveInfo ObjectiveInfo { get; set; }

    public Objective(ObjectiveInfo objectiveInfo)
    {
      PublicObjectiveId = Guid.NewGuid();
      CreatedDate = DateTime.Now;
      ObjectiveInfo = objectiveInfo;
    }
  }
}