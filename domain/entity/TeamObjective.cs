using System;
using System.Globalization;
using System.ComponentModel.DataAnnotations;
using teamev.api.domain.value_object;
using System.ComponentModel.DataAnnotations.Schema;
namespace teamev.api.domain.entity
{
  public class TeamObjective
  {
    [Key]
    public int Id { get; }

    [Column(TypeName = "char(36)")]
    public Guid PublicObjectiveId { get; }

    [Required]
    public int TeamId { get; }

    [Required(ErrorMessage = "date time is required")]
    public DateTime CreatedDate { get; }

    [Required]
    public ObjectiveInfo ObjectiveInfo { get; }

    public TeamObjective(int teamId, ObjectiveInfo objectiveInfo)
    {
      this.PublicObjectiveId = Guid.NewGuid();
      this.TeamId = teamId;
      this.CreatedDate = DateTime.Now;
      this.ObjectiveInfo = objectiveInfo;
    }
  }
}