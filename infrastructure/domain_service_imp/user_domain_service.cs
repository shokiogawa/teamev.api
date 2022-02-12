using System;
using System.Threading.Tasks;
using teamev.api.infrastructure.db;
using teamev.api.domain.domain_service_interface;
namespace teamev.api.infrastructure.domain_service_imp
{
  public class UserDomainService : IUserDomainService
  {
    public UserDomainService(MysqlDb _mysqDb)
    {
      this._mysqlDb = _mysqDb;
    }
    private readonly MysqlDb _mysqlDb;

    public async Task IsUserCreatedAsync(string userUid)
    {
      try
      {
        Console.WriteLine("ドメインサービス");
        using (var cmd = _mysqlDb.DBConnect())
        {
          cmd.CommandText = "SELECT id FROM users WHERE user_uid = @userUid";
          cmd.Parameters.AddWithValue("@userUid", userUid);
          using (var result = await cmd.ExecuteReaderAsync())
          {
            if (result.Read())
            {
              throw new Exception("User has already created");
            }
          }
        }
      }
      catch (Exception error)
      {
        throw error;
      }
    }
  }
}