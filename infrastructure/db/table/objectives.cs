using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace teamev.api.infrastructure.db.table
{
  public class objectives
  {
    [Key]
    public int id { get; set; }
    [Required]
    [Column(TypeName = "char(36)")]

    public Guid publicObjectiveId { get; set; }

    [Required]
    public DateTime createdDate { get; set; }
    [Required]

    [StringLength(100)]
    public string title { get; private set; }

    [Required]
    [StringLength(500)]
    public string content { get; private set; }

    [Required]
    public string author { get; private set; }
  }
}