using System;
using teamev.api.infrastructure.db;
using teamev.api.domain.entity;
using teamev.api.domain.repository_interface;
using System.Threading.Tasks;
namespace teamev.api.infrastructure.repository_imp
{
  public class ObjectiveRepository : IObjectiveRepository
  {
    public ObjectiveRepository(MysqlDb mysqlDb)
    {
      this.mysqlDb = mysqlDb;
    }
    private readonly MysqlDb mysqlDb;
    public async Task CreateAsync(TeamObjective objective)
    {
      Console.WriteLine("作成開始");
      try
      {
        //usingはメソッド内が終わると破棄される。
        using (var cmd = mysqlDb.DBConnect())
        {
          cmd.CommandText = "INSERT INTO team_objectives(public_objective_id, team_id ,use_date, title, content, author) VALUES(@public_objective_id, @team_id, @use_date, @title, @content, @author)";
          cmd.Parameters.AddWithValue("@public_objective_id", objective.PublicObjectiveId);
          cmd.Parameters.AddWithValue("@team_id", objective.TeamId);
          cmd.Parameters.AddWithValue("@use_date", objective.CreatedDate);
          cmd.Parameters.AddWithValue("@title", objective.ObjectiveInfo.Title);
          cmd.Parameters.AddWithValue("@content", objective.ObjectiveInfo.Content);
          cmd.Parameters.AddWithValue("@author", objective.ObjectiveInfo.Author);
          var result = await cmd.ExecuteNonQueryAsync();
          if (result != 1)
          {
            Console.WriteLine("Unable to create database");
          }
        }
      }
      catch (Exception error)
      {
        Console.WriteLine(error);
        Console.WriteLine("'----------------------'");
        throw new Exception("エラーが出たよ");
      }
    }
  }

}