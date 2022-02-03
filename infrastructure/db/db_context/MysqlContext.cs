using Microsoft.EntityFrameworkCore;
namespace teamev.api.infrastructure.db.db_context
{
  public class MyAppContext : DbContext
  {
    public MyAppContext(DbContextOptions<MyAppContext> options) : base(options) { }
  }
}