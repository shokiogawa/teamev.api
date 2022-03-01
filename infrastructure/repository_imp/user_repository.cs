using teamev.api.infrastructure.db;
using System.Threading.Tasks;
using System;
using teamev.api.domain.entity;
using teamev.api.domain.repository_interface;
namespace teamev.api.infrastructure.repository_imp
{
  public class UserRepository : IUserRepository
  {
    public UserRepository(MysqlDb _mysqlDb)
    {
      this._mysqlDb = _mysqlDb;
    }
    private readonly MysqlDb _mysqlDb;

    public async Task CreateUserAsync(User user)
    {
      try
      {
        using (var cmd = _mysqlDb.DBConnect())
        {
          cmd.CommandText = "INSERT INTO users(user_uid, email, name) VALUE (@userUid, @email, @name)";
          cmd.Parameters.AddWithValue("@userUid", user.UserUid);
          cmd.Parameters.AddWithValue("@email", user.Email);
          cmd.Parameters.AddWithValue("@name", user.Name);
          var result = await cmd.ExecuteNonQueryAsync();
          if (result != 1)
          {
            throw new Exception("user can not be created");
          }
        }

      }
      catch (ArithmeticException)
      {
        throw;
      }
    }
  }
}