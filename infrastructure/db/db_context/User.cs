using teamev.api.domain.entity;
using Microsoft.EntityFrameworkCore;
namespace teamev.api.infrastructure.db.db_context
{
  public class UserContext : DbContext
  {
    public UserContext(DbContextOptions<UserContext> options) : base(options) { }
    public DbSet<User> Users { get; set; }
  }
}