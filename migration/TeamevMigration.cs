using Microsoft.EntityFrameworkCore.Migrations;
using System.IO;
using Microsoft.EntityFrameworkCore.Infrastructure;
using teamev.api.infrastructure.db.db_context;
namespace teamev.api.migration
{
  [DbContext(typeof(MyAppContext))]
  [Migration("TeamevMigration")]
  public partial class TeamevMigration : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.Sql(File.ReadAllText("migration/SqlScript.sql"));

    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.Sql(File.ReadAllText("migration/SqlDrop.sql"));
    }
  }
}
