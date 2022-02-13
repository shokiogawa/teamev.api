using teamev.api.domain.entity;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using teamev.api.infrastructure.db;
using teamev.api.usecase.query.query_service_interface;
namespace teamev.api.infrastructure.query_service
{
  public class ListTeamQueryService
  {

    public ListTeamQueryService(MysqlDb mysqlDb)
    {
      this.mysqlDb = mysqlDb;
    }

    private readonly MysqlDb mysqlDb;

    // public async Task<IEnumerable<Team>> InvokeAsync(string userUid)
    // {
    //   using (var cmd = mysqlDb.DBConnect())
    //   {
    //     cmd.CommandText = "SELECT public_team_id, teams.name teams.number FROM teams LEFT JOIN user_team_middles ON teams.id = user_team_middles.team_id LEFT JOIN users ON users.id = user_team_middles.user_id WHERE users.user_uid = @userUid";
    //     cmd.Parameters.AddWithValue("@userUid", userUid);
    //     using (var result = await cmd.ExecuteReaderAsync())
    //     {
    //       while (result.Read()){

    //       }

    //     }
    //   }

    // }
  }
}