using System;
using MySql.Data.MySqlClient;

namespace teamev.api.infrastructure.db
{
  public class MysqlDb
  {
    private static readonly string server = "teamev_db";
    private static readonly string database = "mysql";
    private static readonly string user = "user";
    private static readonly string pass = "secret";
    private static readonly string charset = "utf8";
    private static readonly string dsn = string.Format("Server={0};Database={1};Uid={2};Pwd={3};Charset={4}", server, database, user, pass, charset);

    public readonly MySqlConnection mySqlConnection;
    public MysqlDb()
    {
      this.mySqlConnection = new MySqlConnection(dsn);
      mySqlConnection.Open();
    }

    public MySqlCommand DBConnect()
    {
      MySqlCommand command = mySqlConnection.CreateCommand();
      return command;
    }
  }
}