using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace teamev.api.infrastructure.db.table
{
  public class teams
  {
    [Key]
    public int id { get; set; }
    [Required]
    [Column(TypeName = "char(36)")]

    public Guid publicTeamId { get; set; }

    [Required]
    public string name { get; set; }

    [Required]
    public int number { get; set; }
  }
}