using teamev.api.domain.entity;
using Microsoft.EntityFrameworkCore;
using teamev.api.infrastructure.db.db_context;
namespace teamev.api.infrastructure.db.db_context
{
  public class MyAppContext : DbContext
  {
    public MyAppContext(DbContextOptions<MyAppContext> options) : base(options) { }
    // public DbSet<User> users { get; set; }
    // public DbSet<Team> teams { get; set; }
    // public DbSet<Objective> objectives { get; set; }

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //   modelBuilder.Entity<Team>().ToTable("Team")
    //   .HasOne<User>()
    //   .WithMany();

    //   modelBuilder.Entity<User>()
    //   .ToTable("User")
    //   .Property(u => u.Status)
    //   .HasConversion<string>();
    //   modelBuilder.Entity<Objective>().ToTable("Objective");
    // }
  }
}