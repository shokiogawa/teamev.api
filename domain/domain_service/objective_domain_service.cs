using System;
using System.Threading.Tasks;
using teamev.api.infrastructure.db;
namespace teamev.api.domain.domain_service
{
  public class ObjectiveDomainService
  {
    public ObjectiveDomainService(MysqlDb mysqlDb)
    {
      this.mysqlDb = mysqlDb;
      //コンストラクタ
    }

    private readonly MysqlDb mysqlDb;

    public async Task IsUserJoined(string userUid, Guid publicTeamId)
    {
      try
      {
        using (var cmd = mysqlDb.DBConnect())
        {
          //user_objectiveの作成タイミングで使用可能。
          cmd.CommandText =
          "SELECT users.id FROM users LEFT JOIN user_team_middles ON users.id = user_team_middles.user_id LEFT JOIN teams ON teams.id = user_team_middles.team_id WHERE users.user_uid = @userUid AND teams.public_team_id = @publicTeamId";
          cmd.Parameters.AddWithValue("@userUid", userUid);
          cmd.Parameters.AddWithValue("@publicTeamId", publicTeamId);
          using (var result = await cmd.ExecuteReaderAsync())
          {
            while (result.Read())
            {
              Console.WriteLine(result[0].GetType());
            }
          }
        }
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
      }
    }

    public async Task<int> IsUserLeader(string userUid, Guid publicTeamId)
    {
      try
      {
        using (var cmd = mysqlDb.DBConnect())
        {
          cmd.CommandText = "SELECT user_team_middles.status, teams.id FROM users LEFT JOIN user_team_middles ON users.id = user_team_middles.user_id LEFT JOIN teams ON teams.id = user_team_middles.team_id WHERE users.user_uid = @userUid AND teams.public_team_id = @publicTeamId";
          cmd.Parameters.AddWithValue("@userUid", userUid);
          cmd.Parameters.AddWithValue("@publicTeamId", publicTeamId);
          int teamId = 0;
          string status = "";
          using (var result = await cmd.ExecuteReaderAsync())
          {
            while (result.Read())
            {
              teamId = result.GetInt32(1);
              status = result.GetString(0);
            }
          }
          if (status != "LEADER")
          {
            throw new Exception("user status is not leader");
          }
          return teamId;
        }
      }
      catch (Exception error)
      {
        throw error;
      }
    }
  }

}