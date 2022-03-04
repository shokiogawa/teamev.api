using System;
using System.Globalization;
using System.ComponentModel.DataAnnotations;
using teamev.api.domain.value_object;
using System.ComponentModel.DataAnnotations.Schema;
namespace teamev.api.domain.entity
{
  public class UserObjective
  {
    [Key]
    public int Id { get; set; }

    [Column(TypeName = "char(36)")]
    public Guid PublicObjectiveId { get; set; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public int TeamId { get; set; }

    [Required(ErrorMessage = "date time is required")]
    public DateTime CreatedDate { get; set; }

    [Required]
    public ObjectiveInfo ObjectiveInfo { get; set; }

    public UserObjective(int userId, int teamId, ObjectiveInfo objectiveInfo)
    {
      this.PublicObjectiveId = Guid.NewGuid();
      this.UserId = userId;
      this.TeamId = teamId;
      this.CreatedDate = DateTime.Now;
      this.ObjectiveInfo = objectiveInfo;
    }
  }
}