using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using teamev.api.domain.entity;
namespace teamev.api.infrastructure.db.db_context
{
  public class ObjectiveConfiguration : IEntityTypeConfiguration<Objective>
  {
    public void Configure(EntityTypeBuilder<Objective> builder)
    {
      builder.HasKey(o => o.Id);
      builder.OwnsOne(o => o.ObjectiveInfo);
    }
  }
}