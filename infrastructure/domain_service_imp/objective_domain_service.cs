using System;
using System.Threading.Tasks;
using teamev.api.infrastructure.db;
using teamev.api.domain.domain_service_interface;
namespace teamev.api.infrastructure.domain_service_imp
{
  public class ObjectiveDomainService : IObjectiveDomainService
  {
    public ObjectiveDomainService(MysqlDb mysqlDb)
    {
      this.mysqlDb = mysqlDb;
      //コンストラクタ
    }

    private readonly MysqlDb mysqlDb;

    public async Task<int> IsUserJoined(string userUid, Guid publicTeamId)
    {
      try
      {
        int userId = 0;
        using (var cmd = mysqlDb.DBConnect())
        {
          //user_objectiveの作成タイミングで使用可能。
          cmd.CommandText =
          "SELECT users.id FROM users LEFT JOIN user_team_middles ON users.id = user_team_middles.user_id LEFT JOIN teams ON teams.id = user_team_middles.team_id WHERE users.user_uid = @userUid AND teams.public_team_id = @publicTeamId";
          cmd.Parameters.AddWithValue("@userUid", userUid);
          cmd.Parameters.AddWithValue("@publicTeamId", publicTeamId);
          using (var result = await cmd.ExecuteReaderAsync())
          {
            if (!result.Read())
            {
              throw new Exception("user dose not belong to team");
            }
            else
            {
              userId = result.GetInt32(0);
            }
          }
        }
        return userId;
      }
      catch (Exception error)
      {
        throw error;
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

    public async Task HasTObjectiveCreated(Guid publicTeamId)
    {
      try
      {
        using (var cmd = mysqlDb.DBConnect())
        {
          var today = DateTime.Now;
          cmd.CommandText = "SELECT team_objectives.id FROM team_objectives LEFT JOIN teams ON team_objectives.team_id = teams.id WHERE public_team_id = @publicTeamId AND use_date = @useDate";
          cmd.Parameters.AddWithValue("@publicTeamId", publicTeamId);
          cmd.Parameters.AddWithValue("@useDate", today.ToString("yyyy-MM-dd"));

          using (var result = await cmd.ExecuteReaderAsync())
          {
            if (result.Read())
            {
              var id = result.GetInt32(0);
              if (id > 0)
              {
                throw new Exception("Objective has already existed");
              }
            }
          }
        }

      }
      catch (Exception error)
      {
        Console.WriteLine(error);
        throw error;
      }
    }
  }

}