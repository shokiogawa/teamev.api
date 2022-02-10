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
    public int Id { get; set; }

    [Column(TypeName = "char(36)")]
    public Guid PublicObjectiveId { get; set; }

    [Required]
    public int TeamId { get; set; }

    [Required(ErrorMessage = "date time is required")]
    public DateTime CreatedDate { get; set; }

    [Required]
    public ObjectiveInfo ObjectiveInfo { get; set; }

    public TeamObjective(int teamId, ObjectiveInfo objectiveInfo)
    {
      this.PublicObjectiveId = Guid.NewGuid();
      this.TeamId = teamId;
      this.CreatedDate = DateTime.Now;
      this.ObjectiveInfo = objectiveInfo;
    }
  }
}