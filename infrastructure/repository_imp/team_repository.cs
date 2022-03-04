using System;
using System.Threading.Tasks;
using teamev.api.infrastructure.db;
using teamev.api.domain.entity;
using teamev.api.domain.repository_interface;
namespace teamev.api.infrastructure.repository_imp
{
  public class TeamRepository : ITeamRepository
  {
    public TeamRepository(MysqlDb _mysqlDb)
    {
      this._mysqDb = _mysqlDb;
    }

    private readonly MysqlDb _mysqDb;

    public async Task CreateTeamAsync(string userUid, Team team)
    {
      try
      {
        using (var cmd = _mysqDb.DBConnect())
        {
          cmd.CommandText = "SELECT id FROM users WHERE user_uid = @userUid";
          cmd.Parameters.AddWithValue("@userUid", userUid);
          int userId = 0;
          using (var resultRead = await cmd.ExecuteReaderAsync())
          {
            if (resultRead.Read())
            {
              userId = resultRead.GetInt32(0);
            }
            else
            {
              throw new ArithmeticException("user is not existed");
            }
          }

          //トランザクション開始
          var transaction = await cmd.Connection.BeginTransactionAsync();

          cmd.CommandText = "INSERT INTO teams(public_team_id, name, number) VALUE (@publicTeamId, @name, @number);";
          cmd.Parameters.AddWithValue("@publicTeamId", team.PublicTeamId);
          cmd.Parameters.AddWithValue("@name", team.Name);
          cmd.Parameters.AddWithValue("@number", team.Number);

          var teamresult = await cmd.ExecuteNonQueryAsync();
          if (teamresult != 1)
          {
            await transaction.RollbackAsync();
            throw new ArithmeticException("can not update team table");
          }

          cmd.CommandText = "SELECT id FROM teams ORDER BY id DESC LIMIT 1";
          int teamId = 0;
          using (var resultTe = await cmd.ExecuteReaderAsync())
          {
            if (resultTe.Read())
            {
              teamId = resultTe.GetInt32(0);
            }
          }


          cmd.CommandText = "INSERT INTO user_team_middles(user_id, team_id, status) VALUE (@userId, @teamId, @status)";
          cmd.Parameters.AddWithValue("@userId", userId);
          cmd.Parameters.AddWithValue("@teamId", teamId);
          cmd.Parameters.AddWithValue("@status", "LEADER");
          var result = await cmd.ExecuteNonQueryAsync();
          if (result != 1)
          {
            await transaction.RollbackAsync();
            throw new ArithmeticException("can not update user_team_middle table");
          }

          //トランザクションコミット
          await transaction.CommitAsync();

        }

      }
      catch (ArithmeticException)
      {
        throw;
      }

    }
  }

}