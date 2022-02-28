using teamev.api.domain.entity;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using teamev.api.infrastructure.db;
using teamev.api.usecase.query.query_service_interface;
namespace teamev.api.infrastructure.query_service
{
  public class ListTeamQueryService : IListTeamQueryService
  {

    public ListTeamQueryService(MysqlDb mysqlDb)
    {
      this.mysqlDb = mysqlDb;
    }

    private readonly MysqlDb mysqlDb;

    public async Task<IEnumerable<Team>> InvokeAsync(string userUid)
    {
      using (var cmd = mysqlDb.DBConnect())
      {
        cmd.CommandText = "SELECT teams.id, public_team_id, teams.name, teams.number FROM teams LEFT JOIN user_team_middles ON teams.id = user_team_middles.team_id LEFT JOIN users ON users.id = user_team_middles.user_id WHERE users.user_uid = @userUid";
        cmd.Parameters.AddWithValue("@userUid", userUid);
        List<Team> teamList = new List<Team>();
        using (var result = await cmd.ExecuteReaderAsync())
        {
          while (result.Read())
          {
            teamList.Add(new Team { Id = result.GetInt32(0), PublicTeamId = result.GetGuid(1), Name = result.GetString(2), Number = result.GetInt32(3) });
          }

        }
        return teamList;
      }

    }
  }
}