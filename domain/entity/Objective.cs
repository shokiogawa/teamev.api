using System;
using System.Globalization;
using System.ComponentModel.DataAnnotations;
using teamev.api.domain.value_object;
using System.ComponentModel.DataAnnotations.Schema;
namespace teamev.api.domain.entity
{
  public class Objective
  {
    [Key]
    public int Id { get; set; }
    [Column(TypeName = "char(36)")]

    public Guid PublicObjectiveId { get; set; }

    [Required(ErrorMessage = "date time is required")]
    public DateTime CreatedDate { get; set; }
    public ObjectiveInfo ObjectiveInfo { get; set; }

    public Objective(ObjectiveInfo objectiveInfo)
    {
      PublicObjectiveId = Guid.NewGuid();
      CreatedDate = DateTime.Now;
      ObjectiveInfo = objectiveInfo;
    }
  }
}